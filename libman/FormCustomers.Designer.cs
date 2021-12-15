namespace libman
{
    partial class FormCustomers
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolstrip = new System.Windows.Forms.ToolStrip();
            this.toolbtnSelect = new System.Windows.Forms.ToolStripButton();
            this.toolbtnUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolsepData = new System.Windows.Forms.ToolStripSeparator();
            this.toolbtnNew = new System.Windows.Forms.ToolStripButton();
            this.toolbtnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolbtnRemove = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolbtnSearch = new System.Windows.Forms.ToolStripButton();
            this.toolbtnResetFilter = new System.Windows.Forms.ToolStripButton();
            this.toolsepSearch = new System.Windows.Forms.ToolStripSeparator();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menuData = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.menusepData = new System.Windows.Forms.ToolStripSeparator();
            this.menuitemSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemNewCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemEditCustomer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemRemoveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menusepEdit = new System.Windows.Forms.ToolStripSeparator();
            this.menuitemClearCustomers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSearch = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSearchByName = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSearchByCardId = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemResetFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.buttonClose = new System.Windows.Forms.Button();
            this.gridCustomers = new System.Windows.Forms.DataGridView();
            this.colCardId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBirthYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsourceCustomers = new System.Windows.Forms.BindingSource(this.components);
            this.groupFilter = new System.Windows.Forms.GroupBox();
            this.comboSearch = new System.Windows.Forms.ComboBox();
            this.checkExactly = new System.Windows.Forms.CheckBox();
            this.labelSentinel = new System.Windows.Forms.Label();
            this.textSentinel = new System.Windows.Forms.TextBox();
            this.toolstrip.SuspendLayout();
            this.menu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsourceCustomers)).BeginInit();
            this.groupFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolstrip
            // 
            this.toolstrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtnSelect,
            this.toolbtnUpdate,
            this.toolsepData,
            this.toolbtnNew,
            this.toolbtnEdit,
            this.toolbtnRemove,
            this.toolStripSeparator1,
            this.toolbtnSearch,
            this.toolbtnResetFilter,
            this.toolsepSearch});
            this.toolstrip.Location = new System.Drawing.Point(0, 24);
            this.toolstrip.Name = "toolstrip";
            this.toolstrip.Size = new System.Drawing.Size(800, 25);
            this.toolstrip.TabIndex = 1;
            // 
            // toolbtnSelect
            // 
            this.toolbtnSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnSelect.Image = global::libman.Properties.Resources.Ok;
            this.toolbtnSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnSelect.Name = "toolbtnSelect";
            this.toolbtnSelect.Size = new System.Drawing.Size(23, 22);
            this.toolbtnSelect.Text = "Выбрать";
            this.toolbtnSelect.Click += new System.EventHandler(this.ToolBtnSelect_Click);
            // 
            // toolbtnUpdate
            // 
            this.toolbtnUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnUpdate.Image = global::libman.Properties.Resources.Refresh;
            this.toolbtnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnUpdate.Name = "toolbtnUpdate";
            this.toolbtnUpdate.Size = new System.Drawing.Size(23, 22);
            this.toolbtnUpdate.Text = "Обновить";
            this.toolbtnUpdate.Click += new System.EventHandler(this.ToolBtnUpdate_Click);
            // 
            // toolsepData
            // 
            this.toolsepData.Name = "toolsepData";
            this.toolsepData.Size = new System.Drawing.Size(6, 25);
            // 
            // toolbtnNew
            // 
            this.toolbtnNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnNew.Image = global::libman.Properties.Resources.page;
            this.toolbtnNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnNew.Name = "toolbtnNew";
            this.toolbtnNew.Size = new System.Drawing.Size(23, 22);
            this.toolbtnNew.Text = "Новый читатель";
            this.toolbtnNew.Click += new System.EventHandler(this.ToolBtnNew_Click);
            // 
            // toolbtnEdit
            // 
            this.toolbtnEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnEdit.Image = global::libman.Properties.Resources.page_white_edit;
            this.toolbtnEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnEdit.Name = "toolbtnEdit";
            this.toolbtnEdit.Size = new System.Drawing.Size(23, 22);
            this.toolbtnEdit.Text = "Редактировать";
            this.toolbtnEdit.Click += new System.EventHandler(this.ToolBtnEdit_Click);
            // 
            // toolbtnRemove
            // 
            this.toolbtnRemove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnRemove.Image = global::libman.Properties.Resources.page_delete;
            this.toolbtnRemove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnRemove.Name = "toolbtnRemove";
            this.toolbtnRemove.Size = new System.Drawing.Size(23, 22);
            this.toolbtnRemove.Text = "Удалить";
            this.toolbtnRemove.Click += new System.EventHandler(this.ToolBtnRemove_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
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
            this.menu.Size = new System.Drawing.Size(800, 24);
            this.menu.TabIndex = 2;
            this.menu.Text = "menuStrip1";
            // 
            // menuData
            // 
            this.menuData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitemUpdate,
            this.menusepData,
            this.menuitemSelect,
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
            // menusepData
            // 
            this.menusepData.Name = "menusepData";
            this.menusepData.Size = new System.Drawing.Size(125, 6);
            // 
            // menuitemSelect
            // 
            this.menuitemSelect.Name = "menuitemSelect";
            this.menuitemSelect.Size = new System.Drawing.Size(128, 22);
            this.menuitemSelect.Text = "Выбрать";
            this.menuitemSelect.Click += new System.EventHandler(this.MenuItemSelect_Click);
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
            this.menuitemNewCustomer,
            this.menuitemEditCustomer,
            this.menuitemRemoveItem,
            this.menusepEdit,
            this.menuitemClearCustomers});
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(59, 20);
            this.menuEdit.Text = "Правка";
            // 
            // menuitemNewCustomer
            // 
            this.menuitemNewCustomer.Name = "menuitemNewCustomer";
            this.menuitemNewCustomer.Size = new System.Drawing.Size(250, 22);
            this.menuitemNewCustomer.Text = "Новый читатель";
            this.menuitemNewCustomer.Click += new System.EventHandler(this.MenuItemNewCustomer_Click);
            // 
            // menuitemEditCustomer
            // 
            this.menuitemEditCustomer.Name = "menuitemEditCustomer";
            this.menuitemEditCustomer.Size = new System.Drawing.Size(250, 22);
            this.menuitemEditCustomer.Text = "Редактировать данные читателя";
            this.menuitemEditCustomer.Click += new System.EventHandler(this.MenuItemEditCustomer_Click);
            // 
            // menuitemRemoveItem
            // 
            this.menuitemRemoveItem.Name = "menuitemRemoveItem";
            this.menuitemRemoveItem.Size = new System.Drawing.Size(250, 22);
            this.menuitemRemoveItem.Text = "Удалить данные читателя";
            this.menuitemRemoveItem.Click += new System.EventHandler(this.MenuItemRemoveItem_Click);
            // 
            // menusepEdit
            // 
            this.menusepEdit.Name = "menusepEdit";
            this.menusepEdit.Size = new System.Drawing.Size(247, 6);
            // 
            // menuitemClearCustomers
            // 
            this.menuitemClearCustomers.Name = "menuitemClearCustomers";
            this.menuitemClearCustomers.Size = new System.Drawing.Size(250, 22);
            this.menuitemClearCustomers.Text = "Очистить";
            this.menuitemClearCustomers.Click += new System.EventHandler(this.MenuItemClearCustomers_Click);
            // 
            // menuSearch
            // 
            this.menuSearch.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSearchByName,
            this.menuItemSearchByCardId,
            this.toolStripSeparator2,
            this.menuItemResetFilter});
            this.menuSearch.Name = "menuSearch";
            this.menuSearch.Size = new System.Drawing.Size(54, 20);
            this.menuSearch.Text = "Поиск";
            // 
            // menuItemSearchByName
            // 
            this.menuItemSearchByName.Name = "menuItemSearchByName";
            this.menuItemSearchByName.Size = new System.Drawing.Size(257, 22);
            this.menuItemSearchByName.Text = "по фамилии, имени, отчеству";
            this.menuItemSearchByName.Click += new System.EventHandler(this.MenuItemSearchByName_Click);
            // 
            // menuItemSearchByCardId
            // 
            this.menuItemSearchByCardId.Name = "menuItemSearchByCardId";
            this.menuItemSearchByCardId.Size = new System.Drawing.Size(257, 22);
            this.menuItemSearchByCardId.Text = "по номеру читательского билета";
            this.menuItemSearchByCardId.Click += new System.EventHandler(this.MenuItemSearchByCardId_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(254, 6);
            // 
            // menuItemResetFilter
            // 
            this.menuItemResetFilter.Name = "menuItemResetFilter";
            this.menuItemResetFilter.Size = new System.Drawing.Size(257, 22);
            this.menuItemResetFilter.Text = "Отменить фильтр";
            this.menuItemResetFilter.Click += new System.EventHandler(this.MenuItemResetFilter_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClose.Location = new System.Drawing.Point(0, 420);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 3;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonClose_Click);
            // 
            // gridCustomers
            // 
            this.gridCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCustomers.AutoGenerateColumns = false;
            this.gridCustomers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.gridCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCardId,
            this.colName,
            this.colBirthYear});
            this.gridCustomers.DataSource = this.bsourceCustomers;
            this.gridCustomers.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.gridCustomers.Location = new System.Drawing.Point(0, 111);
            this.gridCustomers.Name = "gridCustomers";
            this.gridCustomers.Size = new System.Drawing.Size(788, 303);
            this.gridCustomers.TabIndex = 0;
            this.gridCustomers.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridCustomers_CellClick);
            this.gridCustomers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridCustomers_CellDoubleClick);
            // 
            // colCardId
            // 
            this.colCardId.DataPropertyName = "CardId";
            this.colCardId.HeaderText = "№ читательского билета";
            this.colCardId.Name = "colCardId";
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Фамилия, имя, отчество";
            this.colName.Name = "colName";
            this.colName.Width = 300;
            // 
            // colBirthYear
            // 
            this.colBirthYear.DataPropertyName = "BirthYear";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.colBirthYear.DefaultCellStyle = dataGridViewCellStyle2;
            this.colBirthYear.HeaderText = "Год рождения";
            this.colBirthYear.Name = "colBirthYear";
            this.colBirthYear.Width = 70;
            // 
            // groupFilter
            // 
            this.groupFilter.Controls.Add(this.comboSearch);
            this.groupFilter.Controls.Add(this.checkExactly);
            this.groupFilter.Controls.Add(this.labelSentinel);
            this.groupFilter.Controls.Add(this.textSentinel);
            this.groupFilter.Location = new System.Drawing.Point(0, 56);
            this.groupFilter.Name = "groupFilter";
            this.groupFilter.Size = new System.Drawing.Size(788, 49);
            this.groupFilter.TabIndex = 8;
            this.groupFilter.TabStop = false;
            this.groupFilter.Text = "Отбор:";
            // 
            // comboSearch
            // 
            this.comboSearch.FormattingEnabled = true;
            this.comboSearch.Items.AddRange(new object[] {
            "<отсутствует>",
            "по Ф.И.О.",
            "по номеру"});
            this.comboSearch.Location = new System.Drawing.Point(5, 19);
            this.comboSearch.Name = "comboSearch";
            this.comboSearch.Size = new System.Drawing.Size(121, 21);
            this.comboSearch.TabIndex = 14;
            // 
            // checkExactly
            // 
            this.checkExactly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkExactly.AutoSize = true;
            this.checkExactly.Location = new System.Drawing.Point(637, 21);
            this.checkExactly.Name = "checkExactly";
            this.checkExactly.Size = new System.Drawing.Size(123, 17);
            this.checkExactly.TabIndex = 13;
            this.checkExactly.Text = "точное совпадение";
            this.checkExactly.UseVisualStyleBackColor = true;
            // 
            // labelSentinel
            // 
            this.labelSentinel.AutoSize = true;
            this.labelSentinel.Location = new System.Drawing.Point(136, 22);
            this.labelSentinel.Name = "labelSentinel";
            this.labelSentinel.Size = new System.Drawing.Size(54, 13);
            this.labelSentinel.TabIndex = 12;
            this.labelSentinel.Text = "Образец:";
            // 
            // textSentinel
            // 
            this.textSentinel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSentinel.Location = new System.Drawing.Point(196, 19);
            this.textSentinel.Name = "textSentinel";
            this.textSentinel.Size = new System.Drawing.Size(435, 20);
            this.textSentinel.TabIndex = 11;
            // 
            // FormCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupFilter);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.toolstrip);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.gridCustomers);
            this.MainMenuStrip = this.menu;
            this.Name = "FormCustomers";
            this.Text = "Читатели";
            this.toolstrip.ResumeLayout(false);
            this.toolstrip.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsourceCustomers)).EndInit();
            this.groupFilter.ResumeLayout(false);
            this.groupFilter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolstrip;
        private System.Windows.Forms.ToolStripButton toolbtnSelect;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripButton toolbtnNew;
        private System.Windows.Forms.ToolStripButton toolbtnEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.ToolStripMenuItem menuData;
        private System.Windows.Forms.BindingSource bsourceCustomers;
        private System.Windows.Forms.ToolStripSeparator toolsepData;
        private System.Windows.Forms.ToolStripButton toolbtnRemove;
        private System.Windows.Forms.DataGridView gridCustomers;
        private System.Windows.Forms.ToolStripButton toolbtnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCardId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBirthYear;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuitemNewCustomer;
        private System.Windows.Forms.ToolStripMenuItem menuitemEditCustomer;
        private System.Windows.Forms.ToolStripMenuItem menuitemRemoveItem;
        private System.Windows.Forms.ToolStripMenuItem menuSearch;
        private System.Windows.Forms.ToolStripMenuItem menuItemSearchByName;
        private System.Windows.Forms.ToolStripMenuItem menuItemSearchByCardId;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuItemResetFilter;
        private System.Windows.Forms.ToolStripButton toolbtnResetFilter;
        private System.Windows.Forms.ToolStripSeparator menusepEdit;
        private System.Windows.Forms.ToolStripMenuItem menuitemClearCustomers;
        private System.Windows.Forms.GroupBox groupFilter;
        private System.Windows.Forms.ComboBox comboSearch;
        private System.Windows.Forms.CheckBox checkExactly;
        private System.Windows.Forms.Label labelSentinel;
        private System.Windows.Forms.TextBox textSentinel;
        private System.Windows.Forms.ToolStripMenuItem menuitemSelect;
        private System.Windows.Forms.ToolStripMenuItem menuitemClose;
        private System.Windows.Forms.ToolStripMenuItem menuitemUpdate;
        private System.Windows.Forms.ToolStripSeparator menusepData;
        private System.Windows.Forms.ToolStripButton toolbtnUpdate;
        private System.Windows.Forms.ToolStripSeparator toolsepSearch;
    }
}