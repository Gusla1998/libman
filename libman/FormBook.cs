using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Linq;

namespace libman
{
    /// <summary>
    /// Форма для редактирования данных о книге.
    /// </summary>
    public partial class FormBook : Form, IDataForm<Book, string>
    {
        #region Конструкторы (общедоступные)

        /// <summary>
        /// Конструктор по умолчанию.<br />
        /// Используется для создания данных о новой книге.
        /// </summary>
        public FormBook()
            : this(null)
        { }

        /// <summary>
        /// Создаёт форму для редактирования данных книги.<br />
        /// Если читатель не указан (null), то открывается форма для
        /// ввода данных о новой книге.
        /// </summary>
        /// <param name="customer">Книга, данные о которой редактируются.</param>
        public FormBook(Book book)
        {
            InitializeComponent();

            Source = book;
            Modified = false;
            IsNew = book == null;

            panelDeliveredBooks.Visible = !IsNew;
            bsourceCustomers.DataSource = CurrentCustomers();
        }

        #endregion

        #region Свойства (общедоступные)

        #region Реализация IDataForm

        /// <summary>
        /// Книга, редактируемая в форме.
        /// </summary>
        public Book Source
        {
            get
            {
                return source;
            }
            set
            {
                source = value;
                if (source == null)
                {
                    maskedCode.Text = string.Empty;
                    textAuthors.Text = string.Empty;
                    textTitle.Text = string.Empty;
                    textPublisher.Text = string.Empty;
                    maskedYear.Text = string.Empty;
                    textTotal.Text = string.Empty;
                    textReady.Text = string.Empty;
                }
                else
                {
                    maskedCode.Text = source.Code;
                    textAuthors.Text = source.Authors;
                    textTitle.Text = source.Title;
                    textPublisher.Text = source.Publisher;
                    maskedYear.Text = source.Year.ToString();
                    textTotal.Text = source.Total.ToString();
                    textReady.Text = source.Ready.ToString();
                }
            }
        }

        /// <summary>
        /// Признак модифицированности данных формы.
        /// </summary>
        public bool Modified
        {
            get
            {
                return modified;
            }
            set
            {
                modified = value;
                Text = Title;
            }
        }

        #endregion

        #endregion

        #region Свойства (закрытые)

        /// <summary>
        /// Основной заголовок формы.
        /// </summary>
        private string Title => "Книга" + (isnew ? "<новая>" : modified ? "<*>" : string.Empty);

        /// <summary>
        /// Редактируются данные новой книги.
        /// </summary>
        private bool IsNew
        {
            get
            {
                return isnew;
            }
            set
            {
                isnew = value;
                labelNew.Visible = isnew;
                Text = Title;
            }
        }

        #endregion

        #region Методы (закрытые)

        /// <summary>
        /// Перечисляет читателей книги.
        /// </summary>
        /// <returns>Последовательность читателей, взявших книгу.</returns>
        IEnumerable<object> CurrentCustomers()
        {
            string code = source?.Code ?? string.Empty;
            var deliveries =
                from delivered in Library.Data.DeliveredBooks
                where delivered.Active && (delivered.BookCode == code)
                select delivered;
            foreach (DeliveredBook delivered in deliveries)
            {
                Customer customer = Library.Data.Customers.Lookup(delivered.CustomerCardId);
                yield return new
                {
                    BookCode = delivered.BookCode,
                    Name = customer.Name,
                    DeliveryDate = delivered.DeliveryDate
                };
            }
        }

        #region Команды

        /// <summary>
        /// Сохраняет данные из формы.
        /// </summary>
        /// <returns>true, если команда выполнена успешно;<br />
        /// false в противном случае.</returns>
        bool CmdSave()
        {
            if (IsNew)
                source = new Book();
            else
                Library.Data.Books.Remove(source);
            if (!Book.CodeIsValid(maskedCode.Text))
            {
                this.ErrorMessage("Неверный формат шифра книги.");
                return false;
            }
            source.Authors = textAuthors.Text;
            source.Title = textTitle.Text;
            try
            {
                source.Year = Convert.ToUInt16(maskedYear.Text);
            }
            catch (Exception)
            {
                this.ErrorMessage("Неверный формат года издания");
                return false;
            }
            if (string.IsNullOrWhiteSpace(textTotal.Text))
                source.Total = 0;
            else {
                try
                {
                    source.Total = Convert.ToUInt16(textTotal.Text);
                }
                catch (Exception)
                {
                    this.ErrorMessage("Неверный формат количества экземпляров");
                    return false;
                }
            }
            source.Publisher = textPublisher.Text;
            if (IsNew)
            {
                if (Library.Data.Books.ContainsKey(maskedCode.Text))
                {
                    this.ErrorMessage("Шифр книги " + maskedCode.Text + " уже зарегистрирован.");
                    return false;
                }
            }
            source.Code = maskedCode.Text;
            try
            {
                Library.Data.Books.Insert(source);
                Modified = false;
                return true;
            }
            catch (Exception exception)
            {
                this.ErrorMessage("Данные не сохранены: " + exception.Message);
                return false;
            }
        }

        /// <summary>
        /// Сохраняет данные и закрывает форму.
        /// </summary>
        /// <returns>true, если команда выполнена успешно;<br />
        /// false в противном случае.</returns>
        bool CmdClose()
        {
            if (Modified && !CmdSave())
                return false;
            DialogResult = DialogResult.OK;
            Close();
            return true;
        }

        /// <summary>
        /// Закрывает форму без сохранения данных.
        /// </summary>
        /// <returns>true, если команда выполнена успешно;<br />
        /// false в противном случае.</returns>
        bool CmdCancel()
        {
            Modified = false;
            DialogResult = DialogResult.Cancel;
            Close();
            return true;
        }

        #endregion

        #region Обработчики событий

        #region Обработчики событий формы

        private void FormBook_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Modified)
            {
                string question = "Несохранённые данные будут утеряны!\nВсё равно закрыть форму?";
                if (this.Question(question, false))
                {
                    Modified = true;
                    CmdCancel();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        #endregion

        #region Обработчики событий элементов формы

        #region textAuthors

        private void TextAuthors_TextChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        #endregion

        #region textTitle

        private void TextTitle_TextChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        #endregion

        #region textPublisher

        private void TextPublisher_TextChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        #endregion

        #region maskedYear

        private void MaskedYear_TextChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        #endregion

        #region textTotal

        private void TextTotal_Validating(object sender, CancelEventArgs e)
        {
            if (!uint.TryParse(textTotal.Text, out uint result))
                e.Cancel = true;
        }

        private void TextTotal_Validated(object sender, EventArgs e)
        {
            if (uint.TryParse(textTotal.Text, out uint total))
                textReady.Text = (total - (source?.Delivered ?? 0)).ToString();
        }

        #endregion

        #region buttonOK

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            CmdClose();
        }

        #endregion

        #region buttonCancel

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            CmdCancel();
        }

        #endregion

        #endregion

        #endregion

        #endregion

        #region Поля

        private Book source;

        private bool modified;

        private bool isnew;

        #endregion
    }
}
