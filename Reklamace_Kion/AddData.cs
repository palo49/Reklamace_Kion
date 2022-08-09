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
    public partial class AddData : Form
    {
        public string MyLevel { get; set; }

        public AddData()
        {
            InitializeComponent();
        }

        private void AddData_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace"))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Name FROM DataComponents", sqlConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbClaimedComponent.DataSource = dt;
                cmbClaimedComponent.DisplayMember = "Name";
                cmbClaimedComponent.ValueMember = "Name";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string CLM = txtCLM.Text;
            string Status = cmbState.Text;
            string CustomerRequire = txtCustomerRequest.Text;
            string DateOfCustomerSendVal = DateOfCustomerSend.Value.ToShortDateString();
            string DateOfSaftAcceptanceVal = DateOfSaftAcceptance.Value.ToShortDateString();
            string DateOfRepairVal = DateOfRepair.Value.ToShortDateString();
            string DateOfSaftSendVal = DateOfSaftSend.Value.ToShortDateString();
            string Type = txtType.Text;
            string SerialNumber = txtSerialNumber.Text;
            string Fault = txtFault.Text;
            string CW = cmbCW.Text;
            string DefectBMS = txtDefectBMS.Text;
            string LocationOfBattery = txtLocationOfBattery.Text;
            string ReplacementSend = cmbReplacementSend.Text;
            string DateOfSendReplacement = DateOfReplacementSend.Value.ToShortDateString();
            string Result = cmbResult.Text;
            string ResultDescription = txtResultDescription.Text;
            string Price = txtCostOfRepair.Text;
            string Contact = txtContact.Text;
            string ClaimedComponent = cmbClaimedComponent.Text;

            if ((CLM != string.Empty) && (Status != string.Empty))
            {
                try
                {
                    SqlConnection conn = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace");
                    string sqlData = "SELECT COUNT(*) from DataMain where CLM like '"+CLM+"'";
                    SqlCommand cmdCount = new SqlCommand(sqlData, conn);

                    conn.Open();
                    int dataCount = (int)cmdCount.ExecuteScalar();
                    conn.Close();

                    if (dataCount == 0)
                    {
                        string sqlInsert = "INSERT INTO DataMain values('" + CLM + "','" + Status + "','" + CustomerRequire + "','" + DateOfCustomerSendVal + "','" + DateOfSaftAcceptanceVal + "'," +
                            "'" + DateOfRepairVal + "','" + DateOfSaftSendVal + "','" + ClaimedComponent + "','" + Type + "','" + SerialNumber + "'," +
                            "'" + Fault + "','" + CW + "','" + DefectBMS + "','" + LocationOfBattery + "','" + ReplacementSend + "'," +
                            "'" + DateOfSendReplacement + "','" + Result + "','" + ResultDescription + "','" + Price + "','" + Contact + "')";

                        SqlCommand cmdInsert = new SqlCommand(sqlInsert, conn);
                        conn.Open();
                        cmdInsert.ExecuteNonQuery();
                        conn.Close();

                        Main.ReloadData();
                        
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Data s tímto CLM již existují.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("CLM a Status jsou povinná pole.");
            }
        }

        private void txtCostOfRepair_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verify that the pressed key isn't CTRL or any non-numeric digit
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // If you want, you can allow decimal (float) numbers
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
