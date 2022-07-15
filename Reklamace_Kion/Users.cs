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
    public partial class Users : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace");

        public Users()
        {
            InitializeComponent();
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand getUserDataEdit = new SqlCommand("SELECT UserId, Name, FirstName, LastName, Level FROM Users", conn);
                SqlDataAdapter daEdit = new SqlDataAdapter(getUserDataEdit);

                DataTable DataUsersEdit = new DataTable();

                daEdit.Fill(DataUsersEdit);

                conn.Close();

                dataGridUsers.DataSource = DataUsersEdit;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUser AddUserForm = new AddUser();
            AddUserForm.Show();
        }
    }
}
