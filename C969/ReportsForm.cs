using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace C969
{
    public partial class ReportsForm : Form
    {
        public ReportsForm(string reportType)
        {
            InitializeComponent();
            LoadReport(reportType);
            reportsDGV.AllowUserToAddRows = false;
            reportsDGV.ReadOnly = true;
            reportsDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void LoadReport(string reportType)
        {
            DataTable reportData = null;

            switch (reportType)
            {
                case "Appt. Types By Month":
                    reportData = GetAppointmentsByMonthReport();
                    reportsLabel.Text = "Appointment Types By Month";
                    break;
                case "Appt. By User":
                    reportData = GetUserScheduleReport();
                    reportsLabel.Text = "Appointments By User";
                    break;
                case "Appt. Per Customer":
                    reportData = GetCustomerReport();
                    reportsLabel.Text = "Appointments Per Customer";
                    break;
            }

            // Display the data
            if (reportData != null)
            {
                reportsDGV.DataSource = reportData;
            }
        }

        public DataTable GetAppointmentsByMonthReport()
        {
            DataTable dataTable = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;
            string query = "SELECT MONTH(start) AS Month, type AS AppointmentType, COUNT(*) AS AppointmentCount " +
                           "FROM appointment GROUP BY MONTH(start), type";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }
            var groupedData = dataTable.AsEnumerable()
    .GroupBy(row => Convert.ToInt32(row["Month"]))
    .Select(group => new
    {
        Month = group.Key,
        AppointmentCount = group.Sum(row => Convert.ToInt32(row["AppointmentCount"]))
    }).ToList();

            return dataTable;
        }

        public DataTable GetUserScheduleReport()
        {
            DataTable dataTable = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;


            string query = @"
        SELECT u.userName AS User, a.type AS AppointmentType, a.start AS StartTime, a.end AS EndTime
        FROM appointment a
        JOIN user u ON a.userId = u.userId
        ORDER BY u.userName, a.start";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            var groupedData = dataTable.AsEnumerable()
        .GroupBy(row => row.Field<string>("User"))
        .Select(group => new
        {
            User = group.Key,
            Appointments = group.Select(row => new
            {
                AppointmentType = Convert.ToString(row["AppointmentType"]),
                StartTime = Convert.ToDateTime(row["StartTime"]),
                EndTime = Convert.ToDateTime(row["EndTime"])
            }).ToList()
        }).ToList();
            return dataTable;
        }


        public DataTable GetCustomerReport()
        {
            DataTable dataTable = new DataTable();
            string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;

            string query = @"
        SELECT c.customerName, COUNT(a.appointmentId) AS AppointmentCount 
        FROM customer c
        LEFT JOIN appointment a ON c.customerId = a.customerId
        GROUP BY c.customerName
        ORDER BY AppointmentCount DESC";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                    {
                        adapter.Fill(dataTable);
                    }
                }
            }

            var groupedData = dataTable.AsEnumerable()
        .GroupBy(row => row.Field<string>("customerName"))
        .Select(group => new
        {
            CustomerName = group.Key,
            AppointmentCount = group.Sum(row => Convert.ToInt32(row["AppointmentCount"]))
        }).ToList();

            return dataTable;
        }
    }
}
