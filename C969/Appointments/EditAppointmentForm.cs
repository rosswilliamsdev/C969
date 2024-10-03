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
    public partial class EditAppointmentForm : Form
    {
        private int customerId;
        private string type;
        private DateTime startTime;
        private DateTime endTime;

        public EditAppointmentForm(int customerId, string type, DateTime startTime, DateTime endTime)
        {
            InitializeComponent();
            dateDTP.Format = DateTimePickerFormat.Short;

            startTimeDTP.Format = DateTimePickerFormat.Time;
            startTimeDTP.ShowUpDown = true;
            endTimeDTP.Format = DateTimePickerFormat.Time;
            endTimeDTP.ShowUpDown = true;

            this.customerId = customerId;
            this.type = type;
            this.startTime = startTime;
            this.endTime = endTime;

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
            appointmentTypeComboBox.DataSource = AppointmentType.GetAppointmentTypes();
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
    }

}
