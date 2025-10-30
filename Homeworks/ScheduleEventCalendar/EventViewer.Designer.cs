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
            this.contextMenuStripCalendar = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UpdateEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteEventToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthCalendar = new MyCalendar();
            this.contextMenuStripCalendar.SuspendLayout();
            this.SuspendLayout();
            // 
            // LstBxEvents
            // 
            this.LstBxEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LstBxEvents.FormattingEnabled = true;
            this.LstBxEvents.ItemHeight = 20;
            this.LstBxEvents.Location = new System.Drawing.Point(228, 0);
            this.LstBxEvents.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LstBxEvents.Name = "LstBxEvents";
            this.LstBxEvents.Size = new System.Drawing.Size(222, 249);
            this.LstBxEvents.TabIndex = 1;
            // 
            // contextMenuStripCalendar
            // 
            this.contextMenuStripCalendar.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStripCalendar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddEventToolStripMenuItem,
            this.UpdateEventToolStripMenuItem,
            this.DeleteEventToolStripMenuItem});
            this.contextMenuStripCalendar.Name = "contextMenuStripCalendar";
            this.contextMenuStripCalendar.Size = new System.Drawing.Size(279, 100);
            // 
            // AddEventToolStripMenuItem
            // 
            this.AddEventToolStripMenuItem.Name = "AddEventToolStripMenuItem";
            this.AddEventToolStripMenuItem.Size = new System.Drawing.Size(278, 32);
            this.AddEventToolStripMenuItem.Text = "Добавить событие";
            this.AddEventToolStripMenuItem.Click += new System.EventHandler(this.AddEventToolStripMenuItem_Click);
            // 
            // UpdateEventToolStripMenuItem
            // 
            this.UpdateEventToolStripMenuItem.Name = "UpdateEventToolStripMenuItem";
            this.UpdateEventToolStripMenuItem.Size = new System.Drawing.Size(278, 32);
            this.UpdateEventToolStripMenuItem.Text = "Редактировать событие";
            this.UpdateEventToolStripMenuItem.Click += new System.EventHandler(this.UpdateEventToolStripMenuItem_Click);
            // 
            // DeleteEventToolStripMenuItem
            // 
            this.DeleteEventToolStripMenuItem.Name = "DeleteEventToolStripMenuItem";
            this.DeleteEventToolStripMenuItem.Size = new System.Drawing.Size(278, 32);
            this.DeleteEventToolStripMenuItem.Text = "Удалить событие";
            this.DeleteEventToolStripMenuItem.Click += new System.EventHandler(this.DeleteEventToolStripMenuItem_Click);
            // 
            // monthCalendar
            // 
            this.monthCalendar.Dock = System.Windows.Forms.DockStyle.Left;
            this.monthCalendar.Location = new System.Drawing.Point(0, 0);
            this.monthCalendar.Name = "monthCalendar";
            this.monthCalendar.TabIndex = 0;
            // 
            // EventViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LstBxEvents);
            this.Controls.Add(this.monthCalendar);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximumSize = new System.Drawing.Size(0, 249);
            this.MinimumSize = new System.Drawing.Size(450, 249);
            this.Name = "EventViewer";
            this.Size = new System.Drawing.Size(450, 249);
            this.contextMenuStripCalendar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LstBxEvents;
        private ContextMenuStrip contextMenuStripCalendar;
        private ToolStripMenuItem AddEventToolStripMenuItem;
        private ToolStripMenuItem UpdateEventToolStripMenuItem;
        private ToolStripMenuItem DeleteEventToolStripMenuItem;
        private MyCalendar monthCalendar;
    }
}
