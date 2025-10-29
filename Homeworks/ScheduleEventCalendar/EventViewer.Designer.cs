using System.Windows.Forms;
using System.Drawing;
using System;

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
            this.components = new System.ComponentModel.Container();
            this.LstBxEvents = new System.Windows.Forms.ListBox();
            this.monthCalendar = new System.Windows.Forms.MonthCalendar();
            this.calendarWrapper = new System.Windows.Forms.Panel();
            this.contextMenuStripCalendar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();

            this.contextMenuStripCalendar.SuspendLayout();
            this.calendarWrapper.SuspendLayout();
            this.SuspendLayout();

            // 
            // calendarWrapper
            // 
            this.calendarWrapper.Dock = System.Windows.Forms.DockStyle.Left;
            this.calendarWrapper.Padding = new Padding(0);
            this.calendarWrapper.Margin = new Padding(0);
            this.calendarWrapper.Name = "calendarWrapper";
            this.calendarWrapper.Size = new System.Drawing.Size(164, 162);
            this.calendarWrapper.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CalendarWrapper_MouseDown);

            // 
            // monthCalendar
            // 
            this.monthCalendar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.monthCalendar.Margin = new System.Windows.Forms.Padding(6);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 0;

            this.calendarWrapper.Controls.Add(this.monthCalendar);

            // 
            // LstBxEvents
            // 
            this.LstBxEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstBxEvents.FormattingEnabled = true;
            this.LstBxEvents.Name = "LstBxEvents";
            this.LstBxEvents.Size = new System.Drawing.Size(136, 162);
            this.LstBxEvents.TabIndex = 1;

            // 
            // contextMenuStripCalendar
            // 
            this.contextMenuStripCalendar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddEventToolStripMenuItem,
            this.UpdateEventToolStripMenuItem,
            this.DeleteEventToolStripMenuItem});
            this.contextMenuStripCalendar.Name = "contextMenuStripCalendar";
            this.contextMenuStripCalendar.Size = new System.Drawing.Size(205, 70);

            // 
            // AddEventToolStripMenuItem
            // 
            this.AddEventToolStripMenuItem.Name = "AddEventToolStripMenuItem";
            this.AddEventToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.AddEventToolStripMenuItem.Text = "Добавить событие";
            this.AddEventToolStripMenuItem.Click += new System.EventHandler(this.AddEventToolStripMenuItem_Click);

            // 
            // UpdateEventToolStripMenuItem
            // 
            this.UpdateEventToolStripMenuItem.Name = "UpdateEventToolStripMenuItem";
            this.UpdateEventToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.UpdateEventToolStripMenuItem.Text = "Редактировать событие";
            this.UpdateEventToolStripMenuItem.Click += new System.EventHandler(this.UpdateEventToolStripMenuItem_Click);

            // 
            // DeleteEventToolStripMenuItem
            // 
            this.DeleteEventToolStripMenuItem.Name = "DeleteEventToolStripMenuItem";
            this.DeleteEventToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.DeleteEventToolStripMenuItem.Text = "Удалить событие";
            this.DeleteEventToolStripMenuItem.Click += new System.EventHandler(this.DeleteEventToolStripMenuItem_Click);

            // 
            // EventViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LstBxEvents);
            this.Controls.Add(this.calendarWrapper);
            this.MaximumSize = new System.Drawing.Size(0, 162);
            this.MinimumSize = new System.Drawing.Size(300, 162);
            this.Name = "EventViewer";
            this.Size = new System.Drawing.Size(300, 162);

            this.contextMenuStripCalendar.ResumeLayout(false);
            this.calendarWrapper.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.ListBox LstBxEvents;
        private System.Windows.Forms.MonthCalendar monthCalendar;
        private Panel calendarWrapper;
        private ContextMenuStrip contextMenuStripCalendar;
        private ToolStripMenuItem AddEventToolStripMenuItem;
        private ToolStripMenuItem UpdateEventToolStripMenuItem;
        private ToolStripMenuItem DeleteEventToolStripMenuItem;
    }
}
