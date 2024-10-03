using C969.Appointments;
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
    public partial class AppointmentsForm : Form
    {
        public AppointmentsForm()
        {
            InitializeComponent();
            appointmentsDGV.AllowUserToAddRows = false;
            appointmentsDGV.ReadOnly = true;
            appointmentsDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            appointmentsDGV.MultiSelect = false;

            LoadAppointments();
        }

        private void LoadAppointments()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;
            string query = "SELECT * FROM appointment";
            DataTable dataTable = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);
                dataAdapter.Fill(dataTable);

                appointmentsDGV.DataSource = dataTable;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            OpenAddAppointmentForm();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (appointmentsDGV.SelectedRows.Count > 0)
            {
                int selectedCustomerId = Convert.ToInt32(appointmentsDGV.SelectedRows[0].Cells["customerId"].Value);
                string selectedType = appointmentsDGV.SelectedRows[0].Cells["type"].Value.ToString();
                DateTime selectedStartTime = Convert.ToDateTime(appointmentsDGV.SelectedRows[0].Cells["start"].Value);
                DateTime selectedEndTime = Convert.ToDateTime(appointmentsDGV.SelectedRows[0].Cells["end"].Value);

                EditAppointmentForm editAppointmentForm = new EditAppointmentForm(selectedCustomerId, selectedType, selectedStartTime, selectedEndTime);
                editAppointmentForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select an appointment to edit.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (appointmentsDGV.SelectedRows.Count > 0)
            {
                // Get the selected appointmentId from the DataGridView (adjust depending on column names)
                int appointmentId = Convert.ToInt32(appointmentsDGV.SelectedRows[0].Cells["appointmentId"].Value);

                DialogResult result = MessageBox.Show("Are you sure you want to delete this appointment?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    DeleteAppointment(appointmentId);
                    LoadAppointments(); // Refresh the DataGridView after deletion
                }
            }
            else
            {
                MessageBox.Show("Please select an appointment to delete.", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteAppointment(int appointmentId)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;
                string query = "DELETE FROM appointment WHERE appointmentId = @appointmentId";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@appointmentId", appointmentId);
                        command.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Appointment deleted successfully.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error deleting appointment: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void OpenAddAppointmentForm()
        {
            AddAppointmentForm addAppointmentForm = new AddAppointmentForm();

            if (addAppointmentForm.ShowDialog() == DialogResult.OK)
            {
                // Refresh the DataGridView
                LoadAppointments();
            }
        }
    }
}
