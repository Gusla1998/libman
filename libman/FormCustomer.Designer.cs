namespace libman
{
    partial class FormCustomer
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
            this.panelPersonalData = new System.Windows.Forms.Panel();
            this.dateRegistration = new System.Windows.Forms.DateTimePicker();
            this.labelNew = new System.Windows.Forms.Label();
            this.maskedCardId = new System.Windows.Forms.MaskedTextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.labelJob = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.textAddress = new System.Windows.Forms.TextBox();
            this.textJob = new System.Windows.Forms.TextBox();
            this.maskedBirthYear = new System.Windows.Forms.MaskedTextBox();
            this.labelBirthYear = new System.Windows.Forms.Label();
            this.labelCardId = new System.Windows.Forms.Label();
            this.labelRights = new System.Windows.Forms.Label();
            this.comboRights = new System.Windows.Forms.ComboBox();
            this.labelName = new System.Windows.Forms.Label();
            this.textName = new System.Windows.Forms.TextBox();
            this.panelDeliveredBooks = new System.Windows.Forms.Panel();
            this.labelBooks = new System.Windows.Forms.Label();
            this.gridBooks = new System.Windows.Forms.DataGridView();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuthors = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsourceBooks = new System.Windows.Forms.BindingSource(this.components);
            this.panelPersonalData.SuspendLayout();
            this.panelDeliveredBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBooks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsourceBooks)).BeginInit();
            this.SuspendLayout();
            // 
            // panelPersonalData
            // 
            this.panelPersonalData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPersonalData.Controls.Add(this.dateRegistration);
            this.panelPersonalData.Controls.Add(this.labelNew);
            this.panelPersonalData.Controls.Add(this.maskedCardId);
            this.panelPersonalData.Controls.Add(this.buttonCancel);
            this.panelPersonalData.Controls.Add(this.buttonOK);
            this.panelPersonalData.Controls.Add(this.labelJob);
            this.panelPersonalData.Controls.Add(this.labelAddress);
            this.panelPersonalData.Controls.Add(this.textAddress);
            this.panelPersonalData.Controls.Add(this.textJob);
            this.panelPersonalData.Controls.Add(this.maskedBirthYear);
            this.panelPersonalData.Controls.Add(this.labelBirthYear);
            this.panelPersonalData.Controls.Add(this.labelCardId);
            this.panelPersonalData.Controls.Add(this.labelRights);
            this.panelPersonalData.Controls.Add(this.comboRights);
            this.panelPersonalData.Controls.Add(this.labelName);
            this.panelPersonalData.Controls.Add(this.textName);
            this.panelPersonalData.Location = new System.Drawing.Point(4, 1);
            this.panelPersonalData.Name = "panelPersonalData";
            this.panelPersonalData.Size = new System.Drawing.Size(784, 233);
            this.panelPersonalData.TabIndex = 17;
            // 
            // dateRegistration
            // 
            this.dateRegistration.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateRegistration.Location = new System.Drawing.Point(321, 8);
            this.dateRegistration.Name = "dateRegistration";
            this.dateRegistration.Size = new System.Drawing.Size(91, 20);
            this.dateRegistration.TabIndex = 18;
            this.dateRegistration.TabStop = false;
            this.dateRegistration.ValueChanged += new System.EventHandler(this.DateRegistration_ValueChanged);
            // 
            // labelNew
            // 
            this.labelNew.AutoSize = true;
            this.labelNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNew.ForeColor = System.Drawing.Color.Red;
            this.labelNew.Location = new System.Drawing.Point(227, 11);
            this.labelNew.Name = "labelNew";
            this.labelNew.Size = new System.Drawing.Size(50, 13);
            this.labelNew.TabIndex = 32;
            this.labelNew.Text = "Новый!";
            // 
            // maskedCardId
            // 
            this.maskedCardId.Location = new System.Drawing.Point(149, 8);
            this.maskedCardId.Mask = "C0000-00";
            this.maskedCardId.Name = "maskedCardId";
            this.maskedCardId.Size = new System.Drawing.Size(56, 20);
            this.maskedCardId.TabIndex = 17;
            this.maskedCardId.TabStop = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(149, 190);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 29;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(68, 190);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 28;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // labelJob
            // 
            this.labelJob.AutoSize = true;
            this.labelJob.Location = new System.Drawing.Point(26, 142);
            this.labelJob.Name = "labelJob";
            this.labelJob.Size = new System.Drawing.Size(117, 13);
            this.labelJob.TabIndex = 31;
            this.labelJob.Text = "Место работы/учёбы:";
            // 
            // labelAddress
            // 
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(102, 116);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(41, 13);
            this.labelAddress.TabIndex = 30;
            this.labelAddress.Text = "Адрес:";
            // 
            // textAddress
            // 
            this.textAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textAddress.Location = new System.Drawing.Point(149, 113);
            this.textAddress.Name = "textAddress";
            this.textAddress.Size = new System.Drawing.Size(614, 20);
            this.textAddress.TabIndex = 25;
            this.textAddress.TextChanged += new System.EventHandler(this.TextAddress_TextChanged);
            // 
            // textJob
            // 
            this.textJob.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textJob.Location = new System.Drawing.Point(149, 139);
            this.textJob.Name = "textJob";
            this.textJob.Size = new System.Drawing.Size(614, 20);
            this.textJob.TabIndex = 27;
            this.textJob.TextChanged += new System.EventHandler(this.TextJob_TextChanged);
            // 
            // maskedBirthYear
            // 
            this.maskedBirthYear.Location = new System.Drawing.Point(149, 87);
            this.maskedBirthYear.Mask = "0000";
            this.maskedBirthYear.Name = "maskedBirthYear";
            this.maskedBirthYear.Size = new System.Drawing.Size(37, 20);
            this.maskedBirthYear.TabIndex = 23;
            this.maskedBirthYear.TextChanged += new System.EventHandler(this.maskedBirthYear_TextChanged);
            // 
            // labelBirthYear
            // 
            this.labelBirthYear.AutoSize = true;
            this.labelBirthYear.Location = new System.Drawing.Point(62, 90);
            this.labelBirthYear.Name = "labelBirthYear";
            this.labelBirthYear.Size = new System.Drawing.Size(81, 13);
            this.labelBirthYear.TabIndex = 26;
            this.labelBirthYear.Text = "Год рождения:";
            // 
            // labelCardId
            // 
            this.labelCardId.AutoSize = true;
            this.labelCardId.Location = new System.Drawing.Point(7, 11);
            this.labelCardId.Name = "labelCardId";
            this.labelCardId.Size = new System.Drawing.Size(136, 13);
            this.labelCardId.TabIndex = 24;
            this.labelCardId.Text = "№ читательского билета:";
            // 
            // labelRights
            // 
            this.labelRights.AutoSize = true;
            this.labelRights.Location = new System.Drawing.Point(101, 63);
            this.labelRights.Name = "labelRights";
            this.labelRights.Size = new System.Drawing.Size(42, 13);
            this.labelRights.TabIndex = 21;
            this.labelRights.Text = "Права:";
            // 
            // comboRights
            // 
            this.comboRights.FormattingEnabled = true;
            this.comboRights.Location = new System.Drawing.Point(149, 60);
            this.comboRights.Name = "comboRights";
            this.comboRights.Size = new System.Drawing.Size(183, 21);
            this.comboRights.TabIndex = 22;
            this.comboRights.SelectedIndexChanged += new System.EventHandler(this.ComboRights_SelectedIndexChanged);
            this.comboRights.Format += new System.Windows.Forms.ListControlConvertEventHandler(this.ComboRights_Format);
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(7, 37);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(136, 13);
            this.labelName.TabIndex = 19;
            this.labelName.Text = "Фамилия, имя, отчество:";
            // 
            // textName
            // 
            this.textName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textName.Location = new System.Drawing.Point(149, 34);
            this.textName.Name = "textName";
            this.textName.Size = new System.Drawing.Size(614, 20);
            this.textName.TabIndex = 20;
            this.textName.TextChanged += new System.EventHandler(this.TextName_TextChanged);
            // 
            // panelDeliveredBooks
            // 
            this.panelDeliveredBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDeliveredBooks.Controls.Add(this.labelBooks);
            this.panelDeliveredBooks.Controls.Add(this.gridBooks);
            this.panelDeliveredBooks.Location = new System.Drawing.Point(4, 240);
            this.panelDeliveredBooks.Name = "panelDeliveredBooks";
            this.panelDeliveredBooks.Size = new System.Drawing.Size(784, 243);
            this.panelDeliveredBooks.TabIndex = 18;
            this.panelDeliveredBooks.Visible = false;
            // 
            // labelBooks
            // 
            this.labelBooks.AutoSize = true;
            this.labelBooks.Location = new System.Drawing.Point(8, 13);
            this.labelBooks.Name = "labelBooks";
            this.labelBooks.Size = new System.Drawing.Size(95, 13);
            this.labelBooks.TabIndex = 1;
            this.labelBooks.Text = "Выданные книги:";
            // 
            // gridBooks
            // 
            this.gridBooks.AllowUserToAddRows = false;
            this.gridBooks.AllowUserToDeleteRows = false;
            this.gridBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridBooks.AutoGenerateColumns = false;
            this.gridBooks.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.gridBooks.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridBooks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridBooks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCode,
            this.colAuthors,
            this.colTitle,
            this.colDeliveryDate});
            this.gridBooks.DataSource = this.bsourceBooks;
            this.gridBooks.GridColor = System.Drawing.SystemColors.Control;
            this.gridBooks.Location = new System.Drawing.Point(8, 29);
            this.gridBooks.MultiSelect = false;
            this.gridBooks.Name = "gridBooks";
            this.gridBooks.ReadOnly = true;
            this.gridBooks.Size = new System.Drawing.Size(755, 211);
            this.gridBooks.TabIndex = 0;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "BookCode";
            this.colCode.HeaderText = "Шифр";
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            this.colCode.Width = 70;
            // 
            // colAuthors
            // 
            this.colAuthors.DataPropertyName = "Authors";
            this.colAuthors.HeaderText = "Авторы";
            this.colAuthors.Name = "colAuthors";
            this.colAuthors.ReadOnly = true;
            this.colAuthors.Width = 200;
            // 
            // colTitle
            // 
            this.colTitle.DataPropertyName = "Title";
            this.colTitle.HeaderText = "Название";
            this.colTitle.Name = "colTitle";
            this.colTitle.ReadOnly = true;
            this.colTitle.Width = 250;
            // 
            // colDeliveryDate
            // 
            this.colDeliveryDate.DataPropertyName = "DeliveryDate";
            this.colDeliveryDate.HeaderText = "Дата выдачи";
            this.colDeliveryDate.Name = "colDeliveryDate";
            this.colDeliveryDate.ReadOnly = true;
            this.colDeliveryDate.Width = 80;
            // 
            // FormCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 495);
            this.Controls.Add(this.panelDeliveredBooks);
            this.Controls.Add(this.panelPersonalData);
            this.Name = "FormCustomer";
            this.Text = "Читатель";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCustomer_FormClosing);
            this.panelPersonalData.ResumeLayout(false);
            this.panelPersonalData.PerformLayout();
            this.panelDeliveredBooks.ResumeLayout(false);
            this.panelDeliveredBooks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBooks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsourceBooks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelPersonalData;
        private System.Windows.Forms.DateTimePicker dateRegistration;
        private System.Windows.Forms.Label labelNew;
        private System.Windows.Forms.MaskedTextBox maskedCardId;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Label labelJob;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.TextBox textAddress;
        private System.Windows.Forms.TextBox textJob;
        private System.Windows.Forms.MaskedTextBox maskedBirthYear;
        private System.Windows.Forms.Label labelBirthYear;
        private System.Windows.Forms.Label labelCardId;
        private System.Windows.Forms.Label labelRights;
        private System.Windows.Forms.ComboBox comboRights;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textName;
        private System.Windows.Forms.Panel panelDeliveredBooks;
        private System.Windows.Forms.Label labelBooks;
        private System.Windows.Forms.DataGridView gridBooks;
        private System.Windows.Forms.BindingSource bsourceBooks;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuthors;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliveryDate;
    }
}