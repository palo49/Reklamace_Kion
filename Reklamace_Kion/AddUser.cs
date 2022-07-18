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
                    if (Level == "Admin") Level = "100";
                    else if (Level == "Technik") Level = "20";
                    else if (Level == "Příjem") Level = "10";
                    else if (Level == "Opravář") Level = "5";
                    else if (Level == "Pouze čtení") Level = "1";
                    SqlConnection conn = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace"); // making connection

                    conn.Open();
                    //SqlCommand cmd = new SqlCommand("INSERT INTO Users VALUES('" + Name + "','" + FirstName + "','" + LastName + "','" + Level + "', CONVERT(varbinary(max), @Pass)", conn);
                    string sql = "insert into Users values('"+Name+ "','" + FirstName + "','" + LastName + "','" + Level + "', HASHBYTES('SHA2_256', '"+Pass+"') )";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();

                    Users.RefData.RefreshData(conn);

                    this.Close();
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
    }
}
