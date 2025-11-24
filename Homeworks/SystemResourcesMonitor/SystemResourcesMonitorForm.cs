using Microsoft.VisualBasic.Devices;
using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using SystemResourcesMonitor;

namespace SystemMonitorApp
{
    public partial class SystemResourcesMonitorForm : Form
    {
        private const byte MAX_PERCENT = 100;
        private const byte TIME_INTERVAL_TO_DELETE = 30; // в сек
        private const short MILLISECONDS_TO_SECONDS= 1000;

        private readonly ResourcesMonitoringService _resourcesMonitoringService;

        private Timer _updateTimer;
        private double _lastXValue = 0;

        public SystemResourcesMonitorForm(ResourcesMonitoringService resourcesMonitoringService)
        {
            _resourcesMonitoringService = resourcesMonitoringService;
            InitializeComponent();
            InitializeChart();
            _resourcesMonitoringService.InitializeNetworkInterface();
            StartDiagnosticsButton.Click += StartDiagnosticsButton_Click;
        }

        /// <summary>
        /// Настраивает график сети
        /// </summary>
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

        /// <summary>
        /// Настройка графиков
        /// </summary>
        /// <param name="name">Имя графика</param>
        /// <param name="color">Цвет графика</param>
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

        /// <summary>
        /// Добавление новых значений на график
        /// </summary>
        /// <param name="x">Координата X</param>
        /// <param name="recvRate">Координата Y для графика получения</param>
        /// <param name="sentRate">Координата Y для графика отправки</param>
        private void AddNetworkPoints(double x, double recvRate, double sentRate)
        {
            NetworkChart.Series["Получено"].Points.AddXY(x, recvRate);
            NetworkChart.Series["Отправлено"].Points.AddXY(x, sentRate);
        }

        /// <summary>
        /// Удалить записи старше определенного промежутка времени 
        /// </summary>
        /// <param name="x">Текущая координата X</param>
        /// <param name="timeIntervalToDelete">Промежуток времени, который отображается на графике</param>
        private void TrimOldNetworkPoints(double x, double timeIntervalToDelete)
        {
            foreach (var s in NetworkChart.Series)
            {
                while (s.Points.Count > 0 && s.Points[0].XValue < x - timeIntervalToDelete)
                    s.Points.RemoveAt(0);
            }
        }

        /// <summary>
        /// Обновление оси X
        /// </summary>
        /// <param name="x">Текущая координата X</param>
        private void UpdateNetworkAxes(double x)
        {
            var area = NetworkChart.ChartAreas[0];
            area.AxisX.Minimum = Math.Max(0, x - 30);
            area.AxisX.Maximum = x;
            area.AxisX.Title = "Время (сек)";
            area.AxisX.LabelStyle.Format = "F1";
            area.AxisX.LabelStyle.Interval = 5;
            area.AxisX.MajorGrid.Interval = 1;
            area.RecalculateAxesScale();
        }

        /// <summary>
        /// Обновление графика сети
        /// </summary>
        /// <param name="recvRate">Скорость скачивания</param>
        /// <param name="sentRate">Скорость отправки</param>
        /// <param name="interval">Временной промежуток обновления графика</param>
        /// <param name="timeIntervalToDelete">Промежуток времени, который отображается на графике</param>
        private void UpdateNetworkChart(double recvRate, double sentRate, double interval, double timeIntervalToDelete)
        {
            _lastXValue += interval;

            AddNetworkPoints(_lastXValue, recvRate, sentRate);
            TrimOldNetworkPoints(_lastXValue, timeIntervalToDelete);
            UpdateNetworkAxes(_lastXValue);
        }

        private void StartDiagnosticsButton_Click(object sender, EventArgs e)
        {
            if (_updateTimer == null)
            {
                _updateTimer = new Timer();
                _updateTimer.Interval = (int)(TimerUpdateNumericUpDown.Value * MILLISECONDS_TO_SECONDS);
                _updateTimer.Tick += UpdateTimer_Tick;
            }

            if (_updateTimer.Enabled)
            {
                _updateTimer.Stop();
                StartDiagnosticsButton.Text = "Запустить диагностику";
            }
            else
            {
                _updateTimer.Start();
                StartDiagnosticsButton.Text = "Остановить диагностику";
            }
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                double intervalSeconds = (double)TimerUpdateNumericUpDown.Value;

                // CPU
                float cpu = CPUPerformanceCounter.NextValue();

                CPUProgressBar.Value = (int)Math.Min(cpu, MAX_PERCENT);
                CPUPercentCounterLabel.Text = $"{cpu:F1}%";

                // RAM
                var usedRAM = _resourcesMonitoringService.UpdateRAMInfo();
                var usedRAMPercent = usedRAM * MAX_PERCENT;
                RAMProgressBar.Value = (int)Math.Min(usedRAMPercent, MAX_PERCENT);
                RAMPercentCounterLabel.Text = $"{usedRAMPercent:F1}%";

                // NETWORK
                _resourcesMonitoringService.UpdateStatistics();
                var (recvRate, sentRate) = _resourcesMonitoringService.GetNetworkSpeed(intervalSeconds);

                UpdateNetworkChart(recvRate, sentRate, intervalSeconds, TIME_INTERVAL_TO_DELETE);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Ошибка обновления: " + ex.Message);
            }
        }

        private void TimerUpdateNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (!(_updateTimer is null))
                _updateTimer.Interval = (int)(TimerUpdateNumericUpDown.Value * MILLISECONDS_TO_SECONDS);
        } 
    }
}
