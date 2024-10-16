﻿using MySql.Data.MySqlClient;
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

namespace C969
{
    public partial class AddCustomerForm : Form
    {
        private CustomerRecordsForm parentForm;
        public AddCustomerForm(CustomerRecordsForm form)
        {
            InitializeComponent();
            parentForm = form;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string customerName = nameTextBox.Text.Trim();
            string address = addressTextBox.Text.Trim();
            string phoneNumber = phoneNumberTextBox.Text.Trim();
            string cityName = cityTextBox.Text.Trim();
            string countryName = countryTextBox.Text.Trim();

            if (string.IsNullOrEmpty(customerName))
            {
                MessageBox.Show("Customer name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(phoneNumber))
            {
                MessageBox.Show("Phone number name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (string.IsNullOrEmpty(address))
            {
                MessageBox.Show("Address name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!IsValidPhoneNumber(phoneNumber))
            {
                MessageBox.Show("Phone number can only include digits and hyphens.", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Call the method to add the customer, passing in the input from the textboxes
            AddCustomer(customerName, address, phoneNumber, cityName, countryName);
            parentForm.LoadCustomerRecords();
            this.Close();
        }



        private bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"^[0-9-]+$";
            return Regex.IsMatch(phoneNumber, pattern);
        }


        private void resetButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Text = "";
            addressTextBox.Text = "";
            phoneNumberTextBox.Text = "";
            cityTextBox.Text = "";
            countryTextBox.Text = "";
        }

        private void AddCustomer(string customerName, string address, string phoneNumber, string cityName, string countryName)
        {
            try
            {
                // Insert country code here
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error inserting country: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                
                int countryId = GetCountryId(countryName);
                if (countryId == -1)
                {
                    countryId = InsertCountry(countryName);
                }

                int cityId = GetCityId(cityName, countryId);
                if (cityId == -1)
                {
                    cityId = InsertCity(cityName, countryId);
                }

                int addressId = InsertAddress(address, cityId, phoneNumber);
                if (addressId > 0)
                {
                    InsertCustomerIntoDatabase(customerName, addressId);
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error adding customer: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private int GetCountryId(string countryName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;
            string query = "SELECT countryId FROM country WHERE country = @countryName";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@countryName", countryName);
                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }

        private int GetCityId(string cityName, int countryId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;
            string query = "SELECT cityId FROM city WHERE city = @cityName AND countryId = @countryId";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@cityName", cityName);
                    command.Parameters.AddWithValue("@countryId", countryId);
                    object result = command.ExecuteScalar();
                    return result != null ? Convert.ToInt32(result) : -1;
                }
            }
        }

        private int InsertCountry(string countryName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;
            string query = "INSERT INTO country (country, createDate, createdBy, lastUpdateBy) VALUES (@country, NOW(), 'system', 'system')";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@country", countryName);
                    cmd.ExecuteNonQuery();
                    return (int)cmd.LastInsertedId;
                }
            }
        }

        private int InsertCity(string cityName, int countryId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;
            string query = "INSERT INTO city (city, countryId, createDate, createdBy, lastUpdateBy) VALUES (@city, @countryId, NOW(), 'system', 'system')";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@city", cityName);
                    command.Parameters.AddWithValue("@countryId", countryId);
                    command.ExecuteNonQuery();
                    return (int)command.LastInsertedId;
                }
            }
        }

        private int InsertAddress(string address, int cityId, string phoneNumber)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;
            string query = "INSERT INTO address (address, address2, cityId, postalCode, phone, createDate, createdBy, lastUpdateBy) " +
                           "VALUES (@address, @address2, @cityId, @postalCode, @phone, NOW(), 'system', 'system')";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    // User-provided fields
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@cityId", cityId);
                    command.Parameters.AddWithValue("@phone", phoneNumber);

                    // Placeholder values for fields not provided by the user
                    command.Parameters.AddWithValue("@address2", "");  
                    command.Parameters.AddWithValue("@postalCode", "00000"); 

                    //The remaining fields should either be auto-increment, set to system, or NOW()
                    
                    command.ExecuteNonQuery();
                    return (int)command.LastInsertedId;
                }
            }
        }


        private void InsertCustomerIntoDatabase(string customerName, int addressId)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;
            string query = "INSERT INTO customer (customerName, addressId, active, createDate, createdBy, lastUpdateBy) " +
                           "VALUES (@customerName, @addressId, 1, NOW(), 'system', 'system')";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@customerName", customerName);
                    command.Parameters.AddWithValue("@addressId", addressId);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Customer added successfully!");
                }
            }
        }
    }
}
