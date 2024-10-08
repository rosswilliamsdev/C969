using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C969
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            InitializeLoginForm();
        }

        private void InitializeLoginForm()
        {
            var culture = CultureInfo.CurrentCulture;

            if (culture.Name == "de-DE")
            {
                SetFormLanguageToGerman();
            }
            else
            {
                SetFormLanguageToEnglish();
            }
        }

        private void SetFormLanguageToEnglish()
        {
            this.Text = "Login";
            loginHeader.Text = "Login";
            usernameLabel.Text = "Username:";
            passwordLabel.Text = "Password:";
            loginButton.Text = "Login";
        }

        private void SetFormLanguageToGerman()
        {
            this.Text = "Anmeldung";
            loginHeader.Text = "Anmeldung";
            usernameLabel.Text = "Benutzername:";
            passwordLabel.Text = "Passwort:";
            loginButton.Text = "Anmelden";
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            int userId = AuthenticateUser(username, password);

            if (userId > 0)
            {
                RecordLogin(username);
                var culture = CultureInfo.CurrentCulture;

                Home homePage = new Home(userId);
                homePage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show(CultureInfo.CurrentCulture.Name == "de-DE" ?
                                "Ungültige Anmeldedaten. Bitte erneut versuchen." :
                                "Invalid login credentials. Please try again.",
                                "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int AuthenticateUser(string username, string password)
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;
                string query = "SELECT userId FROM user WHERE userName = @username AND password = @password AND active = 1";

                using (MySqlConnection connection = new MySqlConnection(connectionString))
                {
                    connection.Open();
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@username", username);
                        command.Parameters.AddWithValue("@password", password);

                        object result = command.ExecuteScalar();

                        if (result != null)
                        {
                            return Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show($"Error connecting to the database: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return -1; // Invalid login
        }

        private void RecordLogin(string username)
        {
            string filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Login_History.txt");
            string logEntry = $"User: {username}, Login Time: {DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}{Environment.NewLine}";

            try
            {
                File.AppendAllText(filepath, logEntry);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error writing to log file: {ex.Message}", "Log Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
