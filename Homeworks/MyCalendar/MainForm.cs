using ScheduleEventCalendar;
using System.Drawing;
using System.Windows.Forms;

namespace MyCalendar
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Пользовательский контрол
        /// </summary>
        private EventViewer eventViewer;

        /// <summary>
        /// Поставщик данных
        /// </summary>
        private readonly IDataProvider dataProvider = DataProviderFactory.CreateProvider();

        public MainForm()
        {
            InitializeComponent();
            InitializeEventViewer();
        }

        /// <summary>
        /// Инициализация пользователького контрола
        /// </summary>
        private void InitializeEventViewer()
        {
            var data = dataProvider.GetData();
            eventViewer = new EventViewer(data.Item1, data.Item2)
            {
                Dock = DockStyle.Fill
            };
            Controls.Add(eventViewer);

            eventViewer.OnEventChanged += EventViewer_OnEventChanged;
        }

        /// <summary>
        /// Сохранение данных после изменений события
        /// </summary>
        private void EventViewer_OnEventChanged(object sender, System.EventArgs e)
        {
            dataProvider.SetData(eventViewer.Events);
        }
    }
}
