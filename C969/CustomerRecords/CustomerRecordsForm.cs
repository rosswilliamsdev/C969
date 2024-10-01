using C969.CustomerRecords;
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
    public partial class CustomerRecordsForm : Form
    {

        public CustomerRecordsForm()
        {
            InitializeComponent();
            customerRecordsDGV.AllowUserToAddRows = false;
            LoadCustomerRecords();
            customerRecordsDGV.ReadOnly = true;
            customerRecordsDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

        }

        public void LoadCustomerRecords()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;
            string query = @"
        SELECT customer.customerId, customer.customerName, address.address, customer.phoneNumber, 
               city.city, country.country 
        FROM customer
        JOIN address ON customer.addressId = address.addressId
        JOIN city ON address.cityId = city.cityId
        JOIN country ON city.countryId = country.countryId";

            DataTable dataTable = new DataTable();

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, connection);
                dataAdapter.Fill(dataTable);

                customerRecordsDGV.DataSource = dataTable;
            }
        }



        private void DeleteCustomer(int customerId)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;
                string query = "DELETE FROM customer WHERE customerId = @customerId";
                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@customerId", customerId);
                        command.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Customer deleted successfully.");
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error deleting customer: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void addButton_Click(object sender, EventArgs e)
        {
            AddCustomerForm addCustomerForm = new AddCustomerForm(this);

            addCustomerForm.ShowDialog();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (customerRecordsDGV.SelectedRows.Count > 0)
            {
                int selectedCustomerId = Convert.ToInt32(customerRecordsDGV.SelectedRows[0].Cells["customerId"].Value);

                DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this customer?", "Delete Customer", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DeleteCustomer(selectedCustomerId);
                    LoadCustomerRecords();
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.");
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (customerRecordsDGV.SelectedCells.Count > 0)
            {
                int selectedRowIndex = customerRecordsDGV.SelectedCells[0].RowIndex;

                // Retrieve the data from the selected row
                int customerId = Convert.ToInt32(customerRecordsDGV.Rows[selectedRowIndex].Cells["customerId"].Value);
                string customerName = customerRecordsDGV.Rows[selectedRowIndex].Cells["customerName"].Value.ToString();
                string address = customerRecordsDGV.Rows[selectedRowIndex].Cells["address"].Value.ToString();
                string cityName = customerRecordsDGV.Rows[selectedRowIndex].Cells["city"].Value.ToString();
                string countryName = customerRecordsDGV.Rows[selectedRowIndex].Cells["country"].Value.ToString();
                string phoneNumber = customerRecordsDGV.Rows[selectedRowIndex].Cells["phoneNumber"].Value.ToString();

                // pass the customer data
                EditCustomerForm editForm = new EditCustomerForm(customerId, customerName, address, cityName, countryName, phoneNumber);
                editForm.ShowDialog();

                // refresh the DGV
                LoadCustomerRecords();
            }
            else
            {
                MessageBox.Show("Please select a customer to edit.");
            }
        }

    }
}
