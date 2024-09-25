using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace C969
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();

            calendarMenuButton.Click += (sender, e) => LoadCalendarPage();
            appointmentsMenuButton.Click += (sender, e) => LoadAppointmentsPage();
            customerRecordsMenuButton.Click += (sender, e) => LoadCustomerRecordsPage();
            reportsMenuButton.Click += (sender, e) => LoadReportsPage();
        }

        // Helper method
        private void LoadFormIntoPanel(Form form)
        {
            try
            {
                mainPanel.Controls.Clear();

                form.TopLevel = false;
                form.FormBorderStyle = FormBorderStyle.None;
                form.Dock = DockStyle.Fill;

                mainPanel.Controls.Add(form);
                form.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading form: {ex.Message}");
                Debug.WriteLine($"Error loading form: {ex}");
            }
        }

        private void LoadCalendarPage()
        {
            LoadFormIntoPanel(new CalendarForm());
        }

        private void LoadAppointmentsPage()
        {
            LoadFormIntoPanel(new AppointmentsForm());
        }

        private void LoadCustomerRecordsPage()
        {
            LoadFormIntoPanel(new CustomerRecordsForm());
        }

        private void LoadReportsPage()
        {
            LoadFormIntoPanel(new ReportsForm());
        }
    }
}
