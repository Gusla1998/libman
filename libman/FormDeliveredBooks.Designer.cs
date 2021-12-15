namespace libman
{
    partial class FormDeliveredBooks
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
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.menuData = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemSelectItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemRefresh = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuitemClose = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemNewDelivery = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuitemRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuitemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.tools = new System.Windows.Forms.ToolStrip();
            this.toolbtnSelect = new System.Windows.Forms.ToolStripButton();
            this.toolbtnRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolsepData = new System.Windows.Forms.ToolStripSeparator();
            this.toolbtnNewItem = new System.Windows.Forms.ToolStripButton();
            this.toolbtnEdit = new System.Windows.Forms.ToolStripButton();
            this.toolbtnRemove = new System.Windows.Forms.ToolStripButton();
            this.toolsepEdit = new System.Windows.Forms.ToolStripSeparator();
            this.gridDelivered = new System.Windows.Forms.DataGridView();
            this.colBookCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCustomerCardId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colActive = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colReturnDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkActive = new System.Windows.Forms.CheckBox();
            this.bsourceDelivered = new System.Windows.Forms.BindingSource(this.components);
            this.menuMain.SuspendLayout();
            this.tools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDelivered)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsourceDelivered)).BeginInit();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuData,
            this.menuEdit});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(570, 24);
            this.menuMain.TabIndex = 0;
            // 
            // menuData
            // 
            this.menuData.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitemRefresh,
            this.toolStripSeparator1,
            this.menuitemSelectItem,
            this.menuitemClose});
            this.menuData.Name = "menuData";
            this.menuData.Size = new System.Drawing.Size(62, 20);
            this.menuData.Text = "Данные";
            // 
            // menuitemSelectItem
            // 
            this.menuitemSelectItem.Name = "menuitemSelectItem";
            this.menuitemSelectItem.Size = new System.Drawing.Size(180, 22);
            this.menuitemSelectItem.Text = "Выбрать";
            this.menuitemSelectItem.Click += new System.EventHandler(this.MenuItemSelectItem_Click);
            // 
            // menuitemRefresh
            // 
            this.menuitemRefresh.Name = "menuitemRefresh";
            this.menuitemRefresh.Size = new System.Drawing.Size(180, 22);
            this.menuitemRefresh.Text = "Обновить";
            this.menuitemRefresh.Click += new System.EventHandler(this.MenuItemRefresh_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // menuitemClose
            // 
            this.menuitemClose.Name = "menuitemClose";
            this.menuitemClose.Size = new System.Drawing.Size(180, 22);
            this.menuitemClose.Text = "Закрыть";
            this.menuitemClose.Click += new System.EventHandler(this.MenuItemClose_Click);
            // 
            // menuEdit
            // 
            this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuitemNewDelivery,
            this.menuitemEdit,
            this.menuitemRemove,
            this.toolStripSeparator2,
            this.menuitemClear});
            this.menuEdit.Name = "menuEdit";
            this.menuEdit.Size = new System.Drawing.Size(59, 20);
            this.menuEdit.Text = "Правка";
            // 
            // menuitemNewDelivery
            // 
            this.menuitemNewDelivery.Name = "menuitemNewDelivery";
            this.menuitemNewDelivery.Size = new System.Drawing.Size(232, 22);
            this.menuitemNewDelivery.Text = "Новая выдача книги";
            this.menuitemNewDelivery.Click += new System.EventHandler(this.MenuItemNewDelivery_Click);
            // 
            // menuitemEdit
            // 
            this.menuitemEdit.Name = "menuitemEdit";
            this.menuitemEdit.Size = new System.Drawing.Size(232, 22);
            this.menuitemEdit.Text = "Редактировать выдачу книги";
            this.menuitemEdit.Click += new System.EventHandler(this.MenuItemEdit_Click);
            // 
            // menuitemRemove
            // 
            this.menuitemRemove.Name = "menuitemRemove";
            this.menuitemRemove.Size = new System.Drawing.Size(232, 22);
            this.menuitemRemove.Text = "Удалить выдачу книги";
            this.menuitemRemove.Click += new System.EventHandler(this.MenuItemRemove_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(229, 6);
            // 
            // menuitemClear
            // 
            this.menuitemClear.Name = "menuitemClear";
            this.menuitemClear.Size = new System.Drawing.Size(232, 22);
            this.menuitemClear.Text = "Очистить данные о выдачах";
            this.menuitemClear.Click += new System.EventHandler(this.MenuItemClear_Click);
            // 
            // tools
            // 
            this.tools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolbtnSelect,
            this.toolbtnRefresh,
            this.toolsepData,
            this.toolbtnNewItem,
            this.toolbtnEdit,
            this.toolbtnRemove,
            this.toolsepEdit});
            this.tools.Location = new System.Drawing.Point(0, 24);
            this.tools.Name = "tools";
            this.tools.Size = new System.Drawing.Size(570, 25);
            this.tools.TabIndex = 1;
            this.tools.Text = "toolStrip1";
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
            // toolbtnNewItem
            // 
            this.toolbtnNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolbtnNewItem.Image = global::libman.Properties.Resources.page;
            this.toolbtnNewItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolbtnNewItem.Name = "toolbtnNewItem";
            this.toolbtnNewItem.Size = new System.Drawing.Size(23, 22);
            this.toolbtnNewItem.Text = "Новая выдача";
            this.toolbtnNewItem.Click += new System.EventHandler(this.ToolBtnNewItem_Click);
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
            // toolsepEdit
            // 
            this.toolsepEdit.Name = "toolsepEdit";
            this.toolsepEdit.Size = new System.Drawing.Size(6, 25);
            // 
            // gridDelivered
            // 
            this.gridDelivered.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridDelivered.AutoGenerateColumns = false;
            this.gridDelivered.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridDelivered.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colBookCode,
            this.colCustomerCardId,
            this.colDeliveryDate,
            this.colActive,
            this.colReturnDate});
            this.gridDelivered.DataSource = this.bsourceDelivered;
            this.gridDelivered.Location = new System.Drawing.Point(0, 77);
            this.gridDelivered.Name = "gridDelivered";
            this.gridDelivered.Size = new System.Drawing.Size(570, 361);
            this.gridDelivered.TabIndex = 2;
            this.gridDelivered.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDelivered_CellClick);
            this.gridDelivered.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GridDelivered_CellContentDoubleClick);
            // 
            // colBookCode
            // 
            this.colBookCode.DataPropertyName = "BookCode";
            this.colBookCode.HeaderText = "Шифр книги";
            this.colBookCode.Name = "colBookCode";
            this.colBookCode.ReadOnly = true;
            // 
            // colCustomerCardId
            // 
            this.colCustomerCardId.DataPropertyName = "CustomerCardId";
            this.colCustomerCardId.HeaderText = "№ читательского билета";
            this.colCustomerCardId.Name = "colCustomerCardId";
            this.colCustomerCardId.ReadOnly = true;
            // 
            // colDeliveryDate
            // 
            this.colDeliveryDate.DataPropertyName = "DeliveryDate";
            this.colDeliveryDate.HeaderText = "Дата выдачи";
            this.colDeliveryDate.Name = "colDeliveryDate";
            this.colDeliveryDate.ReadOnly = true;
            // 
            // colActive
            // 
            this.colActive.DataPropertyName = "Active";
            this.colActive.HeaderText = "на руках";
            this.colActive.Name = "colActive";
            this.colActive.ReadOnly = true;
            // 
            // colReturnDate
            // 
            this.colReturnDate.DataPropertyName = "ReturnDate";
            this.colReturnDate.HeaderText = "Дата возврата";
            this.colReturnDate.Name = "colReturnDate";
            this.colReturnDate.ReadOnly = true;
            this.colReturnDate.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.colReturnDate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // checkActive
            // 
            this.checkActive.AutoSize = true;
            this.checkActive.Location = new System.Drawing.Point(12, 54);
            this.checkActive.Name = "checkActive";
            this.checkActive.Size = new System.Drawing.Size(123, 17);
            this.checkActive.TabIndex = 3;
            this.checkActive.Text = "без возвращённых";
            this.checkActive.UseVisualStyleBackColor = true;
            this.checkActive.CheckedChanged += new System.EventHandler(this.СheckActive_CheckedChanged);
            // 
            // FormDeliveredBooks
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 450);
            this.Controls.Add(this.checkActive);
            this.Controls.Add(this.gridDelivered);
            this.Controls.Add(this.tools);
            this.Controls.Add(this.menuMain);
            this.MainMenuStrip = this.menuMain;
            this.Name = "FormDeliveredBooks";
            this.Text = "Выданные книги";
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.tools.ResumeLayout(false);
            this.tools.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridDelivered)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsourceDelivered)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem menuData;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuitemRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuitemSelectItem;
        private System.Windows.Forms.ToolStripMenuItem menuitemClose;
        private System.Windows.Forms.ToolStripMenuItem menuitemNewDelivery;
        private System.Windows.Forms.ToolStripMenuItem menuitemEdit;
        private System.Windows.Forms.ToolStripMenuItem menuitemRemove;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menuitemClear;
        private System.Windows.Forms.ToolStrip tools;
        private System.Windows.Forms.ToolStripButton toolbtnSelect;
        private System.Windows.Forms.ToolStripButton toolbtnRefresh;
        private System.Windows.Forms.ToolStripSeparator toolsepData;
        private System.Windows.Forms.ToolStripButton toolbtnNewItem;
        private System.Windows.Forms.ToolStripButton toolbtnEdit;
        private System.Windows.Forms.ToolStripButton toolbtnRemove;
        private System.Windows.Forms.ToolStripSeparator toolsepEdit;
        private System.Windows.Forms.DataGridView gridDelivered;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBookCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCustomerCardId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliveryDate;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colActive;
        private System.Windows.Forms.DataGridViewTextBoxColumn colReturnDate;
        private System.Windows.Forms.CheckBox checkActive;
        private System.Windows.Forms.BindingSource bsourceDelivered;
    }
}