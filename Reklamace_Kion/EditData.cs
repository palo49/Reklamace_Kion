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
    public partial class EditData : Form
    {

        public int MyLevel { get; set; }
        public int CLMID { get; set; }

        SqlConnection conn = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace");

        public EditData()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string CLM = txtCLM.Text;
                string Status = cmbState.Text;
                string CustomerRequire = txtCustomerRequest.Text;
                string Pozadavek = txtPozadavek.Text;
                string DateOfCustomerSendVal = DateOfCustomerSend.Value.ToShortDateString();
                string DateOfSaftAcceptanceVal = DateOfSaftAcceptance.Value.ToShortDateString();
                string DateOfRepairVal = DateOfRepair.Value.ToShortDateString();
                string DateOfSaftSendVal = DateOfSaftSend.Value.ToShortDateString();
                string PNBattery = cmbPNBattery.Text;
                string SNBattery = txtSNBattery.Text;
                string PNClaimedComponent = cmbPNComponent.Text;
                string SNClaimedComponent = txtSNComponent.Text;
                string Fault = txtFault.Text;
                string CW = cmbCW.Text;
                string DefectBMS = cmbDefects.Text;
                string LocationOfBattery = txtLocationOfBattery.Text;
                string ReplacementSend = cmbReplacementSend.Text;
                string DateOfSendReplacement = DateOfReplacementSend.Value.ToShortDateString();
                string Result = cmbResult.Text;
                string ResultDescription = txtResultDescription.Text;
                string ContactCompany = cmbContacts.Text;
                string ContactLastName = txtContactLastName.Text;
                string ContactFirstName = txtContactFirstName.Text;
                string ContactEmail = txtContactEmail.Text;
                string Contact = ContactCompany + ";" + ContactEmail + ";";
                decimal Tariff_Repairman = decimal.Parse(numTariffRepairman.Text);
                decimal Hours_Repairman = decimal.Parse(numHoursRepairman.Text);
                decimal Tariff_Technician = decimal.Parse(numTariffTechnician.Text);
                decimal Hours_Technician = decimal.Parse(numHoursTechnician.Text);
                decimal Tariff_Administration = decimal.Parse(numTariffAdministration.Text);
                decimal Hours_Administration = decimal.Parse(numHoursAdministration.Text);
                decimal CostOfComponents = Convert.ToDecimal(numCostOfComponents.Text, CultureInfo.CurrentCulture);
                string Note1 = txtNote1.Text;
                string Note2 = txtNote2.Text;
                decimal finalPrice = (Tariff_Repairman * Hours_Repairman) + (Tariff_Technician * Hours_Technician) + (Tariff_Administration * Hours_Administration) + CostOfComponents;
                
                if (DateOfCustomerSend.Value.ToShortDateString() == "01.01.1753") { DateOfCustomerSendVal = string.Empty; }
                if (DateOfSaftAcceptance.Value.ToShortDateString() == "01.01.1753") { DateOfSaftAcceptanceVal = string.Empty; }
                if (DateOfRepair.Value.ToShortDateString() == "01.01.1753") { DateOfRepairVal = string.Empty; }
                if (DateOfSaftSend.Value.ToShortDateString() == "01.01.1753") { DateOfSaftSendVal = string.Empty; }
                if (DateOfReplacementSend.Value.ToShortDateString() == "01.01.1753") { DateOfSendReplacement = string.Empty; }

                SqlCommand cmd; 

                conn.Open();
                
                if (Contact == ";;")
                {
                    cmd = new SqlCommand("UPDATE DataMain SET State='" + Status + "', Customer_Require='" + CustomerRequire + "', Pozadavek='" + Pozadavek + "', Date_Of_Customer_Send='" + DateOfCustomerSendVal + "', Date_Of_Saft_Acceptance='" + DateOfSaftAcceptanceVal + "', Date_Of_Repair='" + DateOfRepairVal + "', Date_Of_Saft_Send='" + DateOfSaftSendVal + "', PN_Battery='" + PNBattery + "', Fault='" + Fault + "', Type_CW='" + CW + "', Defect_BMS='" + DefectBMS + "', Location_Of_Battery='" + LocationOfBattery + "', Replacement_Send='" + ReplacementSend + "', Date_Of_Replacement_Send='" + DateOfSendReplacement + "', Result='" + Result + "', Result_Description='" + ResultDescription + "', Tariff_Repairman='" + Tariff_Repairman + "', Hours_Repairman='" + Hours_Repairman + "', Tariff_Technician='" + Tariff_Technician + "', Hours_Technician='" + Hours_Technician + "', Tariff_Administration='" + Tariff_Administration + "', Hours_Administration='" + Hours_Administration + "', Cost_Of_Components=@components, Cost_Of_Repair=@finalPrice, Note_1='" + Note1 + "', Note_2='" + Note2 + "'  WHERE CLM='" + CLM + "'", conn);
                }
                else
                {
                    cmd = new SqlCommand("UPDATE DataMain SET State='" + Status + "', Customer_Require='" + CustomerRequire + "', Pozadavek='" + Pozadavek + "', Date_Of_Customer_Send='" + DateOfCustomerSendVal + "', Date_Of_Saft_Acceptance='" + DateOfSaftAcceptanceVal + "', Date_Of_Repair='" + DateOfRepairVal + "', Date_Of_Saft_Send='" + DateOfSaftSendVal + "', PN_Battery='" + PNBattery + "', Fault='" + Fault + "', Type_CW='" + CW + "', Defect_BMS='" + DefectBMS + "', Location_Of_Battery='" + LocationOfBattery + "', Replacement_Send='" + ReplacementSend + "', Date_Of_Replacement_Send='" + DateOfSendReplacement + "', Result='" + Result + "', Result_Description='" + ResultDescription + "', Contact='" + Contact + "', Tariff_Repairman='" + Tariff_Repairman + "', Hours_Repairman='" + Hours_Repairman + "', Tariff_Technician='" + Tariff_Technician + "', Hours_Technician='" + Hours_Technician + "', Tariff_Administration='" + Tariff_Administration + "', Hours_Administration='" + Hours_Administration + "', Cost_Of_Components=@components, Cost_Of_Repair=@finalPrice, Note_1='" + Note1 + "', Note_2='" + Note2 + "'  WHERE CLM='" + CLM + "'", conn);
                }

                cmd.Parameters.Add("@components", SqlDbType.Decimal).Value = CostOfComponents;
                cmd.Parameters.Add("@finalPrice", SqlDbType.Decimal).Value = finalPrice;
                int res = cmd.ExecuteNonQuery();

                conn.Close();

                string strRepair = "SELECT COUNT(*) from DataRepairs where CLM like '" + CLM + "'";
                SqlCommand cmdCount = new SqlCommand(strRepair, conn);

                conn.Open();
                int dataCount = (int)cmdCount.ExecuteScalar();

                if (dataCount > 0)
                {
                    SqlCommand cmdRepair = new SqlCommand("UPDATE DataRepairs SET Pozadavek='" + Pozadavek + "' WHERE CLM='" + CLM + "'", conn);
                    cmdRepair.ExecuteNonQuery();
                }
                conn.Close();

                if (res > 0)
                {
                    Main.ReloadData();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Editace nebyla úspěšná!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void EmptyDate(DateTimePicker picker)
        {
            picker.Value = DateTimePicker.MinimumDateTime;
            picker.CustomFormat = " ";
            picker.Format = DateTimePickerFormat.Custom;
        }

        private void EditData_Load(object sender, EventArgs e)
        {
            if (MyLevel >= 5)
            {
                if (MyLevel == 5 || MyLevel == 100) { numTariffRepairman.Enabled = true; numHoursRepairman.Enabled = true; }
                if (MyLevel == 10 || MyLevel == 100) { numTariffAdministration.Enabled = true; numHoursAdministration.Enabled = true; }
                if (MyLevel == 20 || MyLevel == 100) { numTariffTechnician.Enabled = true; numHoursTechnician.Enabled = true; }

                numCostOfComponents.Enabled = true;
            }
            if (MyLevel >= 10)
            {
                cmbState.Enabled = true;
                DateOfCustomerSend.Enabled = true;
                DateOfSaftAcceptance.Enabled = true;
                DateOfRepair.Enabled = true;
                DateOfSaftSend.Enabled = true;
                cmbReplacementSend.Enabled = true;
                DateOfReplacementSend.Enabled = true;
                txtFault.Enabled = true;
                cmbCW.Enabled = true;
                cmbDefects.Enabled = true;
                txtLocationOfBattery.Enabled = true;
                txtCustomerRequest.Enabled = true;
                cmbResult.Enabled = true;
                txtResultDescription.Enabled = true;
                cmbContacts.Enabled = true;
                txtNote1.Enabled = true;
                txtNote2.Enabled = true;
            }
            if (MyLevel >= 100)
            {
                txtCLM.Enabled = true;
                cmbPNBattery.Enabled = true; 
                txtSNBattery.Enabled = true; txtSNBattery.ReadOnly = false;
                cmbPNComponent.Enabled = true;
                txtSNComponent.Enabled = true; txtSNComponent.ReadOnly = false;
            }

            try
            {
                conn.Open();

                SqlDataAdapter da = new SqlDataAdapter("SELECT Name FROM DataComponents", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbPNComponent.DataSource = dt;
                cmbPNComponent.DisplayMember = "Name";
                cmbPNComponent.ValueMember = "Name";

                SqlDataAdapter da2 = new SqlDataAdapter("SELECT Name FROM DataDefects", conn);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                cmbDefects.DataSource = dt2;
                cmbDefects.DisplayMember = "Name";
                cmbDefects.ValueMember = "Name";

                SqlDataAdapter da3 = new SqlDataAdapter("SELECT Id, Company, Last_Name, First_Name, Email, (Company + ' | ' + Last_Name + ' ' + First_Name) AS Comp FROM Contacts", conn);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);
                dt3.DefaultView.Sort = "Company";
                cmbContacts.DataSource = dt3;
                cmbContacts.DisplayMember = "Comp";
                cmbContacts.ValueMember = "Id";
                cmbContacts.SelectedIndex = -1;
                txtContactId.Text = "";

                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM DataMain WHERE DataId='" + CLMID + "'", conn);

                conn.Open();

                using (SqlDataReader data = cmd.ExecuteReader())
                {
                    while (data.Read())
                    {
                        txtCLM.Text = data.GetString(1);
                        cmbState.Text = data.GetString(2);
                        txtCustomerRequest.Text = data.GetString(3);
                        txtPozadavek.Text = data.GetString(4); 

                        if (data.GetString(5) == String.Empty)
                        {
                            EmptyDate(DateOfCustomerSend);
                        }
                        else
                        {
                            DateOfCustomerSend.Value = Convert.ToDateTime(data.GetString(5));
                        }
                        if (data.GetString(6) == String.Empty)
                        {
                            EmptyDate(DateOfSaftAcceptance);
                        }
                        else
                        {
                            DateOfSaftAcceptance.Value = Convert.ToDateTime(data.GetString(6));
                        }
                        if (data.GetString(7) == String.Empty)
                        {
                            EmptyDate(DateOfRepair);
                        }
                        else
                        {
                            DateOfRepair.Value = Convert.ToDateTime(data.GetString(7));
                        }
                        if (data.GetString(8) == String.Empty)
                        {
                            EmptyDate(DateOfSaftSend);
                        }
                        else
                        {
                            DateOfSaftSend.Value = Convert.ToDateTime(data.GetString(8));
                        }

                        string pnstring = data.GetString(9);
                        if (pnstring == "A1") { pnstring = "775369_A1"; }
                        else if (pnstring == "A2") { pnstring = "774166_A2"; }
                        else if (pnstring == "B1") { pnstring = "776445_B1"; }
                        else if (pnstring == "B2") { pnstring = "774100_B2"; }
                        if (cmbPNBattery.Items.Contains(pnstring))
                        {
                            cmbPNBattery.Text = pnstring;
                        }
                        else
                        {
                            cmbPNBattery.SelectedIndex = -1;
                        }
                        txtSNBattery.Text = data.GetString(10);
                        if (cmbPNComponent.Text.Contains(data.GetString(11)))
                        {
                            cmbPNComponent.Text = data.GetString(11);
                        }
                        else
                        {
                            cmbPNComponent.SelectedIndex = -1;
                        }
                        txtSNComponent.Text = data.GetString(12);
                        txtFault.Text = data.GetString(13);
                        cmbCW.Text = data.GetString(14);

                        if (data.GetString(15) == String.Empty)
                        {
                            cmbDefects.SelectedIndex = -1;
                        }
                        else
                        {
                            cmbDefects.Text = data.GetString(15);
                        }
                        
                        txtLocationOfBattery.Text = data.GetString(16);
                        cmbReplacementSend.Text = data.GetString(17);

                        if (data.GetString(18) == String.Empty)
                        {
                            EmptyDate(DateOfReplacementSend);
                        }
                        else
                        {
                            DateOfReplacementSend.Value = Convert.ToDateTime(data.GetString(18));
                        }
                        
                        cmbResult.Text = data.GetString(19);
                        txtResultDescription.Text = data.GetString(20);
                        //cmbContacts.Text = data.GetString(20);
                        numTariffRepairman.Value = Convert.ToInt32(data.GetDouble(22));
                        numHoursRepairman.Value = Convert.ToInt32(data.GetDouble(23));
                        numTariffTechnician.Value = Convert.ToInt32(data.GetDouble(24));
                        numHoursTechnician.Value = Convert.ToInt32(data.GetDouble(25));
                        numTariffAdministration.Value = Convert.ToInt32(data.GetDouble(26));
                        numHoursAdministration.Value = Convert.ToInt32(data.GetDouble(27));
                        numCostOfComponents.Value = data.GetDecimal(28);
                        txtCostOfRepair.Text = data.GetDecimal(29).ToString();
                        txtNote1.Text = data.GetString(30);
                        txtNote2.Text = data.GetString(31);
                    }
                }

                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show(ex.Message);
            }

            // Disable mouse wheel on comboboxes and numerics
            foreach (ComboBox cmb in panelControls.Controls.OfType<ComboBox>())
            {
                cmb.MouseWheel += (o, ee) => ((HandledMouseEventArgs)ee).Handled = true;
            }

            foreach (NumericUpDown num in panelControls.Controls.OfType<NumericUpDown>())
            {
                num.MouseWheel += (o, ee) => ((HandledMouseEventArgs)ee).Handled = true;
            }
        }

        private void btnClearDateSendFromCustomer_Click(object sender, EventArgs e)
        {
            if (MyLevel == 10 || MyLevel >= 100)
            {
                DateOfCustomerSend.Value = DateTimePicker.MinimumDateTime;
                DateOfCustomerSend.CustomFormat = " ";
                DateOfCustomerSend.Format = DateTimePickerFormat.Custom;
            }
        }

        private void DateOfCustomerSend_ValueChanged(object sender, EventArgs e)
        {
            DateOfCustomerSend.Format = DateTimePickerFormat.Short;
        }

        private void btnClearDateOfSaftAccept_Click(object sender, EventArgs e)
        {
            if (MyLevel == 10 || MyLevel >= 100)
            {
                DateOfSaftAcceptance.Value = DateTimePicker.MinimumDateTime;
                DateOfSaftAcceptance.CustomFormat = " ";
                DateOfSaftAcceptance.Format = DateTimePickerFormat.Custom;
            }
        }

        private void DateOfSaftAcceptance_ValueChanged(object sender, EventArgs e)
        {
            DateOfSaftAcceptance.Format = DateTimePickerFormat.Short;
        }

        private void btnClearDateOfRepair_Click(object sender, EventArgs e)
        {
            if (MyLevel == 10 || MyLevel >= 100)
            {
                DateOfRepair.Value = DateTimePicker.MinimumDateTime;
                DateOfRepair.CustomFormat = " ";
                DateOfRepair.Format = DateTimePickerFormat.Custom;
            }
        }

        private void DateOfRepair_ValueChanged(object sender, EventArgs e)
        {
            DateOfRepair.Format = DateTimePickerFormat.Short;
        }

        private void btnClearDateOfSaftSend_Click(object sender, EventArgs e)
        {
            if (MyLevel == 10 || MyLevel >= 100)
            {
                DateOfSaftSend.Value = DateTimePicker.MinimumDateTime;
                DateOfSaftSend.CustomFormat = " ";
                DateOfSaftSend.Format = DateTimePickerFormat.Custom;
            }
        }

        private void DateOfSaftSend_ValueChanged(object sender, EventArgs e)
        {
            DateOfSaftSend.Format = DateTimePickerFormat.Short;
        }

        private void btnClearDateOfReplacementSend_Click(object sender, EventArgs e)
        {
            if (MyLevel == 10 || MyLevel >= 100)
            {
                DateOfReplacementSend.Value = DateTimePicker.MinimumDateTime;
                DateOfReplacementSend.CustomFormat = " ";
                DateOfReplacementSend.Format = DateTimePickerFormat.Custom;
            }
        }

        private void DateOfReplacementSend_ValueChanged(object sender, EventArgs e)
        {
            DateOfReplacementSend.Format = DateTimePickerFormat.Short;
        }

        private void cmbPNComponent_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPNComponent.Text == cmbPNBattery.Text)
            {
                txtSNComponent.Text = txtSNBattery.Text;
            }
        }

        private void btnClearDefekt_Click(object sender, EventArgs e)
        {
            if (MyLevel == 10 || MyLevel >= 100)
            {
                cmbDefects.SelectedIndex = -1;
            }
        }

        private void cmbContacts_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbContacts.SelectedIndex != -1)
                {
                    txtContactId.Text = cmbContacts.SelectedValue.ToString();
                    SqlConnection sqlConnection = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace");
                    sqlConnection.Open();
                    string sqlData = "SELECT Last_Name, First_Name, Email from Contacts where Id like '" + cmbContacts.SelectedValue.ToString() + "'";
                    SqlCommand cmd = new SqlCommand(sqlData, sqlConnection);
                    SqlDataReader DR1 = cmd.ExecuteReader();
                    if (DR1.Read())
                    {
                        txtContactLastName.Text = DR1.GetValue(0).ToString();
                        txtContactFirstName.Text = DR1.GetValue(1).ToString();
                        txtContactEmail.Text = DR1.GetValue(2).ToString();
                    }
                    sqlConnection.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void UpdateFinalPrice()
        {
            try
            {
                float Tariff_Repairman = (float)numTariffRepairman.Value;
                float Hours_Repairman = (float)numHoursRepairman.Value;
                float Tariff_Technician = (float)numTariffTechnician.Value;
                float Hours_Technician = (float)numHoursTechnician.Value;
                float Tariff_Administration = (float)numTariffAdministration.Value;
                float Hours_Administration = (float)numHoursAdministration.Value;
                float CostOfComponents = (float)numCostOfComponents.Value;

                float finalPrice = (Tariff_Repairman * Hours_Repairman) + (Tariff_Technician * Hours_Technician) + (Tariff_Administration * Hours_Administration) + CostOfComponents;

                txtCostOfRepair.Text = finalPrice.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateFinalPrice(object sender, EventArgs e)
        {
            UpdateFinalPrice();
        }

        private void EditData_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
