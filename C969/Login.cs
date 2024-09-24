using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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

            if (IsValidLogin(username, password))
            {

                var culture = CultureInfo.CurrentCulture;

                Home homePage = new Home();
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

        private bool IsValidLogin(string username, string password)
        {
            //change this eventually to actual users!
            return username == "test" && password == "test";
        }

    }
}
