using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C969.Utilities
{
    public static class AppointmentHelper
    {
        public static bool IsWithinBusinessHours(DateTime start, DateTime end)
        {
            // Business hours in EST
            DateTime startBusinessHours = DateTime.Today.AddHours(9); // 9 AM
            DateTime endBusinessHours = DateTime.Today.AddHours(17); // 5 PM

            bool withinHours = start.TimeOfDay >= startBusinessHours.TimeOfDay && end.TimeOfDay <= endBusinessHours.TimeOfDay;
            bool isWeekday = start.DayOfWeek >= DayOfWeek.Monday && start.DayOfWeek <= DayOfWeek.Friday;

            return withinHours && isWeekday;
        }

        public static bool IsOverlappingAppointment(int customerId, DateTime start, DateTime end)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;
            string query = "SELECT COUNT(*) FROM appointment WHERE customerId = @customerId AND ((@start BETWEEN start AND end) OR (@end BETWEEN start AND end))";
            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@customerId", customerId);
                    command.Parameters.AddWithValue("@start", start);
                    command.Parameters.AddWithValue("@end", end);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    return count > 0; // Return true if overlapping appointments are found
                }
            }
        }

        public static DataTable GetAppointments()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;
            string query = "SELECT * FROM appointment";
            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                dataAdapter.Fill(dataTable);
            }

            return dataTable;
        }

        public static List<string> GetAppointmentTypes()
        {
            return new List<string> { "Consultation", "Meeting", "Personal", "Other" };
        }
    }

}
