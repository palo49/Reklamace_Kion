using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reklamace_Kion
{
    public partial class BlackBoxData : Form
    {
        public int Id { get; set; }
        public string CLM { get; set; }

        SqlConnection conn = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace");

        public BlackBoxData()
        {
            InitializeComponent();
        }

        private void BlackBoxData_Load(object sender, EventArgs e)
        {
            txtCLM.Text = CLM;
            changeDate();
            LoadData();
            loaded = true;
        }

        private void LoadData()
        {
            try
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand("SELECT * FROM DataAnalysis_BB WHERE CLM='" + CLM + "'", conn);

                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        txtBattery.Text = rdr.GetString(2);
                        txtBMS.Text = rdr.GetString(3);
                        cmbVoltage.Text = rdr.GetString(4);
                        txtVoltage.Text = rdr.GetValue(5).ToString();
                        cmbFunctBMS.Text = rdr.GetString(6);
                        txtFunctionalBMS.Text = rdr.GetString(7);
                        cmbWinDiag.Text = rdr.GetString(8);
                        txtWinDiag.Text = rdr.GetString(9);
                        cmbActualCurr.Text = rdr.GetString(10);
                        txtActualCurr.Text = rdr.GetString(11);
                        cmbPresence.Text = rdr.GetString(12);
                        cmbPresence12.Text = rdr.GetString(13);
                        cmbPresence24.Text = rdr.GetString(14);
                        txtPresence.Text = rdr.GetString(15);
                        cmbSMU.Text = rdr.GetString(16);
                        txtSMUVal.Text = rdr.GetValue(17).ToString();
                        //txtSMU.Text = rdr.GetString(18);
                        cmbCurrentConst.Text = rdr.GetString(19);
                        txtIG.Text = rdr.GetString(20);
                        txtIO.Text = rdr.GetString(21);
                        cmbCANSpeed.Text = rdr.GetString(22);
                        txtCanSpeed.Text = rdr.GetValue(23).ToString();
                        //txtCANKbps.Text = rdr.GetValue(24).ToString();
                        cmbCRCofSW.Text = rdr.GetString(25);
                        txtCRCofSW.Text = rdr.GetString(26);
                        cmbBB.Text = rdr.GetString(27);
                        txtBB.Text = rdr.GetString(28);
                        cmbSaftCode.Text = rdr.GetString(29);
                        cmbKionCode.Text = rdr.GetString(30);
                        cmbKionDTC.Text = rdr.GetString(31);
                        txtSaftCode1.Text = rdr.GetValue(32).ToString(); txtKionCode1.Text = rdr.GetValue(33).ToString(); txtKionDTC1.Text = rdr.GetValue(34).ToString();
                        txtSaftCode2.Text = rdr.GetValue(35).ToString(); txtKionCode2.Text = rdr.GetValue(36).ToString(); txtKionDTC2.Text = rdr.GetValue(37).ToString();
                        txtSaftCode3.Text = rdr.GetValue(38).ToString(); txtKionCode3.Text = rdr.GetValue(39).ToString(); txtKionDTC3.Text = rdr.GetValue(40).ToString();
                        txtSaftCode4.Text = rdr.GetValue(41).ToString(); txtKionCode4.Text = rdr.GetValue(42).ToString(); txtKionDTC4.Text = rdr.GetValue(43).ToString();
                        txtSaftCode5.Text = rdr.GetValue(44).ToString(); txtKionCode5.Text = rdr.GetValue(45).ToString(); txtKionDTC5.Text = rdr.GetValue(46).ToString();
                        txtSaftCode6.Text = rdr.GetValue(47).ToString(); txtKionCode6.Text = rdr.GetValue(48).ToString(); txtKionDTC6.Text = rdr.GetValue(49).ToString();
                        txtSaftCode7.Text = rdr.GetValue(50).ToString(); txtKionCode7.Text = rdr.GetValue(51).ToString(); txtKionDTC7.Text = rdr.GetValue(52).ToString();
                        txtSaftCode8.Text = rdr.GetValue(53).ToString(); txtKionCode8.Text = rdr.GetValue(54).ToString(); txtKionDTC8.Text = rdr.GetValue(55).ToString();
                        txtSaftCode9.Text = rdr.GetValue(56).ToString(); txtKionCode9.Text = rdr.GetValue(57).ToString(); txtKionDTC9.Text = rdr.GetValue(58).ToString();
                        txtSaftCode10.Text = rdr.GetValue(59).ToString(); txtKionCode10.Text = rdr.GetValue(60).ToString(); txtKionDTC10.Text = rdr.GetValue(61).ToString();
                        txtSaftCode11.Text = rdr.GetValue(62).ToString(); txtKionCode11.Text = rdr.GetValue(63).ToString(); txtKionDTC11.Text = rdr.GetValue(64).ToString();
                        txtSaftCode12.Text = rdr.GetValue(65).ToString(); txtKionCode12.Text = rdr.GetValue(66).ToString(); txtKionDTC12.Text = rdr.GetValue(67).ToString();
                        cmbCharging.Text = rdr.GetString(68);
                        txtCharging.Text = rdr.GetString(69);
                        cmbDischarging.Text = rdr.GetString(70);
                        txtDischarging.Text = rdr.GetString(71);
                        cmbRTC.Text = rdr.GetString(72);
                        txtRTC.Text = rdr.GetString(73);
                        cmbBMSTested.Text = rdr.GetString(74);
                        txtBMSTested.Text = rdr.GetString(75);
                        cmbReplacement.Text = rdr.GetString(76);
                        txtReplacement.Text = rdr.GetString(77);
                        cmbStatus.Text = rdr.GetString(78);
                        txtStatus.Text = rdr.GetString(79);
                        cmbWarranty.Text = rdr.GetString(80);
                        txtWarranty.Text = rdr.GetString(81);
                        dateWarranty.Text = rdr.GetString(82);
                    }
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void changeDate()
        {
            try
            {
                var NoD = (dateNow.Value - dateWarranty.Value).Days;
                var NoM = ((dateNow.Value.Year - dateWarranty.Value.Year) * 12) + dateNow.Value.Month - dateWarranty.Value.Month;
                var NoY = (dateNow.Value.Year - dateWarranty.Value.Year - 1) + (((dateNow.Value.Month > dateWarranty.Value.Month) || ((dateNow.Value.Month == dateWarranty.Value.Month) && (dateNow.Value.Day >= dateWarranty.Value.Day))) ? 1 : 0);
                lblNoD.Text = NoD.ToString();
                lblNoM.Text = NoM.ToString();
                lblNoY.Text = NoY.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbChanged(object sender, EventArgs e)
        {
            var cmb = (ComboBox)sender;

            try
            {
                if (cmb.SelectedItem.ToString() == "") { cmb.BackColor = SystemColors.Control; }
                else if (cmb.SelectedItem.ToString() == "NOK") { cmb.BackColor = Color.OrangeRed; }
                else if (cmb.SelectedItem.ToString() == "OK") { cmb.BackColor = Color.GreenYellow; }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        bool loaded = false;

        private void FaultCodeChanged(object sender, EventArgs e)
        {
            TextBox[] Codes = { txtKionCode1, txtKionCode2, txtKionCode3, txtKionCode4, txtKionCode5, txtKionCode6, txtKionCode7, txtKionCode8, txtKionCode9, txtKionCode10, txtKionCode11, txtKionCode12 };
            TextBox[] DTCs = { txtKionDTC1, txtKionDTC2, txtKionDTC3, txtKionDTC4, txtKionDTC5, txtKionDTC6, txtKionDTC7, txtKionDTC8, txtKionDTC9, txtKionDTC10, txtKionDTC11, txtKionDTC12 };

            if (loaded)
            {
                try
                {
                    var mytxt = (TextBox)sender;
                    int SaftCode = 0;
                    int txtNum = 0;

                    for (int i = 1; i <= Codes.Length; i++)
                    {
                        if (mytxt.Name.Contains(i.ToString()))
                        {
                            txtNum = i - 1;
                        }
                    }

                    if (int.TryParse(mytxt.Text, out int a))
                    {
                        SaftCode = int.Parse(mytxt.Text);
                        SqlCommand cmd = new SqlCommand("SELECT Kion_Code,Kion_DTC FROM FaultCodes WHERE Saft_Code = '" + SaftCode + "'", conn);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                while (reader.Read())
                                {
                                    Codes[txtNum].Text = reader["Kion_Code"].ToString();
                                    DTCs[txtNum].Text = reader["Kion_DTC"].ToString();
                                }
                            }
                            else
                            {
                                Codes[txtNum].Text = "0";
                                DTCs[txtNum].Text = "0";
                            }

                        }
                        conn.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dateWarranty_ValueChanged(object sender, EventArgs e)
        {
            changeDate();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("UPDATE DataAnalysis_BB SET Battery='" + txtBattery.Text + "', BMS='" + txtBMS.Text + "', ModuleVoltage_State='" + cmbVoltage.Text + "', ModuleVoltage=@modVoltage, Funct_BMS_State='" + cmbFunctBMS.Text + "', Funct_BMS='" + txtFunctionalBMS.Text + "', WinDiag_State='" + cmbWinDiag.Text + "', WinDiag='" + txtWinDiag.Text + "', ActualCurr_State='" + cmbActualCurr.Text + "', ActualCurr='" + txtActualCurr.Text + "', Presence_State='" + cmbPresence.Text + "', Presence_State12='" + cmbPresence12.Text + "', Presence_State24='" + cmbPresence24.Text + "', Presence='" + txtPresence.Text + "', SMU_State='" + cmbSMU.Text + "', SMU_Val=@smuVal, Current_Const_State='" + cmbCurrentConst.Text + "', Current_Const_IG='" + txtIG.Text + "', Current_Const_IO='" + txtIO.Text + "', CAN_Speed_State='" + cmbCANSpeed.Text + "', CAN_Speed_Val='" + txtCanSpeed.Text + "', CRC_of_SW_State='" + cmbCRCofSW.Text + "', CRC_of_SW='" + txtCRCofSW.Text + "', BB_State='" + cmbBB.Text + "', BB='" + txtBB.Text + "', Saft_Fault_Code_State='" + cmbSaftCode.Text + "', Kion_Fault_Code_State='" + cmbKionCode.Text + "', Kion_DTC_State='" + cmbKionDTC.Text + "', Saft_Fault_Code_1=@saftCode1, Saft_Fault_Code_2=@saftCode2, Saft_Fault_Code_3=@saftCode3, Saft_Fault_Code_4=@saftCode4, Saft_Fault_Code_5=@saftCode5, Saft_Fault_Code_6=@saftCode6, Saft_Fault_Code_7=@saftCode7, Saft_Fault_Code_8=@saftCode8, Saft_Fault_Code_9=@saftCode9, Saft_Fault_Code_10=@saftCode10, Saft_Fault_Code_11=@saftCode11, Saft_Fault_Code_12=@saftCode12, Kion_Fault_Code_1=@kionCode1, Kion_Fault_Code_2=@kionCode2, Kion_Fault_Code_3=@kionCode3, Kion_Fault_Code_4=@kionCode4, Kion_Fault_Code_5=@kionCode5, Kion_Fault_Code_6=@kionCode6, Kion_Fault_Code_7=@kionCode7, Kion_Fault_Code_8=@kionCode8, Kion_Fault_Code_9=@kionCode9, Kion_Fault_Code_10=@kionCode10, Kion_Fault_Code_11=@kionCode11, Kion_Fault_Code_12=@kionCode12, Kion_DTC_1=@dtcCode1, Kion_DTC_2=@dtcCode2, Kion_DTC_3=@dtcCode3, Kion_DTC_4=@dtcCode4, Kion_DTC_5=@dtcCode5, Kion_DTC_6=@dtcCode6, Kion_DTC_7=@dtcCode7, Kion_DTC_8=@dtcCode8, Kion_DTC_9=@dtcCode9, Kion_DTC_10=@dtcCode10, Kion_DTC_11=@dtcCode11, Kion_DTC_12=@dtcCode12, Charging_State='" + cmbCharging.Text + "', Charging='" + txtCharging.Text + "', Discharging_State='" + cmbDischarging.Text + "', discharging='" + txtDischarging.Text + "', RTC_State='" + cmbRTC.Text + "', RTC='" + txtRTC.Text + "', BMS_Tested_State='" + cmbBMSTested.Text + "', BMS_Tested='" + txtBMSTested.Text + "', Replacement_State='" + cmbReplacement.Text + "', Replacement='" + txtReplacement.Text + "', Status_State='" + cmbStatus.Text + "', Status='" + txtStatus.Text + "', Warranty_State='" + cmbWarranty.Text + "', Warranty='" + txtWarranty.Text + "', Production_Date='" + dateWarranty.Text + "', Now_Date='" + dateNow.Text + "' WHERE CLM='" + CLM + "'", conn);
                cmd.Parameters.Add("@modVoltage", SqlDbType.Real).Value = txtVoltage.Text == "" ? 0 : float.Parse(txtVoltage.Text);
                cmd.Parameters.Add("@smuVal", SqlDbType.Real).Value = txtSMUVal.Text == "" ? 0 : float.Parse(txtSMUVal.Text);

                cmd.Parameters.Add("@saftCode1", SqlDbType.Int).Value = txtSaftCode1.Text == "" ? 0 : Int16.Parse(txtSaftCode1.Text);
                cmd.Parameters.Add("@saftCode2", SqlDbType.Int).Value = txtSaftCode2.Text == "" ? 0 : Int16.Parse(txtSaftCode2.Text);
                cmd.Parameters.Add("@saftCode3", SqlDbType.Int).Value = txtSaftCode3.Text == "" ? 0 : Int16.Parse(txtSaftCode3.Text);
                cmd.Parameters.Add("@saftCode4", SqlDbType.Int).Value = txtSaftCode4.Text == "" ? 0 : Int16.Parse(txtSaftCode4.Text);
                cmd.Parameters.Add("@saftCode5", SqlDbType.Int).Value = txtSaftCode5.Text == "" ? 0 : Int16.Parse(txtSaftCode5.Text);
                cmd.Parameters.Add("@saftCode6", SqlDbType.Int).Value = txtSaftCode6.Text == "" ? 0 : Int16.Parse(txtSaftCode6.Text);
                cmd.Parameters.Add("@saftCode7", SqlDbType.Int).Value = txtSaftCode7.Text == "" ? 0 : Int16.Parse(txtSaftCode7.Text);
                cmd.Parameters.Add("@saftCode8", SqlDbType.Int).Value = txtSaftCode8.Text == "" ? 0 : Int16.Parse(txtSaftCode8.Text);
                cmd.Parameters.Add("@saftCode9", SqlDbType.Int).Value = txtSaftCode9.Text == "" ? 0 : Int16.Parse(txtSaftCode9.Text);
                cmd.Parameters.Add("@saftCode10", SqlDbType.Int).Value = txtSaftCode10.Text == "" ? 0 : Int16.Parse(txtSaftCode10.Text);
                cmd.Parameters.Add("@saftCode11", SqlDbType.Int).Value = txtSaftCode11.Text == "" ? 0 : Int16.Parse(txtSaftCode11.Text);
                cmd.Parameters.Add("@saftCode12", SqlDbType.Int).Value = txtSaftCode12.Text == "" ? 0 : Int16.Parse(txtSaftCode12.Text);

                cmd.Parameters.Add("@kionCode1", SqlDbType.Int).Value = txtKionCode1.Text == "" ? 0 : Int16.Parse(txtKionCode1.Text);
                cmd.Parameters.Add("@kionCode2", SqlDbType.Int).Value = txtKionCode2.Text == "" ? 0 : Int16.Parse(txtKionCode2.Text);
                cmd.Parameters.Add("@kionCode3", SqlDbType.Int).Value = txtKionCode3.Text == "" ? 0 : Int16.Parse(txtKionCode3.Text);
                cmd.Parameters.Add("@kionCode4", SqlDbType.Int).Value = txtKionCode4.Text == "" ? 0 : Int16.Parse(txtKionCode4.Text);
                cmd.Parameters.Add("@kionCode5", SqlDbType.Int).Value = txtKionCode5.Text == "" ? 0 : Int16.Parse(txtKionCode5.Text);
                cmd.Parameters.Add("@kionCode6", SqlDbType.Int).Value = txtKionCode6.Text == "" ? 0 : Int16.Parse(txtKionCode6.Text);
                cmd.Parameters.Add("@kionCode7", SqlDbType.Int).Value = txtKionCode7.Text == "" ? 0 : Int16.Parse(txtKionCode7.Text);
                cmd.Parameters.Add("@kionCode8", SqlDbType.Int).Value = txtKionCode8.Text == "" ? 0 : Int16.Parse(txtKionCode8.Text);
                cmd.Parameters.Add("@kionCode9", SqlDbType.Int).Value = txtKionCode9.Text == "" ? 0 : Int16.Parse(txtKionCode9.Text);
                cmd.Parameters.Add("@kionCode10", SqlDbType.Int).Value = txtKionCode10.Text == "" ? 0 : Int16.Parse(txtKionCode10.Text);
                cmd.Parameters.Add("@kionCode11", SqlDbType.Int).Value = txtKionCode11.Text == "" ? 0 : Int16.Parse(txtKionCode11.Text);
                cmd.Parameters.Add("@kionCode12", SqlDbType.Int).Value = txtKionCode12.Text == "" ? 0 : Int16.Parse(txtKionCode12.Text);

                cmd.Parameters.Add("@dtcCode1", SqlDbType.Int).Value = txtKionDTC1.Text == "" ? 0 : Int16.Parse(txtKionDTC1.Text);
                cmd.Parameters.Add("@dtcCode2", SqlDbType.Int).Value = txtKionDTC2.Text == "" ? 0 : Int16.Parse(txtKionDTC2.Text);
                cmd.Parameters.Add("@dtcCode3", SqlDbType.Int).Value = txtKionDTC3.Text == "" ? 0 : Int16.Parse(txtKionDTC3.Text);
                cmd.Parameters.Add("@dtcCode4", SqlDbType.Int).Value = txtKionDTC4.Text == "" ? 0 : Int16.Parse(txtKionDTC4.Text);
                cmd.Parameters.Add("@dtcCode5", SqlDbType.Int).Value = txtKionDTC5.Text == "" ? 0 : Int16.Parse(txtKionDTC5.Text);
                cmd.Parameters.Add("@dtcCode6", SqlDbType.Int).Value = txtKionDTC6.Text == "" ? 0 : Int16.Parse(txtKionDTC6.Text);
                cmd.Parameters.Add("@dtcCode7", SqlDbType.Int).Value = txtKionDTC7.Text == "" ? 0 : Int16.Parse(txtKionDTC7.Text);
                cmd.Parameters.Add("@dtcCode8", SqlDbType.Int).Value = txtKionDTC8.Text == "" ? 0 : Int16.Parse(txtKionDTC8.Text);
                cmd.Parameters.Add("@dtcCode9", SqlDbType.Int).Value = txtKionDTC9.Text == "" ? 0 : Int16.Parse(txtKionDTC9.Text);
                cmd.Parameters.Add("@dtcCode10", SqlDbType.Int).Value = txtKionDTC10.Text == "" ? 0 : Int16.Parse(txtKionDTC10.Text);
                cmd.Parameters.Add("@dtcCode11", SqlDbType.Int).Value = txtKionDTC11.Text == "" ? 0 : Int16.Parse(txtKionDTC11.Text);
                cmd.Parameters.Add("@dtcCode12", SqlDbType.Int).Value = txtKionDTC12.Text == "" ? 0 : Int16.Parse(txtKionDTC12.Text);

                conn.Open();
                int res = cmd.ExecuteNonQuery();
                conn.Close();
                if (res > 0)
                {
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
