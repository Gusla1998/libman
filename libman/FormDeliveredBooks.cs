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
    public partial class FormDeliveredBooks : Form, IListForm<DeliveredBook, string>
    {
        #region Конструкторы (общедоступные)

        /// <summary>
        /// Конструктор по умолчанию.<br />
        /// Создаёт форму в режиме просмотра.
        /// </summary>
        public FormDeliveredBooks()
            : this(FormPurpose.View)
        { }

        /// <summary>
        /// Создаёт новую форму для указанного назначения (просмотра либо выбора).
        /// </summary>
        /// <param name="purpose">Назначение формы.</param>
        public FormDeliveredBooks(FormPurpose purpose)
        {
            InitializeComponent();

            checkActive.Checked = true;
            Purpose = purpose;
        }

        #endregion

        #region Свойства (общедоступные)

        #region Реализация IListForm<DeliveredBook, string>

        /// <summary>
        /// Назначение формы.
        /// </summary>
        public FormPurpose Purpose
        {
            get => purpose;
            set
            {
                purpose = value;
                menuitemSelectItem.Visible = purpose == FormPurpose.Select;
                toolbtnSelect.Visible = purpose == FormPurpose.Select;
            }
        }

        /// <summary>
        /// Выбранный элемент (выдача книги).<br />
        /// При установке закрывает форму.
        /// </summary>
        public DeliveredBook SelectedItem
        {
            get => selecteditem;
            set
            {
                selecteditem = value;
                Close();
            }
        }

        #endregion

        #endregion

        #region Свойства (закрытые)

        private string CurrentKey
        {
            get
            {
                if (gridDelivered.CurrentRow == null)
                    return null;
                else if (gridDelivered.CurrentRow.Index < 0)
                    return null;
                else
                {
                    string code = (string)gridDelivered.CurrentRow.Cells["colBookCode"].Value;
                    string cardid = (string)gridDelivered.CurrentRow.Cells["colCustomerCardId"].Value;
                    return DeliveredBook.CreateKey(code, cardid);
                }
            }
        }

        private DeliveredBook CurrentItem
        {
            get
            {
                if (Library.Data.DeliveredBooks.Lookup(CurrentKey, out DeliveredBook delivered))
                    return delivered;
                else
                    return null;
            }
        }

        private IEnumerable<DeliveredBook> CurrentFilter
        {
            get
            {
                if (checkActive.Checked)
                    return
                        from delivered in Library.Data.DeliveredBooks
                        where delivered.Active
                        select delivered;
                else
                    return
                        from delivered in Library.Data.DeliveredBooks
                        select delivered;
            }
        }

        #endregion

        #region Методы (закрытые)

        #region Вспомогательные методы

        void RefreshGrid()
        {
            bsourceDelivered.DataSource = CurrentFilter.ToList();
            gridDelivered.Update();
        }

        #endregion

        #region Команды

        void CmdSelectItem()
        {
            if (CurrentKey == null)
            {
                this.Warning("Не выбрана выдача книги!");
                return;
            }
            SelectedItem = CurrentItem;
        }

        void CmdClose()
        {
            Close();
        }

        void CmdRefresh()
        {
            RefreshGrid();
        }

        void CmdNewItem()
        {
            Library.Data.DeliveredBooks.NewItem();
            RefreshGrid();
        }

        void CmdEdit()
        {
            if (CurrentKey == null)
            {
                this.Warning("Не выбрана выдача книги!");
                return;
            }
            CurrentItem.Edit();
            RefreshGrid();
        }

        void CmdRemove()
        {
            if (CurrentKey == null)
            {
                this.Warning("Не выбрана выдача книги!");
                return;
            }
            Library.Data.DeliveredBooks.Remove(CurrentKey);
            RefreshGrid();
        }

        void CmdClear()
        {
            if (this.Question("Вы уверены, что хотите удалить все данные о выдаче книг?", false))
            {
                Library.Data.DeliveredBooks.Clear();
                RefreshGrid();
            }
        }

        #endregion

        #region Обработчики событий

        #region Главное меню

        private void MenuItemSelectItem_Click(object sender, EventArgs e)
        {
            CmdSelectItem();
        }

        private void MenuItemRefresh_Click(object sender, EventArgs e)
        {
            CmdRefresh();
        }

        private void MenuItemClose_Click(object sender, EventArgs e)
        {
            CmdClose();
        }

        private void MenuItemNewDelivery_Click(object sender, EventArgs e)
        {
            CmdNewItem();
        }

        private void MenuItemEdit_Click(object sender, EventArgs e)
        {
            CmdEdit();
        }

        private void MenuItemRemove_Click(object sender, EventArgs e)
        {
            CmdRemove();
        }

        private void MenuItemClear_Click(object sender, EventArgs e)
        {
            CmdClear();
        }

        #endregion

        #region Командная панель

        private void ToolBtnSelect_Click(object sender, EventArgs e)
        {
            CmdSelectItem();
        }

        private void ToolBtnRefresh_Click(object sender, EventArgs e)
        {
            CmdRefresh();
        }

        private void ToolBtnNewItem_Click(object sender, EventArgs e)
        {
            CmdNewItem();
        }

        private void ToolBtnEdit_Click(object sender, EventArgs e)
        {
            CmdEdit();
        }

        private void ToolBtnRemove_Click(object sender, EventArgs e)
        {
            CmdRemove();
        }

        #endregion

        #region Обработчики событий элементов формы

        private void СheckActive_CheckedChanged(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        #endregion

        #endregion

        #endregion

        #region Поля

        FormPurpose purpose;

        DeliveredBook selecteditem;

        #endregion

        private void GridDelivered_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            gridDelivered.CurrentCell = gridDelivered.Rows[e.RowIndex].Cells[e.ColumnIndex];
        }

        private void GridDelivered_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            gridDelivered.CurrentCell = gridDelivered.Rows[e.RowIndex].Cells[e.ColumnIndex];
            switch (Purpose)
            {
                case FormPurpose.View:
                    CmdEdit();
                    break;
                case FormPurpose.Select:
                    CmdSelectItem();
                    break;
                default:
                    break;
            }
        }
    }
}
