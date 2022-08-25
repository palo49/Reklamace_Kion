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

namespace Reklamace_Kion.Opravy
{
    public partial class AddComponentRepair : Form
    {
        public AddComponentRepair()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text != string.Empty)
            {
                try
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace");
                    string sqlData = "SELECT COUNT(*) from RepairComponents where Name like '" + txtName.Text + "'";
                    SqlCommand cmdCount = new SqlCommand(sqlData, conn);

                    conn.Open();
                    int dataCount = (int)cmdCount.ExecuteScalar();
                    conn.Close();

                    if (dataCount == 0)
                    {
                        string sqlInsert = "INSERT INTO RepairComponents (Name) values('" + txtName.Text + "')";

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
                MessageBox.Show("Vyplňte pole s *", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
