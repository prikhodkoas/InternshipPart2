﻿namespace RejectTwoSameSymbols
{
    partial class RejectTwoSameSymbolsForm
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

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // RejectTwoSameSymbolsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 34);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(380, 90);
            this.Name = "RejectTwoSameSymbolsForm";
            this.Text = "RejectTwoSameSymbolsForm";

            Initialize_inputTextBox();
            this.Controls.Add(this.inputTextBox);

            this.ResumeLayout(false);

        }

        #endregion
    }
}

