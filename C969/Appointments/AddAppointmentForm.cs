using C969.Utilities;
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

namespace C969.Appointments
{
    public partial class AddAppointmentForm : Form
    {
        public AddAppointmentForm()
        {
            InitializeComponent();
            LoadCustomerDropdown();
            LoadAppointmentTypes();
            
            dateDTP.Format = DateTimePickerFormat.Short;
            dateDTP.Value = DateTime.Now;
            startTimeDTP.Format = DateTimePickerFormat.Time;
            startTimeDTP.ShowUpDown = true;
            endTimeDTP.Format = DateTimePickerFormat.Time;
            endTimeDTP.ShowUpDown = true;
        }

        private void LoadAppointmentTypes()
        {
            appointmentTypeComboBox.DataSource = AppointmentHelper.GetAppointmentTypes();
        }

        private void LoadCustomerDropdown()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;
            string query = "SELECT customerId, customerName FROM customer";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Add customer name to the combo box but store the customerId
                            customerComboBox.Items.Add(new ComboBoxItem(
                                reader["customerName"].ToString(),   // Customer name (Text)
                                Convert.ToInt32(reader["customerId"])
                            ));
                        }
                    }
                }
            }
        }

        private void AddAppointment(int customerId, string type, DateTime start, DateTime end, int userId)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;
                string query = "INSERT INTO appointment (customerId, userId, title, description, location, contact, type, url, start, end, createDate, createdBy, lastUpdateBy) " +
                               "VALUES (@customerId, @userId, @title, @description, @location, @contact, @type, @url, @start, @end, NOW(), 'system', 'system')";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@customerId", customerId);
                        command.Parameters.AddWithValue("@userId", userId);
                        command.Parameters.AddWithValue("@title", "Default Title");           // Placeholder
                        command.Parameters.AddWithValue("@description", "Default Description"); // Placeholder
                        command.Parameters.AddWithValue("@location", "Default Location");       // Placeholder
                        command.Parameters.AddWithValue("@contact", "Default Contact");         // Placeholder
                        command.Parameters.AddWithValue("@type", type);
                        command.Parameters.AddWithValue("@url", "http://default.url");          // Placeholder
                        command.Parameters.AddWithValue("@start", start);
                        command.Parameters.AddWithValue("@end", end);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Appointment added successfully.");
                this.DialogResult = DialogResult.OK;
                
                this.Close();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error adding appointment: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            TimeZoneInfo localTimeZone = TimeZoneInfo.Local;
            ComboBoxItem selectedCustomer = (ComboBoxItem)customerComboBox.SelectedItem;
            if (selectedCustomer == null)
            {
                MessageBox.Show("Please select a customer.", "Missing Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int customerId = selectedCustomer.CustomerId;

            // combines the selected date with start and end times
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
            int userId = 1; // default userId value

            AddAppointment(customerId, appointmentType, utcStartDateTime, utcEndDateTime, userId);
        }


    }
}
