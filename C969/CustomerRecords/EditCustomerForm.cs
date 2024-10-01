using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969.CustomerRecords
{
    public partial class EditCustomerForm : Form
    {
        private int customerId;
        private int addressId;
        private int cityId;
        public EditCustomerForm(int customerId, string customerName, string address, string city, string countryName, string phoneNumber)
        {
            InitializeComponent();
            this.customerId = customerId;

            //populates fields with data from selected customer
            nameTextBox.Text = customerName;
            addressTextBox.Text = address;
            cityTextBox.Text = city;
            countryTextBox.Text = countryName;
            phoneNumberTextBox.Text = phoneNumber;

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            //get updated data from text boxes
            string updatedName = nameTextBox.Text.Trim();
            string updatedAddress = addressTextBox.Text.Trim();
            string updatedCity = cityTextBox.Text.Trim();
            string updatedCountry = countryTextBox.Text.Trim();
            string updatedPhoneNumber = phoneNumberTextBox.Text.Trim();

            // ensure required fields are filled
            if (string.IsNullOrEmpty(updatedName))
            {
                MessageBox.Show("Customer name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(updatedAddress))
            {
                MessageBox.Show("Address cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(updatedPhoneNumber))
            {
                MessageBox.Show("Phone number cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidPhoneNumber(updatedPhoneNumber))
            {
                MessageBox.Show("Phone number can only include digits and hyphens.", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //update customer record
            UpdateCustomer(customerId, updatedName, updatedAddress, updatedCity, updatedCountry, updatedPhoneNumber);

            //close after save
            this.Close();
        }

        private bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"^[0-9-]+$";
            return Regex.IsMatch(phoneNumber, pattern);
        }

        private void UpdateCustomer(int customerId, string name, string address, string city, string country, string phoneNumber)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;

                int addressId = GetCustomerAddressId(customerId);
                int cityId = GetCityId(city, country);

                string updateAddressQuery = "UPDATE address SET address = @address, cityId = @cityId WHERE addressId = @addressId";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(updateAddressQuery, connection))
                    {
                        command.Parameters.AddWithValue("@address", address);
                        command.Parameters.AddWithValue("@cityId", cityId);
                        command.Parameters.AddWithValue("@addressId", addressId);
                        command.ExecuteNonQuery();
                    }

                    string updateCustomerQuery = "UPDATE customer SET customerName = @name, phoneNumber = @phoneNumber WHERE customerId = @customerId";

                    using (MySqlCommand command = new MySqlCommand(updateCustomerQuery, connection))
                    {
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@phoneNumber", phoneNumber);
                        command.Parameters.AddWithValue("@customerId", customerId);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error updating customer: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private int GetCustomerAddressId(int customerId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;
            string query = "SELECT addressId FROM customer WHERE customerId = @customerId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@customerId", customerId);
                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }

        private int GetCityId(string city, string country)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;

            int countryId = GetCountryId(country);

            string query = "SELECT cityId FROM city WHERE city = @city AND countryID = @countryId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@city", city);
                    command.Parameters.AddWithValue("@countryId", countryId);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        return InsertCity(city, countryId);
                    }
                }
            }
        }

        private int GetCountryId(string country)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;
            string query = "SELECT countryId FROM country WHERE country = @country";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@country", country);

                    object result = command.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                    else
                    {
                        // Insert the country if it doesn't exist
                        return InsertCountry(country);
                    }
                }
            }
        }

        private int InsertCity(string city, int countryId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;
            string query = "INSERT INTO city (city, countryId, createDate, createdBy, lastUpdateBy) VALUES (@city, @countryId, NOW(), 'system', 'system')";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@city", city);
                    command.Parameters.AddWithValue("@countryId", countryId);
                    command.ExecuteNonQuery();
                    return (int)command.LastInsertedId;
                }
            }
        }
        private int InsertCountry(string country)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;
            string query = "INSERT INTO country (country, createDate, createdBy, lastUpdateBy) VALUES (@country, NOW(), 'system', 'system')";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@country", country);
                    command.ExecuteNonQuery();
                    return (int)command.LastInsertedId;
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
