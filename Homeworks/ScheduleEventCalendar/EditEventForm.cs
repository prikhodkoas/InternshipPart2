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
    /// <summary>
    /// Форма редактирования заказа
    /// </summary>
    public partial class EditEventForm : Form
    {
        /// <summary>
        /// Редактируемое событие
        /// </summary>
        public ScheduleEvent ChangedEvent { get; private set; }

        public EditEventForm(ScheduleEvent changedEvent, Dictionary<string, Color> categories)
        {
            ChangedEvent = new ScheduleEvent()
            {
                Title = changedEvent.Title,
                EventDate = changedEvent.EventDate,
                Category = changedEvent.Category
            };

            InitializeComponent();
            LoadCategoriesToComboBox(categories);

            this.StartPosition = FormStartPosition.CenterParent;
 
            TitleTxtBx.Text = changedEvent.Title;
            EventDateDtTmPckr.Value = changedEvent.EventDate;
        }

        /// <summary>
        /// Загрузка категорий в ComboBox
        /// </summary>
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

        /// <summary>
        /// Отмена
        /// </summary>
        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Созранить изменения
        /// </summary>
        private void OkBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TitleTxtBx.Text))
            {
                MessageBox.Show("Введите название события.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ChangedEvent.Title = TitleTxtBx.Text;
            ChangedEvent.EventDate = EventDateDtTmPckr.Value;
            ChangedEvent.Category = CategoryCmbBx.SelectedItem as string;

            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
