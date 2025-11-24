namespace SystemMonitorApp
{
    partial class SystemResourcesMonitorForm
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.CPUPerformanceCounter = new System.Diagnostics.PerformanceCounter();
            this.RAMPerformanceCounter = new System.Diagnostics.PerformanceCounter();
            this.NetSentPerformanceCounter = new System.Diagnostics.PerformanceCounter();
            this.NetReceivedPerformanceCounter = new System.Diagnostics.PerformanceCounter();
            this.TimerUpdateNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.TimerLabel = new System.Windows.Forms.Label();
            this.NetworkChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.CPUProgressBar = new System.Windows.Forms.ProgressBar();
            this.CPULabel = new System.Windows.Forms.Label();
            this.CPUPercentCounterLabel = new System.Windows.Forms.Label();
            this.RAMPercentCounterLabel = new System.Windows.Forms.Label();
            this.RAMLabel = new System.Windows.Forms.Label();
            this.RAMProgressBar = new System.Windows.Forms.ProgressBar();
            this.NetworkLabel = new System.Windows.Forms.Label();
            this.StartDiagnosticsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CPUPerformanceCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RAMPerformanceCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetSentPerformanceCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetReceivedPerformanceCounter)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimerUpdateNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetworkChart)).BeginInit();
            this.SuspendLayout();
            // 
            // CPUPerformanceCounter
            // 
            this.CPUPerformanceCounter.CategoryName = "Processor";
            this.CPUPerformanceCounter.CounterName = "% Processor Time";
            this.CPUPerformanceCounter.InstanceName = "_Total";
            // 
            // RAMPerformanceCounter
            // 
            this.RAMPerformanceCounter.CategoryName = "Memory";
            this.RAMPerformanceCounter.CounterName = "Available MBytes";
            // 
            // NetSentPerformanceCounter
            // 
            this.NetSentPerformanceCounter.CategoryName = "Network Interface";
            this.NetSentPerformanceCounter.CounterName = "Bytes Sent/sec";
            this.NetSentPerformanceCounter.InstanceName = "Wi-Fi";
            // 
            // NetReceivedPerformanceCounter
            // 
            this.NetReceivedPerformanceCounter.CategoryName = "Network Interface";
            this.NetReceivedPerformanceCounter.CounterName = "Bytes Received/sec";
            this.NetReceivedPerformanceCounter.InstanceName = "Wi-Fi";
            // 
            // TimerUpdateNumericUpDown
            // 
            this.TimerUpdateNumericUpDown.DecimalPlaces = 1;
            this.TimerUpdateNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.TimerUpdateNumericUpDown.Location = new System.Drawing.Point(12, 25);
            this.TimerUpdateNumericUpDown.Maximum = new decimal(new int[] {
            600,
            0,
            0,
            65536});
            this.TimerUpdateNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.TimerUpdateNumericUpDown.Name = "TimerUpdateNumericUpDown";
            this.TimerUpdateNumericUpDown.Size = new System.Drawing.Size(100, 20);
            this.TimerUpdateNumericUpDown.TabIndex = 0;
            this.TimerUpdateNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.TimerUpdateNumericUpDown.ValueChanged += new System.EventHandler(this.TimerUpdateNumericUpDown_ValueChanged);
            // 
            // TimerLabel
            // 
            this.TimerLabel.AutoSize = true;
            this.TimerLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TimerLabel.Location = new System.Drawing.Point(9, 9);
            this.TimerLabel.Name = "TimerLabel";
            this.TimerLabel.Size = new System.Drawing.Size(192, 13);
            this.TimerLabel.TabIndex = 1;
            this.TimerLabel.Text = "Частота обновления данных (сек)";
            // 
            // NetworkChart
            // 
            this.NetworkChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea2.Name = "ChartArea1";
            this.NetworkChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            this.NetworkChart.Legends.Add(legend2);
            this.NetworkChart.Location = new System.Drawing.Point(12, 119);
            this.NetworkChart.Name = "NetworkChart";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            this.NetworkChart.Series.Add(series2);
            this.NetworkChart.Size = new System.Drawing.Size(420, 230);
            this.NetworkChart.TabIndex = 2;
            this.NetworkChart.Text = "chart1";
            // 
            // CPUProgressBar
            // 
            this.CPUProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CPUProgressBar.Location = new System.Drawing.Point(304, 25);
            this.CPUProgressBar.Name = "CPUProgressBar";
            this.CPUProgressBar.Size = new System.Drawing.Size(128, 23);
            this.CPUProgressBar.TabIndex = 3;
            // 
            // CPULabel
            // 
            this.CPULabel.AutoSize = true;
            this.CPULabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CPULabel.Location = new System.Drawing.Point(301, 9);
            this.CPULabel.Name = "CPULabel";
            this.CPULabel.Size = new System.Drawing.Size(91, 13);
            this.CPULabel.TabIndex = 4;
            this.CPULabel.Text = "Работа CPU (%)";
            // 
            // CPUPercentCounterLabel
            // 
            this.CPUPercentCounterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CPUPercentCounterLabel.AutoSize = true;
            this.CPUPercentCounterLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CPUPercentCounterLabel.Location = new System.Drawing.Point(406, 9);
            this.CPUPercentCounterLabel.Name = "CPUPercentCounterLabel";
            this.CPUPercentCounterLabel.Size = new System.Drawing.Size(23, 13);
            this.CPUPercentCounterLabel.TabIndex = 5;
            this.CPUPercentCounterLabel.Text = "0%";
            // 
            // RAMPercentCounterLabel
            // 
            this.RAMPercentCounterLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RAMPercentCounterLabel.AutoSize = true;
            this.RAMPercentCounterLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RAMPercentCounterLabel.Location = new System.Drawing.Point(406, 55);
            this.RAMPercentCounterLabel.Name = "RAMPercentCounterLabel";
            this.RAMPercentCounterLabel.Size = new System.Drawing.Size(23, 13);
            this.RAMPercentCounterLabel.TabIndex = 8;
            this.RAMPercentCounterLabel.Text = "0%";
            // 
            // RAMLabel
            // 
            this.RAMLabel.AutoSize = true;
            this.RAMLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RAMLabel.Location = new System.Drawing.Point(301, 55);
            this.RAMLabel.Name = "RAMLabel";
            this.RAMLabel.Size = new System.Drawing.Size(95, 13);
            this.RAMLabel.TabIndex = 7;
            this.RAMLabel.Text = "Работа RAM (%)";
            // 
            // RAMProgressBar
            // 
            this.RAMProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RAMProgressBar.Location = new System.Drawing.Point(304, 71);
            this.RAMProgressBar.Name = "RAMProgressBar";
            this.RAMProgressBar.Size = new System.Drawing.Size(128, 23);
            this.RAMProgressBar.TabIndex = 6;
            // 
            // NetworkLabel
            // 
            this.NetworkLabel.AutoSize = true;
            this.NetworkLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NetworkLabel.Location = new System.Drawing.Point(9, 103);
            this.NetworkLabel.Name = "NetworkLabel";
            this.NetworkLabel.Size = new System.Drawing.Size(73, 13);
            this.NetworkLabel.TabIndex = 9;
            this.NetworkLabel.Text = "Работа Сети";
            // 
            // StartDiagnosticsButton
            // 
            this.StartDiagnosticsButton.Location = new System.Drawing.Point(12, 71);
            this.StartDiagnosticsButton.Name = "StartDiagnosticsButton";
            this.StartDiagnosticsButton.Size = new System.Drawing.Size(154, 23);
            this.StartDiagnosticsButton.TabIndex = 10;
            this.StartDiagnosticsButton.Text = "Запустить дагностику";
            this.StartDiagnosticsButton.UseVisualStyleBackColor = true;
            // 
            // SystemResourcesMonitorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 361);
            this.Controls.Add(this.StartDiagnosticsButton);
            this.Controls.Add(this.NetworkLabel);
            this.Controls.Add(this.RAMPercentCounterLabel);
            this.Controls.Add(this.RAMLabel);
            this.Controls.Add(this.RAMProgressBar);
            this.Controls.Add(this.CPUPercentCounterLabel);
            this.Controls.Add(this.CPULabel);
            this.Controls.Add(this.CPUProgressBar);
            this.Controls.Add(this.NetworkChart);
            this.Controls.Add(this.TimerLabel);
            this.Controls.Add(this.TimerUpdateNumericUpDown);
            this.MinimumSize = new System.Drawing.Size(460, 400);
            this.Name = "SystemResourcesMonitorForm";
            this.Text = "Монитор системных ресурсов";
            ((System.ComponentModel.ISupportInitialize)(this.CPUPerformanceCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RAMPerformanceCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetSentPerformanceCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetReceivedPerformanceCounter)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimerUpdateNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NetworkChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Diagnostics.PerformanceCounter CPUPerformanceCounter;
        private System.Diagnostics.PerformanceCounter RAMPerformanceCounter;
        private System.Diagnostics.PerformanceCounter NetSentPerformanceCounter;
        private System.Diagnostics.PerformanceCounter NetReceivedPerformanceCounter;
        private System.Windows.Forms.NumericUpDown TimerUpdateNumericUpDown;
        private System.Windows.Forms.Label TimerLabel;
        private System.Windows.Forms.DataVisualization.Charting.Chart NetworkChart;
        private System.Windows.Forms.ProgressBar CPUProgressBar;
        private System.Windows.Forms.Label CPULabel;
        private System.Windows.Forms.Label CPUPercentCounterLabel;
        private System.Windows.Forms.Label RAMPercentCounterLabel;
        private System.Windows.Forms.Label RAMLabel;
        private System.Windows.Forms.ProgressBar RAMProgressBar;
        private System.Windows.Forms.Label NetworkLabel;
        private System.Windows.Forms.Button StartDiagnosticsButton;
    }
}

