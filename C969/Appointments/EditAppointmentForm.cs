using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using C969.Utilities;
using static Google.Protobuf.Reflection.SourceCodeInfo.Types;
using System.Security.Policy;

namespace C969.Appointments
{
    public partial class EditAppointmentForm : Form
    {
        private int appointmentId;
        private int customerId;
        private string type;
        private DateTime startTime;
        private DateTime endTime;

        public EditAppointmentForm(int appointmentId, int customerId, string type, DateTime startTime, DateTime endTime)
        {
            InitializeComponent();
            dateDTP.Format = DateTimePickerFormat.Short;

            startTimeDTP.Format = DateTimePickerFormat.Time;
            startTimeDTP.ShowUpDown = true;
            endTimeDTP.Format = DateTimePickerFormat.Time;
            endTimeDTP.ShowUpDown = true;

            this.appointmentId = appointmentId;
            this.customerId = customerId;
            this.type = type;

            LoadCustomerName(customerId);
            LoadAppointmentTypes();

            customerNameTextBox.ReadOnly = true;

            // Set DateTimePickers with existing data
            dateDTP.Value = startTime.Date;
            startTimeDTP.Value = startTime;
            endTimeDTP.Value = endTime;

            // Set appointment type ComboBox
            appointmentTypeComboBox.SelectedItem = type;
        }

        private void LoadAppointmentTypes()
        {
            appointmentTypeComboBox.DataSource = AppointmentHelper.GetAppointmentTypes();
        }

        private void LoadCustomerName(int customerId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;
            string query = "SELECT customerName FROM customer WHERE customerId = @customerId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@customerId", customerId);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            customerNameTextBox.Text = reader["customerName"].ToString();
                        }
                    }
                }
            }
        }

        private void EditAppointment(int appointmentId, int customerId, string type, DateTime start, DateTime end, int userId)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;
                string query = "UPDATE appointment " +
                       "SET customerId = @customerId, userId = @userId, type = @type, start = @start, end = @end, lastUpdateBy = 'system', lastUpdate = NOW() " +
                       "WHERE appointmentId = @appointmentId";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@appointmentId", appointmentId);
                        command.Parameters.AddWithValue("@customerId", customerId);
                        command.Parameters.AddWithValue("@userId", userId);
                        command.Parameters.AddWithValue("@type", type);
                        command.Parameters.AddWithValue("@start", start);
                        command.Parameters.AddWithValue("@end", end);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Appointment updated successfully.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error updating appointment: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            TimeZoneInfo localTimeZone = TimeZoneInfo.Local;

            // Combine date and time for start and end
            DateTime startDateTime = dateDTP.Value.Date + startTimeDTP.Value.TimeOfDay;
            DateTime endDateTime = dateDTP.Value.Date + endTimeDTP.Value.TimeOfDay;

            DateTime utcStartDateTime = TimeZoneInfo.ConvertTimeToUtc(startDateTime, localTimeZone);
            DateTime utcEndDateTime = TimeZoneInfo.ConvertTimeToUtc(endDateTime, localTimeZone);

            if (!AppointmentHelper.IsWithinBusinessHours(startDateTime, endDateTime))
            {
                MessageBox.Show("Appointments must be scheduled between 9:00 AM and 5:00 PM, Monday-Friday.", "Invalid Time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (AppointmentHelper.IsOverlappingAppointment(customerId, startDateTime, endDateTime))
            {
                MessageBox.Show("This appointment overlaps with another appointment.", "Overlapping Appointment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (appointmentTypeComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select an appointment type.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string appointmentType = appointmentTypeComboBox.SelectedItem.ToString();
            int userId = 1; // default userId value;

            EditAppointment(appointmentId, customerId, appointmentType, utcStartDateTime, utcEndDateTime, userId);
            ((AppointmentsForm)this.Owner).LoadAppointments();
        }

    }

}
