using System.Windows.Forms;
using System.Drawing;

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
            this.SuspendLayout();

            // 
            // monthCalendar
            // 
            this.monthCalendar.Dock = System.Windows.Forms.DockStyle.Left;
            this.monthCalendar.Margin = new System.Windows.Forms.Padding(6);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 0;

            // 
            // LstBxEvents
            // 
            this.LstBxEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstBxEvents.FormattingEnabled = true;
            this.LstBxEvents.Name = "LstBxEvents";
            this.LstBxEvents.TabIndex = 1;

            // 
            // EventViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LstBxEvents);
            this.Controls.Add(this.monthCalendar);
            this.Name = "EventViewer";
            this.MinimumSize = new System.Drawing.Size(300, monthCalendar.Height + 2);
            this.MaximumSize = new System.Drawing.Size(int.MaxValue, monthCalendar.Height + 2);
            this.Size = new System.Drawing.Size(500, monthCalendar.Height + 2);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.ListBox LstBxEvents;
        private System.Windows.Forms.MonthCalendar monthCalendar;
    }
}
