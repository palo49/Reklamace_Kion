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

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridUsers_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string CommandText = string.Empty;
            string columnName = dataGridUsers.Columns[e.ColumnIndex].Name;
            int rowId = Convert.ToInt32(dataGridUsers[0, e.RowIndex].Value);
            string newValue = dataGridUsers[e.ColumnIndex, e.RowIndex].Value.ToString();

            if (columnName == "Name") { CommandText = "UPDATE Users SET Name = @newval WHERE UserId = @id"; }
            else if (columnName == "FirstName") { CommandText = "UPDATE Users SET FirstName = @newval WHERE UserId = @id"; }
            else if (columnName == "LastName") { CommandText = "UPDATE Users SET LastName = @newval WHERE UserId = @id"; }
            else if (columnName == "Level") { CommandText = "UPDATE Users SET Level = @newval WHERE UserId = @id"; }

            //MessageBox.Show("id "+rowId.ToString()+"\ncolumn name "+columnName+"\nnew data "+newValue);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@newval", newValue);
                cmd.Parameters.AddWithValue("@id", rowId);
                cmd.ExecuteNonQuery();
                conn.Close();
                RefData.RefreshData(conn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
