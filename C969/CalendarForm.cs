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

namespace C969
{
    public partial class CalendarForm : Form
    {
        public CalendarForm()
        {
            InitializeComponent();
            appointmentsDGV.AllowUserToAddRows = false;
            appointmentsDGV.ReadOnly = true;
            appointmentsDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            appointmentsDGV.MultiSelect = false;
        }

        private void LoadAppointmentsForDate(DateTime selectedDate)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;
            string query = "SELECT * FROM appointment WHERE DATE(start) = @selectedDate";
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@selectedDate", selectedDate.Date);
                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(command))
                    {
                        dataAdapter.Fill(dataTable);
                    }
                }
            }
            appointmentsDGV.DataSource = dataTable;
        }

        private void calendar_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = calendar.SelectionStart;
            LoadAppointmentsForDate(selectedDate);
        }
    }
}
