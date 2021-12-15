using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace libman
{
    /// <summary>
    /// Главная форма приложения.
    /// </summary>
    public partial class FormMain : Form
    {
        #region Конструкторы

        /// <summary>
        /// Конструктор по умолчанию.
        /// </summary>
        public FormMain()
        {
            InitializeComponent();

            Library.Data.FileNameChanged +=
                (sender, args) => Text = "Библиотека" + (string.IsNullOrWhiteSpace(args.FileName) ? "" : " - " + args.FileName);
            forceclose = false;
        }

        #endregion

        #region Свойства (закрытые)

        /// <summary>
        /// Имя файла данных библиотеки.
        /// </summary>
        string FileName => Library.Data.FileName;

        #endregion

        #region Методы (закрытые)

        #region Команды

        /// <summary>
        /// Удаляет все данные.
        /// </summary>
        void CmdClearData()
        {
            if (this.Question("Вы действительно хотите удалить все данные?"))
            {
                if (Library.Data.Modified)
                {
                    string question =
                        "Данные ещё не сохранены!\n" +
                        "Всё равно удалить данные?"
                        ;
                    if (!this.Question(question, false))
                        return;
                }
                Library.Data.Clear();
            }
        }

        /// <summary>
        /// Загружает данные из файла.
        /// </summary>
        void CmdLoadData()
        {
            if (Library.Data.Modified)
            {
                string question =
                    "Данные ещё не сохранены!\n" +
                    "При загрузке эти данные будут утрачены и заменены данным из файла.\n" +
                    "Всё равно продолжить загрузку из файла?"
                    ;
                if (!this.Question(question, false))
                    return;
            }
            if (!string.IsNullOrEmpty(FileName))
                openDialog.FileName = FileName;
            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                Library.Data.Load(openDialog.FileName);
                this.InfoMessage("Данные загружены");
            }
        }

        /// <summary>
        /// Команда сохранения данных библиотеки.
        /// </summary>
        void CmdSaveData()
        {
            if (String.IsNullOrEmpty(Library.Data.FileName))
                CmdSaveDataAs();
            else
            {
                Library.Data.Save(Library.Data.FileName);
                this.InfoMessage("Данные сохранены");
            }
        }

        /// <summary>
        /// Команда сохранения данных библиотеки в новый файл.
        /// </summary>
        void CmdSaveDataAs()
        {
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                Library.Data.Save(saveDialog.FileName);
                this.InfoMessage("Данные сохранены");
            }
        }

        /// <summary>
        /// Завершение работы.
        /// </summary>
        void CmdExit()
        {
            if (Library.Data.Modified)
            {
                string question =
                    "Данные ещё не сохранены!\n" +
                    "При завершении работы эти данные будут утеряны.\n" +
                    "Всё равно завершить?"
                    ;
                if (!this.Question(question, false))
                    return;
            }
            forceclose = true;
            Close();
        }

        /// <summary>
        /// Открыть список читателей.
        /// </summary>
        void CmdCustomers()
        {
            Library.Data.Customers.EditList();
        }

        /// <summary>
        /// Регистрация нового читателя.
        /// </summary>
        void CmdCustomerNew()
        {
            Library.Data.Customers.NewItem();
        }

        /// <summary>
        /// Открыть список книг.
        /// </summary>
        void CmdBooks()
        {
            Library.Data.Books.EditList();
        }

        /// <summary>
        /// Внести данные о новой книге.
        /// </summary>
        void CmdNewBook()
        {
            Library.Data.Books.NewItem();
        }

        /// <summary>
        /// Удаляет все данные.
        /// </summary>
        void CmdClearAll()
        {
            if (this.Question("Вы действительно хотите удалить все данные?", false))
                Library.Data.Clear();
        }

        /// <summary>
        /// Открыть список выданных книг
        /// </summary>
        void CmdDeliveredBooks()
        {
            Library.Data.DeliveredBooks.EditList();
        }

        void CmdNewDeliveredBook()
        {
            Library.Data.DeliveredBooks.NewItem();
        }

        void CmdAbout()
        {
            using (FormAbout form = new FormAbout())
            {
                form.ShowDialog();
            }
        }

        #endregion

        #region Обработчики событий

        #region Обработчики событий формы

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!forceclose)
            {
                e.Cancel = true;
                CmdExit();
            }
        }

        #endregion

        #region Главное меню

        private void MenuItemFileExit_Click(object sender, EventArgs e)
        {
            CmdExit();
        }

        private void MenuItemCustomers_Click(object sender, EventArgs e)
        {
            CmdCustomers();
        }

        private void MenuItemLoadData_Click(object sender, EventArgs e)
        {
            CmdLoadData();
        }

        private void MenuItemSaveData_Click(object sender, EventArgs e)
        {
            CmdSaveData();
        }

        private void MenuItemSaveDataAs_Click(object sender, EventArgs e)
        {
            CmdSaveDataAs();
        }

        private void MenuItemCustomersNew_Click(object sender, EventArgs e)
        {
            CmdCustomerNew();
        }

        private void MenuItemBooks_Click(object sender, EventArgs e)
        {
            CmdBooks();
        }

        private void MenuItemBooksNew_Click(object sender, EventArgs e)
        {
            CmdNewBook();
        }

        private void MenuItemClearData_Click(object sender, EventArgs e)
        {
            CmdClearData();
        }

        private void MenuItemDeliveredBooks_Click(object sender, EventArgs e)
        {
            CmdDeliveredBooks();
        }

        private void MenuItemNewDeliveredBook_Click(object sender, EventArgs e)
        {
            CmdNewDeliveredBook();
        }

        private void MenuItemHelpAbout_Click(object sender, EventArgs e)
        {
            CmdAbout();
        }

        #endregion

        #endregion

        #endregion

        #region Поля

        /// <summary>
        /// Признак обязательного завершения.
        /// </summary>
        bool forceclose;

        #endregion
    }
}
