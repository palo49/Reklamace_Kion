using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reklamace_Kion.Contacts
{
    public partial class AddContact : Form
    {
        public AddContact()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((txtCompany.Text != string.Empty) || (txtEmail.Text != string.Empty) || (txtFirstName.Text != string.Empty) || (txtLastName.Text != string.Empty))
            {
                try
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace");
                    string sqlData = "SELECT COUNT(*) from Contacts where email like '" + txtEmail.Text + "'";
                    SqlCommand cmdCount = new SqlCommand(sqlData, conn);

                    conn.Open();
                    int dataCount = (int)cmdCount.ExecuteScalar();
                    conn.Close();

                    if (dataCount == 0)
                    {
                        string sqlInsert = "INSERT INTO Contacts (Company, Last_Name, First_Name, Email) values('" + txtCompany.Text + "','" + txtLastName.Text + "','" + txtFirstName.Text + "','" + txtEmail.Text + "')";

                        SqlCommand cmdInsert = new SqlCommand(sqlInsert, conn);
                        conn.Open();
                        cmdInsert.ExecuteNonQuery();
                        conn.Close();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Tento záznam již existuje.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vyplňte všechna pole.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
