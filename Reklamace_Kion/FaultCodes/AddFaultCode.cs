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

namespace Reklamace_Kion.FaultCodes
{
    public partial class AddFaultCode : Form
    {
        public AddFaultCode()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string SaftCode = txtSaftCode.Text;
            string KionCode = txtKionCode.Text;
            string KionDTC = txtKionDTC.Text;

            if ((name == string.Empty) || (SaftCode == string.Empty) || (KionCode == string.Empty) || (KionDTC == string.Empty))
            {
                MessageBox.Show("Vyplňte všechna pole s *.");
            }
            else
            {
                try
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace");
                    string sqlData = "SELECT COUNT(*) from FaultCodes where Saft_Code like '" + SaftCode + "'";
                    SqlCommand cmdCount = new SqlCommand(sqlData, conn);

                    conn.Open();
                    int dataCount = (int)cmdCount.ExecuteScalar();
                    conn.Close();

                    if (dataCount == 0)
                    {
                        string sqlInsert = "INSERT INTO FaultCodes values('" + name + "','" + SaftCode + "','" + KionCode + "','" + KionDTC + "')";

                        SqlCommand cmdInsert = new SqlCommand(sqlInsert, conn);
                        conn.Open();
                        cmdInsert.ExecuteNonQuery();
                        conn.Close();

                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Tento chybový kód již existuje.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
