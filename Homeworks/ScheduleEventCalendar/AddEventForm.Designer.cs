namespace ScheduleEventCalendar
{
    partial class AddEventForm
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
            this.TitleLbl = new System.Windows.Forms.Label();
            this.TitleTxtBx = new System.Windows.Forms.TextBox();
            this.StartTimeDtTmPckr = new System.Windows.Forms.DateTimePicker();
            this.StartTimeLbl = new System.Windows.Forms.Label();
            this.EndTimeLbl = new System.Windows.Forms.Label();
            this.EndTimeDtTmPckr = new System.Windows.Forms.DateTimePicker();
            this.CategoryCmbBx = new System.Windows.Forms.ComboBox();
            this.CategoryLbl = new System.Windows.Forms.Label();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OkBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Location = new System.Drawing.Point(12, 9);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(151, 20);
            this.TitleLbl.TabIndex = 0;
            this.TitleLbl.Text = "Название события";
            // 
            // TitleTxtBx
            // 
            this.TitleTxtBx.Location = new System.Drawing.Point(12, 32);
            this.TitleTxtBx.Name = "TitleTxtBx";
            this.TitleTxtBx.Size = new System.Drawing.Size(200, 26);
            this.TitleTxtBx.TabIndex = 1;
            // 
            // StartTimeDtTmPckr
            // 
            this.StartTimeDtTmPckr.Location = new System.Drawing.Point(12, 84);
            this.StartTimeDtTmPckr.Name = "StartTimeDtTmPckr";
            this.StartTimeDtTmPckr.Size = new System.Drawing.Size(200, 26);
            this.StartTimeDtTmPckr.TabIndex = 2;
            // 
            // StartTimeLbl
            // 
            this.StartTimeLbl.AutoSize = true;
            this.StartTimeLbl.Location = new System.Drawing.Point(12, 61);
            this.StartTimeLbl.Name = "StartTimeLbl";
            this.StartTimeLbl.Size = new System.Drawing.Size(135, 20);
            this.StartTimeLbl.TabIndex = 3;
            this.StartTimeLbl.Text = "Начало события";
            // 
            // EndTimeLbl
            // 
            this.EndTimeLbl.AutoSize = true;
            this.EndTimeLbl.Location = new System.Drawing.Point(12, 113);
            this.EndTimeLbl.Name = "EndTimeLbl";
            this.EndTimeLbl.Size = new System.Drawing.Size(123, 20);
            this.EndTimeLbl.TabIndex = 4;
            this.EndTimeLbl.Text = "Конец события";
            // 
            // EndTimeDtTmPckr
            // 
            this.EndTimeDtTmPckr.Location = new System.Drawing.Point(12, 136);
            this.EndTimeDtTmPckr.Name = "EndTimeDtTmPckr";
            this.EndTimeDtTmPckr.Size = new System.Drawing.Size(200, 26);
            this.EndTimeDtTmPckr.TabIndex = 5;
            // 
            // CategoryCmbBx
            // 
            this.CategoryCmbBx.FormattingEnabled = true;
            this.CategoryCmbBx.Location = new System.Drawing.Point(12, 188);
            this.CategoryCmbBx.Name = "CategoryCmbBx";
            this.CategoryCmbBx.Size = new System.Drawing.Size(200, 28);
            this.CategoryCmbBx.TabIndex = 6;
            // 
            // CategoryLbl
            // 
            this.CategoryLbl.AutoSize = true;
            this.CategoryLbl.Location = new System.Drawing.Point(12, 165);
            this.CategoryLbl.Name = "CategoryLbl";
            this.CategoryLbl.Size = new System.Drawing.Size(89, 20);
            this.CategoryLbl.TabIndex = 7;
            this.CategoryLbl.Text = "Категория";
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(11, 223);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(98, 30);
            this.CancelBtn.TabIndex = 8;
            this.CancelBtn.Text = "Отмена";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(115, 223);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(98, 30);
            this.OkBtn.TabIndex = 9;
            this.OkBtn.Text = "Ок";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // AddEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 264);
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
            this.Name = "AddEventForm";
            this.Text = "AddEventForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.TextBox TitleTxtBx;
        private System.Windows.Forms.DateTimePicker StartTimeDtTmPckr;
        private System.Windows.Forms.Label StartTimeLbl;
        private System.Windows.Forms.Label EndTimeLbl;
        private System.Windows.Forms.DateTimePicker EndTimeDtTmPckr;
        private System.Windows.Forms.ComboBox CategoryCmbBx;
        private System.Windows.Forms.Label CategoryLbl;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OkBtn;
    }
}