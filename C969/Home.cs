using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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

            calendarMenuButton.Click += (sender, e) => LoadCalendarPage();
            appointmentsMenuButton.Click += (sender, e) => LoadAppointmentsPage();
            customerRecordsMenuButton.Click += (sender, e) => LoadCustomerRecordsPage();
            reportsMenuButton.Click += (sender, e) => LoadReportsPage();
        }

        private void LoadCalendarPage()
        {
            mainPanel.Controls.Clear();

            CalendarForm calendarForm = new CalendarForm
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill

            };

            mainPanel.Controls.Add(calendarForm);
            calendarForm.Show();
        }

        private void LoadAppointmentsPage()
        {
            mainPanel.Controls.Clear();

            AppointmentsForm appointmentsForm = new AppointmentsForm
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            mainPanel.Controls.Add(appointmentsForm);
            appointmentsForm.Show();
        }
        private void LoadCustomerRecordsPage()
        {
            mainPanel.Controls.Clear();

            CustomerRecordsForm customerRecordsForm = new CustomerRecordsForm
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            mainPanel.Controls.Add(customerRecordsForm);
            customerRecordsForm.Show();
        }
        private void LoadReportsPage()
        {
            mainPanel.Controls.Clear();

            ReportsForm reportsForm = new ReportsForm
            {
                TopLevel = false,
                FormBorderStyle = FormBorderStyle.None,
                Dock = DockStyle.Fill
            };

            mainPanel.Controls.Add(reportsForm);
            reportsForm.Show();
        }
    }
}
