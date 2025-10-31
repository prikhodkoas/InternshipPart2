using System.Windows.Forms;
using System.Drawing;
using System;

namespace ScheduleEventCalendar
{
    partial class EventViewer
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.LstBxEvents = new System.Windows.Forms.ListBox();
            this.UpdateEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripEventList = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStripCalendar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.monthCalendar = new MyCalendar();
            this.contextMenuStripEventList.SuspendLayout();
            this.contextMenuStripCalendar.SuspendLayout();
            this.SuspendLayout();
            // 
            // LstBxEvents
            // 
            this.LstBxEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstBxEvents.FormattingEnabled = true;
            this.LstBxEvents.Location = new System.Drawing.Point(164, 0);
            this.LstBxEvents.Name = "LstBxEvents";
            this.LstBxEvents.Size = new System.Drawing.Size(136, 162);
            this.LstBxEvents.TabIndex = 1;
            this.LstBxEvents.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LstBxEvents_MouseDown);
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
            this.DeleteEventToolStripMenuItem.Click += DeleteEventToolStripMenuItem_Click;
            // 
            // contextMenuStripEventList
            // 
            this.contextMenuStripEventList.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripEventList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UpdateEventToolStripMenuItem,
            this.DeleteEventToolStripMenuItem});
            this.contextMenuStripEventList.Name = "contextMenuStripEventList";
            this.contextMenuStripEventList.Size = new System.Drawing.Size(205, 48);
            // 
            // AddEventToolStripMenuItem
            // 
            this.AddEventToolStripMenuItem.Name = "AddEventToolStripMenuItem";
            this.AddEventToolStripMenuItem.Size = new System.Drawing.Size(176, 22);
            this.AddEventToolStripMenuItem.Text = "Добавить событие";
            this.AddEventToolStripMenuItem.Click += new System.EventHandler(this.AddEventToolStripMenuItem_Click);
            // 
            // contextMenuStripCalendar
            // 
            this.contextMenuStripCalendar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripCalendar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddEventToolStripMenuItem});
            this.contextMenuStripCalendar.Name = "contextMenuStripCalendar";
            this.contextMenuStripCalendar.Size = new System.Drawing.Size(177, 26);
            // 
            // monthCalendar
            // 
            this.monthCalendar.Dock = System.Windows.Forms.DockStyle.Left;
            this.monthCalendar.Location = new System.Drawing.Point(0, 0);
            this.monthCalendar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 0;
            this.monthCalendar.DateChanged += MonthCalendar_DateChanged;
            // 
            // EventViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LstBxEvents);
            this.Controls.Add(this.monthCalendar);
            this.MaximumSize = new System.Drawing.Size(0, 162);
            this.MinimumSize = new System.Drawing.Size(300, 162);
            this.Name = "EventViewer";
            this.Size = new System.Drawing.Size(300, 162);
            this.contextMenuStripEventList.ResumeLayout(false);
            this.contextMenuStripCalendar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ListBox LstBxEvents;
        private MyCalendar monthCalendar;
        private ToolStripMenuItem UpdateEventToolStripMenuItem;
        private ToolStripMenuItem DeleteEventToolStripMenuItem;
        private ContextMenuStrip contextMenuStripEventList;
        private ToolStripMenuItem AddEventToolStripMenuItem;
        private ContextMenuStrip contextMenuStripCalendar;
    }
}