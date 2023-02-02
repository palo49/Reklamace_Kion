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
    public partial class AddUser : Form
    {
        public string MyName { get; set; }

        public AddUser()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string Name = txtName.Text;
            string FirstName = txtFirstName.Text;
            string LastName = txtLastName.Text;
            string Level = cmbLevel.Text;
            string Pass = txtPass.Text;

            try
            {
                if (Name != string.Empty && FirstName != string.Empty && LastName != string.Empty && Level != string.Empty && Pass != string.Empty)
                {
                    if (Name != MyName)
                    {
                        SqlConnection conn = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace"); // making connection
                        string sqlUser = "SELECT COUNT(*) from Users where Name like '" + Name + "'";
                        SqlCommand cmdCount = new SqlCommand(sqlUser, conn);
                        conn.Open();
                        int userCount = (int) cmdCount.ExecuteScalar();
                        conn.Close();
                        if (userCount == 0)
                        {
                            if (Level == "Admin") Level = "100";
                            else if (Level == "Technik") Level = "20";
                            else if (Level == "Příjem") Level = "10";
                            else if (Level == "Opravář") Level = "5";
                            else if (Level == "Pouze čtení") Level = "1";

                            conn.Open();
                            //SqlCommand cmd = new SqlCommand("INSERT INTO Users VALUES('" + Name + "','" + FirstName + "','" + LastName + "','" + Level + "', CONVERT(varbinary(max), @Pass)", conn);
                            string sql = "insert into Users values('" + Name + "','" + FirstName + "','" + LastName + "','" + Level + "', HASHBYTES('SHA2_256', '" + Pass + "') )";
                            SqlCommand cmd = new SqlCommand(sql, conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();

                            Users.RefData.RefreshData(conn);

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Uživatel s tímto loginem již existuje.");
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Tento login již existuje.");
                    }
                }
                else
                {
                    MessageBox.Show("Vyplňte všechna pole!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
