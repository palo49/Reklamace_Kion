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

        public string MyName { get; set; }

        private static Users form = null;
        public Users()
        {
            InitializeComponent();
            form = this;
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            try
            {
                RefData.RefreshData(conn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUser AddUserForm = new AddUser();
            AddUserForm.MyName = MyName;
            AddUserForm.Show();
        }

        public class RefData
        {
            public static void RefreshData(SqlConnection connection)
            {
                connection.Open();
                SqlCommand getUserDataEdit = new SqlCommand("SELECT UserId, Name, FirstName, LastName, Level FROM Users", connection);
                SqlDataAdapter daEdit = new SqlDataAdapter(getUserDataEdit);

                DataTable DataUsersEdit = new DataTable();

                daEdit.Fill(DataUsersEdit);

                connection.Close();

                form.dataGridUsers.DataSource = DataUsersEdit;
            }
        }

        private void btnDelUser_Click(object sender, EventArgs e)
        {
            try
            {
                int UserId = (int)dataGridUsers.CurrentRow.Cells[0].Value;
                string UserName = (string)dataGridUsers.CurrentRow.Cells[1].Value;

                DialogResult dialogResult = MessageBox.Show("Opravdu chcete smazat uživatele " + UserName + "?", "Smazat uživatele", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (UserName != MyName)
                    {
                        conn.Open();
                        SqlCommand delUser = new SqlCommand("DELETE FROM Users WHERE UserId=" + UserId + "", conn);
                        delUser.ExecuteNonQuery();
                        conn.Close();
                        RefData.RefreshData(conn);
                    }else
                    {
                        MessageBox.Show("Nemůžete smazat sami sebe.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
