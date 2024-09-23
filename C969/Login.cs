using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            if (IsValidLogin(username, password))
            {
                Home homePage = new Home();
                homePage.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid login credentials. Please try again.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidLogin(string username, string password)
        {
            //change this eventually to actual users!
            return username == "test" && password == "test";
        }

    }
}
