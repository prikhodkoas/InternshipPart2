namespace XMLNotes
{
    partial class NotesForm
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
            this.flowLayoutPanelNotes = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanelNotes
            // 
            this.flowLayoutPanelNotes.AutoScroll = true;
            this.flowLayoutPanelNotes.Location = new System.Drawing.Point(0, 3);
            this.flowLayoutPanelNotes.Name = "flowLayoutPanelNotes";
            this.flowLayoutPanelNotes.Size = new System.Drawing.Size(498, 446);
            this.flowLayoutPanelNotes.TabIndex = 0;
            // 
            // NotesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 451);
            this.Controls.Add(this.flowLayoutPanelNotes);
            this.Name = "NotesForm";
            this.Text = "NotesForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelNotes;
    }
}