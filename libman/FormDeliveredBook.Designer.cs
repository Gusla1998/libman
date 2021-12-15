namespace libman
{
    partial class FormDeliveredBook
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
            this.labelBookCode = new System.Windows.Forms.Label();
            this.labelCustomerCardId = new System.Windows.Forms.Label();
            this.labelDeliveryDate = new System.Windows.Forms.Label();
            this.labelReturnDate = new System.Windows.Forms.Label();
            this.maskedBookCode = new System.Windows.Forms.MaskedTextBox();
            this.maskedCustomerCardId = new System.Windows.Forms.MaskedTextBox();
            this.buttonSelectBook = new System.Windows.Forms.Button();
            this.buttonSelectCustomer = new System.Windows.Forms.Button();
            this.dateDelivery = new System.Windows.Forms.DateTimePicker();
            this.dateReturn = new System.Windows.Forms.DateTimePicker();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelBook = new System.Windows.Forms.Label();
            this.labelCustomer = new System.Windows.Forms.Label();
            this.checkReturn = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelBookCode
            // 
            this.labelBookCode.AutoSize = true;
            this.labelBookCode.Location = new System.Drawing.Point(74, 15);
            this.labelBookCode.Name = "labelBookCode";
            this.labelBookCode.Size = new System.Drawing.Size(71, 13);
            this.labelBookCode.TabIndex = 0;
            this.labelBookCode.Text = "Шифр книги:";
            // 
            // labelCustomerCardId
            // 
            this.labelCustomerCardId.AutoSize = true;
            this.labelCustomerCardId.Location = new System.Drawing.Point(10, 66);
            this.labelCustomerCardId.Name = "labelCustomerCardId";
            this.labelCustomerCardId.Size = new System.Drawing.Size(136, 13);
            this.labelCustomerCardId.TabIndex = 4;
            this.labelCustomerCardId.Text = "№ читательского билета:";
            // 
            // labelDeliveryDate
            // 
            this.labelDeliveryDate.AutoSize = true;
            this.labelDeliveryDate.Location = new System.Drawing.Point(69, 127);
            this.labelDeliveryDate.Name = "labelDeliveryDate";
            this.labelDeliveryDate.Size = new System.Drawing.Size(76, 13);
            this.labelDeliveryDate.TabIndex = 5;
            this.labelDeliveryDate.Text = "Дата выдачи:";
            // 
            // labelReturnDate
            // 
            this.labelReturnDate.AutoSize = true;
            this.labelReturnDate.Location = new System.Drawing.Point(59, 185);
            this.labelReturnDate.Name = "labelReturnDate";
            this.labelReturnDate.Size = new System.Drawing.Size(86, 13);
            this.labelReturnDate.TabIndex = 6;
            this.labelReturnDate.Text = "Дата возврата:";
            // 
            // maskedBookCode
            // 
            this.maskedBookCode.Location = new System.Drawing.Point(151, 12);
            this.maskedBookCode.Mask = "000\\.000";
            this.maskedBookCode.Name = "maskedBookCode";
            this.maskedBookCode.Size = new System.Drawing.Size(62, 20);
            this.maskedBookCode.TabIndex = 1;
            this.maskedBookCode.TextChanged += new System.EventHandler(this.MaskedBookCode_TextChanged);
            this.maskedBookCode.Validating += new System.ComponentModel.CancelEventHandler(this.MaskedBookCode_Validating);
            this.maskedBookCode.Validated += new System.EventHandler(this.MaskedBookCode_Validated);
            // 
            // maskedCustomerCardId
            // 
            this.maskedCustomerCardId.Location = new System.Drawing.Point(152, 63);
            this.maskedCustomerCardId.Mask = "C0000-00";
            this.maskedCustomerCardId.Name = "maskedCustomerCardId";
            this.maskedCustomerCardId.Size = new System.Drawing.Size(62, 20);
            this.maskedCustomerCardId.TabIndex = 5;
            this.maskedCustomerCardId.TextChanged += new System.EventHandler(this.MaskedCustomerCardId_TextChanged);
            this.maskedCustomerCardId.Validating += new System.ComponentModel.CancelEventHandler(this.MaskedCustomerCardId_Validating);
            // 
            // buttonSelectBook
            // 
            this.buttonSelectBook.Location = new System.Drawing.Point(212, 10);
            this.buttonSelectBook.Name = "buttonSelectBook";
            this.buttonSelectBook.Size = new System.Drawing.Size(28, 23);
            this.buttonSelectBook.TabIndex = 2;
            this.buttonSelectBook.Text = "...";
            this.buttonSelectBook.UseVisualStyleBackColor = true;
            this.buttonSelectBook.Click += new System.EventHandler(this.ButtonSelectBook_Click);
            // 
            // buttonSelectCustomer
            // 
            this.buttonSelectCustomer.Location = new System.Drawing.Point(212, 61);
            this.buttonSelectCustomer.Name = "buttonSelectCustomer";
            this.buttonSelectCustomer.Size = new System.Drawing.Size(28, 23);
            this.buttonSelectCustomer.TabIndex = 6;
            this.buttonSelectCustomer.Text = "...";
            this.buttonSelectCustomer.UseVisualStyleBackColor = true;
            this.buttonSelectCustomer.Click += new System.EventHandler(this.ButtonSelectCustomer_Click);
            // 
            // dateDelivery
            // 
            this.dateDelivery.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateDelivery.Location = new System.Drawing.Point(151, 124);
            this.dateDelivery.Name = "dateDelivery";
            this.dateDelivery.Size = new System.Drawing.Size(88, 20);
            this.dateDelivery.TabIndex = 12;
            // 
            // dateReturn
            // 
            this.dateReturn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateReturn.Location = new System.Drawing.Point(151, 182);
            this.dateReturn.Name = "dateReturn";
            this.dateReturn.Size = new System.Drawing.Size(88, 20);
            this.dateReturn.TabIndex = 13;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(70, 229);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 14;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(151, 229);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // labelBook
            // 
            this.labelBook.AutoSize = true;
            this.labelBook.Location = new System.Drawing.Point(149, 41);
            this.labelBook.Name = "labelBook";
            this.labelBook.Size = new System.Drawing.Size(0, 13);
            this.labelBook.TabIndex = 3;
            // 
            // labelCustomer
            // 
            this.labelCustomer.AutoSize = true;
            this.labelCustomer.Location = new System.Drawing.Point(149, 94);
            this.labelCustomer.Name = "labelCustomer";
            this.labelCustomer.Size = new System.Drawing.Size(0, 13);
            this.labelCustomer.TabIndex = 7;
            // 
            // checkReturn
            // 
            this.checkReturn.AutoSize = true;
            this.checkReturn.Location = new System.Drawing.Point(151, 158);
            this.checkReturn.Name = "checkReturn";
            this.checkReturn.Size = new System.Drawing.Size(67, 17);
            this.checkReturn.TabIndex = 16;
            this.checkReturn.Text = "возврат";
            this.checkReturn.UseVisualStyleBackColor = true;
            this.checkReturn.CheckedChanged += new System.EventHandler(this.CheckReturn_CheckedChanged);
            // 
            // FormDeliveredBook
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(777, 285);
            this.Controls.Add(this.checkReturn);
            this.Controls.Add(this.labelCustomer);
            this.Controls.Add(this.labelBook);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.dateReturn);
            this.Controls.Add(this.dateDelivery);
            this.Controls.Add(this.buttonSelectCustomer);
            this.Controls.Add(this.buttonSelectBook);
            this.Controls.Add(this.maskedCustomerCardId);
            this.Controls.Add(this.maskedBookCode);
            this.Controls.Add(this.labelReturnDate);
            this.Controls.Add(this.labelDeliveryDate);
            this.Controls.Add(this.labelCustomerCardId);
            this.Controls.Add(this.labelBookCode);
            this.Name = "FormDeliveredBook";
            this.Text = "Выданная книга";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDeliveredBook_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelBookCode;
        private System.Windows.Forms.Label labelCustomerCardId;
        private System.Windows.Forms.Label labelDeliveryDate;
        private System.Windows.Forms.Label labelReturnDate;
        private System.Windows.Forms.MaskedTextBox maskedBookCode;
        private System.Windows.Forms.MaskedTextBox maskedCustomerCardId;
        private System.Windows.Forms.Button buttonSelectBook;
        private System.Windows.Forms.Button buttonSelectCustomer;
        private System.Windows.Forms.DateTimePicker dateDelivery;
        private System.Windows.Forms.DateTimePicker dateReturn;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelBook;
        private System.Windows.Forms.Label labelCustomer;
        private System.Windows.Forms.CheckBox checkReturn;
    }
}