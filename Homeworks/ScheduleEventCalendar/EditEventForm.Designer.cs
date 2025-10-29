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
            this.EndTimeDtTmPckr = new System.Windows.Forms.DateTimePicker();
            this.EndTimeLbl = new System.Windows.Forms.Label();
            this.StartTimeLbl = new System.Windows.Forms.Label();
            this.StartTimeDtTmPckr = new System.Windows.Forms.DateTimePicker();
            this.TitleTxtBx = new System.Windows.Forms.TextBox();
            this.TitleLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(77, 145);
            this.OkBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(65, 20);
            this.OkBtn.TabIndex = 19;
            this.OkBtn.Text = "Ок";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(7, 145);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(65, 20);
            this.CancelBtn.TabIndex = 18;
            this.CancelBtn.Text = "Отмена";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // CategoryLbl
            // 
            this.CategoryLbl.AutoSize = true;
            this.CategoryLbl.Location = new System.Drawing.Point(8, 107);
            this.CategoryLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CategoryLbl.Name = "CategoryLbl";
            this.CategoryLbl.Size = new System.Drawing.Size(60, 13);
            this.CategoryLbl.TabIndex = 17;
            this.CategoryLbl.Text = "Категория";
            // 
            // CategoryCmbBx
            // 
            this.CategoryCmbBx.FormattingEnabled = true;
            this.CategoryCmbBx.Location = new System.Drawing.Point(8, 122);
            this.CategoryCmbBx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CategoryCmbBx.Name = "CategoryCmbBx";
            this.CategoryCmbBx.Size = new System.Drawing.Size(135, 21);
            this.CategoryCmbBx.TabIndex = 16;
            // 
            // EndTimeDtTmPckr
            // 
            this.EndTimeDtTmPckr.Location = new System.Drawing.Point(8, 88);
            this.EndTimeDtTmPckr.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.EndTimeDtTmPckr.Name = "EndTimeDtTmPckr";
            this.EndTimeDtTmPckr.Size = new System.Drawing.Size(135, 20);
            this.EndTimeDtTmPckr.TabIndex = 15;
            // 
            // EndTimeLbl
            // 
            this.EndTimeLbl.AutoSize = true;
            this.EndTimeLbl.Location = new System.Drawing.Point(8, 73);
            this.EndTimeLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EndTimeLbl.Name = "EndTimeLbl";
            this.EndTimeLbl.Size = new System.Drawing.Size(84, 13);
            this.EndTimeLbl.TabIndex = 14;
            this.EndTimeLbl.Text = "Конец события";
            // 
            // StartTimeLbl
            // 
            this.StartTimeLbl.AutoSize = true;
            this.StartTimeLbl.Location = new System.Drawing.Point(8, 40);
            this.StartTimeLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.StartTimeLbl.Name = "StartTimeLbl";
            this.StartTimeLbl.Size = new System.Drawing.Size(90, 13);
            this.StartTimeLbl.TabIndex = 13;
            this.StartTimeLbl.Text = "Начало события";
            // 
            // StartTimeDtTmPckr
            // 
            this.StartTimeDtTmPckr.Location = new System.Drawing.Point(8, 55);
            this.StartTimeDtTmPckr.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.StartTimeDtTmPckr.Name = "StartTimeDtTmPckr";
            this.StartTimeDtTmPckr.Size = new System.Drawing.Size(135, 20);
            this.StartTimeDtTmPckr.TabIndex = 12;
            // 
            // TitleTxtBx
            // 
            this.TitleTxtBx.Location = new System.Drawing.Point(8, 21);
            this.TitleTxtBx.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TitleTxtBx.Name = "TitleTxtBx";
            this.TitleTxtBx.Size = new System.Drawing.Size(135, 20);
            this.TitleTxtBx.TabIndex = 11;
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Location = new System.Drawing.Point(8, 6);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(103, 13);
            this.TitleLbl.TabIndex = 10;
            this.TitleLbl.Text = "Название события";
            // 
            // EditEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(149, 171);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.CategoryLbl);
            this.Controls.Add(this.CategoryCmbBx);
            this.Controls.Add(this.EndTimeDtTmPckr);
            this.Controls.Add(this.EndTimeLbl);
            this.Controls.Add(this.StartTimeLbl);
            this.Controls.Add(this.StartTimeDtTmPckr);
            this.Controls.Add(this.TitleTxtBx);
            this.Controls.Add(this.TitleLbl);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
        private System.Windows.Forms.DateTimePicker EndTimeDtTmPckr;
        private System.Windows.Forms.Label EndTimeLbl;
        private System.Windows.Forms.Label StartTimeLbl;
        private System.Windows.Forms.DateTimePicker StartTimeDtTmPckr;
        private System.Windows.Forms.TextBox TitleTxtBx;
        private System.Windows.Forms.Label TitleLbl;
    }
}