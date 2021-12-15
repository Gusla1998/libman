using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace libman
{
    public partial class FormCustomers : Form, IListForm<Customer, string>
    {
        #region Вспомогательные типы (закрытые)

        /// <summary>
        /// Поле, по которому упорядочивается вывод данных.
        /// </summary>
        enum Order
        {
            /// <summary>
            /// без упорядочивания
            /// </summary>
            None,
            /// <summary>
            /// по номеру читательского билета
            /// </summary>
            CardId,
            /// <summary>
            /// по фамилии, имени, отчеству
            /// </summary>
            Name
        }

        #endregion

        #region Конструкторы (общедоступные)

        /// <summary>
        /// Конструктор по умолчанию.<br />
        /// Открывает форму для просмотра.
        /// </summary>
        public FormCustomers()
            : this(FormPurpose.View)
        { }

        /// <summary>
        /// Открывает форму с указанной целью.
        /// </summary>
        /// <param name="purpose">Назначение открытия формы.</param>
        public FormCustomers(FormPurpose purpose)
        {
            InitializeComponent();

            comboSearch.SelectedIndex = 0;

            Purpose = purpose;
            CurrentOrder = Order.None;
            Filter = from item in Library.Data.Customers select item;
            selecteditem = null;
        }

        #endregion

        #region Свойства (общедоступные)

        /// <summary>
        /// Элемент, выбранный в форме.
        /// </summary>
        public Customer SelectedItem
        {
            get => selecteditem;
            set
            {
                selecteditem = value;
                if (selecteditem != null)
                {
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
        }

        /// <summary>
        /// Назначение экземпляра формы.
        /// </summary>
        public FormPurpose Purpose
        {
            get => purpose;
            set
            {
                purpose = value;
                bool selectvisibility = purpose == FormPurpose.Select;
                menuitemSelect.Visible = selectvisibility;
                toolbtnSelect.Visible = selectvisibility;
            }
        }

        #endregion

        #region Свойства (закрытые)

        /// <summary>
        /// Номер текущей (выделенной) строки таблицы читателей.
        /// </summary>
        private int CurrentRowIndex => gridCustomers.CurrentRow?.Index ?? -1;

        /// <summary>
        /// Текущий источник отображаемых данных.
        /// </summary>
        private IEnumerable<Customer> Filter
        {
            get => filter;
            set
            {
                filter = value;
                UpdateGrid();
            }
        }

        private Order CurrentOrder { get; set; }

        #endregion

        #region Методы (закрытые)

        /// <summary>
        /// Обновляет содержимое таблицы читателей на форме.
        /// </summary>
        private void UpdateGrid()
        {
            switch (CurrentOrder)
            {
                case Order.CardId:
                    bsourceCustomers.DataSource =
                        Sorting<Customer, string>.Coctail(Filter, item => item.CardId).ToList();
                    break;
                case Order.Name:
                    bsourceCustomers.DataSource =
                        Sorting<Customer, string>.Coctail(Filter, item => item.Name).ToList();
                    break;
                default:
                    bsourceCustomers.DataSource = Filter.ToList();
                    break;
            }
            gridCustomers.Invalidate();
            gridCustomers.Update();
        }

        #region Команды

        /// <summary>
        /// Закрывает форму.
        /// </summary>
        void CmdClose()
        {
            Close();
        }

        /// <summary>
        /// Выбирает читателя из текущей строки как результат.
        /// </summary>
        void CmdSelectItem()
        {
            if (gridCustomers.CurrentRow != null)
            {
                string cardid = (string)gridCustomers.CurrentRow.Cells["colCardId"].Value;
                if (Library.Data.Customers.Lookup(cardid, out Customer customer))
                {
                    SelectedItem = customer;
                    return;
                }
            }
            this.Warning("Не выбран читатель!");
        }

        /// <summary>
        /// Обновляет данные в таблице формы.
        /// </summary>
        void CmdUpdateGrid()
        {
            UpdateGrid();
        }

        /// <summary>
        /// Новый читатель
        /// </summary>
        void CmdNewCustomer()
        {
            if (Library.Data.Customers.IsFull)
            {
                this.ErrorMessage("Таблица читателей заполнена - добавление данных невозможно");
                return;
            }
            Library.Data.Customers.NewItem();
            UpdateGrid();
        }

        /// <summary>
        /// Редактировать данные читателя из текущей строки
        /// </summary>
        void CmdEditCustomer()
        {
            if (gridCustomers.CurrentRow == null)
                CmdNewCustomer();
            else
            {
                string cardid = (string)gridCustomers.CurrentRow.Cells["colCardId"].Value;
                if (Library.Data.Customers.Lookup(cardid, out Customer customer))
                {
                    customer.Edit();
                    UpdateGrid();
                }
                else
                    CmdNewCustomer();
            }
        }

        /// <summary>
        /// Удалить данные читателя из текущей строки
        /// </summary>
        void CmdRemoveCustomer()
        {
            if (gridCustomers.CurrentRow == null)
                return;
            string cardid = (string)gridCustomers.CurrentRow.Cells["colCardId"].Value;
            if (Library.Data.Customers.Lookup(cardid, out Customer customer))
            {
                if (customer.HasBooks)
                {
                    this.ProhibitionMessage("Этого читателя нельзя удалять, так как у него на руках есть невозвращённые книги");
                    return;
                }
                if (this.Question($"Удалить читателя {customer.CardId} {customer.Name}?", true))
                {
                    Library.Data.Customers.Remove(cardid);
                    UpdateGrid();
                }
            }
        }

        /// <summary>
        /// Удаляет данные обо всех читателях.
        /// </summary>
        void CmdClearCustomers()
        {
            if (this.Question("Вы действительно хотите удалить данные обо всех читателях?", false))
            {
                foreach(Customer customer in Library.Data.Customers)
                    if (customer.HasBooks)
                    {
                        this.ProhibitionMessage("Невозможно очистить список, так как у читателей на руках есть книги.");
                        return;
                    }
                Library.Data.Customers.Clear();
                UpdateGrid();
            }
        }

        /// <summary>
        /// Поиск (фильтр) по фамилии, имени, отчеству.
        /// </summary>
        void CmdSearchByName()
        {
            if (checkExactly.Checked)
            {
                Filter =
                    from item in Library.Data.Customers
                    where item.Name == textSentinel.Text
                    select item;
            }
            else
            {
                KMPSearch kmp = new KMPSearch(textSentinel.Text);
                Filter =
                    from item in Library.Data.Customers
                    where kmp.FindFirstIn(item.Name) >= 0
                    select item;
            }
        }

        /// <summary>
        /// Поиск по номеру читательского билета.
        /// </summary>
        void CmdSearchByCardId()
        {
            if (checkExactly.Checked)
            {
                Filter =
                    from item in Library.Data.Customers
                    where item.CardId == textSentinel.Text
                    select item;
            }
            else
            {
                KMPSearch kmp = new KMPSearch(textSentinel.Text);
                Filter =
                    from item in Library.Data.Customers
                    where kmp.FindFirstIn(item.CardId) >= 0
                    select item;
            }
        }

        /// <summary>
        /// Отменяет ранее установленные фильтры и выдаёт полные данные.
        /// </summary>
        void CmdResetFilter()
        {
            comboSearch.SelectedIndex = 0;
            textSentinel.Text = string.Empty;
            checkExactly.Checked = false;
            Filter = from item in Library.Data.Customers select item;
        }

        #endregion

        #region Обработчики событий

        #region Обработчики элементов меню

        private void MenuItemUpdate_Click(object sender, EventArgs e)
        {
            CmdUpdateGrid();
        }

        private void MenuItemSelect_Click(object sender, EventArgs e)
        {
            CmdSelectItem();
        }

        private void MenuItemClose_Click(object sender, EventArgs e)
        {
            CmdClose();
        }

        private void MenuItemNewCustomer_Click(object sender, EventArgs e)
        {
            CmdNewCustomer();
        }

        private void MenuItemEditCustomer_Click(object sender, EventArgs e)
        {
            CmdEditCustomer();
        }

        private void MenuItemRemoveItem_Click(object sender, EventArgs e)
        {
            CmdRemoveCustomer();
        }

        private void MenuItemClearCustomers_Click(object sender, EventArgs e)
        {
            CmdClearCustomers();
        }

        private void MenuItemSearchByName_Click(object sender, EventArgs e)
        {
            CmdSearchByName();
        }

        private void MenuItemSearchByCardId_Click(object sender, EventArgs e)
        {
            CmdSearchByCardId();
        }

        private void MenuItemResetFilter_Click(object sender, EventArgs e)
        {
            CmdResetFilter();
        }

        #endregion

        #region Обработчики кнопок командной панели

        private void ToolBtnSelect_Click(object sender, EventArgs e)
        {
            CmdSelectItem();
        }

        private void ToolBtnUpdate_Click(object sender, EventArgs e)
        {
            CmdUpdateGrid();
        }

        private void ToolBtnNew_Click(object sender, EventArgs e)
        {
            CmdNewCustomer();
        }

        private void ToolBtnEdit_Click(object sender, EventArgs e)
        {
            CmdEditCustomer();
        }

        private void ToolBtnRemove_Click(object sender, EventArgs e)
        {
            CmdRemoveCustomer();
        }

        private void ToolBtnSearch_Click(object sender, EventArgs e)
        {
            switch (comboSearch.SelectedIndex)
            {
                case 0:
                    CmdResetFilter();
                    break;
                case 1:
                    CmdSearchByName();
                    break;
                case 2:
                    CmdSearchByCardId();
                    break;
                default:
                    break;
            }
        }

        private void ToolBtnResetFilter_Click(object sender, EventArgs e)
        {
            CmdResetFilter();
        }

        #endregion

        #region Обработчики событий таблицы gridCustomers

        private void GridCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            gridCustomers.CurrentCell = gridCustomers.Rows[e.RowIndex].Cells[e.ColumnIndex];
        }

        private void GridCustomers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                switch(e.ColumnIndex)
                {
                    case 0:
                        if (CurrentOrder == Order.CardId)
                            CurrentOrder = Order.None;
                        else
                            CurrentOrder = Order.CardId;
                        break;
                    case 1:
                        if (CurrentOrder == Order.Name)
                            CurrentOrder = Order.None;
                        else
                            CurrentOrder = Order.Name;
                        break;
                    default:
                        break;
                }
                UpdateGrid();
                return;
            }
            gridCustomers.CurrentCell = gridCustomers.Rows[e.RowIndex].Cells[e.ColumnIndex];
            switch (Purpose)
            {
                case FormPurpose.View:
                    CmdEditCustomer();
                    break;
                case FormPurpose.Select:
                    CmdSelectItem();
                    break;
                default:
                    break;
            }
        }

        #endregion

        #region Обработчики событий кнопок

        private void ButtonClose_Click(object sender, EventArgs e)
        {
            CmdClose();
        }

        #endregion

        #endregion

        #endregion

        #region Поля

        FormPurpose purpose;

        IEnumerable<Customer> filter;

        Customer selecteditem;

        #endregion
    }
}
