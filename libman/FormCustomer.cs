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
    /// <summary>
    /// Форма для редактирования в диалоге данных о читателе.
    /// </summary>
    public partial class FormCustomer : Form, IDataForm<Customer, string>
    {

        #region Конструкторы (общедоступные)

        /// <summary>
        /// Конструктор по умолчанию.<br />
        /// Используется для создания данных о новом читателе.
        /// </summary>
        public FormCustomer()
            : this(null)
        { }

        /// <summary>
        /// Создаёт форму для редактирования данных читателя.<br />
        /// Если читатель не указан (null), то открывается форма для
        /// регистрации нового читателя.
        /// </summary>
        /// <param name="customer">Читатель, данные которого редактируются.</param>
        public FormCustomer(Customer customer)
        {
            InitializeComponent();

            comboRights.Items.Add(Customer.Rights.None);
            comboRights.Items.Add(Customer.Rights.Abonement);
            comboRights.Items.Add(Customer.Rights.ReadingRoom);
            comboRights.Items.Add(Customer.Rights.All);
            comboRights.SelectedIndex = 0;
            dateRegistration.Value = DateTime.Now;

            Source = customer;
            IsNew = Source == null;
            Modified = false;

            bsourceBooks.DataSource = CurrentBooks();
            panelDeliveredBooks.Visible = !IsNew;
        }

        #endregion

        #region Свойства (общедоступные)

        /// <summary>
        /// Редактируемый объект "Читатель" (<see cref="Customer"/>).
        /// </summary>
        public Customer Source
        {
            get
            {
                return source;
            }
            set
            {
                source = value;
                labelNew.Visible = IsNew;
                dateRegistration.Visible = IsNew;
                panelDeliveredBooks.Visible = !IsNew;
                comboRights.SelectedIndex = source?.CustomerRights.Ord() ?? 0;
                maskedCardId.Text = source?.CardId ?? CreateNumber();
                textName.Text = source?.Name;
                maskedBirthYear.Text = source?.BirthYear.ToString();
                textAddress.Text = source?.Address;
                textJob.Text = source?.Job;
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

        #region Свойства (закрытые)

        /// <summary>
        /// Вычисляемый заголовок формы.
        /// </summary>
        private string Title => "Читатель" + (isnew ? "<новый>" : modified ? "<*>" : string.Empty);

        /// <summary>
        /// Являются ли редактируемые данные данными нового читателя.
        /// </summary>
        private bool IsNew
        {
            get => isnew;
            set
            {
                isnew = value;
                labelNew.Visible = isnew;
            }
        }

        #endregion

        #region Методы (закрытые)

        /// <summary>
        /// Создаёт номер читательского билета по имеющимся данным.
        /// </summary>
        /// <param name="newnumber">Это номер нового читателя.</param>
        /// <param name="seize">Признак захвата номера.<br />
        /// true - номер регистрируется и не может быть использован для номеров
        /// других читательских билетов;<br />
        /// false - временный номер (может быть изменён в ходе редактирования,
        /// не сохранён и впоследствии использован ещё раз для другого
        /// читательского билета.</param>
        /// <returns></returns>
        string CreateNumber(bool newnumber = true, bool seize = false)
        {
            Customer.Rights rights = (Customer.Rights)(comboRights.Items[comboRights.SelectedIndex]);
            if (newnumber)
            {
                int year = dateRegistration.Value.Year;
                uint number = seize ? Library.Data.Customers.SeizeNewNumber(year) : Library.Data.Customers.GetNewNumber(year);
                return Customer.CreateCardId(rights, number, year);
            }
            else
                return rights.ToChar() + maskedCardId.Text.Substring(1);
        }

        /// <summary>
        /// Перечисляет выданные читателю книги.
        /// </summary>
        /// <returns>Последовательность полученных читателем книг.</returns>
        IEnumerable<object> CurrentBooks()
        {
            string cardid = source?.CardId ?? string.Empty;
            var deliveries =
                from delivered in Library.Data.DeliveredBooks
                where delivered.Active && (delivered.CustomerCardId == cardid)
                select delivered;
            foreach (DeliveredBook delivered in deliveries)
            {
                Book book = Library.Data.Books.Lookup(delivered.BookCode);
                yield return new
                {
                    BookCode = delivered.BookCode,
                    Authors = book.Authors,
                    Title = book.Title,
                    DeliveryDate = delivered.DeliveryDate
                };
            }
        }

        #region Команды

        /// <summary>
        /// Сохраняет данные о читателе.
        /// </summary>
        /// <returns>true, если команда выполнена успешно;<br />
        /// false в противном случае.</returns>
        bool CmdSave()
        {
            try
            {
                if (IsNew)
                    source = new Customer();
                else
                    Library.Data.Customers.Remove(source);
                if (!Customer.CardIdIsValid(maskedCardId.Text))
                {
                    this.ErrorMessage("Неверный формат номера читательского билета");
                    return false;
                }
                source.Name = textName.Text;
                source.BirthYear = Convert.ToUInt16(maskedBirthYear.Text);
                source.Address = textAddress.Text;
                source.Job = textJob.Text;
            }
            catch (Exception exception)
            {
                this.ErrorMessage("Неверный формат данных: " + exception.Message);
                return false;
            }
            if (IsNew)
            {
                string testnumber = CreateNumber(IsNew);
                if (Library.Data.Customers.ContainsKey(testnumber))
                {
                    this.ErrorMessage("Номер читательского билета " + testnumber + "уже зарегистрирован ранее");
                    return false;
                }
            }
            source.CardId = CreateNumber(IsNew, true);
            try
            {
                Library.Data.Customers.Insert(source);
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

        #region Обработчики событий формы

        private void FormCustomer_FormClosing(object sender, FormClosingEventArgs e)
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

        #region dateRegistration

        private void DateRegistration_ValueChanged(object sender, EventArgs e)
        {
            maskedCardId.Text = CreateNumber();
            Modified = true;
        }

        #endregion

        #region textName

        private void TextName_TextChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        #endregion

        #region comboRights

        private void ComboRights_Format(object sender, ListControlConvertEventArgs e)
        {
            e.Value = ((Customer.Rights)e.Value).PrettyString();
        }

        private void ComboRights_SelectedIndexChanged(object sender, EventArgs e)
        {
            maskedCardId.Text = CreateNumber(source == null);
            Modified = true;
        }

        #endregion

        #region maskedBitrhYear

        private void MaskedBirthYear_Changed(object sender, MaskInputRejectedEventArgs e)
        {
            Modified = true;
        }

        private void maskedBirthYear_TextChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        #endregion

        #region textAddress

        private void TextAddress_TextChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        #endregion

        #region textJob

        private void TextJob_TextChanged(object sender, EventArgs e)
        {
            Modified = true;
        }

        #endregion

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            CmdClose();
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            CmdCancel();
        }

        #endregion

        #endregion

        #region Поля

        private bool modified;

        Customer source;

        bool isnew;

        #endregion

        #region Статические члены (общедоступные)

        public static Customer Edit(Customer customer)
        {
            FormCustomer form = new FormCustomer(customer);
            if (form.ShowDialog() == DialogResult.OK)
                return form.Source;
            else
                return null;
        }

        #endregion

    }
}
