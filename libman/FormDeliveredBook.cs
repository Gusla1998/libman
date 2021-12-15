using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace libman
{
    public partial class FormDeliveredBook : Form, IDataForm<DeliveredBook, string>
    {
        #region Конструкторы (общедоступные)

        /// <summary>
        /// Конструктор по умолчанию.<br />
        /// Создаёт форму для регистрации выдачи книги.
        /// </summary>
        public FormDeliveredBook()
            : this(null)
        { }

        /// <summary>
        /// Открывает форму для редактирования данных о указанной выданной книге.
        /// </summary>
        /// <param name="delivered">Выдача книг</param>
        public FormDeliveredBook(DeliveredBook delivered)
        {
            InitializeComponent();

            Source = delivered;
            IsNew = Source == null;
            Modified = false;
        }

        #endregion

        #region Свойства (общедоступные)

        /// <summary>
        /// Редактируемая выдача книги.
        /// </summary>
        public DeliveredBook Source
        {
            get => source;
            set
            {
                source = value;
                if (source == null)
                {
                    maskedBookCode.Text = string.Empty;
                    labelBook.Text = Library.Data.Books.Description(null);
                    maskedCustomerCardId.Text = string.Empty;
                    labelCustomer.Text = Library.Data.Customers.Description(null);
                    dateDelivery.Text = string.Empty;
                    checkReturn.Checked = false;
                    labelReturnDate.Visible = false;
                    dateReturn.Visible = false;
                    dateReturn.Text = string.Empty;
                }
                else
                {
                    maskedBookCode.Text = source.BookCode;
                    if (Library.Data.Books.Lookup(maskedBookCode.Text, out Book book))
                        labelBook.Text = Library.Data.Books.Description(book);
                    else
                        labelBook.Text = Library.Data.Books.Description(null);
                    maskedCustomerCardId.Text = source.CustomerCardId;
                    if (Library.Data.Customers.Lookup(maskedCustomerCardId.Text, out Customer customer))
                        labelCustomer.Text = Library.Data.Customers.Description(customer);
                    else
                        labelCustomer.Text = Library.Data.Customers.Description(null);
                    dateDelivery.Value = source.DeliveryDate;
                    checkReturn.Checked = source.ReturnDate.HasValue;
                    if (source.ReturnDate.HasValue)
                        dateReturn.Value = source.ReturnDate.Value;
                    labelReturnDate.Visible = checkReturn.Checked;
                    dateReturn.Visible = checkReturn.Checked;
                }
            }
        }

        /// <summary>
        /// Признак модифицированности формы.
        /// </summary>
        public bool Modified
        {
            get => modified;
            set
            {
                modified = value;
                Text = Title;
            }
        }

        #endregion

        #region Свойства (закрытые)

        /// <summary>
        /// Редактируется новая выдача книги.
        /// </summary>
        private bool IsNew
        {
            get => isnew;
            set
            {
                isnew = value;
                Text = Title;
            }
        }

        /// <summary>
        /// Основной заголовок формы.
        /// </summary>
        private string Title => "Выданная книга" + (isnew ? "<новая>" : modified ? "<*>" : string.Empty);

        #endregion

        #region Методы (закрытые)

        #region Команды

        /// <summary>
        /// Сохраняет данные из формы.
        /// </summary>
        /// <returns>true, если команда выполнена успешно;<br />
        /// false в противном случае.</returns>
        bool CmdSave()
        {
            if (IsNew)
                source = new DeliveredBook();
            else
                Library.Data.DeliveredBooks.Remove(source);
            if (!Book.CodeIsValid(maskedBookCode.Text))
            {
                this.ErrorMessage("Неверный формат шифра книги.");
                return false;
            }
            if (Library.Data.Books.Lookup(maskedBookCode.Text, out Book book))
            {
                if (book.Ready <= 0)
                {
                    this.ErrorMessage("Отсутствуют экземпляры книги для выдачи.");
                    return true;
                }
            }
            else
            {
                this.ErrorMessage($"Книги с шифром {maskedBookCode.Text} не существует.");
                return false;
            }
            if (!Customer.CardIdIsValid(maskedCustomerCardId.Text))
            {
                this.ErrorMessage("Неверный формат номера читательского билета.");
                return false;
            }
            if (!Library.Data.Customers.ContainsKey(maskedCustomerCardId.Text))
            {
                this.ErrorMessage($"Читателя с номером билета {maskedCustomerCardId.Text} не существует.");
                return false;
            }
            source.BookCode = maskedBookCode.Text;
            source.CustomerCardId = maskedCustomerCardId.Text;
            source.DeliveryDate = dateDelivery.Value;
            if (checkReturn.Checked)
                source.ReturnDate = dateReturn.Value;
            else
                source.ReturnDate = null;
            try
            {
                Library.Data.DeliveredBooks.Insert(source);
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
        /// Сохраняет данные и закрывает форму
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

        private void FormDeliveredBook_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Modified)
            {
                string question = "Несохранённые данные будут утеряны!\nВсё равно закрыть форму?";
                if (this.Question(question, false))
                    CmdCancel();
                else
                    e.Cancel = true;
            }
        }

        #endregion

        #region Обработчики событий элементов формы

        #region maskedBookCode

        private void MaskedBookCode_TextChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void MaskedBookCode_Validating(object sender, CancelEventArgs e)
        {
            if (maskedBookCode.Text.Trim() != Book.EmptyCode.Trim())
            {
                if (!Library.Data.Books.ContainsKey(maskedBookCode.Text))
                    this.Warning("Книги с таким шифром не существует!");
            }
        }

        private void MaskedBookCode_Validated(object sender, EventArgs e)
        {
            if (Library.Data.Books.Lookup(maskedBookCode.Text, out Book book))
                labelBook.Text = Library.Data.Books.Description(book);
            else
                labelBook.Text = Library.Data.Books.Description(null);
        }

        #endregion

        #region buttonSelectBook

        private void ButtonSelectBook_Click(object sender, EventArgs e)
        {
            Book book = Library.Data.Books.SelectItem();
            if (book != null)
            {
                maskedBookCode.Text = book.Code;
                labelBook.Text = book.Description;
                Modified = true;
            }
        }

        #endregion

        #region maskedCustomerCardId

        private void MaskedCustomerCardId_TextChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        private void MaskedCustomerCardId_Validating(object sender, CancelEventArgs e)
        {
            if (!Library.Data.Customers.ContainsKey(maskedCustomerCardId.Text))
            {
                this.Warning("Читателя с таким номером билета не существует!");
            }
        }

        #endregion

        #region buttonSelectCustomer

        private void ButtonSelectCustomer_Click(object sender, EventArgs e)
        {
            Customer customer = Library.Data.Customers.SelectItem();
            if (customer != null)
            {
                maskedCustomerCardId.Text = customer.CardId;
                labelCustomer.Text = customer.Name;
                Modified = true;
            }
        }

        #endregion

        #region checkReturn

        private void CheckReturn_CheckedChanged(object sender, EventArgs e)
        {
            labelReturnDate.Visible = checkReturn.Checked;
            dateReturn.Visible = checkReturn.Checked;
            Modified = true;
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

        DeliveredBook source;

        bool modified;

        bool isnew;

        #endregion
    }
}
