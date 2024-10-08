using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace C969
{
    public partial class Home : Form
    {
        private int userId;
        public Home(int userId)
        {
            InitializeComponent();
            this.userId = userId;
            calendarMenuButton.Click += (sender, e) => LoadCalendarPage();
            appointmentsMenuButton.Click += (sender, e) => LoadAppointmentsPage();
            customerRecordsMenuButton.Click += (sender, e) => LoadCustomerRecordsPage();
            CheckForUpcomingAppointments(userId);
            
        }

        private void CheckForUpcomingAppointments(int userId)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;

                DateTime currentUtcTime = DateTime.UtcNow;

                DateTime thresholdTime = currentUtcTime.AddMinutes(15);

                string query = "SELECT appointmentId, start FROM appointment " +
                    "WHERE userId = @userId AND start BETWEEN @currentUtcTime AND @thresholdTime";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();

                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userId", userId);
                        command.Parameters.AddWithValue("@currentUtcTime", currentUtcTime);
                        command.Parameters.AddWithValue("@thresholdTime", thresholdTime);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    DateTime appointmentStartTime = reader.GetDateTime("start");
                                    MessageBox.Show($"You have an upcoming appointment at {appointmentStartTime.ToLocalTime():hh:mm tt}.",
                                "Upcoming Appointment Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error checking for upcoming appointments: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        public void LoadCalendarPage()
        {
            LoadFormIntoPanel(new CalendarForm());
        }

        public void LoadAppointmentsPage()
        {
            LoadFormIntoPanel(new AppointmentsForm());
        }

        public void LoadCustomerRecordsPage()
        {
            LoadFormIntoPanel(new CustomerRecordsForm());
        }

        public void reportsMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            string reportType = e.ClickedItem.Text;
            ReportsForm reportsForm = new ReportsForm(reportType); 
            reportsForm.Show();
        }

    }
}
