using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace libman
{
    public partial class FormBooks : Form
    {

        #region Конструкторы (общедоступные)

        /// <summary>
        /// Конструктор по умолчанию
        /// </summary>
        public FormBooks()
            : this(FormPurpose.View)
        { }

        public FormBooks(FormPurpose purpose)
        {
            InitializeComponent();

            comboSearch.SelectedIndex = 0;

            Purpose = purpose;
            Filter = from item in Library.Data.Books select item;
            selecteditem = null;
        }

        #endregion

        #region Свойства(общедоступные)

        /// <summary>
        /// Значение, выбранное в форме.
        /// </summary>
        public Book SelectedItem
        {
            get => selecteditem;
            private set
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
        /// Текущий источник отображаемых данных.
        /// </summary>
        private IEnumerable<Book> Filter
        {
            get => filter;
            set
            {
                filter = value;
                RefreshGrid();
            }
        }

        #endregion

        #region Методы (закрытые)

        /// <summary>
        /// Обновляет данные таблицы на форме
        /// </summary>
        void RefreshGrid()
        {
            bsourceBooks.DataSource = filter.ToList();
            gridBooks.Update();
        }

        #region Команды

        /// <summary>
        /// Обновляет данные в таблице формы.
        /// </summary>
        void CmdRefresh()
        {
            RefreshGrid();
        }

        /// <summary>
        /// Выбирает книгу из текущей строки как результат.
        /// </summary>
        void CmdSelectItem()
        {
            if (gridBooks.CurrentRow != null)
            {
                string cardid = (string)gridBooks.CurrentRow.Cells["colCode"].Value;
                if (Library.Data.Books.Lookup(cardid, out Book book))
                {
                    SelectedItem = book;
                    return;
                }
            }
            this.Warning("Не выбрана книга!");
        }

        /// <summary>
        /// Закрывает форму
        /// </summary>
        void CmdClose()
        {
            Close();
        }

        /// <summary>
        /// Открывает форму для добавления новой книги.
        /// </summary>
        void CmdNewBook()
        {
            if (Library.Data.Books.IsFull)
            {
                this.ErrorMessage("Таблица книг заполнена - добавление данных невозможно");
                return;
            }
            Library.Data.Books.NewItem();
            RefreshGrid();
        }

        /// <summary>
        /// Открывает форму для редактирования книги из текущей строки таблицы.
        /// </summary>
        void CmdEditBook()
        {
            if (gridBooks.CurrentRow == null)
                CmdNewBook();
            else
            {
                string code = (string)gridBooks.CurrentRow.Cells["colCode"].Value;
                if (Library.Data.Books.Lookup(code, out Book book))
                {
                    book.Edit();
                    RefreshGrid();
                }
                else
                    CmdNewBook();
            }
        }

        /// <summary>
        /// Удаление данных о книге.
        /// </summary>
        void CmdRemoveBook()
        {
            if (gridBooks.CurrentRow != null)
            {
                string code = (string)gridBooks.CurrentRow.Cells["colCode"].Value;
                if (Library.Data.Books.Lookup(code, out Book book))
                {
                    if (this.Question($"Удалить {code} {book.Authors} {book.Title}?"))
                    {
                        foreach (DeliveredBook delivered in Library.Data.DeliveredBooks.BooksForCustomers(book))
                        {
                            this.ProhibitionMessage("Удалить книгу невозможно, так как она есть на руках у читателей.");
                            return;
                        }
                        Library.Data.Books.Remove(code);
                        RefreshGrid();
                    }
                }
            }
        }

        /// <summary>
        /// Удаляет все книги.
        /// </summary>
        void CmdClearBooks()
        {
            if (this.Question("Вы действительно хотите удалить данные обо всех книгах?", false))
            {
                foreach (Book book in Library.Data.Books)
                    if (book.Delivered > 0)
                    {
                        this.ProhibitionMessage("Невозможно очистить список, так как книги есть на руках у читателей.");
                        return;
                    }
                Library.Data.Books.Clear();
                RefreshGrid();
            }
        }

        /// <summary>
        /// Устанавливает фильтр по наименованию.
        /// </summary>
        void CmdSearchByTitle()
        {
            if (checkExactly.Checked)
            {
                Filter =
                    from item in Library.Data.Books
                    where item.Title == textSentinel.Text
                    select item;
            }
            else
            {
                KMPSearch kmp = new KMPSearch(textSentinel.Text);
                Filter =
                    from item in Library.Data.Books
                    where kmp.FindFirstIn(item.Title) >= 0
                    select item;
            }
        }

        /// <summary>
        /// Устанавливает фильтр по авторам.
        /// </summary>
        void CmdSearchByAuthors()
        {
            if (checkExactly.Checked)
            {
                Filter =
                    from item in Library.Data.Books
                    where item.Authors == textSentinel.Text
                    select item;
            }
            else
            {
                KMPSearch kmp = new KMPSearch(textSentinel.Text);
                Filter =
                    from item in Library.Data.Books
                    where kmp.FindFirstIn(item.Authors) >= 0
                    select item;
            }
        }

        /// <summary>
        /// Устанавливает фильтр по коду.
        /// </summary>
        void CmdSearchByCode()
        {
            if (checkExactly.Checked)
            {
                Filter =
                    from item in Library.Data.Books
                    where item.Code == textSentinel.Text
                    select item;
            }
            else
            {
                KMPSearch kmp = new KMPSearch(textSentinel.Text);
                Filter =
                    from item in Library.Data.Books
                    where kmp.FindFirstIn(item.Code) >= 0
                    select item;
            }
        }

        /// <summary>
        /// Устанавливает фильтр по разделу.
        /// </summary>
        void CmdSearchBySection()
        {
            if (ushort.TryParse(textSentinel.Text, out ushort nsection))
            {
                string section = nsection.ToString("000") + '.';
                Filter =
                    from item in Library.Data.Books
                    where item.Code.StartsWith(section)
                    select item;
            }
        }

        /// <summary>
        /// Сбрасывает ранее установленный фильтр.
        /// </summary>
        void CmdResetFilter()
        {
            comboSearch.SelectedIndex = 0;
            textSentinel.Text = string.Empty;
            checkExactly.Checked = false;
            Filter = from item in Library.Data.Books select item;
        }

        #endregion

        #region Обработчики событий

        #region Главное меню

        private void MenuItemUpdate_Click(object sender, EventArgs e)
        {
            CmdRefresh();
        }

        private void MenuItemSelect_Click(object sender, EventArgs e)
        {
            CmdSelectItem();
        }

        private void MenuItemClose_Click(object sender, EventArgs e)
        {
            CmdClose();
        }

        private void MenuItemNewBook_Click(object sender, EventArgs e)
        {
            CmdNewBook();
        }

        private void MenuItemEditBook_Click(object sender, EventArgs e)
        {
            CmdEditBook();
        }

        private void MenuItemRemoveBook_Click(object sender, EventArgs e)
        {
            CmdRemoveBook();
        }

        private void MenuItemClear_Click(object sender, EventArgs e)
        {
            CmdClearBooks();
        }

        private void MenuItemSearchByTitle_Click(object sender, EventArgs e)
        {
            CmdSearchByTitle();
        }

        private void MenuItemSearchByAuthors_Click(object sender, EventArgs e)
        {
            CmdSearchByAuthors();
        }

        private void MenuItemSearchBySection_Click(object sender, EventArgs e)
        {
            CmdSearchBySection();
        }

        private void MenuItemSearchByCode_Click(object sender, EventArgs e)
        {
            CmdSearchByCode();
        }

        #endregion

        #region Кнопки командной панели

        private void ToolBtnSelect_Click(object sender, EventArgs e)
        {
            CmdSelectItem();
        }

        private void ToolBtnRefresh_Click(object sender, EventArgs e)
        {
            CmdRefresh();
        }

        private void toolbtnNewBook_Click(object sender, EventArgs e)
        {
            CmdNewBook();
        }

        private void ToolBtnEditBook_Click(object sender, EventArgs e)
        {
            CmdEditBook();
        }

        private void ToolBtnRemoveBook_Click(object sender, EventArgs e)
        {
            CmdRemoveBook();
        }

        private void ToolBtnSearch_Click(object sender, EventArgs e)
        {
            switch (comboSearch.SelectedIndex)
            {
                case 0:
                    CmdResetFilter();
                    break;
                case 1:
                    CmdSearchByAuthors();
                    break;
                case 2:
                    CmdSearchByTitle();
                    break;
                case 3:
                    CmdSearchBySection();
                    break;
                case 4:
                    CmdSearchByCode();
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

        #region Обработчики событий элементов формы

        #region gridBooks

        private void GridBooks_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            gridBooks.CurrentCell = gridBooks.Rows[e.RowIndex].Cells[e.ColumnIndex];
            switch (Purpose)
            {
                case FormPurpose.View:
                    CmdEditBook();
                    break;
                case FormPurpose.Select:
                    CmdSelectItem();
                    break;
                default:
                    break;
            }
        }

        private void GridBooks_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        #endregion

        #endregion

        #endregion

        #endregion

        #region Поля

        FormPurpose purpose;

        IEnumerable<Book> filter;

        Book selecteditem;

        #endregion
    }
}
