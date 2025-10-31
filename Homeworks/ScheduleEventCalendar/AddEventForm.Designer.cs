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
            this.CategoryCmbBx = new System.Windows.Forms.ComboBox();
            this.CategoryLbl = new System.Windows.Forms.Label();
            this.CancelBtn = new System.Windows.Forms.Button();
            this.OkBtn = new System.Windows.Forms.Button();
            this.EventDateDtTmPckr = new System.Windows.Forms.DateTimePicker();
            this.DateTimeLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // TitleLbl
            // 
            this.TitleLbl.AutoSize = true;
            this.TitleLbl.Location = new System.Drawing.Point(8, 6);
            this.TitleLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.TitleLbl.Name = "TitleLbl";
            this.TitleLbl.Size = new System.Drawing.Size(103, 13);
            this.TitleLbl.TabIndex = 0;
            this.TitleLbl.Text = "Название события";
            // 
            // TitleTxtBx
            // 
            this.TitleTxtBx.Location = new System.Drawing.Point(8, 21);
            this.TitleTxtBx.Margin = new System.Windows.Forms.Padding(2);
            this.TitleTxtBx.Name = "TitleTxtBx";
            this.TitleTxtBx.Size = new System.Drawing.Size(135, 20);
            this.TitleTxtBx.TabIndex = 1;
            // 
            // CategoryCmbBx
            // 
            this.CategoryCmbBx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CategoryCmbBx.FormattingEnabled = true;
            this.CategoryCmbBx.Location = new System.Drawing.Point(8, 96);
            this.CategoryCmbBx.Margin = new System.Windows.Forms.Padding(2);
            this.CategoryCmbBx.Name = "CategoryCmbBx";
            this.CategoryCmbBx.Size = new System.Drawing.Size(135, 21);
            this.CategoryCmbBx.TabIndex = 6;
            // 
            // CategoryLbl
            // 
            this.CategoryLbl.AutoSize = true;
            this.CategoryLbl.Location = new System.Drawing.Point(8, 81);
            this.CategoryLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CategoryLbl.Name = "CategoryLbl";
            this.CategoryLbl.Size = new System.Drawing.Size(60, 13);
            this.CategoryLbl.TabIndex = 7;
            this.CategoryLbl.Text = "Категория";
            // 
            // CancelBtn
            // 
            this.CancelBtn.Location = new System.Drawing.Point(8, 121);
            this.CancelBtn.Margin = new System.Windows.Forms.Padding(2);
            this.CancelBtn.Name = "CancelBtn";
            this.CancelBtn.Size = new System.Drawing.Size(65, 20);
            this.CancelBtn.TabIndex = 8;
            this.CancelBtn.Text = "Отмена";
            this.CancelBtn.UseVisualStyleBackColor = true;
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OkBtn
            // 
            this.OkBtn.Location = new System.Drawing.Point(76, 121);
            this.OkBtn.Margin = new System.Windows.Forms.Padding(2);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(65, 20);
            this.OkBtn.TabIndex = 9;
            this.OkBtn.Text = "ОК";
            this.OkBtn.UseVisualStyleBackColor = true;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // EventDateDtTmPckr
            // 
            this.EventDateDtTmPckr.Enabled = false;
            this.EventDateDtTmPckr.Location = new System.Drawing.Point(8, 59);
            this.EventDateDtTmPckr.Margin = new System.Windows.Forms.Padding(2);
            this.EventDateDtTmPckr.Name = "EventDateDtTmPckr";
            this.EventDateDtTmPckr.Size = new System.Drawing.Size(135, 20);
            this.EventDateDtTmPckr.TabIndex = 2;
            // 
            // DateTimeLbl
            // 
            this.DateTimeLbl.AutoSize = true;
            this.DateTimeLbl.Location = new System.Drawing.Point(8, 44);
            this.DateTimeLbl.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.DateTimeLbl.Name = "DateTimeLbl";
            this.DateTimeLbl.Size = new System.Drawing.Size(79, 13);
            this.DateTimeLbl.TabIndex = 3;
            this.DateTimeLbl.Text = "Дата события";
            // 
            // AddEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(151, 147);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.CancelBtn);
            this.Controls.Add(this.CategoryLbl);
            this.Controls.Add(this.CategoryCmbBx);
            this.Controls.Add(this.DateTimeLbl);
            this.Controls.Add(this.EventDateDtTmPckr);
            this.Controls.Add(this.TitleTxtBx);
            this.Controls.Add(this.TitleLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "AddEventForm";
            this.Text = "AddEventForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TitleLbl;
        private System.Windows.Forms.TextBox TitleTxtBx;
        private System.Windows.Forms.ComboBox CategoryCmbBx;
        private System.Windows.Forms.Label CategoryLbl;
        private System.Windows.Forms.Button CancelBtn;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.DateTimePicker EventDateDtTmPckr;
        private System.Windows.Forms.Label DateTimeLbl;
    }
}