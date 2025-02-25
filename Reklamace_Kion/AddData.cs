﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
        static SqlConnection conn = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace");
        SqlDataAdapter da3 = new SqlDataAdapter("SELECT Id, Company, Last_Name, First_Name, Email, (Company + ' | ' + Last_Name + ' ' + First_Name) AS Comp FROM Contacts", conn);
        DataTable dt3 = new DataTable();

        private void AddData_Load(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace"))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT Name FROM DataComponents", sqlConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                cmbPNComponent.DataSource = dt;
                cmbPNComponent.DisplayMember = "Name";
                cmbPNComponent.ValueMember = "Name";

                SqlDataAdapter da2 = new SqlDataAdapter("SELECT Name FROM DataDefects", sqlConnection);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                cmbDefects.DataSource = dt2;
                cmbDefects.DisplayMember = "Name";
                cmbDefects.ValueMember = "Name";

                
                da3.Fill(dt3);
                dt3.DefaultView.Sort = "Company";
                cmbContacts.DataSource = dt3;
                cmbContacts.DisplayMember = "Comp";
                cmbContacts.ValueMember = "Id";
                cmbContacts.SelectedIndex = -1;
                txtContactId.Text = "";
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
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
            float Tariff_Repairman = float.Parse(numTariffRepairman.Text);
            float Hours_Repairman = float.Parse(numHoursRepairman.Text);
            float Tariff_Technician = float.Parse(numTariffTechnician.Text);
            float Hours_Technician = float.Parse(numHoursTechnician.Text);
            float Tariff_Administration = float.Parse(numTariffAdministration.Text);
            float Hours_Administration = float.Parse(numHoursAdministration.Text);
            float CostOfComponents = float.Parse(numCostOfComponents.Text);
            string Note1 = txtNote1.Text;
            string Note2 = txtNote2.Text;

            if (DateOfCustomerSend.Value.ToShortDateString() == "01.01.1753") { DateOfCustomerSendVal = string.Empty; }
            if (DateOfSaftAcceptance.Value.ToShortDateString() == "01.01.1753") { DateOfSaftAcceptanceVal = string.Empty; }
            if (DateOfRepair.Value.ToShortDateString() == "01.01.1753") { DateOfRepairVal = string.Empty; }
            if (DateOfSaftSend.Value.ToShortDateString() == "01.01.1753") { DateOfSaftSendVal = string.Empty; }
            if (DateOfReplacementSend.Value.ToShortDateString() == "01.01.1753") { DateOfSendReplacement = string.Empty; }

            float finalPrice = (Tariff_Repairman * Hours_Repairman) + (Tariff_Technician * Hours_Technician) + (Tariff_Administration * Hours_Administration) + CostOfComponents;

            if ((CLM != string.Empty) && (Status != string.Empty) && (PNClaimedComponent != string.Empty) && (SNClaimedComponent != string.Empty))
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
                        Cursor.Current = Cursors.WaitCursor;

                        string sqlInsert = "INSERT INTO DataMain values('" + CLM + "','" + Status + "','" + CustomerRequire + "', '" + Pozadavek + "', '" + DateOfCustomerSendVal + "','" + DateOfSaftAcceptanceVal + "'," +
                            "'" + DateOfRepairVal + "','" + DateOfSaftSendVal + "','" + PNBattery + "','" + SNBattery + "','" + PNClaimedComponent + "','" + SNClaimedComponent + "'," +
                            "'" + Fault + "','" + CW + "','" + DefectBMS + "','" + LocationOfBattery + "','" + ReplacementSend + "'," +
                            "'" + DateOfSendReplacement + "','" + Result + "','" + ResultDescription + "','" + Contact + "','" + Tariff_Repairman + "','" + Hours_Repairman + "','" + Tariff_Technician + "','" + Hours_Technician + "','" + Tariff_Administration + "','" + Hours_Administration + "','" + CostOfComponents + "','" + finalPrice + "', '" + Note1 + "', '" + Note2 + "')";

                        SqlCommand cmdInsert = new SqlCommand(sqlInsert, conn);
                        conn.Open();
                        cmdInsert.ExecuteNonQuery();
                        conn.Close();

                        // Vytvoření složek
                        /////////////////////////////////////////////////////////
                        ///

                        string dir = @"\\cz-ras-fs2\Applications\KION\10_Reklamace\KionApp\";
                        string CLMDir = CLM;
                        string BatteryDir = "undefined";
                        string ComponentDir = PNClaimedComponent.Substring(0,6) + "_" + SNClaimedComponent;

                        if ((PNBattery != string.Empty) || (SNBattery != string.Empty))
                        {
                            BatteryDir = PNBattery.Substring(0, 6) + "_" + SNBattery;
                        }

                        string path = dir + CLMDir + @"\" + BatteryDir + @"\" + ComponentDir;

                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                            Directory.CreateDirectory(path + @"\01_Dokumenty");
                            CloneDirectory(@"\\cz-ras-fs2\Applications\Reklamace Kion App\Data\ToCopy\02_Interni_hodnoceni", path + @"\02_Interni_hodnoceni");
                            Directory.CreateDirectory(path + @"\03_Vyjadreni_pro_zakaznika");
                            File.Copy(@"\\cz-ras-fs2\Applications\Reklamace Kion App\Data\ToCopy\03_Vyjadreni_pro_zakaznika\TE_template.xlsx", path + @"\03_Vyjadreni_pro_zakaznika\TE_template.xlsx");
                            File.Copy(@"\\cz-ras-fs2\Applications\Reklamace Kion App\Data\ToCopy\BMSAnalysis_template.xlsx", path + @"\BMSAnalysis_" + ComponentDir + ".xlsx");
                        }

                        ///////////////////////////////////////////////////////

                        Main.ReloadData();
                        Cursor.Current = Cursors.Default;
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
                MessageBox.Show("CLM, Status, PN a S/N komponenty jsou povinná pole.");
            }
        }

        private static void CloneDirectory(string root, string dest)
        {
            try
            {
                foreach (var directory in Directory.GetDirectories(root))
                {
                    string dirName = Path.GetFileName(directory);
                    if (!Directory.Exists(Path.Combine(dest, dirName)))
                    {
                        Directory.CreateDirectory(Path.Combine(dest, dirName));
                    }
                    CloneDirectory(directory, Path.Combine(dest, dirName));
                }

                foreach (var file in Directory.GetFiles(root))
                {
                    File.Copy(file, Path.Combine(dest, Path.GetFileName(file)));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void numTariffRepairman_ValueChanged(object sender, EventArgs e)
        {
            UpdateFinalPrice();
        }

        private void numTariffTechnician_ValueChanged(object sender, EventArgs e)
        {
            UpdateFinalPrice();
        }

        private void numTariffAdministration_ValueChanged(object sender, EventArgs e)
        {
            UpdateFinalPrice();
        }

        private void numHoursRepairman_ValueChanged(object sender, EventArgs e)
        {
            UpdateFinalPrice();
        }

        private void numHoursTechnician_ValueChanged(object sender, EventArgs e)
        {
            UpdateFinalPrice();
        }

        private void numHoursAdministration_ValueChanged(object sender, EventArgs e)
        {
            UpdateFinalPrice();
        }

        private void numCostOfComponents_ValueChanged(object sender, EventArgs e)
        {
            UpdateFinalPrice();
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

        private void btnClearDateSendFromCustomer_Click(object sender, EventArgs e)
        {
            DateOfCustomerSend.Value = DateTimePicker.MinimumDateTime;
            DateOfCustomerSend.CustomFormat = " ";
            DateOfCustomerSend.Format = DateTimePickerFormat.Custom;
        }

        private void DateOfCustomerSend_ValueChanged(object sender, EventArgs e)
        {
            DateOfCustomerSend.Format = DateTimePickerFormat.Short;
        }

        private void btnClearDateOfSaftAccept_Click(object sender, EventArgs e)
        {
            DateOfSaftAcceptance.Value = DateTimePicker.MinimumDateTime;
            DateOfSaftAcceptance.CustomFormat = " ";
            DateOfSaftAcceptance.Format = DateTimePickerFormat.Custom;
        }

        private void DateOfSaftAcceptance_ValueChanged(object sender, EventArgs e)
        {
            DateOfSaftAcceptance.Format = DateTimePickerFormat.Short;
        }

        private void btnClearDateOfRepair_Click(object sender, EventArgs e)
        {
            DateOfRepair.Value = DateTimePicker.MinimumDateTime;
            DateOfRepair.CustomFormat = " ";
            DateOfRepair.Format = DateTimePickerFormat.Custom;
        }

        private void DateOfRepair_ValueChanged(object sender, EventArgs e)
        {
            DateOfRepair.Format = DateTimePickerFormat.Short;
        }

        private void btnClearDateOfSaftSend_Click(object sender, EventArgs e)
        {
            DateOfSaftSend.Value = DateTimePicker.MinimumDateTime;
            DateOfSaftSend.CustomFormat = " ";
            DateOfSaftSend.Format = DateTimePickerFormat.Custom;
        }

        private void DateOfSaftSend_ValueChanged(object sender, EventArgs e)
        {
            DateOfSaftSend.Format = DateTimePickerFormat.Short;
        }

        private void btnClearDateOfReplacementSend_Click(object sender, EventArgs e)
        {
            DateOfReplacementSend.Value = DateTimePicker.MinimumDateTime;
            DateOfReplacementSend.CustomFormat = " ";
            DateOfReplacementSend.Format = DateTimePickerFormat.Custom;
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
            cmbDefects.SelectedIndex = -1;
        }

        private void AddData_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
