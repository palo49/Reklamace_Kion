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

namespace Reklamace_Kion
{
    public partial class AddRepair : Form
    {
        public string MyLevel { get; set; }

        public AddRepair()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void trackBarSOH_ValueChanged(object sender, EventArgs e)
        {
            numSOH.Value = trackBarSOH.Value;
        }

        private void numSOH_ValueChanged(object sender, EventArgs e)
        {
            trackBarSOH.Value = (int) numSOH.Value;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string Brand = txtBrand.Text;
            bool WD = chckWD.Checked;
            bool BB = chckBB.Checked;  
            bool ZD = chckZD.Checked;
            bool SW = chckSW.Checked;
            bool PD = chckPD.Checked;
            bool Test = chckTest.Checked;
            bool Charging = chckCharging.Checked;
            bool SetBrandId = chckSetBrandId.Checked;
            bool PrtScr = chckPrtscr.Checked;
            bool Label = chckLabel.Checked;
            string TypeOfPalette = cmbTypeOfPalette.Text;
            string DateOfExp = dateExpExp.Value.ToShortDateString();
            int SOH = trackBarSOH.Value;
            double Capacity = Convert.ToDouble(numCapacity.Value);

            if (Brand != string.Empty)
            {
                try
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace");
                    string sqlRepairs = "SELECT COUNT(*) from DataRepairs where Brand like '" + Brand + "'";
                    SqlCommand cmdCount = new SqlCommand(sqlRepairs, conn);

                    conn.Open();
                    int dataCount = (int)cmdCount.ExecuteScalar();
                    conn.Close();

                    if (dataCount == 0)
                    {
                        string sqlInsert = "INSERT INTO DataRepairs values('" + Brand + "','" + WD + "','" + BB + "','" + ZD + "','" + SW + "'," +
                            "'" + PD + "','" + Test + "','" + Charging + "','" + SetBrandId + "','" + PrtScr + "'," +
                            "'" + Label + "','" + TypeOfPalette + "','" + DateOfExp + "','" + SOH + "',@Capacity)";

                        SqlCommand cmdInsert = new SqlCommand(sqlInsert, conn);
                        cmdInsert.CommandType = System.Data.CommandType.Text;
                        cmdInsert.Parameters.Add("@Capacity", SqlDbType.Float).Value = Capacity;
                        conn.Open();
                        cmdInsert.ExecuteNonQuery();
                        conn.Close();

                        Main.GetTableDataRepairs(conn);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Tento záznam již existuje.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Vyplňte pole označené *.");
            }
        }
    }
}
