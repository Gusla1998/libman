namespace libman
{
    partial class FormBook
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelNew = new System.Windows.Forms.Label();
            this.maskedYear = new System.Windows.Forms.MaskedTextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.textReady = new System.Windows.Forms.TextBox();
            this.labelReady = new System.Windows.Forms.Label();
            this.textTotal = new System.Windows.Forms.TextBox();
            this.labelTotal = new System.Windows.Forms.Label();
            this.labelYear = new System.Windows.Forms.Label();
            this.textPublisher = new System.Windows.Forms.TextBox();
            this.textTitle = new System.Windows.Forms.TextBox();
            this.labelPublisher = new System.Windows.Forms.Label();
            this.labelTitle = new System.Windows.Forms.Label();
            this.textAuthors = new System.Windows.Forms.TextBox();
            this.labelAuthors = new System.Windows.Forms.Label();
            this.maskedCode = new System.Windows.Forms.MaskedTextBox();
            this.labelCode = new System.Windows.Forms.Label();
            this.panelDeliveredBooks = new System.Windows.Forms.Panel();
            this.labelCustomers = new System.Windows.Forms.Label();
            this.gridCustomers = new System.Windows.Forms.DataGridView();
            this.colCardId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDeliveryDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsourceCustomers = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panelDeliveredBooks.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsourceCustomers)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.labelNew);
            this.panel1.Controls.Add(this.maskedYear);
            this.panel1.Controls.Add(this.buttonCancel);
            this.panel1.Controls.Add(this.buttonOK);
            this.panel1.Controls.Add(this.textReady);
            this.panel1.Controls.Add(this.labelReady);
            this.panel1.Controls.Add(this.textTotal);
            this.panel1.Controls.Add(this.labelTotal);
            this.panel1.Controls.Add(this.labelYear);
            this.panel1.Controls.Add(this.textPublisher);
            this.panel1.Controls.Add(this.textTitle);
            this.panel1.Controls.Add(this.labelPublisher);
            this.panel1.Controls.Add(this.labelTitle);
            this.panel1.Controls.Add(this.textAuthors);
            this.panel1.Controls.Add(this.labelAuthors);
            this.panel1.Controls.Add(this.maskedCode);
            this.panel1.Controls.Add(this.labelCode);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 241);
            this.panel1.TabIndex = 16;
            // 
            // labelNew
            // 
            this.labelNew.AutoSize = true;
            this.labelNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelNew.ForeColor = System.Drawing.Color.Red;
            this.labelNew.Location = new System.Drawing.Point(164, 10);
            this.labelNew.Name = "labelNew";
            this.labelNew.Size = new System.Drawing.Size(50, 13);
            this.labelNew.TabIndex = 1;
            this.labelNew.Text = "Новый!";
            // 
            // maskedYear
            // 
            this.maskedYear.Location = new System.Drawing.Point(90, 111);
            this.maskedYear.Mask = "0000";
            this.maskedYear.Name = "maskedYear";
            this.maskedYear.Size = new System.Drawing.Size(41, 20);
            this.maskedYear.TabIndex = 5;
            this.maskedYear.TextChanged += new System.EventHandler(this.MaskedYear_TextChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(90, 201);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 9;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(9, 201);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 8;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // textReady
            // 
            this.textReady.Location = new System.Drawing.Point(90, 163);
            this.textReady.Name = "textReady";
            this.textReady.ReadOnly = true;
            this.textReady.Size = new System.Drawing.Size(41, 20);
            this.textReady.TabIndex = 7;
            this.textReady.TabStop = false;
            this.textReady.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // labelReady
            // 
            this.labelReady.AutoSize = true;
            this.labelReady.Location = new System.Drawing.Point(23, 166);
            this.labelReady.Name = "labelReady";
            this.labelReady.Size = new System.Drawing.Size(61, 13);
            this.labelReady.TabIndex = 28;
            this.labelReady.Text = "В наличии:";
            // 
            // textTotal
            // 
            this.textTotal.Location = new System.Drawing.Point(90, 137);
            this.textTotal.Name = "textTotal";
            this.textTotal.Size = new System.Drawing.Size(41, 20);
            this.textTotal.TabIndex = 6;
            this.textTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textTotal.Validating += new System.ComponentModel.CancelEventHandler(this.TextTotal_Validating);
            this.textTotal.Validated += new System.EventHandler(this.TextTotal_Validated);
            // 
            // labelTotal
            // 
            this.labelTotal.AutoSize = true;
            this.labelTotal.Location = new System.Drawing.Point(44, 140);
            this.labelTotal.Name = "labelTotal";
            this.labelTotal.Size = new System.Drawing.Size(40, 13);
            this.labelTotal.TabIndex = 26;
            this.labelTotal.Text = "Всего:";
            // 
            // labelYear
            // 
            this.labelYear.AutoSize = true;
            this.labelYear.Location = new System.Drawing.Point(11, 114);
            this.labelYear.Name = "labelYear";
            this.labelYear.Size = new System.Drawing.Size(73, 13);
            this.labelYear.TabIndex = 24;
            this.labelYear.Text = "Год издания:";
            // 
            // textPublisher
            // 
            this.textPublisher.Location = new System.Drawing.Point(90, 85);
            this.textPublisher.Name = "textPublisher";
            this.textPublisher.Size = new System.Drawing.Size(100, 20);
            this.textPublisher.TabIndex = 4;
            this.textPublisher.TextChanged += new System.EventHandler(this.TextPublisher_TextChanged);
            // 
            // textTitle
            // 
            this.textTitle.Location = new System.Drawing.Point(90, 59);
            this.textTitle.Name = "textTitle";
            this.textTitle.Size = new System.Drawing.Size(661, 20);
            this.textTitle.TabIndex = 3;
            this.textTitle.TextChanged += new System.EventHandler(this.TextTitle_TextChanged);
            // 
            // labelPublisher
            // 
            this.labelPublisher.AutoSize = true;
            this.labelPublisher.Location = new System.Drawing.Point(25, 88);
            this.labelPublisher.Name = "labelPublisher";
            this.labelPublisher.Size = new System.Drawing.Size(59, 13);
            this.labelPublisher.TabIndex = 21;
            this.labelPublisher.Text = "Издатель:";
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(24, 62);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(60, 13);
            this.labelTitle.TabIndex = 20;
            this.labelTitle.Text = "Название:";
            // 
            // textAuthors
            // 
            this.textAuthors.Location = new System.Drawing.Point(90, 33);
            this.textAuthors.Name = "textAuthors";
            this.textAuthors.Size = new System.Drawing.Size(661, 20);
            this.textAuthors.TabIndex = 2;
            this.textAuthors.TextChanged += new System.EventHandler(this.TextAuthors_TextChanged);
            // 
            // labelAuthors
            // 
            this.labelAuthors.AutoSize = true;
            this.labelAuthors.Location = new System.Drawing.Point(36, 35);
            this.labelAuthors.Name = "labelAuthors";
            this.labelAuthors.Size = new System.Drawing.Size(48, 13);
            this.labelAuthors.TabIndex = 18;
            this.labelAuthors.Text = "Авторы:";
            // 
            // maskedCode
            // 
            this.maskedCode.Location = new System.Drawing.Point(90, 7);
            this.maskedCode.Mask = "000\\.000";
            this.maskedCode.Name = "maskedCode";
            this.maskedCode.Size = new System.Drawing.Size(54, 20);
            this.maskedCode.TabIndex = 0;
            // 
            // labelCode
            // 
            this.labelCode.AutoSize = true;
            this.labelCode.Location = new System.Drawing.Point(45, 10);
            this.labelCode.Name = "labelCode";
            this.labelCode.Size = new System.Drawing.Size(39, 13);
            this.labelCode.TabIndex = 16;
            this.labelCode.Text = "Шифр:";
            // 
            // panelDeliveredBooks
            // 
            this.panelDeliveredBooks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDeliveredBooks.Controls.Add(this.labelCustomers);
            this.panelDeliveredBooks.Controls.Add(this.gridCustomers);
            this.panelDeliveredBooks.Location = new System.Drawing.Point(12, 259);
            this.panelDeliveredBooks.Name = "panelDeliveredBooks";
            this.panelDeliveredBooks.Size = new System.Drawing.Size(776, 227);
            this.panelDeliveredBooks.TabIndex = 19;
            this.panelDeliveredBooks.Visible = false;
            // 
            // labelCustomers
            // 
            this.labelCustomers.AutoSize = true;
            this.labelCustomers.Location = new System.Drawing.Point(8, 13);
            this.labelCustomers.Name = "labelCustomers";
            this.labelCustomers.Size = new System.Drawing.Size(81, 13);
            this.labelCustomers.TabIndex = 1;
            this.labelCustomers.Text = "Книга выдана:";
            // 
            // gridCustomers
            // 
            this.gridCustomers.AllowUserToAddRows = false;
            this.gridCustomers.AllowUserToDeleteRows = false;
            this.gridCustomers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridCustomers.AutoGenerateColumns = false;
            this.gridCustomers.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCellsExceptHeaders;
            this.gridCustomers.BackgroundColor = System.Drawing.SystemColors.Control;
            this.gridCustomers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCustomers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colCardId,
            this.colName,
            this.colDeliveryDate});
            this.gridCustomers.DataSource = this.bsourceCustomers;
            this.gridCustomers.GridColor = System.Drawing.SystemColors.Control;
            this.gridCustomers.Location = new System.Drawing.Point(11, 29);
            this.gridCustomers.MultiSelect = false;
            this.gridCustomers.Name = "gridCustomers";
            this.gridCustomers.ReadOnly = true;
            this.gridCustomers.Size = new System.Drawing.Size(747, 195);
            this.gridCustomers.TabIndex = 0;
            // 
            // colCardId
            // 
            this.colCardId.DataPropertyName = "CustomerCardId";
            this.colCardId.HeaderText = "№ билета";
            this.colCardId.Name = "colCardId";
            this.colCardId.ReadOnly = true;
            // 
            // colName
            // 
            this.colName.DataPropertyName = "Name";
            this.colName.HeaderText = "Фамилия, имя, отчество";
            this.colName.Name = "colName";
            this.colName.ReadOnly = true;
            this.colName.Width = 400;
            // 
            // colDeliveryDate
            // 
            this.colDeliveryDate.DataPropertyName = "DeliveryDate";
            this.colDeliveryDate.HeaderText = "Дата выдачи";
            this.colDeliveryDate.Name = "colDeliveryDate";
            this.colDeliveryDate.ReadOnly = true;
            this.colDeliveryDate.Width = 80;
            // 
            // FormBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 498);
            this.Controls.Add(this.panelDeliveredBooks);
            this.Controls.Add(this.panel1);
            this.Name = "FormBook";
            this.Text = "Книга";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormBook_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelDeliveredBooks.ResumeLayout(false);
            this.panelDeliveredBooks.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsourceCustomers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MaskedTextBox maskedYear;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox textReady;
        private System.Windows.Forms.Label labelReady;
        private System.Windows.Forms.TextBox textTotal;
        private System.Windows.Forms.Label labelTotal;
        private System.Windows.Forms.Label labelYear;
        private System.Windows.Forms.TextBox textPublisher;
        private System.Windows.Forms.TextBox textTitle;
        private System.Windows.Forms.Label labelPublisher;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textAuthors;
        private System.Windows.Forms.Label labelAuthors;
        private System.Windows.Forms.MaskedTextBox maskedCode;
        private System.Windows.Forms.Label labelCode;
        private System.Windows.Forms.Label labelNew;
        private System.Windows.Forms.Panel panelDeliveredBooks;
        private System.Windows.Forms.Label labelCustomers;
        private System.Windows.Forms.DataGridView gridCustomers;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCardId;
        private System.Windows.Forms.DataGridViewTextBoxColumn colName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDeliveryDate;
        private System.Windows.Forms.BindingSource bsourceCustomers;
    }
}