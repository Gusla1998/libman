namespace libman
{
    partial class FormBooks
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gridBooks = new System.Windows.Forms.DataGridView();
            this.bsourceBooks = new System.Windows.Forms.BindingSource(this.components);
            this.toolstrip = new System.Windows.Forms.ToolStrip();
            this.toolbtnSelect = new System.Windows.Forms.ToolStripButton();
            this.toolbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolsepData = new System.Windows.Forms.ToolStripSeparator();
            this.toolbtnNewBook = new System.Windows.Forms.ToolStripButton();
            this.toolbtnEditBook = new System.Windows.Forms.ToolStripButton();
            this.toolbtnRemoveBook = new System.Windows.Forms.ToolStripButton();
            this.toolsetEdit = new System.Windows.Forms.ToolStripSeparator();
            this.toolbtnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolbtnResetFilter = new System.Windows.Forms.ToolStripButton();
            this.toolsepSearch = new System.Windows.Forms.ToolStripSeparator();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuData = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.menusepData = new System.Windows.Forms.ToolStripSeparator();
            this.menuitemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemNewBook = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemEditBook = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemRemoveBook = new System.Windows.Forms.ToolStripMenuItem();
            this.menusepEdit = new System.Windows.Forms.ToolStripSeparator();
            this.menuitemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemSearchByTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemSearchByAuthors = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemSearchBySection = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemSearchByCode = new System.Windows.Forms.ToolStripMenuItem();
            this.menusepSearch = new System.Windows.Forms.ToolStripSeparator();
            this.menuitemResetFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.groupFilter = new System.Windows.Forms.GroupBox();
            this.comboSearch = new System.Windows.Forms.ComboBox();
            this.checkExactly = new System.Windows.Forms.CheckBox();
            this.labelSentinel = new System.Windows.Forms.Label();
            this.textSentinel = new System.Windows.Forms.TextBox();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuthors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPublisher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colReady = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsourceBooks)).BeginInit();
            this.toolstrip.SuspendLayout();
            this.menu.SuspendLayout();
            this.groupFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridBooks
            // 
            this.gridBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridBooks.AutoGenerateColumns = false;
            this.gridBooks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.gridBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCode,
            this.colAuthors,
            this.colTitle,
            this.colPublisher,
            this.colYear,
            this.colTotal,
            this.colReady});
            this.gridBooks.DataSource = this.bsourceBooks;
            this.gridBooks.Location = new System.Drawing.Point(12, 97);
            this.gridBooks.Name = "gridBooks";
            this.gridBooks.Size = new System.Drawing.Size(868, 327);
            this.gridBooks.TabIndex = 0;
            this.gridBooks.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridBooks_CellClick);
            this.gridBooks.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridBooks_CellDoubleClick);
            // 
            // toolstrip
            // 
            this.toolstrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtnSelect,
            this.toolbtnRefresh,
            this.toolsepData,
            this.toolbtnNewBook,
            this.toolbtnEditBook,
            this.toolbtnRemoveBook,
            this.toolsetEdit,
            this.toolbtnSearch,
            this.toolbtnResetFilter,
            this.toolsepSearch});
            this.toolstrip.Location = new System.Drawing.Point(0, 24);
            this.toolstrip.Name = "toolstrip";
            this.toolstrip.Size = new System.Drawing.Size(886, 25);
            this.toolstrip.TabIndex = 1;
            this.toolstrip.Text = "toolstrip";
            // 
            // toolbtnSelect
            // 
            this.toolbtnSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnSelect.Image = global::libman.Properties.Resources.Ok;
            this.toolbtnSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnSelect.Name = "toolbtnSelect";
            this.toolbtnSelect.Size = new System.Drawing.Size(23, 22);
            this.toolbtnSelect.Text = "toolbtnSelect";
            this.toolbtnSelect.Click += new System.EventHandler(this.ToolBtnSelect_Click);
            // 
            // toolbtnRefresh
            // 
            this.toolbtnRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnRefresh.Image = global::libman.Properties.Resources.Refresh;
            this.toolbtnRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnRefresh.Name = "toolbtnRefresh";
            this.toolbtnRefresh.Size = new System.Drawing.Size(23, 22);
            this.toolbtnRefresh.Text = "Обновить";
            this.toolbtnRefresh.Click += new System.EventHandler(this.ToolBtnRefresh_Click);
            // 
            // toolsepData
            // 
            this.toolsepData.Name = "toolsepData";
            this.toolsepData.Size = new System.Drawing.Size(6, 25);
            // 
            // toolbtnNewBook
            // 
            this.toolbtnNewBook.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnNewBook.Image = global::libman.Properties.Resources.page;
            this.toolbtnNewBook.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnNewBook.Name = "toolbtnNewBook";
            this.toolbtnNewBook.Size = new System.Drawing.Size(23, 22);
            this.toolbtnNewBook.Text = "Новая книга";
            this.toolbtnNewBook.Click += new System.EventHandler(this.toolbtnNewBook_Click);
            // 
            // toolbtnEditBook
            // 
            this.toolbtnEditBook.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnEditBook.Image = global::libman.Properties.Resources.page_white_edit;
            this.toolbtnEditBook.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnEditBook.Name = "toolbtnEditBook";
            this.toolbtnEditBook.Size = new System.Drawing.Size(23, 22);
            this.toolbtnEditBook.Text = "Редактировать данные книги";
            this.toolbtnEditBook.Click += new System.EventHandler(this.ToolBtnEditBook_Click);
            // 
            // toolbtnRemoveBook
            // 
            this.toolbtnRemoveBook.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnRemoveBook.Image = global::libman.Properties.Resources.page_delete;
            this.toolbtnRemoveBook.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnRemoveBook.Name = "toolbtnRemoveBook";
            this.toolbtnRemoveBook.Size = new System.Drawing.Size(23, 22);
            this.toolbtnRemoveBook.Text = "Удалить книгу";
            this.toolbtnRemoveBook.Click += new System.EventHandler(this.ToolBtnRemoveBook_Click);
            // 
            // toolsetEdit
            // 
            this.toolsetEdit.Name = "toolsetEdit";
            this.toolsetEdit.Size = new System.Drawing.Size(6, 25);
            // 
            // toolbtnSearch
            // 
            this.toolbtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnSearch.Image = global::libman.Properties.Resources.find;
            this.toolbtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnSearch.Name = "toolbtnSearch";
            this.toolbtnSearch.Size = new System.Drawing.Size(23, 22);
            this.toolbtnSearch.Text = "Поиск";
            this.toolbtnSearch.Click += new System.EventHandler(this.ToolBtnSearch_Click);
            // 
            // toolbtnResetFilter
            // 
            this.toolbtnResetFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnResetFilter.Image = global::libman.Properties.Resources.cancel;
            this.toolbtnResetFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnResetFilter.Name = "toolbtnResetFilter";
            this.toolbtnResetFilter.Size = new System.Drawing.Size(23, 22);
            this.toolbtnResetFilter.Text = "Сбросить фильтр";
            this.toolbtnResetFilter.Click += new System.EventHandler(this.ToolBtnResetFilter_Click);
            // 
            // toolsepSearch
            // 
            this.toolsepSearch.Name = "toolsepSearch";
            this.toolsepSearch.Size = new System.Drawing.Size(6, 25);
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuData,
            this.menuEdit,
            this.menuSearch});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(886, 24);
            this.menu.TabIndex = 2;
            this.menu.Text = "menuStrip1";
            // 
            // menuData
            // 
            this.menuData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitemUpdate,
            this.menuitemSelect,
            this.menusepData,
            this.menuitemClose});
            this.menuData.Name = "menuData";
            this.menuData.Size = new System.Drawing.Size(62, 20);
            this.menuData.Text = "Данные";
            // 
            // menuitemUpdate
            // 
            this.menuitemUpdate.Name = "menuitemUpdate";
            this.menuitemUpdate.Size = new System.Drawing.Size(128, 22);
            this.menuitemUpdate.Text = "Обновить";
            this.menuitemUpdate.Click += new System.EventHandler(this.MenuItemUpdate_Click);
            // 
            // menuitemSelect
            // 
            this.menuitemSelect.Name = "menuitemSelect";
            this.menuitemSelect.Size = new System.Drawing.Size(128, 22);
            this.menuitemSelect.Text = "Выбрать";
            this.menuitemSelect.Click += new System.EventHandler(this.MenuItemSelect_Click);
            // 
            // menusepData
            // 
            this.menusepData.Name = "menusepData";
            this.menusepData.Size = new System.Drawing.Size(125, 6);
            // 
            // menuitemClose
            // 
            this.menuitemClose.Name = "menuitemClose";
            this.menuitemClose.Size = new System.Drawing.Size(128, 22);
            this.menuitemClose.Text = "Закрыть";
            this.menuitemClose.Click += new System.EventHandler(this.MenuItemClose_Click);
            // 
            // menuEdit
            // 
            this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitemNewBook,
            this.menuitemEditBook,
            this.menuitemRemoveBook,
            this.menusepEdit,
            this.menuitemClear});
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(59, 20);
            this.menuEdit.Text = "Правка";
            // 
            // menuitemNewBook
            // 
            this.menuitemNewBook.Name = "menuitemNewBook";
            this.menuitemNewBook.Size = new System.Drawing.Size(233, 22);
            this.menuitemNewBook.Text = "Новая книга";
            this.menuitemNewBook.Click += new System.EventHandler(this.MenuItemNewBook_Click);
            // 
            // menuitemEditBook
            // 
            this.menuitemEditBook.Name = "menuitemEditBook";
            this.menuitemEditBook.Size = new System.Drawing.Size(233, 22);
            this.menuitemEditBook.Text = "Редактировать данные книги";
            this.menuitemEditBook.Click += new System.EventHandler(this.MenuItemEditBook_Click);
            // 
            // menuitemRemoveBook
            // 
            this.menuitemRemoveBook.Name = "menuitemRemoveBook";
            this.menuitemRemoveBook.Size = new System.Drawing.Size(233, 22);
            this.menuitemRemoveBook.Text = "Удалить книгу";
            this.menuitemRemoveBook.Click += new System.EventHandler(this.MenuItemRemoveBook_Click);
            // 
            // menusepEdit
            // 
            this.menusepEdit.Name = "menusepEdit";
            this.menusepEdit.Size = new System.Drawing.Size(230, 6);
            // 
            // menuitemClear
            // 
            this.menuitemClear.Name = "menuitemClear";
            this.menuitemClear.Size = new System.Drawing.Size(233, 22);
            this.menuitemClear.Text = "Очистить";
            this.menuitemClear.Click += new System.EventHandler(this.MenuItemClear_Click);
            // 
            // menuSearch
            // 
            this.menuSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitemSearchByTitle,
            this.menuitemSearchByAuthors,
            this.menuitemSearchBySection,
            this.menuitemSearchByCode,
            this.menusepSearch,
            this.menuitemResetFilter});
            this.menuSearch.Name = "menuSearch";
            this.menuSearch.Size = new System.Drawing.Size(54, 20);
            this.menuSearch.Text = "Поиск";
            // 
            // menuitemSearchByTitle
            // 
            this.menuitemSearchByTitle.Name = "menuitemSearchByTitle";
            this.menuitemSearchByTitle.Size = new System.Drawing.Size(171, 22);
            this.menuitemSearchByTitle.Text = "по названию";
            this.menuitemSearchByTitle.Click += new System.EventHandler(this.MenuItemSearchByTitle_Click);
            // 
            // menuitemSearchByAuthors
            // 
            this.menuitemSearchByAuthors.Name = "menuitemSearchByAuthors";
            this.menuitemSearchByAuthors.Size = new System.Drawing.Size(171, 22);
            this.menuitemSearchByAuthors.Text = "по авторам";
            this.menuitemSearchByAuthors.Click += new System.EventHandler(this.MenuItemSearchByAuthors_Click);
            // 
            // menuitemSearchBySection
            // 
            this.menuitemSearchBySection.Name = "menuitemSearchBySection";
            this.menuitemSearchBySection.Size = new System.Drawing.Size(171, 22);
            this.menuitemSearchBySection.Text = "по разделу";
            this.menuitemSearchBySection.Click += new System.EventHandler(this.MenuItemSearchBySection_Click);
            // 
            // menuitemSearchByCode
            // 
            this.menuitemSearchByCode.Name = "menuitemSearchByCode";
            this.menuitemSearchByCode.Size = new System.Drawing.Size(171, 22);
            this.menuitemSearchByCode.Text = "по шифру";
            this.menuitemSearchByCode.Click += new System.EventHandler(this.MenuItemSearchByCode_Click);
            // 
            // menusepSearch
            // 
            this.menusepSearch.Name = "menusepSearch";
            this.menusepSearch.Size = new System.Drawing.Size(168, 6);
            // 
            // menuitemResetFilter
            // 
            this.menuitemResetFilter.Name = "menuitemResetFilter";
            this.menuitemResetFilter.Size = new System.Drawing.Size(171, 22);
            this.menuitemResetFilter.Text = "Сбросить фильтр";
            // 
            // groupFilter
            // 
            this.groupFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupFilter.Controls.Add(this.comboSearch);
            this.groupFilter.Controls.Add(this.checkExactly);
            this.groupFilter.Controls.Add(this.labelSentinel);
            this.groupFilter.Controls.Add(this.textSentinel);
            this.groupFilter.Location = new System.Drawing.Point(12, 52);
            this.groupFilter.Name = "groupFilter";
            this.groupFilter.Size = new System.Drawing.Size(868, 46);
            this.groupFilter.TabIndex = 14;
            this.groupFilter.TabStop = false;
            this.groupFilter.Text = "Отбор:";
            // 
            // comboSearch
            // 
            this.comboSearch.FormattingEnabled = true;
            this.comboSearch.Items.AddRange(new object[] {
            "<отсутствует>",
            "по авторам",
            "по названию",
            "по разделу",
            "по шифру"});
            this.comboSearch.Location = new System.Drawing.Point(6, 19);
            this.comboSearch.Name = "comboSearch";
            this.comboSearch.Size = new System.Drawing.Size(121, 21);
            this.comboSearch.TabIndex = 19;
            // 
            // checkExactly
            // 
            this.checkExactly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkExactly.AutoSize = true;
            this.checkExactly.Location = new System.Drawing.Point(722, 21);
            this.checkExactly.Name = "checkExactly";
            this.checkExactly.Size = new System.Drawing.Size(123, 17);
            this.checkExactly.TabIndex = 18;
            this.checkExactly.Text = "точное совпадение";
            this.checkExactly.UseVisualStyleBackColor = true;
            // 
            // labelSentinel
            // 
            this.labelSentinel.AutoSize = true;
            this.labelSentinel.Location = new System.Drawing.Point(157, 22);
            this.labelSentinel.Name = "labelSentinel";
            this.labelSentinel.Size = new System.Drawing.Size(54, 13);
            this.labelSentinel.TabIndex = 17;
            this.labelSentinel.Text = "Образец:";
            // 
            // textSentinel
            // 
            this.textSentinel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSentinel.Location = new System.Drawing.Point(217, 19);
            this.textSentinel.Name = "textSentinel";
            this.textSentinel.Size = new System.Drawing.Size(499, 20);
            this.textSentinel.TabIndex = 16;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            this.colCode.HeaderText = "Шифр";
            this.colCode.Name = "colCode";
            this.colCode.Width = 80;
            // 
            // colAuthors
            // 
            this.colAuthors.DataPropertyName = "Authors";
            this.colAuthors.HeaderText = "Авторы";
            this.colAuthors.Name = "colAuthors";
            this.colAuthors.Width = 150;
            // 
            // colTitle
            // 
            this.colTitle.DataPropertyName = "Title";
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.colTitle.DefaultCellStyle = dataGridViewCellStyle10;
            this.colTitle.HeaderText = "Название";
            this.colTitle.Name = "colTitle";
            this.colTitle.Width = 250;
            // 
            // colPublisher
            // 
            this.colPublisher.DataPropertyName = "Publisher";
            this.colPublisher.HeaderText = "Издатель";
            this.colPublisher.Name = "colPublisher";
            // 
            // colYear
            // 
            this.colYear.DataPropertyName = "Year";
            this.colYear.HeaderText = "Год издания";
            this.colYear.Name = "colYear";
            this.colYear.Width = 70;
            // 
            // colTotal
            // 
            this.colTotal.DataPropertyName = "Total";
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colTotal.DefaultCellStyle = dataGridViewCellStyle11;
            this.colTotal.HeaderText = "Количество";
            this.colTotal.Name = "colTotal";
            this.colTotal.Width = 70;
            // 
            // colReady
            // 
            this.colReady.DataPropertyName = "Ready";
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colReady.DefaultCellStyle = dataGridViewCellStyle12;
            this.colReady.HeaderText = "В наличии";
            this.colReady.Name = "colReady";
            this.colReady.Width = 70;
            // 
            // FormBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 432);
            this.Controls.Add(this.groupFilter);
            this.Controls.Add(this.toolstrip);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.gridBooks);
            this.MainMenuStrip = this.menu;
            this.Name = "FormBooks";
            this.Text = "Книги";
            ((System.ComponentModel.ISupportInitialize)(this.gridBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsourceBooks)).EndInit();
            this.toolstrip.ResumeLayout(false);
            this.toolstrip.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.groupFilter.ResumeLayout(false);
            this.groupFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gridBooks;
        private System.Windows.Forms.ToolStrip toolstrip;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuSearch;
        private System.Windows.Forms.ToolStripButton toolbtnSelect;
        private System.Windows.Forms.ToolStripSeparator toolsepData;
        private System.Windows.Forms.ToolStripButton toolbtnNewBook;
        private System.Windows.Forms.ToolStripButton toolbtnEditBook;
        private System.Windows.Forms.ToolStripButton toolbtnRemoveBook;
        private System.Windows.Forms.ToolStripMenuItem menuitemNewBook;
        private System.Windows.Forms.ToolStripMenuItem menuitemEditBook;
        private System.Windows.Forms.ToolStripMenuItem menuitemRemoveBook;
        private System.Windows.Forms.BindingSource bsourceBooks;
        private System.Windows.Forms.ToolStripSeparator menusepEdit;
        private System.Windows.Forms.ToolStripMenuItem menuitemClear;
        private System.Windows.Forms.ToolStripMenuItem menuitemSearchByTitle;
        private System.Windows.Forms.ToolStripMenuItem menuitemSearchByAuthors;
        private System.Windows.Forms.ToolStripMenuItem menuitemSearchByCode;
        private System.Windows.Forms.ToolStripSeparator menusepSearch;
        private System.Windows.Forms.ToolStripMenuItem menuitemResetFilter;
        private System.Windows.Forms.ToolStripMenuItem menuitemSearchBySection;
        private System.Windows.Forms.ToolStripSeparator toolsetEdit;
        private System.Windows.Forms.ToolStripButton toolbtnSearch;
        private System.Windows.Forms.GroupBox groupFilter;
        private System.Windows.Forms.ComboBox comboSearch;
        private System.Windows.Forms.CheckBox checkExactly;
        private System.Windows.Forms.Label labelSentinel;
        private System.Windows.Forms.TextBox textSentinel;
        private System.Windows.Forms.ToolStripMenuItem menuData;
        private System.Windows.Forms.ToolStripMenuItem menuitemSelect;
        private System.Windows.Forms.ToolStripMenuItem menuitemClose;
        private System.Windows.Forms.ToolStripSeparator menusepData;
        private System.Windows.Forms.ToolStripMenuItem menuitemUpdate;
        private System.Windows.Forms.ToolStripButton toolbtnResetFilter;
        private System.Windows.Forms.ToolStripSeparator toolsepSearch;
        private System.Windows.Forms.ToolStripButton toolbtnRefresh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuthors;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPublisher;
        private System.Windows.Forms.DataGridViewTextBoxColumn colYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReady;
    }
}