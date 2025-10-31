using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScheduleEventCalendar
{
    public partial class AddEventForm : Form
    {
        public ScheduleEvent CreatedEvent { get; private set; } = new ScheduleEvent();

        public AddEventForm(DateTime selectedDate, Dictionary<string, Color> categories)
        {
            InitializeComponent();
            LoadCategoriesToComboBox(categories);
            this.StartPosition = FormStartPosition.CenterParent;

            EventDateDtTmPckr.Value = selectedDate;
        }
        private void LoadCategoriesToComboBox(Dictionary<string, Color> categories)
        {
            CategoryCmbBx.Items.Clear();

            if (categories != null && categories.Count > 0)
            {
                foreach (var cat in categories)
                {
                    // Добавляем название категории в ComboBox
                    CategoryCmbBx.Items.Add(cat.Key);
                }
            }

            // Можно выбрать первую категорию по умолчанию
            if (CategoryCmbBx.Items.Count > 0)
                CategoryCmbBx.SelectedIndex = 0;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TitleTxtBx.Text))
            {
                MessageBox.Show("Введите название события.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            CreatedEvent.Title = TitleTxtBx.Text;
            CreatedEvent.EventDate = EventDateDtTmPckr.Value;
            CreatedEvent.Category = CategoryCmbBx.SelectedItem as string;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
