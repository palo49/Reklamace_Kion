using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Reklamace_Kion
{
    public partial class Main : Form
    {
        public string MyName { get; set; }

        string FirstName = string.Empty;
        string LastName = string.Empty;
        string Level = string.Empty;

        SqlConnection conn = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace");

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            SqlCommand getUserData = new SqlCommand("SELECT FirstName, LastName, Level FROM Users WHERE Name='" + MyName + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(getUserData);

            try
            {
                conn.Open();
                SqlDataReader reader = getUserData.ExecuteReader();

                while(reader.Read())
                {
                    lblFirstName.Text = reader.GetString(0);
                    lblLastName.Text = reader.GetString(1);
                    lblLevel.Text = reader.GetString(2);
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
