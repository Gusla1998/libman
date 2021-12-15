namespace libman
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuitemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemLoadData = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemSaveData = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemSaveDataAs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemClearData = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuitemFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemCatalogs = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemCustomers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemCustomersNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuitemBooks = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemBooksNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDeliveredBooks = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemDeliveredBooks = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemNewDeliveredBook = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.openDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveDialog = new System.Windows.Forms.SaveFileDialog();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitemFile,
            this.menuitemCatalogs,
            this.menuDeliveredBooks,
            this.menuitemHelp});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(800, 24);
            this.menuMain.TabIndex = 3;
            this.menuMain.Text = "menuStrip1";
            // 
            // menuitemFile
            // 
            this.menuitemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitemLoadData,
            this.menuitemSaveData,
            this.menuitemSaveDataAs,
            this.menuitemClearData,
            this.toolStripSeparator1,
            this.menuitemFileExit});
            this.menuitemFile.Name = "menuitemFile";
            this.menuitemFile.Size = new System.Drawing.Size(48, 20);
            this.menuitemFile.Text = "Файл";
            // 
            // menuitemLoadData
            // 
            this.menuitemLoadData.Name = "menuitemLoadData";
            this.menuitemLoadData.Size = new System.Drawing.Size(206, 22);
            this.menuitemLoadData.Text = "Загрузить данные";
            this.menuitemLoadData.Click += new System.EventHandler(this.MenuItemLoadData_Click);
            // 
            // menuitemSaveData
            // 
            this.menuitemSaveData.Name = "menuitemSaveData";
            this.menuitemSaveData.Size = new System.Drawing.Size(206, 22);
            this.menuitemSaveData.Text = "Сохранить данные";
            this.menuitemSaveData.Click += new System.EventHandler(this.MenuItemSaveData_Click);
            // 
            // menuitemSaveDataAs
            // 
            this.menuitemSaveDataAs.Name = "menuitemSaveDataAs";
            this.menuitemSaveDataAs.Size = new System.Drawing.Size(206, 22);
            this.menuitemSaveDataAs.Text = "Сохранить данные как...";
            this.menuitemSaveDataAs.Click += new System.EventHandler(this.MenuItemSaveDataAs_Click);
            // 
            // menuitemClearData
            // 
            this.menuitemClearData.Name = "menuitemClearData";
            this.menuitemClearData.Size = new System.Drawing.Size(206, 22);
            this.menuitemClearData.Text = "Очистить данные";
            this.menuitemClearData.Click += new System.EventHandler(this.MenuItemClearData_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(203, 6);
            // 
            // menuitemFileExit
            // 
            this.menuitemFileExit.Name = "menuitemFileExit";
            this.menuitemFileExit.Size = new System.Drawing.Size(206, 22);
            this.menuitemFileExit.Text = "Выход";
            this.menuitemFileExit.Click += new System.EventHandler(this.MenuItemFileExit_Click);
            // 
            // menuitemCatalogs
            // 
            this.menuitemCatalogs.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitemCustomers,
            this.menuitemCustomersNew,
            this.toolStripSeparator2,
            this.menuitemBooks,
            this.menuItemBooksNew});
            this.menuitemCatalogs.Name = "menuitemCatalogs";
            this.menuitemCatalogs.Size = new System.Drawing.Size(94, 20);
            this.menuitemCatalogs.Text = "Справочники";
            // 
            // menuitemCustomers
            // 
            this.menuitemCustomers.Name = "menuitemCustomers";
            this.menuitemCustomers.Size = new System.Drawing.Size(226, 22);
            this.menuitemCustomers.Text = "Читатели";
            this.menuitemCustomers.Click += new System.EventHandler(this.MenuItemCustomers_Click);
            // 
            // menuitemCustomersNew
            // 
            this.menuitemCustomersNew.Name = "menuitemCustomersNew";
            this.menuitemCustomersNew.Size = new System.Drawing.Size(226, 22);
            this.menuitemCustomersNew.Text = "Зарегистрировать читателя";
            this.menuitemCustomersNew.Click += new System.EventHandler(this.MenuItemCustomersNew_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(223, 6);
            // 
            // menuitemBooks
            // 
            this.menuitemBooks.Name = "menuitemBooks";
            this.menuitemBooks.Size = new System.Drawing.Size(226, 22);
            this.menuitemBooks.Text = "Книги";
            this.menuitemBooks.Click += new System.EventHandler(this.MenuItemBooks_Click);
            // 
            // menuItemBooksNew
            // 
            this.menuItemBooksNew.Name = "menuItemBooksNew";
            this.menuItemBooksNew.Size = new System.Drawing.Size(226, 22);
            this.menuItemBooksNew.Text = "Новая книга";
            this.menuItemBooksNew.Click += new System.EventHandler(this.MenuItemBooksNew_Click);
            // 
            // menuDeliveredBooks
            // 
            this.menuDeliveredBooks.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitemDeliveredBooks,
            this.menuitemNewDeliveredBook});
            this.menuDeliveredBooks.Name = "menuDeliveredBooks";
            this.menuDeliveredBooks.Size = new System.Drawing.Size(111, 20);
            this.menuDeliveredBooks.Text = "Выданные книги";
            // 
            // menuitemDeliveredBooks
            // 
            this.menuitemDeliveredBooks.Name = "menuitemDeliveredBooks";
            this.menuitemDeliveredBooks.Size = new System.Drawing.Size(201, 22);
            this.menuitemDeliveredBooks.Text = "Список выданных книг";
            this.menuitemDeliveredBooks.Click += new System.EventHandler(this.MenuItemDeliveredBooks_Click);
            // 
            // menuitemNewDeliveredBook
            // 
            this.menuitemNewDeliveredBook.Name = "menuitemNewDeliveredBook";
            this.menuitemNewDeliveredBook.Size = new System.Drawing.Size(201, 22);
            this.menuitemNewDeliveredBook.Text = "Выдача книги";
            this.menuitemNewDeliveredBook.Click += new System.EventHandler(this.MenuItemNewDeliveredBook_Click);
            // 
            // menuitemHelp
            // 
            this.menuitemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemHelpAbout});
            this.menuitemHelp.Name = "menuitemHelp";
            this.menuitemHelp.Size = new System.Drawing.Size(65, 20);
            this.menuitemHelp.Text = "Справка";
            // 
            // menuItemHelpAbout
            // 
            this.menuItemHelpAbout.Name = "menuItemHelpAbout";
            this.menuItemHelpAbout.Size = new System.Drawing.Size(158, 22);
            this.menuItemHelpAbout.Text = "О программе...";
            this.menuItemHelpAbout.Click += new System.EventHandler(this.MenuItemHelpAbout_Click);
            // 
            // tools
            // 
            this.tools.Location = new System.Drawing.Point(0, 24);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(800, 25);
            this.tools.TabIndex = 4;
            this.tools.Text = "tools";
            // 
            // openDialog
            // 
            this.openDialog.DefaultExt = "xml";
            this.openDialog.FileName = "openDialog";
            this.openDialog.Filter = "Файлы XML (*.xml)|*.xml|Все файлы (*.*)|*.*";
            // 
            // saveDialog
            // 
            this.saveDialog.DefaultExt = "xml";
            this.saveDialog.Filter = "Файлы XML (*.xml)|*.xml|Все файлы (*.*)|*.*";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "FormMain";
            this.Text = "Библиотека";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuitemFile;
        private System.Windows.Forms.ToolStripMenuItem menuitemCatalogs;
        private System.Windows.Forms.ToolStripMenuItem menuitemHelp;
        private System.Windows.Forms.ToolStripMenuItem menuitemFileExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemHelpAbout;
        private System.Windows.Forms.ToolStripMenuItem menuitemCustomersNew;
        private System.Windows.Forms.ToolStripMenuItem menuitemCustomers;
        private System.Windows.Forms.ToolStripMenuItem menuitemLoadData;
        private System.Windows.Forms.ToolStripMenuItem menuitemSaveData;
        private System.Windows.Forms.ToolStripMenuItem menuitemSaveDataAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuitemBooks;
        private System.Windows.Forms.ToolStripMenuItem menuItemBooksNew;
        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.ToolStripMenuItem menuitemClearData;
        private System.Windows.Forms.OpenFileDialog openDialog;
        private System.Windows.Forms.SaveFileDialog saveDialog;
        private System.Windows.Forms.ToolStripMenuItem menuDeliveredBooks;
        private System.Windows.Forms.ToolStripMenuItem menuitemDeliveredBooks;
        private System.Windows.Forms.ToolStripMenuItem menuitemNewDeliveredBook;
    }
}

