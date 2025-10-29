using System.Windows.Forms;

namespace ScheduleEventCalendar
{
    partial class EventViewer
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
            this.LstBxEvents = new System.Windows.Forms.ListBox();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.PnlDelete = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // LstBxEvents
            // 
            this.LstBxEvents.FormattingEnabled = true;
            this.LstBxEvents.ItemHeight = 20;
            this.LstBxEvents.Location = new System.Drawing.Point(178, 0);
            this.LstBxEvents.Name = "LstBxEvents";
            this.LstBxEvents.Size = new System.Drawing.Size(263, 264);
            this.LstBxEvents.TabIndex = 1;
            // 
            // monthCalendar
            // 
            this.monthCalendar.Dock = System.Windows.Forms.DockStyle.Left;
            this.monthCalendar.Location = new System.Drawing.Point(0, 0);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 0;
            // 
            // PnlDelete
            // 
            this.PnlDelete.Dock = System.Windows.Forms.DockStyle.Right;
            this.PnlDelete.ForeColor = System.Drawing.Color.White;
            this.PnlDelete.Location = new System.Drawing.Point(487, 0);
            this.PnlDelete.Name = "PnlDelete";
            this.PnlDelete.Size = new System.Drawing.Size(145, 251);
            this.PnlDelete.TabIndex = 2;
            // 
            // EventViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.monthCalendar);
            this.Controls.Add(this.PnlDelete);
            this.Controls.Add(this.LstBxEvents);
            this.Name = "EventViewer";
            this.Size = new System.Drawing.Size(632, 251);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LstBxEvents;
        private System.Windows.Forms.Panel PnlDelete;
        private System.Windows.Forms.MonthCalendar monthCalendar;
    }
}
