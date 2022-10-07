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
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace Reklamace_Kion
{
    public partial class Main : Form
    {
        public string MyName { get; set; }
        public bool DisableExit { get; set; }

        string FirstName = string.Empty;
        string LastName = string.Empty;
        string Level = string.Empty;

        int curTab = 0;

        SqlConnection conn = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace");

        private static Main form = null;

        public Main()
        {
            InitializeComponent();

            lblLoadingData.Visible = false;

            tabControl1.TabPages[0].Text = "Reklamace";
            tabControl1.TabPages[1].Text = "Opravy";
            tabControl1.TabPages[2].Text = "Analýzy";
            tabControl1.TabPages[3].Text = "Expedice";

            btnAddData.Visible = false;
            btnDelData.Visible = false;

            // Double buffering can make DGV slow in remote desktop
            if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
            {
                Type dgvType = dataGrid1.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(dataGrid1, true, null);

                Type dgvType2 = dataGridOpravy.GetType();
                PropertyInfo pi2 = dgvType2.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
                pi2.SetValue(dataGridOpravy, true, null);

                Type dgvType3 = dgvAnalysis.GetType();
                PropertyInfo pi3 = dgvType3.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
                pi3.SetValue(dgvAnalysis, true, null);

                Type dgvType4 = dgvExpedition.GetType();
                PropertyInfo pi4 = dgvType4.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
                pi4.SetValue(dgvExpedition, true, null);
            }

            form = this;
        }

        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        public DataTable DataMain = new DataTable();
        BindingSource bindMainData = new BindingSource();

        public DataTable DataRepair = new DataTable();
        BindingSource bindRepairData = new BindingSource();
        private void Main_Load(object sender, EventArgs e)
        {
            lblActionInfo.ForeColor = Color.Black;
            lblActionInfo.Text = "Uživatel " + MyName + " přihlášen.";

            try
            {
                conn.Open();
                SqlCommand getUserData = new SqlCommand("SELECT FirstName, LastName, Level FROM Users WHERE Name='" + MyName + "'", conn);
                SqlDataAdapter da = new SqlDataAdapter(getUserData);

                using (SqlDataReader reader = getUserData.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        lblFirstName.Text = reader.GetString(0);
                        lblLastName.Text = reader.GetString(1);
                        Level = reader.GetString(2);
                    }

                    conn.Close();

                    if (Level != string.Empty)
                    {
                        if (Level == "100")
                        {
                            lblLevel.Text = "Administrátor";

                            btnUsers.Visible = true;
                            btnAddData.Visible = true;
                            btnDelData.Visible = true;

                            dataGrid1.ReadOnly = dataGridOpravy.ReadOnly = dgvAnalysis.ReadOnly = false;
                        }
                        else if (Level == "20")
                        {
                            lblLevel.Text = "Technik";

                            btnAddData.Visible = true;
                            btnDelData.Visible = true;

                            dataGrid1.ReadOnly = dataGridOpravy.ReadOnly = dgvAnalysis.ReadOnly = false;
                        }
                        else if (Level == "10")
                        {
                            lblLevel.Text = "Příjem";

                            btnAddData.Visible = true;
                            btnDelData.Visible = true;

                            dataGrid1.ReadOnly = false;
                        }
                        else if (Level == "5")
                        {
                            lblLevel.Text = "Opravář";

                            btnDelData.Visible = true;
                            btnAddData.Visible = true;

                            dataGridOpravy.ReadOnly = false;
                        }
                        else if (Level == "1")
                        {
                            lblLevel.Text = "Pouze čtení";
                        }
                    }
                }  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            lblLoadingData.Visible = true;
            backgroundWorker1.RunWorkerAsync();
        }

        public static BindingSource GetTableDataMain(SqlConnection connection, DataTable dt, BindingSource src)
        {
            try
            {
                
                connection.Open();
                SqlCommand getDataMain = new SqlCommand("SELECT * FROM DataMain", connection);
                SqlDataAdapter daDataMain = new SqlDataAdapter(getDataMain);

                daDataMain.Fill(dt);

                connection.Close();
                src.DataSource = dt;
                return src;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public static BindingSource GetTableDataRepairs(SqlConnection connection, DataTable dt, BindingSource src)
        {
            try
            {

                connection.Open();
                SqlCommand getDataRepairs = new SqlCommand("SELECT * FROM DataRepairs", connection);
                SqlDataAdapter daDataRepairs = new SqlDataAdapter(getDataRepairs);

                daDataRepairs.Fill(dt);

                connection.Close();
                src.DataSource = dt;
                return src;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void btnReloadData_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                ReloadData();
                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ReloadData()
        {
            form.DataMain.Clear();
            form.DataRepair.Clear();
            form.conn.Open();
            SqlCommand getDataMain = new SqlCommand("SELECT * FROM DataMain", form.conn);
            SqlDataAdapter daDataMain = new SqlDataAdapter(getDataMain);
            SqlCommand getDataRepair = new SqlCommand("SELECT * FROM DataRepairs", form.conn);
            SqlDataAdapter daDataRepair = new SqlDataAdapter(getDataRepair);

            daDataMain.Fill(form.DataMain);
            daDataRepair.Fill(form.DataRepair);
            form.conn.Close();
            form.bindMainData.ResetBindings(true);
            form.bindRepairData.ResetBindings(true);

            form.dataGrid1.Rows[0].Selected = true;
            form.dataGridOpravy.Rows[0].Selected = true;

            form.lblActionInfo.ForeColor = Color.Black;
            form.lblActionInfo.Text = "Data aktualizována.";
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            Users UserForm = new Users();

            UserForm.MyName = MyName;

            UserForm.Show();
        }

        private void btnAddData_Click(object sender, EventArgs e)
        {
            if ((curTab == 0) && ((Level == "100") || (Level == "20") || (Level == "10")))
            {
                AddData addForm = new AddData();
                addForm.MyLevel = Level;
                addForm.Show();
            }
            else if ((curTab == 1) && ((Level == "100") || (Level == "20") || (Level == "5")))
            {
                AddRepair repairForm = new AddRepair();
                repairForm.MyLevel = Level;
                repairForm.Show();
            }
            else if ((curTab == 3) && ((Level == "100") || (Level == "20") || (Level == "10") || (Level == "5")))
            {
                try
                {
                    conn.Open();

                    SqlCommand cmd = new SqlCommand("INSERT INTO DataExpedition (Type_of_Palette) VALUES ('')", conn);
                    cmd.ExecuteNonQuery();

                    conn.Close();

                    loadDgvExpedition();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnDelData_Click(object sender, EventArgs e)
        {
            if ((curTab == 0) && ((Level == "100") || (Level == "20") || (Level == "10")))
            {
                try
                {
                    int DataIdTab = (int)dataGrid1.CurrentRow.Cells[0].Value;
                    string CLM = (string)dataGrid1.CurrentRow.Cells[1].Value;

                    DialogResult dialogResult = MessageBox.Show("Opravdu chcete smazat záznam " + CLM + "?", "Smazat záznam", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        conn.Open();
                        SqlCommand delData = new SqlCommand("DELETE FROM DataMain WHERE DataId=" + DataIdTab + "", conn);
                        delData.ExecuteNonQuery();
                        conn.Close();
                        form.DataMain.Clear();
                        dataGrid1.DataSource = GetTableDataMain(conn, DataMain, bindMainData);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if ((curTab == 1) && ((Level == "100") || (Level == "20") || (Level == "5")))
            {
                try
                {
                    int RepairIdTab = (int)dataGridOpravy.CurrentRow.Cells[0].Value;
                    string CLM = (string)dataGridOpravy.CurrentRow.Cells[1].Value;
                    string PNBattery = (string)dataGridOpravy.CurrentRow.Cells[3].Value;
                    string PNChar = PNBattery.Substring(PNBattery.LastIndexOf('_') + 1);

                    DialogResult dialogResult = MessageBox.Show("Opravdu chcete smazat záznam s ID " + RepairIdTab + "?", "Smazat záznam", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        conn.Open();
                        SqlCommand delData = new SqlCommand("DELETE FROM DataRepairs WHERE RepairId=" + RepairIdTab + "", conn);
                        delData.ExecuteNonQuery();
                        if (PNChar == "A1")
                        {
                            delData = new SqlCommand("DELETE FROM A1_torques WHERE CLM='" + CLM + "'", conn);
                            delData.ExecuteNonQuery();
                        }
                        else if (PNChar == "A2")
                        {
                            delData = new SqlCommand("DELETE FROM A2_torques WHERE CLM='" + CLM + "'", conn);
                            delData.ExecuteNonQuery();
                        }
                        else if (PNChar == "B1")
                        {
                            delData = new SqlCommand("DELETE FROM B1_torques WHERE CLM='" + CLM + "'", conn);
                            delData.ExecuteNonQuery();
                        }
                        else if (PNChar == "B2")
                        {
                            delData = new SqlCommand("DELETE FROM B2_torques WHERE CLM='" + CLM + "'", conn);
                            delData.ExecuteNonQuery();
                        }


                        conn.Close();
                        form.DataRepair.Clear();
                        dataGridOpravy.DataSource = GetTableDataRepairs(conn, DataRepair, bindRepairData);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if ((curTab == 2) && ((Level == "100") || (Level == "20") || (Level == "5")))
            {
                try
                {
                    string CLM = (string)dgvAnalysis.CurrentRow.Cells[0].Value;

                    DialogResult dialogResult = MessageBox.Show("Opravdu chcete smazat záznam s CLM: " + CLM + "?", "Smazat záznam", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        conn.Open();
                        SqlCommand delData = new SqlCommand("DELETE FROM DataAnalysis WHERE CLM='" + CLM + "'", conn);
                        delData.ExecuteNonQuery();

                        SqlCommand delData2 = new SqlCommand("DELETE FROM DataAnalysis_BB WHERE CLM='" + CLM + "'", conn);
                        delData2.ExecuteNonQuery();

                        conn.Close();

                        loadDgvAnalysis();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if ((curTab == 3) && ((Level == "100") || (Level == "20") || (Level == "10") || (Level == "5")))
            {
                try
                {
                    int id = (int)dgvExpedition.CurrentRow.Cells[0].Value;

                    DialogResult dialogResult = MessageBox.Show("Opravdu chcete smazat záznam s Expedition ID: " + id + "?", "Smazat záznam", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        conn.Open();
                        SqlCommand delData = new SqlCommand("DELETE FROM DataExpedition WHERE Expedition_Id=" + id + "", conn);
                        delData.ExecuteNonQuery();

                        conn.Close();

                        loadDgvExpedition();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    curTab = 0;
                    break;
                case 1:
                    curTab = 1;
                    break;
                case 2:
                    curTab = 2;
                    break;
                case 3:
                    curTab = 3;
                    break;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            string exportName = string.Empty;
            DataGridView tabulka = new DataGridView();

            if ((curTab == 0) && ((Level == "100") || (Level == "20") || (Level == "10") || (Level == "1")))
            {
                exportName = "DataMain_export_";
                tabulka = dataGrid1;
            }
            else if ((curTab == 1) && ((Level == "100") || (Level == "20") || (Level == "5") || (Level == "1")))
            {
                exportName = "DataRepairs_export_";
                tabulka = dataGridOpravy;
            }
            else
            {
                return;
            }

            string fileName = exportName + DateTime.Now.ToString("yy:M:d_H:mm:ss") + ".xlsx";

            string filePath = string.Empty;

            FolderBrowserDialog SaveFileExport = new FolderBrowserDialog();

            fileName = fileName.Replace(":", "");

            DialogResult result = SaveFileExport.ShowDialog();
            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(SaveFileExport.SelectedPath))
            {
                filePath = SaveFileExport.SelectedPath + "\\" + fileName;

                SaveInfo saveDialog = new SaveInfo();
                saveDialog.Show();

                Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
                Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
                Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
                app.Visible = false;
                worksheet = workbook.ActiveSheet;
                worksheet.Name = exportName;

                for (int i = 1; i < tabulka.Columns.Count + 1; i++)
                {
                    worksheet.Cells[1, i] = tabulka.Columns[i - 1].HeaderText;
                }

                for (int i = 0; i < tabulka.Rows.Count; i++)
                {
                    for (int j = 0; j < tabulka.Columns.Count; j++)
                    {
                        worksheet.Cells[i + 2, j + 1] = tabulka.Rows[i].Cells[j].Value.ToString();
                    }
                }

                workbook.SaveAs(filePath, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
                app.Quit();

                saveDialog.Hide();

                lblActionInfo.ForeColor = Color.Black;
                lblActionInfo.Text = "Export dokončen.";
            }
        }

        private void dataGrid1_SortStringChanged(object sender, EventArgs e)
        {
            this.bindMainData.Sort = this.dataGrid1.SortString;
        }

        private void dataGrid1_FilterStringChanged(object sender, EventArgs e)
        {
            this.bindMainData.Filter = this.dataGrid1.FilterString;
        }
        private void dataGridOpravy_SortStringChanged(object sender, EventArgs e)
        {
            this.bindRepairData.Sort = this.dataGridOpravy.SortString;
        }

        private void dataGridOpravy_FilterStringChanged(object sender, EventArgs e)
        {
            this.bindRepairData.Filter = this.dataGridOpravy.FilterString;
        }

        private void dataGridOpravy_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string CommandText = string.Empty;
            string columnName = dataGridOpravy.Columns[e.ColumnIndex].Name;
            int rowId = Convert.ToInt32(dataGridOpravy[0, e.RowIndex].Value);
            string newValue = dataGridOpravy[e.ColumnIndex, e.RowIndex].Value.ToString();

            if (columnName == "BrandId_Speed") { CommandText = "UPDATE DataRepairs SET BrandId_Speed = @newval WHERE RepairId = @id"; }
            else if (columnName == "WD") { CommandText = "UPDATE DataRepairs SET WD = @newval WHERE RepairId = @id"; }
            else if (columnName == "BB") { CommandText = "UPDATE DataRepairs SET BB = @newval WHERE RepairId = @id"; }
            else if (columnName == "ZD") { CommandText = "UPDATE DataRepairs SET ZD = @newval WHERE RepairId = @id"; }
            else if (columnName == "SW") { CommandText = "UPDATE DataRepairs SET SW = @newval WHERE RepairId = @id"; }
            else if (columnName == "PD") { CommandText = "UPDATE DataRepairs SET PD = @newval WHERE RepairId = @id"; }
            else if (columnName == "Test") { CommandText = "UPDATE DataRepairs SET Test = @newval WHERE RepairId = @id"; }
            else if (columnName == "Charging") { CommandText = "UPDATE DataRepairs SET Charging = @newval WHERE RepairId = @id"; }
            else if (columnName == "SetBrandID_Speed") { CommandText = "UPDATE DataRepairs SET SetBrandID_Speed = @newval WHERE RepairId = @id"; }
            else if (columnName == "PrintScr") { CommandText = "UPDATE DataRepairs SET PrintScr = @newval WHERE RepairId = @id"; }
            else if (columnName == "Label") { CommandText = "UPDATE DataRepairs SET Label = @newval WHERE RepairId = @id"; }
            else if (columnName == "TypeOfPalette") { CommandText = "UPDATE DataRepairs SET TypeOfPalette = @newval WHERE RepairId = @id"; }
            else if (columnName == "ExpectedExpedition") { CommandText = "UPDATE DataRepairs SET ExpectedExpedition = @newval WHERE RepairId = @id"; }
            else if (columnName == "SOH") { CommandText = "UPDATE DataRepairs SET SOH = @newval WHERE RepairId = @id"; }
            else if (columnName == "CapacityTest") { CommandText = "UPDATE DataRepairs SET CapacityTest = @newval WHERE RepairId = @id"; }
            else if ((columnName == "CLM") || (columnName == "PN_Battery") || (columnName == "SN_Battery")) { CommandText = string.Empty; bindRepairData.CancelEdit(); dataGridOpravy.CancelEdit(); dataGridOpravy.EndEdit(); MessageBox.Show("Nelze upravit CLM, PN a SN."); }

            try
            {
                if (CommandText != string.Empty)
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(CommandText, conn);
                    cmd.Parameters.AddWithValue("@newval", newValue);
                    cmd.Parameters.AddWithValue("@id", rowId);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    lblActionInfo.ForeColor = Color.Green;
                    lblActionInfo.Text = "Data '" + columnName + "' úspěšně změněna pro ID = " + rowId + ".";
                    //form.DataRepair.Clear();
                    //dataGridOpravy.DataSource = GetTableDataRepairs(conn, DataRepair, bindRepairData);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dataGrid1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string CommandText = string.Empty;
            string columnName = dataGrid1.Columns[e.ColumnIndex].Name;
            int rowId = Convert.ToInt32(dataGrid1[0, e.RowIndex].Value);
            string newValue = dataGrid1[e.ColumnIndex, e.RowIndex].Value.ToString();

            if(columnName != "Cost_Of_Repair")
            {
                if (columnName == "CLM") { CommandText = "UPDATE DataMain SET CLM = @newval WHERE DataId = @id"; }
                else if (columnName == "State") { CommandText = "UPDATE DataMain SET State = @newval WHERE DataId = @id"; }
                else if (columnName == "Customer_Require") { CommandText = "UPDATE DataMain SET Customer_Require = @newval WHERE DataId = @id"; }
                else if (columnName == "Date_Of_Customer_Send") { CommandText = "UPDATE DataMain SET Date_Of_Customer_Send = @newval WHERE DataId = @id"; }
                else if (columnName == "Date_Of_Saft_Acceptance") { CommandText = "UPDATE DataMain SET Date_Of_Saft_Acceptance = @newval WHERE DataId = @id"; }
                else if (columnName == "Date_Of_Repair") { CommandText = "UPDATE DataMain SET Date_Of_Repair = @newval WHERE DataId = @id"; }
                else if (columnName == "Date_Of_Saft_Send") { CommandText = "UPDATE DataMain SET Date_Of_Saft_Send = @newval WHERE DataId = @id"; }
                else if (columnName == "PN_Battery") { CommandText = "UPDATE DataMain SET PN_Battery = @newval WHERE DataId = @id"; }
                else if (columnName == "SN_Battery") { CommandText = "UPDATE DataMain SET SN_Battery = @newval WHERE DataId = @id"; }
                else if (columnName == "PN_Claimed_Component") { CommandText = "UPDATE DataMain SET PN_Claimed_Component = @newval WHERE DataId = @id"; }
                else if (columnName == "SN_Claimed_Component") { CommandText = "UPDATE DataMain SET SN_Claimed_Component = @newval WHERE DataId = @id"; }
                else if (columnName == "Fault") { CommandText = "UPDATE DataMain SET Fault = @newval WHERE DataId = @id"; }
                else if (columnName == "Type_CW") { CommandText = "UPDATE DataMain SET Type_CW = @newval WHERE DataId = @id"; }
                else if (columnName == "Defect_BMS") { CommandText = "UPDATE DataMain SET Defect_BMS = @newval WHERE DataId = @id"; }
                else if (columnName == "Location_Of_Battery") { CommandText = "UPDATE DataMain SET Location_Of_Battery = @newval WHERE DataId = @id"; }
                else if (columnName == "Replacement_Send") { CommandText = "UPDATE DataMain SET Replacement_Send = @newval WHERE DataId = @id"; }
                else if (columnName == "Date_Of_Replacement_Send") { CommandText = "UPDATE DataMain SET Date_Of_Replacement_Send = @newval WHERE DataId = @id"; }
                else if (columnName == "Result") { CommandText = "UPDATE DataMain SET Result = @newval WHERE DataId = @id"; }
                else if (columnName == "Result_Description") { CommandText = "UPDATE DataMain SET Result_Description = @newval WHERE DataId = @id"; }
                else if (columnName == "Contact") { CommandText = "UPDATE DataMain SET Contact = @newval WHERE DataId = @id"; }
                else if (columnName == "Tariff_Repairman") { CommandText = "UPDATE DataMain SET Tariff_Repairman = @newval WHERE DataId = @id"; }
                else if (columnName == "Hours_Repairman") { CommandText = "UPDATE DataMain SET Hours_Repairman = @newval WHERE DataId = @id"; }
                else if (columnName == "Tariff_Technician") { CommandText = "UPDATE DataMain SET Tariff_Technician = @newval WHERE DataId = @id"; }
                else if (columnName == "Hours_Technician") { CommandText = "UPDATE DataMain SET Hours_Technician = @newval WHERE DataId = @id"; }
                else if (columnName == "Tariff_Administration") { CommandText = "UPDATE DataMain SET Tariff_Administration = @newval WHERE DataId = @id"; }
                else if (columnName == "Hours_Administration") { CommandText = "UPDATE DataMain SET Hours_Administration = @newval WHERE DataId = @id"; }
                else if (columnName == "Cost_Of_Components") { CommandText = "UPDATE DataMain SET Cost_Of_Components = @newval WHERE DataId = @id"; }
                else if (columnName == "Note_1") { CommandText = "UPDATE DataMain SET Note_1 = @newval WHERE DataId = @id"; }
                else if (columnName == "Note_2") { CommandText = "UPDATE DataMain SET Note_2 = @newval WHERE DataId = @id"; }

                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand(CommandText, conn);
                    cmd.Parameters.AddWithValue("@newval", newValue);
                    cmd.Parameters.AddWithValue("@id", rowId);

                    if ((columnName == "CLM") || (columnName == "PN_Battery") || (columnName == "SN_Battery"))
                    {
                        string PNChar = PNBattery.Substring(PNBattery.LastIndexOf('_') + 1);

                        int dataCount = 0;
                        if (PNChar != string.Empty)
                        {
                            string sqlTorques = "SELECT COUNT(*) from " + PNChar + "_torques where CLM like '" + CLM + "'";
                            SqlCommand cmdCount = new SqlCommand(sqlTorques, conn);

                            dataCount = (int)cmdCount.ExecuteScalar();
                        }
                        string dir = @"\\cz-ras-fs2\Applications\KION\10_Reklamace\KionApp\";
                        



                        if (dataCount > 0)
                        {
                            var result = MessageBox.Show("Tato akce provede také změny v databázi oprav a změnu názvu složky.\nOpravdu chcete tento údaj změnit?", "Varování", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                            if (result == DialogResult.Yes)
                            {
                                
                                cmd.ExecuteNonQuery();
                                if (columnName == "CLM")
                                {
                                    CommandText = "UPDATE DataRepairs SET CLM = '" + newValue + "' WHERE CLM = '" + CLM + "'";
                                    cmd = new SqlCommand(CommandText, conn);
                                    cmd.ExecuteNonQuery();
                                    CommandText = "UPDATE " + PNChar + "_torques SET CLM = '" + newValue + "' WHERE CLM = '" + CLM + "'";
                                    cmd = new SqlCommand(CommandText, conn);
                                    cmd.ExecuteNonQuery();
                                    try
                                    {
                                        System.IO.Directory.Move(dir + CLM, dir + newValue);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                        conn.Close();
                                    }
                                }
                                else if (columnName == "PN_Battery")
                                {
                                    CommandText = "UPDATE DataRepairs SET PN_Battery = '" + newValue + "' WHERE CLM = '" + CLM + "'";
                                    cmd = new SqlCommand(CommandText, conn);
                                    cmd.ExecuteNonQuery();
                                    CommandText = "UPDATE " + PNChar + "_torques SET PN = '" + newValue + "' WHERE CLM = '" + CLM + "'";
                                    cmd = new SqlCommand(CommandText, conn);
                                    cmd.ExecuteNonQuery();
                                    try
                                    {
                                        System.IO.Directory.Move(dir + CLM + "\\" + PNBattery + "_" + SNBattery, dir + CLM + "\\" + newValue + "_" + SNBattery);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                        conn.Close();
                                    }
                                }
                                else if (columnName == "SN_Battery")
                                {
                                    CommandText = "UPDATE DataRepairs SET SN_Battery = '" + newValue + "' WHERE CLM = '" + CLM + "'";
                                    cmd = new SqlCommand(CommandText, conn);
                                    cmd.ExecuteNonQuery();
                                    try
                                    {
                                        System.IO.Directory.Move(dir + CLM + "\\" + PNBattery + "_" + SNBattery, dir + CLM + "\\" + PNBattery + "_" + newValue);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(ex.Message);
                                        conn.Close();
                                    }
                                }
                            }
                            else
                            {
                                bindMainData.CancelEdit(); dataGrid1.CancelEdit(); dataGrid1.EndEdit();
                            }
                        }
                        else
                        {
                            cmd.ExecuteNonQuery();
                        }
                    }
                    else
                    {
                        cmd.ExecuteNonQuery();

                        string dir = @"\\cz-ras-fs2\Applications\KION\10_Reklamace\KionApp\";
                        if ((columnName == "PN_Claimed_Component") || (columnName == "SN_Claimed_Component"))
                        {
                            if (columnName == "PN_Claimed_Component")
                            {
                                try
                                {
                                    System.IO.Directory.Move(dir + CLM + "\\" + PNBattery + "_" + SNBattery + "\\" + PNComponent + "_" + SNComponent, dir + CLM + "\\" + PNBattery + "_" + SNBattery + "\\" + newValue + "_" + SNComponent);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                    conn.Close();
                                }
                            }
                            if (columnName == "SN_Claimed_Component")
                            {
                                try
                                {
                                    System.IO.Directory.Move(dir + CLM + "\\" + PNBattery + "_" + SNBattery + "\\" + PNComponent + "_" + SNComponent, dir + CLM + "\\" + PNBattery + "_" + SNBattery + "\\" + PNComponent + "_" + newValue);
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(ex.Message);
                                    conn.Close();
                                }
                            }
                        }
                    }

                    lblActionInfo.ForeColor = Color.Green;
                    lblActionInfo.Text = "Data '" + columnName + "' úspěšně změněna pro ID = " + rowId + ".";
                    //form.DataMain.Clear();
                    //dataGrid1.DataSource = GetTableDataMain(conn, DataMain, bindMainData);
                    if ((columnName == "Tariff_Repairman") || (columnName == "Hours_Repairman") || (columnName == "Tariff_Technician") || (columnName == "Hours_Technician") || (columnName == "Tariff_Administration") || (columnName == "Hours_Administration") || (columnName == "Cost_Of_Components"))
                    {
                        float Tariff_Repairman = float.Parse(dataGrid1[21, e.RowIndex].Value.ToString());
                        float Hours_Repairman = float.Parse(dataGrid1[22, e.RowIndex].Value.ToString());
                        float Tariff_Technician = float.Parse(dataGrid1[23, e.RowIndex].Value.ToString());
                        float Hours_Technician = float.Parse(dataGrid1[24, e.RowIndex].Value.ToString());
                        float Tariff_Administration = float.Parse(dataGrid1[25, e.RowIndex].Value.ToString());
                        float Hours_Administration = float.Parse(dataGrid1[26, e.RowIndex].Value.ToString());
                        float Cost_Of_Components = float.Parse(dataGrid1[27, e.RowIndex].Value.ToString());

                        float finalCost = (Tariff_Repairman * Hours_Repairman) + (Tariff_Technician * Hours_Technician) + (Tariff_Administration * Hours_Administration) + Cost_Of_Components;

                        SqlCommand price = new SqlCommand("UPDATE DataMain SET Cost_Of_Repair = @finalCost WHERE DataId = @id", conn);
                        price.Parameters.AddWithValue("@finalCost", finalCost);
                        price.Parameters.AddWithValue("@id", rowId);
                        int res = price.ExecuteNonQuery();

                        if (res != 0)
                        {
                            dataGrid1[28, rowId - 1].Value = finalCost;
                        }
                    }

                    conn.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            } 
        }

        private void změnitHesloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditPass editPassForm = new EditPass();
            editPassForm.MyName = MyName;
            editPassForm.Show();
        }

        private void oAplikaciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.Show();
        }

        

        private void dataGrid1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGrid1.BeginEdit(true);
        }

        private void dataGridOpravy_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridOpravy.BeginEdit(true);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            conn.Open();
            SqlCommand getDataMain = new SqlCommand("SELECT * FROM DataMain", conn);
            SqlDataAdapter daDataMain = new SqlDataAdapter(getDataMain);

            daDataMain.Fill(DataMain);

            conn.Close();
            dataGridOpravy.DataSource = GetTableDataRepairs(conn, DataRepair, bindRepairData);
            bindMainData.DataSource = DataMain;

        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGrid1.DataSource = bindMainData;
            dataGrid1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            for (int i = 0; i <= dataGrid1.Columns.Count - 1; i++)
            {
                // Store Auto Sized Widths:
                int colw = dataGrid1.Columns[i].Width;

                // Remove AutoSizing:
                dataGrid1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                // Set Width to calculated AutoSize value:
                dataGrid1.Columns[i].Width = colw;
            }
            for (int i = 0; i <= dataGridOpravy.Columns.Count - 1; i++)
            {
                // Store Auto Sized Widths:
                int colw = dataGridOpravy.Columns[i].Width;

                // Remove AutoSizing:
                dataGridOpravy.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

                // Set Width to calculated AutoSize value:
                dataGridOpravy.Columns[i].Width = colw;
            }
            lblLoadingData.Visible = false;

            dataGrid1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridOpravy.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        }

        private void přidatKomponentuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Level == "100") || (Level == "20") || (Level == "10")) {
                Komponenty.AddComponent addComponent = new Komponenty.AddComponent();
                addComponent.Show();
            }
        }

        private void upravitKomponentyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Level == "100") || (Level == "20") || (Level == "10"))
            {
                Komponenty.ListComponents listComponents = new Komponenty.ListComponents();
                listComponents.Show();
            }
        }

        private void RefTime_Tick(object sender, EventArgs e)
        {
            lblActualDate.Text = DateTime.Now.ToString();
        }

        private void btnResetFiltr_Click(object sender, EventArgs e)
        {
            try
            {
                txtSearch.Text = string.Empty;
                this.bindMainData.Filter = String.Empty;
                this.bindRepairData.Filter = String.Empty;
                this.dataGrid1.ClearFilter();
                this.dataGridOpravy.ClearFilter();
            }
            catch (Exception ex)
            {
                lblActionInfo.Text = ex.Message;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchProc();
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SearchProc();
            }
        }

        public void SearchProc()
        {
            try
            {
                if(curTab == 0)
                {
                    this.bindMainData.Filter = "(CLM LIKE '%" + txtSearch.Text + "%') OR " +
                        "(State LIKE '%" + txtSearch.Text + "%') OR " +
                        "(Customer_Require LIKE '%" + txtSearch.Text + "%') OR " +
                        "(Date_Of_Customer_Send LIKE '%" + txtSearch.Text + "%') OR " +
                        "(Date_Of_Saft_Acceptance LIKE '%" + txtSearch.Text + "%') OR " +
                        "(Date_Of_Repair LIKE '%" + txtSearch.Text + "%') OR " +
                        "(Date_Of_Saft_Send LIKE '%" + txtSearch.Text + "%') OR " +
                        "(PN_Battery LIKE '%" + txtSearch.Text + "%') OR " +
                        "(SN_Battery LIKE '%" + txtSearch.Text + "%') OR " +
                        "(PN_Claimed_Component LIKE '%" + txtSearch.Text + "%') OR " +
                        "(SN_Claimed_Component LIKE '%" + txtSearch.Text + "%') OR " +
                        "(Fault LIKE '%" + txtSearch.Text + "%') OR " +
                        "(Type_CW LIKE '%" + txtSearch.Text + "%') OR " +
                        "(Defect_BMS LIKE '%" + txtSearch.Text + "%') OR " +
                        "(Location_Of_Battery LIKE '%" + txtSearch.Text + "%') OR " +
                        "(Replacement_Send LIKE '%" + txtSearch.Text + "%') OR " +
                        "(Date_Of_Replacement_Send LIKE '%" + txtSearch.Text + "%') OR " +
                        "(Result LIKE '%" + txtSearch.Text + "%') OR " +
                        "(Result_Description LIKE '%" + txtSearch.Text + "%') OR " +
                        "(Contact LIKE '%" + txtSearch.Text + "%')";
                }
                else if (curTab == 1)
                {
                    this.bindRepairData.Filter = "(CLM LIKE '%" + txtSearch.Text + "%') OR " +
                        "(BrandId_Speed LIKE '%" + txtSearch.Text + "%') OR " +
                        "(TypeOfPalette LIKE '%" + txtSearch.Text + "%')";
                }
            }
            catch (Exception ex)
            {
                lblActionInfo.Text = ex.Message;
            }
        }

        DataGridView.HitTestInfo actualCell;
        DataGridView.HitTestInfo actualClick;
        string CLM = string.Empty;
        string PNBattery = string.Empty;
        string SNBattery = string.Empty;
        string PNComponent = string.Empty;
        string SNComponent = string.Empty;
        private void dataGrid1_MouseDown(object sender, MouseEventArgs e)
        {
            actualClick = dataGrid1.HitTest(e.X, e.Y);
            if (actualClick.RowIndex >= 0)
            {
                CLM = dataGrid1[1, actualClick.RowIndex].Value.ToString();
                PNBattery = dataGrid1[8, actualClick.RowIndex].Value.ToString();
                SNBattery = dataGrid1[9, actualClick.RowIndex].Value.ToString();
                PNComponent = dataGrid1[10, actualClick.RowIndex].Value.ToString();
                SNComponent = dataGrid1[11, actualClick.RowIndex].Value.ToString();
            }
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    var hti = dataGrid1.HitTest(e.X, e.Y);
                    if (hti.RowIndex >= 0)
                    {
                        dataGrid1.ClearSelection();
                        dataGrid1.Rows[hti.RowIndex].Selected = true;
                        actualCell = hti;
                        dataGrid1.ContextMenuStrip.Enabled = true;
                    }
                    else
                    {
                        dataGrid1.ContextMenuStrip.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void dataGridOpravy_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    var hti = dataGridOpravy.HitTest(e.X, e.Y);
                    if (hti.RowIndex >= 0)
                    {
                        dataGridOpravy.ClearSelection();
                        dataGridOpravy.Rows[hti.RowIndex].Selected = true;
                        actualCell = hti;
                        dataGridOpravy.ContextMenuStrip.Enabled = true;
                    }
                    else
                    {
                        dataGridOpravy.ContextMenuStrip.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private string torque(float val)
        {
            string result = val.ToString() + " Nm \u00B1 " + (val / 10).ToString() + " Nm";
            return result;
        }

        private void přidatKOpravámToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Level == "100") || (Level == "20") || (Level == "10"))
            {
                try
                {
                    string actualCellValue = dataGrid1[1, actualCell.RowIndex].Value.ToString();
                    string PNBattery = dataGrid1[8, actualCell.RowIndex].Value.ToString();
                    string SNBattery = dataGrid1[9, actualCell.RowIndex].Value.ToString();

                    DialogResult resultBox = MessageBox.Show("Přidat k opravám " + actualCellValue + "?", "Přidat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultBox == DialogResult.Yes)
                    {
                        string sqlRepairs = "SELECT COUNT(*) from DataRepairs where CLM like '" + actualCellValue + "'";
                        SqlCommand cmdCount = new SqlCommand(sqlRepairs, conn);

                        conn.Open();
                        int dataCount = (int)cmdCount.ExecuteScalar();
                        conn.Close();

                        if (dataCount == 0)
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("INSERT INTO DataRepairs values('" + actualCellValue + "', '', '" + PNBattery + "', '" + SNBattery + "', '', '', " +
                                    "'','','','','','',''," +
                                    "'','','','','')", conn);
                            if (cmd.ExecuteNonQuery() != 0)
                            {
                                form.DataRepair.Clear();
                                SqlCommand getDataRepair = new SqlCommand("SELECT * FROM DataRepairs", form.conn);
                                SqlDataAdapter daDataRepair = new SqlDataAdapter(getDataRepair);

                                daDataRepair.Fill(form.DataRepair);
                                form.bindRepairData.ResetBindings(true);
                                
                                string PNChar = PNBattery.Substring(PNBattery.LastIndexOf('_') + 1);

                                if (PNChar == "A1")
                                {
                                    cmd = new SqlCommand("INSERT INTO A1_torques (CLM,PN) values('" + actualCellValue + "','" + PNBattery + "')", conn);
                                    cmd.ExecuteNonQuery();
                                }
                                else if (PNChar == "A2")
                                {
                                    cmd = new SqlCommand("INSERT INTO A2_torques (CLM,PN) values('" + actualCellValue + "','" + PNBattery + "')", conn);
                                    cmd.ExecuteNonQuery();
                                }
                                else if (PNChar == "B1")
                                {
                                    cmd = new SqlCommand("INSERT INTO B1_torques (CLM,PN) values('" + actualCellValue + "','" + PNBattery + "')", conn);
                                    cmd.ExecuteNonQuery();
                                }
                                else if (PNChar == "B2")
                                {
                                    cmd = new SqlCommand("INSERT INTO B2_torques (CLM,PN) values('" + actualCellValue + "','" + PNBattery + "')", conn);
                                    cmd.ExecuteNonQuery();
                                }



                                lblActionInfo.ForeColor = Color.Green;
                                lblActionInfo.Text = "Záznam " + actualCellValue + " byl přidán k opravám.";
                            }
                            conn.Close();
                        }
                        else
                        {
                            MessageBox.Show("Tento záznam již existuje.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void přidatDefektToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Level == "100") || (Level == "20") || (Level == "10"))
            {
                Defekty.AddDefect addDefectForm = new Defekty.AddDefect();
                addDefectForm.Show();
            }
        }

        private void upravitDefektyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Level == "100") || (Level == "20") || (Level == "10"))
            {
                Defekty.ListDefects listDefectsForm = new Defekty.ListDefects();
                listDefectsForm.Show();
            }
        }

        private void toolStripShowFolder_Click(object sender, EventArgs e)
        {
            OpenFolderCLM(dataGrid1);
        }

        private void stripMenuOpenFolderRepairs_Click(object sender, EventArgs e)
        {
            OpenFolderCLM(dataGridOpravy);
        }

        private void OpenFolderCLM(ADGV.AdvancedDataGridView grid)
        {
            string actualCellValue = grid[1, actualCell.RowIndex].Value.ToString();
            string dir = @"\\cz-ras-fs2\Applications\KION\10_Reklamace\KionApp\";

            try
            {
                string path = dir + actualCellValue;
                if (Directory.Exists(path))
                {
                    Process.Start(path);
                }
                else
                {
                    MessageBox.Show("Pro tento záznam neexistuje složka.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void StripMenuOpenDataRepairs_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            RepairAnalyze.AnalysisForm repForm = new RepairAnalyze.AnalysisForm();
            repForm.PN = dataGridOpravy[3, actualCell.RowIndex].Value.ToString();
            repForm.CLM = dataGridOpravy[1, actualCell.RowIndex].Value.ToString();
            repForm.Level = Level;
            repForm.Show();
            Cursor.Current = Cursors.Default;
        }

        private void přidatSoučástToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Level == "100") || (Level == "20") || (Level == "10") || (Level == "5"))
            {
                Opravy.AddComponentRepair addComponentRepair = new Opravy.AddComponentRepair();
                addComponentRepair.Show();
            }
        }

        private void upravitSoučástiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Level == "100") || (Level == "20") || (Level == "10") || (Level == "5"))
            {
                Opravy.ListComponentsRepair listComponentsRepair = new Opravy.ListComponentsRepair();
                listComponentsRepair.Show();
            }
        }

        private void přidatKontaktToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Level == "100") || (Level == "20") || (Level == "10"))
            {
                Contacts.AddContact addContact = new Contacts.AddContact();
                addContact.Show();
            }
        }

        private void upravitKontaktyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Level == "100") || (Level == "20") || (Level == "10"))
            {
                Contacts.ListContacts listContacts = new Contacts.ListContacts();
                listContacts.Show();
            }
        }

        private void CellContext_Opening(object sender, CancelEventArgs e)
        {

        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Report.Report repForm = new Report.Report();
            repForm.Show();
        }

        private void toolStripAddToAnalysis_Click(object sender, EventArgs e)
        {
            if ((Level == "100") || (Level == "20") || (Level == "10"))
            {
                try
                {
                    string actualCellValue = dataGrid1[1, actualCell.RowIndex].Value.ToString();

                    DialogResult resultBox = MessageBox.Show("Přidat k analýzam " + actualCellValue + "?", "Přidat", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultBox == DialogResult.Yes)
                    {
                        string sqlRepairs = "SELECT COUNT(*) from DataAnalysis where CLM like '" + actualCellValue + "'";
                        SqlCommand cmdCount = new SqlCommand(sqlRepairs, conn);

                        conn.Open();
                        int dataCount = (int)cmdCount.ExecuteScalar();
                        conn.Close();

                        if (dataCount == 0)
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("INSERT INTO DataAnalysis (CLM) values('" + actualCellValue + "')", conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();

                            lblActionInfo.ForeColor = Color.Green;
                            lblActionInfo.Text = "Záznam " + actualCellValue + " byl přidán k analýze.";
                        }
                        else
                        {
                            MessageBox.Show("Tento záznam již existuje.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        string sqlBB = "SELECT COUNT(*) from DataAnalysis_BB where CLM like '" + actualCellValue + "'";
                        SqlCommand cmdBBCount = new SqlCommand(sqlBB, conn);

                        conn.Open();
                        int dataBBCount = (int)cmdBBCount.ExecuteScalar();
                        conn.Close();

                        if (dataBBCount == 0)
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand("INSERT INTO DataAnalysis_BB (CLM) values('" + actualCellValue + "')", conn);
                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                        else
                        {
                            MessageBox.Show("Tento záznam již existuje.", "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        public static string SafeGetString(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
            {
                return reader.GetString(colIndex);
            }
            return string.Empty;
        }

        public static double SafeGetDouble(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
            {
                return reader.GetDouble(colIndex);
            }
            return -0;
        }

        public static bool SafeGetBool(SqlDataReader reader, int colIndex)
        {
            if (!reader.IsDBNull(colIndex))
            {
                return reader.GetBoolean(colIndex);
            }
            return false;
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabControl1.TabPages[2])
                {
                    loadDgvAnalysis();
                }
                else if (tabControl1.SelectedTab == tabControl1.TabPages[3])
                {
                    loadDgvExpedition();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void loadDgvAnalysis()
        {
            dgvAnalysis.Rows.Clear();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM DataAnalysis", conn);
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    dgvAnalysis.Rows.Add(SafeGetString(rdr, 1), SafeGetString(rdr, 2), SafeGetDouble(rdr, 3), SafeGetString(rdr, 4), SafeGetString(rdr, 5), SafeGetDouble(rdr, 6), SafeGetDouble(rdr, 7), SafeGetString(rdr, 8), SafeGetString(rdr, 9), SafeGetString(rdr, 10), SafeGetDouble(rdr, 11), SafeGetString(rdr, 12), SafeGetString(rdr, 13), "", SafeGetString(rdr, 14), SafeGetString(rdr, 15), SafeGetString(rdr, 16), SafeGetString(rdr, 17), SafeGetString(rdr, 18), SafeGetBool(rdr, 19), SafeGetBool(rdr, 20), SafeGetBool(rdr, 21), SafeGetBool(rdr, 22), SafeGetBool(rdr, 23), SafeGetBool(rdr, 24), SafeGetString(rdr, 25), SafeGetString(rdr, 26));
                    //dgvAnalysis.Rows.Add(rdr.GetString(1), rdr.GetString(2), rdr.GetDouble(3), rdr.GetString(4), rdr.GetString(5), rdr.GetDouble(6), rdr.GetDouble(7), rdr.GetString(8), rdr.GetString(9), rdr.GetString(10), rdr.GetDouble(11), rdr.GetString(12), rdr.GetString(13), "",rdr.GetString(14), rdr.GetString(15), rdr.GetString(16), rdr.GetString(17), rdr.GetString(18), rdr.GetBoolean(19), rdr.GetBoolean(20), rdr.GetBoolean(21), rdr.GetBoolean(22), rdr.GetBoolean(23), rdr.GetBoolean(24), rdr.GetString(25), rdr.GetString(26));
                }
            }

            conn.Close();
        }

        private void loadDgvExpedition()
        {
            dgvExpedition.Rows.Clear();
            conn.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM DataExpedition", conn);
            using (SqlDataReader rdr = cmd.ExecuteReader())
            {
                while (rdr.Read())
                {
                    dgvExpedition.Rows.Add(rdr.GetValue(0), SafeGetString(rdr, 1), SafeGetString(rdr, 2), "+", SafeGetString(rdr, 3), "+", SafeGetString(rdr, 4), "+", SafeGetString(rdr, 5), "+", SafeGetString(rdr, 6), "+", SafeGetString(rdr, 7), "+", SafeGetString(rdr, 8), SafeGetString(rdr, 9), SafeGetString(rdr, 10));
                }
            }

            conn.Close();
        }

        private void dgvAnalysis_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAnalysis.Columns[e.ColumnIndex].Name == "Column26")
            {
                if (e.RowIndex >= 0)
                {
                    BlackBoxData blackBoxData = new BlackBoxData();
                    blackBoxData.Id = e.RowIndex;
                    blackBoxData.CLM = dgvAnalysis[0, e.RowIndex].Value.ToString();
                    blackBoxData.Show();
                }
            }
        }

        private void dgvAnalysis_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages[2])
            {
                string CommandText = string.Empty;
                string columnName = dgvAnalysis.Columns[e.ColumnIndex].HeaderText;
                string rowId = dgvAnalysis[0, e.RowIndex].Value.ToString();
                string newValue = dgvAnalysis[e.ColumnIndex, e.RowIndex].Value.ToString();

                if (columnName == "Visual_State") { CommandText = "UPDATE DataAnalysis SET Visual_State = @newval WHERE CLM = @id"; }
                else if (columnName == "Voltage_(V)") { CommandText = "UPDATE DataAnalysis SET Voltage_V = @newval WHERE CLM = @id"; }
                else if (columnName == "BMS_Function_OK") { CommandText = "UPDATE DataAnalysis SET BMS_Function_OK = @newval WHERE CLM = @id"; }
                else if (columnName == "PrtScn_Overview") { CommandText = "UPDATE DataAnalysis SET PrtScn_Overview = @newval WHERE CLM = @id"; }
                else if (columnName == "Actual_Current_(A)") { CommandText = "UPDATE DataAnalysis SET Actuall_Current_A = @newval WHERE CLM = @id"; }
                else if (columnName == "Voltage_Diag_Con_Pin3_4_(V)") { CommandText = "UPDATE DataAnalysis SET Voltage_Diag_Con_Pin3_4_V = @newval WHERE CLM = @id"; }
                else if (columnName == "SMU_CRC") { CommandText = "UPDATE DataAnalysis SET SMU_CRC = @newval WHERE CLM = @id"; }
                else if (columnName == "Calib_Const_IG") { CommandText = "UPDATE DataAnalysis SET Calib_Const_IG = @newval WHERE CLM = @id"; }
                else if (columnName == "Calib_Const_IO") { CommandText = "UPDATE DataAnalysis SET Calib_Const_IO = @newval WHERE CLM = @id"; }
                else if (columnName == "CAN_Speed_(kbps)") { CommandText = "UPDATE DataAnalysis SET CAN_Speed_kbps = @newval WHERE CLM = @id"; }
                else if (columnName == "Brand_ID") { CommandText = "UPDATE DataAnalysis SET Brand_ID = @newval WHERE CLM = @id"; }
                else if (columnName == "BlackBox_Downloaded") { CommandText = "UPDATE DataAnalysis SET BlackBox_Downloaded = @newval WHERE CLM = @id"; }
                else if (columnName == "Critical_Fault") { CommandText = "UPDATE DataAnalysis SET Critical_Fault = @newval WHERE CLM = @id"; }
                else if (columnName == "Pofbit_CBIT") { CommandText = "UPDATE DataAnalysis SET Pofbit_CBIT = @newval WHERE CLM = @id"; }
                else if (columnName == "Fault_Description") { CommandText = "UPDATE DataAnalysis SET Fault_Description = @newval WHERE CLM = @id"; }
                else if (columnName == "Production_Date") { CommandText = "UPDATE DataAnalysis SET Production_Date = @newval WHERE CLM = @id"; }
                else if (columnName == "Warranty_(2_5_years)") { CommandText = "UPDATE DataAnalysis SET Warranty_2_5_years = @newval WHERE CLM = @id"; }
                else if (columnName == "Charged") { CommandText = "UPDATE DataAnalysis SET Charged = @newval WHERE CLM = @id"; }
                else if (columnName == "Discharged") { CommandText = "UPDATE DataAnalysis SET Discharged = @newval WHERE CLM = @id"; }
                else if (columnName == "Capacity_Test") { CommandText = "UPDATE DataAnalysis SET Capacity_Test = @newval WHERE CLM = @id"; }
                else if (columnName == "Contiunity_Test") { CommandText = "UPDATE DataAnalysis SET Contiunity_Test = @newval WHERE CLM = @id"; }
                else if (columnName == "Function_Test") { CommandText = "UPDATE DataAnalysis SET Function_Test = @newval WHERE CLM = @id"; }
                else if (columnName == "BMS_Test") { CommandText = "UPDATE DataAnalysis SET BMS_Test = @newval WHERE CLM = @id"; }
                else if (columnName == "BMS_Test_Result") { CommandText = "UPDATE DataAnalysis SET BMS_Test_Result = @newval WHERE CLM = @id"; }
                else if (columnName == "Result") { CommandText = "UPDATE DataAnalysis SET Result = @newval WHERE CLM = @id"; }

                try
                {
                    if (CommandText != string.Empty)
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@newval", newValue);
                        cmd.Parameters.AddWithValue("@id", rowId);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        lblActionInfo.ForeColor = Color.Green;
                        lblActionInfo.Text = "Data '" + columnName + "' úspěšně změněna pro ID = " + rowId + ".";
                        //form.DataRepair.Clear();
                        //dataGridOpravy.DataSource = GetTableDataRepairs(conn, DataRepair, bindRepairData);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void přidatKódToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((Level == "100") || (Level == "20") || (Level == "10"))
            {
                FaultCodes.AddFaultCode faultCodesAdd = new FaultCodes.AddFaultCode();
                faultCodesAdd.Show();
            }
        }

        private void upravitKódyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FaultCodes.ListFaultCodes listFaultCodes = new FaultCodes.ListFaultCodes();
            listFaultCodes.Show();
        }

        bool selectClaim = false;
        int rowSelectClaim = 0;
        string colSelectClaim = string.Empty;

        private void dgvExpedition_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var x = dgvExpedition.Columns[e.ColumnIndex].Name;
            if ((x == "Column_3_add") || (x == "Column_4_add") || (x == "Column_5_add") || (x == "Column_6_add") || (x == "Column_7_add") || (x == "Column_8_add"))
            {
                if (e.RowIndex >= 0)
                {
                    selectClaim = true;
                    rowSelectClaim = dgvExpedition.Rows[e.RowIndex].Index;
                    colSelectClaim = dgvExpedition.Columns[e.ColumnIndex - 1].Name;
                    tabControl1.SelectedTab = tabPage2;
                }
            }
        }

        private void dataGridOpravy_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (selectClaim)
            {
                string PNValue = dataGridOpravy.SelectedCells[3].Value.ToString();
                string SNValue = dataGridOpravy.SelectedCells[4].Value.ToString();
                string final = PNValue + "_" + SNValue;

                tabControl1.SelectedTab = tabPage4;

                try
                {
                    conn.Open();

                    SqlCommand cmdCount = new SqlCommand("SELECT COUNT(*) from DataExpedition where Position_1 like '" + final + "' OR Position_2 like '" + final + "' OR Position_3 like '" + final + "' OR Position_4 like '" + final + "' OR Position_5 like '" + final + "' OR Position_6 like '" + final + "'", conn);

                    int count = (int)cmdCount.ExecuteScalar();
                    conn.Close();

                    if (count > 0)
                    {
                        MessageBox.Show("PN a SN baterie je již v seznamu expedice.", "Upozornění", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        dgvExpedition.Rows[rowSelectClaim].Cells[colSelectClaim].Value = final;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                selectClaim = false;
            }
        }

        private void dgvExpedition_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (tabControl1.SelectedTab == tabControl1.TabPages[3])
            {
                string CommandText = string.Empty;
                string columnName = dgvExpedition.Columns[e.ColumnIndex].HeaderText;
                string rowId = dgvExpedition[0, e.RowIndex].Value.ToString();
                string newValue = String.Empty;
                if (dgvExpedition[e.ColumnIndex, e.RowIndex].Value == null)
                {
                    newValue = String.Empty;
                }
                else
                {
                    newValue = dgvExpedition[e.ColumnIndex, e.RowIndex].Value.ToString();
                }

                if (columnName == "Typ palety") { CommandText = "UPDATE DataExpedition SET Type_of_Palette = @newval WHERE Expedition_Id = @id"; }
                else if (columnName == "1. Pozice") { CommandText = "UPDATE DataExpedition SET Position_1 = @newval WHERE Expedition_Id = @id"; }
                else if (columnName == "2. Pozice") { CommandText = "UPDATE DataExpedition SET Position_2 = @newval WHERE Expedition_Id = @id"; }
                else if (columnName == "3. Pozice") { CommandText = "UPDATE DataExpedition SET Position_3 = @newval WHERE Expedition_Id = @id"; }
                else if (columnName == "4. Pozice") { CommandText = "UPDATE DataExpedition SET Position_4 = @newval WHERE Expedition_Id = @id"; }
                else if (columnName == "5. Pozice") { CommandText = "UPDATE DataExpedition SET Position_5 = @newval WHERE Expedition_Id = @id"; }
                else if (columnName == "6. Pozice") { CommandText = "UPDATE DataExpedition SET Position_6 = @newval WHERE Expedition_Id = @id"; }
                else if (columnName == "Místo") { CommandText = "UPDATE DataExpedition SET Place = @newval WHERE Expedition_Id = @id"; }
                else if (columnName == "Datum přípravy") { CommandText = "UPDATE DataExpedition SET Date_of_prepare = @newval WHERE Expedition_Id = @id"; }
                else if (columnName == "Datum expedice") { CommandText = "UPDATE DataExpedition SET Date_of_expedition = @newval WHERE Expedition_Id = @id"; }

                try
                {
                    if (CommandText != string.Empty)
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(CommandText, conn);
                        cmd.Parameters.AddWithValue("@newval", newValue);
                        cmd.Parameters.AddWithValue("@id", rowId);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                        lblActionInfo.ForeColor = Color.Green;
                        lblActionInfo.Text = "Data '" + columnName + "' úspěšně změněna pro ID = " + rowId + ".";
                        //form.DataRepair.Clear();
                        //dataGridOpravy.DataSource = GetTableDataRepairs(conn, DataRepair, bindRepairData);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void RemoveValue_Click(object sender, EventArgs e)
        {
            if ((Level == "100") || (Level == "20") || (Level == "10") || (Level == "5"))
            {
                dgvExpedition.CurrentCell.Value = string.Empty;
            }
        }
    }
}
