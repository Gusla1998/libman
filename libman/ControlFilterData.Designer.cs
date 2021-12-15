namespace libman
{
    partial class ControlFilterData
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupFilter = new System.Windows.Forms.GroupBox();
            this.comboSearch = new System.Windows.Forms.ComboBox();
            this.checkExactly = new System.Windows.Forms.CheckBox();
            this.labelSentinel = new System.Windows.Forms.Label();
            this.textSentinel = new System.Windows.Forms.TextBox();
            this.groupFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupFilter
            // 
            this.groupFilter.Controls.Add(this.comboSearch);
            this.groupFilter.Controls.Add(this.checkExactly);
            this.groupFilter.Controls.Add(this.labelSentinel);
            this.groupFilter.Controls.Add(this.textSentinel);
            this.groupFilter.Location = new System.Drawing.Point(3, 3);
            this.groupFilter.Name = "groupFilter";
            this.groupFilter.Size = new System.Drawing.Size(847, 46);
            this.groupFilter.TabIndex = 15;
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
            this.comboSearch.Location = new System.Drawing.Point(6, 15);
            this.comboSearch.Name = "comboSearch";
            this.comboSearch.Size = new System.Drawing.Size(121, 21);
            this.comboSearch.TabIndex = 19;
            // 
            // checkExactly
            // 
            this.checkExactly.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkExactly.AutoSize = true;
            this.checkExactly.Location = new System.Drawing.Point(721, 16);
            this.checkExactly.Name = "checkExactly";
            this.checkExactly.Size = new System.Drawing.Size(123, 17);
            this.checkExactly.TabIndex = 18;
            this.checkExactly.Text = "точное совпадение";
            this.checkExactly.UseVisualStyleBackColor = true;
            // 
            // labelSentinel
            // 
            this.labelSentinel.AutoSize = true;
            this.labelSentinel.Location = new System.Drawing.Point(144, 17);
            this.labelSentinel.Name = "labelSentinel";
            this.labelSentinel.Size = new System.Drawing.Size(54, 13);
            this.labelSentinel.TabIndex = 17;
            this.labelSentinel.Text = "Образец:";
            // 
            // textSentinel
            // 
            this.textSentinel.Location = new System.Drawing.Point(204, 15);
            this.textSentinel.Name = "textSentinel";
            this.textSentinel.Size = new System.Drawing.Size(508, 20);
            this.textSentinel.TabIndex = 16;
            // 
            // ControlFilterData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupFilter);
            this.Name = "ControlFilterData";
            this.Size = new System.Drawing.Size(850, 54);
            this.groupFilter.ResumeLayout(false);
            this.groupFilter.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupFilter;
        private System.Windows.Forms.ComboBox comboSearch;
        private System.Windows.Forms.CheckBox checkExactly;
        private System.Windows.Forms.Label labelSentinel;
        private System.Windows.Forms.TextBox textSentinel;
    }
}
