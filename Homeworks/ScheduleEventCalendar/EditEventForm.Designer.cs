namespace ScheduleEventCalendar
{
    partial class EditEventForm
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
            this.OkBtn = new System.Windows.Forms.Button();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.CategoryLbl = new System.Windows.Forms.Label();
            this.CategoryCmbBx = new System.Windows.Forms.ComboBox();
            this.DateTimeLbl = new System.Windows.Forms.Label();
            this.EventDateDtTmPckr = new System.Windows.Forms.DateTimePicker();
            this.TitleTxtBx = new System.Windows.Forms.TextBox();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(116, 172);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(98, 30);
            this.OkBtn.TabIndex = 17;
            this.OkBtn.Text = "ОК";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(14, 172);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(98, 30);
            this.CancelBtn.TabIndex = 16;
            this.CancelBtn.Text = "Отмена";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // CategoryLbl
            // 
            this.CategoryLbl.AutoSize = true;
            this.CategoryLbl.Location = new System.Drawing.Point(14, 115);
            this.CategoryLbl.Name = "CategoryLbl";
            this.CategoryLbl.Size = new System.Drawing.Size(89, 20);
            this.CategoryLbl.TabIndex = 15;
            this.CategoryLbl.Text = "Категория";
            // 
            // CategoryCmbBx
            // 
            this.CategoryCmbBx.FormattingEnabled = true;
            this.CategoryCmbBx.Location = new System.Drawing.Point(14, 138);
            this.CategoryCmbBx.Name = "CategoryCmbBx";
            this.CategoryCmbBx.Size = new System.Drawing.Size(200, 28);
            this.CategoryCmbBx.TabIndex = 14;
            // 
            // DateTimeLbl
            // 
            this.DateTimeLbl.AutoSize = true;
            this.DateTimeLbl.Location = new System.Drawing.Point(14, 62);
            this.DateTimeLbl.Name = "DateTimeLbl";
            this.DateTimeLbl.Size = new System.Drawing.Size(116, 20);
            this.DateTimeLbl.TabIndex = 13;
            this.DateTimeLbl.Text = "Дата события";
            // 
            // EventDateDtTmPckr
            // 
            this.EventDateDtTmPckr.Location = new System.Drawing.Point(14, 85);
            this.EventDateDtTmPckr.Name = "EventDateDtTmPckr";
            this.EventDateDtTmPckr.Size = new System.Drawing.Size(200, 26);
            this.EventDateDtTmPckr.TabIndex = 12;
            // 
            // TitleTxtBx
            // 
            this.TitleTxtBx.Location = new System.Drawing.Point(14, 33);
            this.TitleTxtBx.Name = "TitleTxtBx";
            this.TitleTxtBx.Size = new System.Drawing.Size(200, 26);
            this.TitleTxtBx.TabIndex = 11;
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Location = new System.Drawing.Point(14, 10);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(151, 20);
            this.TitleLbl.TabIndex = 10;
            this.TitleLbl.Text = "Название события";
            // 
            // EditEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 217);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.CategoryLbl);
            this.Controls.Add(this.CategoryCmbBx);
            this.Controls.Add(this.DateTimeLbl);
            this.Controls.Add(this.EventDateDtTmPckr);
            this.Controls.Add(this.TitleTxtBx);
            this.Controls.Add(this.TitleLbl);
            this.Name = "EditEventForm";
            this.Text = "EditEventForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Label CategoryLbl;
        private System.Windows.Forms.ComboBox CategoryCmbBx;
        private System.Windows.Forms.Label DateTimeLbl;
        private System.Windows.Forms.DateTimePicker EventDateDtTmPckr;
        private System.Windows.Forms.TextBox TitleTxtBx;
        private System.Windows.Forms.Label TitleLbl;
    }
}