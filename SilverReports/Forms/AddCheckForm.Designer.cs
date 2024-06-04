namespace SilverReports.Forms
{
    partial class AddCheckForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNumber = new System.Windows.Forms.TextBox();
            this.comboBoxDepart = new System.Windows.Forms.ComboBox();
            this.maskedTextBoxNorm = new System.Windows.Forms.MaskedTextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.maskedTextBoxCover = new System.Windows.Forms.MaskedTextBox();
            this.comboBoxDecimal = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxOrder = new System.Windows.Forms.TextBox();
            this.numericUpDownAmount = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.dtCheck = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label1.Location = new System.Drawing.Point(45, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Номер цеха";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label2.Location = new System.Drawing.Point(45, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 18);
            this.label2.TabIndex = 3;
            this.label2.Text = "Номер чека";
            // 
            // textBoxNumber
            // 
            this.textBoxNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.textBoxNumber.Location = new System.Drawing.Point(206, 58);
            this.textBoxNumber.Name = "textBoxNumber";
            this.textBoxNumber.Size = new System.Drawing.Size(121, 24);
            this.textBoxNumber.TabIndex = 2;
            this.textBoxNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxNumber_KeyDown);
            // 
            // comboBoxDepart
            // 
            this.comboBoxDepart.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.comboBoxDepart.FormattingEnabled = true;
            this.comboBoxDepart.Location = new System.Drawing.Point(206, 26);
            this.comboBoxDepart.Name = "comboBoxDepart";
            this.comboBoxDepart.Size = new System.Drawing.Size(121, 26);
            this.comboBoxDepart.TabIndex = 4;
            // 
            // maskedTextBoxNorm
            // 
            this.maskedTextBoxNorm.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.maskedTextBoxNorm.Location = new System.Drawing.Point(206, 88);
            this.maskedTextBoxNorm.Mask = "0.000000";
            this.maskedTextBoxNorm.Name = "maskedTextBoxNorm";
            this.maskedTextBoxNorm.Size = new System.Drawing.Size(121, 24);
            this.maskedTextBoxNorm.TabIndex = 5;
            this.maskedTextBoxNorm.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maskedTextBoxNorm_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label3.Location = new System.Drawing.Point(45, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Норма";
            // 
            // comboBoxType
            // 
            this.comboBoxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.comboBoxType.FormattingEnabled = true;
            this.comboBoxType.Location = new System.Drawing.Point(206, 118);
            this.comboBoxType.Name = "comboBoxType";
            this.comboBoxType.Size = new System.Drawing.Size(194, 26);
            this.comboBoxType.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label4.Location = new System.Drawing.Point(45, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 18);
            this.label4.TabIndex = 7;
            this.label4.Text = "Тип серебра";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label5.Location = new System.Drawing.Point(45, 156);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(144, 18);
            this.label5.TabIndex = 10;
            this.label5.Text = "Площадь покрытия";
            // 
            // maskedTextBoxCover
            // 
            this.maskedTextBoxCover.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.maskedTextBoxCover.Location = new System.Drawing.Point(206, 153);
            this.maskedTextBoxCover.Mask = "0.000000";
            this.maskedTextBoxCover.Name = "maskedTextBoxCover";
            this.maskedTextBoxCover.Size = new System.Drawing.Size(121, 24);
            this.maskedTextBoxCover.TabIndex = 9;
            this.maskedTextBoxCover.KeyDown += new System.Windows.Forms.KeyEventHandler(this.maskedTextBoxCover_KeyDown);
            // 
            // comboBoxDecimal
            // 
            this.comboBoxDecimal.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxDecimal.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxDecimal.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.comboBoxDecimal.FormattingEnabled = true;
            this.comboBoxDecimal.Location = new System.Drawing.Point(206, 213);
            this.comboBoxDecimal.Name = "comboBoxDecimal";
            this.comboBoxDecimal.Size = new System.Drawing.Size(194, 26);
            this.comboBoxDecimal.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label6.Location = new System.Drawing.Point(45, 216);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(155, 18);
            this.label6.TabIndex = 11;
            this.label6.Text = "Децимальный номер";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label7.Location = new System.Drawing.Point(45, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 18);
            this.label7.TabIndex = 14;
            this.label7.Text = "Номер заказа";
            // 
            // textBoxOrder
            // 
            this.textBoxOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.textBoxOrder.Location = new System.Drawing.Point(206, 245);
            this.textBoxOrder.Name = "textBoxOrder";
            this.textBoxOrder.Size = new System.Drawing.Size(121, 24);
            this.textBoxOrder.TabIndex = 13;
            // 
            // numericUpDownAmount
            // 
            this.numericUpDownAmount.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.numericUpDownAmount.Location = new System.Drawing.Point(207, 183);
            this.numericUpDownAmount.Name = "numericUpDownAmount";
            this.numericUpDownAmount.Size = new System.Drawing.Size(120, 24);
            this.numericUpDownAmount.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label8.Location = new System.Drawing.Point(45, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 18);
            this.label8.TabIndex = 16;
            this.label8.Text = "Количество";
            // 
            // dtCheck
            // 
            this.dtCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.dtCheck.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtCheck.Location = new System.Drawing.Point(206, 276);
            this.dtCheck.Name = "dtCheck";
            this.dtCheck.Size = new System.Drawing.Size(121, 24);
            this.dtCheck.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.label9.Location = new System.Drawing.Point(45, 281);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(107, 18);
            this.label9.TabIndex = 18;
            this.label9.Text = "Номер заказа";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonAdd.Location = new System.Drawing.Point(48, 337);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(352, 35);
            this.buttonAdd.TabIndex = 19;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.buttonClose.Location = new System.Drawing.Point(48, 378);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(352, 35);
            this.buttonClose.TabIndex = 20;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // AddCheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(442, 425);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtCheck);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.numericUpDownAmount);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxOrder);
            this.Controls.Add(this.comboBoxDecimal);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maskedTextBoxCover);
            this.Controls.Add(this.comboBoxType);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.maskedTextBoxNorm);
            this.Controls.Add(this.comboBoxDepart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxNumber);
            this.Controls.Add(this.label1);
            this.Name = "AddCheckForm";
            this.Text = "Формирование чека";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownAmount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNumber;
        private System.Windows.Forms.ComboBox comboBoxDepart;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxNorm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCover;
        private System.Windows.Forms.ComboBox comboBoxDecimal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxOrder;
        private System.Windows.Forms.NumericUpDown numericUpDownAmount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtCheck;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonClose;
    }
}