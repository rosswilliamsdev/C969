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
            LoadCustomerRecords();
        }

        public void LoadCustomerRecords()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ClientScheduleDB"].ConnectionString;
            string query = "SELECT * FROM customer";
            DataTable dataTable = new DataTable();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn);
                dataAdapter.Fill(dataTable);

                customerRecordsDGV.DataSource = dataTable;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            AddCustomerForm addCustomerForm = new AddCustomerForm(this);

            addCustomerForm.ShowDialog();
        }
    }
}
