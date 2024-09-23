using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969
{
    public partial class Home : Form
    {
        private Panel mainContentPanel;
        public Home()
        {
            InitializeComponent();

            mainContentPanel = new Panel
            {
                Dock = DockStyle.Fill,
            };
            this.Controls.Add(mainContentPanel);

            Button calendarButton = new Button
            {
                Text = "Calendar",
                Location = new Point(20, 20)
            };
            calendarButton.Click += (sender, e) => LoadCalendarPage();

            this.Controls.Add(calendarButton);

        }

        private void LoadCalendarPage()
        {
            mainContentPanel.Controls.Clear();

            Calendar calendarForm = new Calendar
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill,
            };

            mainContentPanel.Controls.Add(calendarForm);
            calendarForm.Show();
        }

    }
}
