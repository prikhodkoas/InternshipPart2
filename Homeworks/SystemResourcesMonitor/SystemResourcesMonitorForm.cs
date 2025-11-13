using Microsoft.VisualBasic.Devices;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace SystemMonitorApp
{
    public partial class SystemResourcesMonitorForm : Form
    {
        private Timer _updateTimer;
        private double _lastXValue = 0;

        private NetworkInterface _networkInterface;
        private long _lastBytesSent = 0;
        private long _lastBytesReceived = 0;

        public SystemResourcesMonitorForm()
        {
            InitializeComponent();
            InitializeChart();
            InitializeControls();
            InitializePerformanceCounters();
        }

        private void InitializePerformanceCounters()
        {
            // Выбираем первый активный интерфейс (Wi-Fi или Ethernet)
            _networkInterface = NetworkInterface.GetAllNetworkInterfaces()
                .FirstOrDefault(n =>
                    n.NetworkInterfaceType != NetworkInterfaceType.Loopback &&
                    n.OperationalStatus == OperationalStatus.Up);

            if (_networkInterface != null)
            {
                var stats = _networkInterface.GetIPv4Statistics();
                _lastBytesSent = stats.BytesSent;
                _lastBytesReceived = stats.BytesReceived;
            }
        }

        private void InitializeChart()
        {
            NetworkChart.Series.Clear();

            var chartArea = NetworkChart.ChartAreas[0];
            chartArea.AxisX.Title = "Время";
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;

            // Формат времени с десятыми секунды
            chartArea.AxisX.LabelStyle.Format = "HH:mm:ss.ff"; // ff = сотые, можно использовать f = десятые
            chartArea.AxisX.MajorGrid.Interval = 0.1; // линии сетки каждые 0.1 сек

            chartArea.AxisY.Title = "Скорость (КБ/с)";
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.Minimum = 0;

            AddSeries("Получено", Color.DeepSkyBlue);
            AddSeries("Отправлено", Color.OrangeRed);
        }


        private void AddSeries(string name, Color color)
        {
            Series s = new Series(name)
            {
                ChartType = SeriesChartType.Line,
                BorderWidth = 2,
                Color = color
            };
            NetworkChart.Series.Add(s);
        }

        private void InitializeControls()
        {
            StartDiagnosticsButton.Click += StartDiagnosticsButton_Click;

            TimerUpdateNumericUpDown.ValueChanged += (s, e) =>
            {
                if (_updateTimer != null)
                    _updateTimer.Interval = (int)(TimerUpdateNumericUpDown.Value * 1000);
            };

            CPUProgressBar.Minimum = 0;
            CPUProgressBar.Maximum = 100;
            RAMProgressBar.Minimum = 0;
            RAMProgressBar.Maximum = 100;
        }

        private async void StartDiagnosticsButton_Click(object sender, EventArgs e)
        {
            if (_updateTimer == null)
            {
                _updateTimer = new Timer();
                _updateTimer.Interval = (int)(TimerUpdateNumericUpDown.Value * 1000);
                _updateTimer.Tick += UpdateTimer_Tick;
            }

            if (_updateTimer.Enabled)
            {
                _updateTimer.Stop();
                StartDiagnosticsButton.Text = "Запустить диагностику";
            }
            else
            {
                CPUPerformanceCounter.NextValue();
                await Task.Delay(500);

                _updateTimer.Start();
                StartDiagnosticsButton.Text = "Остановить диагностику";
            }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                // --- CPU ---
                float cpu = CPUPerformanceCounter.NextValue();
                CPUProgressBar.Value = (int)Math.Min(cpu, 100);
                CPUPercentCounterLabel.Text = $"{cpu:F1}%";

                // --- RAM ---
                ComputerInfo info = new ComputerInfo();
                float totalMemory = info.TotalPhysicalMemory / (1024 * 1024);
                float availableMemory = info.AvailablePhysicalMemory / (1024 * 1024);
                float usedMemoryPercent = (1 - (availableMemory / totalMemory)) * 100f;
                RAMProgressBar.Value = (int)Math.Min(usedMemoryPercent, 100);
                RAMPercentCounterLabel.Text = $"{usedMemoryPercent:F1}%";

                // --- Network ---
                var stats = _networkInterface.GetIPv4Statistics();
                double intervalSeconds = (double)TimerUpdateNumericUpDown.Value;

                double recvRate = (stats.BytesReceived - _lastBytesReceived) / 1024.0 / intervalSeconds;
                double sentRate = (stats.BytesSent - _lastBytesSent) / 1024.0 / intervalSeconds;

                // X-координата = предыдущая + текущий интервал
                double xValue = _lastXValue + intervalSeconds;

                NetworkChart.Series["Получено"].Points.AddXY(xValue, recvRate);
                NetworkChart.Series["Отправлено"].Points.AddXY(xValue, sentRate);

                // Ограничиваем количество точек (например, последние 30 секунд)
                foreach (var s in NetworkChart.Series)
                {
                    while (s.Points.Count > 0 && s.Points[0].XValue < xValue - 30)
                        s.Points.RemoveAt(0);
                }

                // Настройка оси X
                var area = NetworkChart.ChartAreas[0];
                area.AxisX.Minimum = Math.Max(0, xValue - 30);
                area.AxisX.Maximum = xValue;
                area.AxisX.Title = "Время (сек)";
                area.AxisX.LabelStyle.Format = "F1"; // десятые доли
                area.AxisX.LabelStyle.Interval = 5;
                area.AxisX.MajorGrid.Interval = 1;
                area.RecalculateAxesScale();

                // Сохраняем состояние для следующего тика
                _lastBytesReceived = stats.BytesReceived;
                _lastBytesSent = stats.BytesSent;
                _lastXValue = xValue;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ошибка обновления: " + ex.Message);
            }
        }

        private void TimerUpdateNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if(!(_updateTimer is null))
                _updateTimer.Interval = (int)(TimerUpdateNumericUpDown.Value * 1000);
        }
    }
}
