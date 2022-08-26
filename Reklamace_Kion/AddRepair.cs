using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
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
            string CLM = cmbCLM.Text;
            string BrandSpeed = txtBrandSpeed.Text;
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

            DataTable PNSN = new DataTable();

            if (CLM != string.Empty)
            {
                try
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace");
                    string sqlRepairs = "SELECT COUNT(*) from DataRepairs where CLM like '" + CLM + "'";
                    SqlCommand cmdCount = new SqlCommand(sqlRepairs, conn);

                    conn.Open();
                    int dataCount = (int)cmdCount.ExecuteScalar();
                    string cmdstring = "SELECT PN_Battery, SN_Battery from DataMain where CLM like '" + CLM + "'";
                    SqlCommand cmdd = new SqlCommand(cmdstring, conn);
                    SqlDataAdapter da = new SqlDataAdapter(cmdd);
                    da.Fill(PNSN);
                    
                    conn.Close();

                    if (dataCount == 0)
                    {
                        
                        groupBox1.Visible = false;
                        Cursor.Current = Cursors.WaitCursor;
                        string a = "PN_battery";
                        string b = "SN_battery";
                        string sqlInsert = "INSERT INTO DataRepairs values('" + CLM + "','" + BrandSpeed + "','" + PNSN.Rows[0][a] + "','" + PNSN.Rows[0][b] + "','" + WD + "','" + BB + "','" + ZD + "','" + SW + "'," +
                            "'" + PD + "','" + Test + "','" + Charging + "','" + SetBrandId + "','" + PrtScr + "'," +
                            "'" + Label + "','" + TypeOfPalette + "',@DateExpedition,'" + SOH + "',@Capacity)";

                        SqlCommand cmdInsert = new SqlCommand(sqlInsert, conn);
                        cmdInsert.CommandType = System.Data.CommandType.Text;
                        cmdInsert.Parameters.Add("@Capacity", SqlDbType.Float).Value = Capacity;
                        cmdInsert.Parameters.Add("@DateExpedition", SqlDbType.Date).Value = DateOfExp;
                        conn.Open();
                        cmdInsert.ExecuteNonQuery();

                        string PN = PNSN.Rows[0][a].ToString();
                        string PNChar = PNSN.Rows[0][a].ToString().Substring(PNSN.Rows[0][a].ToString().LastIndexOf('_') + 1);
                        string cmdString = string.Empty;
                        if (PNChar == "A1")
                        {
                            cmdString = "INSERT INTO A1_torques (CLM,PN) values('" + CLM + "','" + PN + "')";
                        }
                        else if (PNChar == "A2")
                        {
                            cmdString = "INSERT INTO A2_torques (CLM,PN) values('" + CLM + "','" + PN + "')";
                        }
                        else if (PNChar == "B1")
                        {
                            cmdString = "INSERT INTO B1_torques (CLM,PN) values('" + CLM + "','" + PN + "')";
                        }
                        else if (PNChar == "B2")
                        {
                            cmdString = "INSERT INTO B2_torques (CLM,PN) values('" + CLM + "','" + PN + "')";
                        }
                        SqlCommand cmdI = new SqlCommand(cmdString, conn);
                        cmdI.ExecuteNonQuery();
                        conn.Close();

                        Main.ReloadData();
                        
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

        private void AddRepair_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace"))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT CLM FROM DataMain", sqlConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbCLM.DataSource = dt;
                cmbCLM.DisplayMember = "Name";
                cmbCLM.ValueMember = "CLM";
            }
        }
    }
}
