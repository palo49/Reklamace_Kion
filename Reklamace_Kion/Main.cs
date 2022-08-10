﻿using System;
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

                            dataGrid1.ReadOnly = dataGridOpravy.ReadOnly = false;
                        }
                        else if (Level == "20")
                        {
                            lblLevel.Text = "Technik";

                            btnAddData.Visible = true;
                            btnDelData.Visible = true;

                            dataGrid1.ReadOnly = dataGridOpravy.ReadOnly = false;
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
                ReloadData();
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

                    DialogResult dialogResult = MessageBox.Show("Opravdu chcete smazat záznam s ID " + RepairIdTab + "?", "Smazat záznam", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dialogResult == DialogResult.Yes)
                    {
                        conn.Open();
                        SqlCommand delData = new SqlCommand("DELETE FROM DataRepairs WHERE RepairId=" + RepairIdTab + "", conn);
                        delData.ExecuteNonQuery();
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

            if (columnName == "Brand") { CommandText = "UPDATE DataRepairs SET Brand = @newval WHERE RepairId = @id"; }
            else if (columnName == "WD") { CommandText = "UPDATE DataRepairs SET WD = @newval WHERE RepairId = @id"; }
            else if (columnName == "BB") { CommandText = "UPDATE DataRepairs SET BB = @newval WHERE RepairId = @id"; }
            else if (columnName == "ZD") { CommandText = "UPDATE DataRepairs SET ZD = @newval WHERE RepairId = @id"; }
            else if (columnName == "SW") { CommandText = "UPDATE DataRepairs SET SW = @newval WHERE RepairId = @id"; }
            else if (columnName == "PD") { CommandText = "UPDATE DataRepairs SET PD = @newval WHERE RepairId = @id"; }
            else if (columnName == "Test") { CommandText = "UPDATE DataRepairs SET Test = @newval WHERE RepairId = @id"; }
            else if (columnName == "Charging") { CommandText = "UPDATE DataRepairs SET Charging = @newval WHERE RepairId = @id"; }
            else if (columnName == "SetBrandID") { CommandText = "UPDATE DataRepairs SET SetBrandID = @newval WHERE RepairId = @id"; }
            else if (columnName == "PrintScr") { CommandText = "UPDATE DataRepairs SET PrintScr = @newval WHERE RepairId = @id"; }
            else if (columnName == "Label") { CommandText = "UPDATE DataRepairs SET Label = @newval WHERE RepairId = @id"; }
            else if (columnName == "TypeOfPalette") { CommandText = "UPDATE DataRepairs SET TypeOfPalette = @newval WHERE RepairId = @id"; }
            else if (columnName == "ExpectedExpedition") { CommandText = "UPDATE DataRepairs SET ExpectedExpedition = @newval WHERE RepairId = @id"; }
            else if (columnName == "SOH") { CommandText = "UPDATE DataRepairs SET SOH = @newval WHERE RepairId = @id"; }
            else if (columnName == "CapacityTest") { CommandText = "UPDATE DataRepairs SET CapacityTest = @newval WHERE RepairId = @id"; }

            try
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

            if (columnName == "CLM") { CommandText = "UPDATE DataMain SET CLM = @newval WHERE DataId = @id"; }
            else if (columnName == "State") { CommandText = "UPDATE DataMain SET State = @newval WHERE DataId = @id"; }
            else if (columnName == "CustomerRequire") { CommandText = "UPDATE DataMain SET CustomerRequire = @newval WHERE DataId = @id"; }
            else if (columnName == "DateOfCustomerSend") { CommandText = "UPDATE DataMain SET DateOfCustomerSend = @newval WHERE DataId = @id"; }
            else if (columnName == "DateOfSaftAcceptance") { CommandText = "UPDATE DataMain SET DateOfSaftAcceptance = @newval WHERE DataId = @id"; }
            else if (columnName == "DateOfRepair") { CommandText = "UPDATE DataMain SET DateOfRepair = @newval WHERE DataId = @id"; }
            else if (columnName == "DateOfSaftSend") { CommandText = "UPDATE DataMain SET DateOfSaftSend = @newval WHERE DataId = @id"; }
            else if (columnName == "ClaimedComponent") { CommandText = "UPDATE DataMain SET ClaimedComponent = @newval WHERE DataId = @id"; }
            else if (columnName == "Type") { CommandText = "UPDATE DataMain SET Type = @newval WHERE DataId = @id"; }
            else if (columnName == "SerialNumber") { CommandText = "UPDATE DataMain SET SerialNumber = @newval WHERE DataId = @id"; }
            else if (columnName == "Fault") { CommandText = "UPDATE DataMain SET Fault = @newval WHERE DataId = @id"; }
            else if (columnName == "TypeCW") { CommandText = "UPDATE DataMain SET TypeCW = @newval WHERE DataId = @id"; }
            else if (columnName == "DefectBMS") { CommandText = "UPDATE DataMain SET DefectBMS = @newval WHERE DataId = @id"; }
            else if (columnName == "LocationOfBattery") { CommandText = "UPDATE DataMain SET LocationOfBattery = @newval WHERE DataId = @id"; }
            else if (columnName == "ReplacementSend") { CommandText = "UPDATE DataMain SET ReplacementSend = @newval WHERE DataId = @id"; }
            else if (columnName == "DateOfReplacementSend") { CommandText = "UPDATE DataMain SET DateOfReplacementSend = @newval WHERE DataId = @id"; }
            else if (columnName == "Result") { CommandText = "UPDATE DataMain SET Result = @newval WHERE DataId = @id"; }
            else if (columnName == "ResultDescription") { CommandText = "UPDATE DataMain SET ResultDescription = @newval WHERE DataId = @id"; }
            else if (columnName == "CostOfRepair") { CommandText = "UPDATE DataMain SET CostOfRepair = @newval WHERE DataId = @id"; }
            else if (columnName == "Contact") { CommandText = "UPDATE DataMain SET Contact = @newval WHERE DataId = @id"; }

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@newval", newValue);
                cmd.Parameters.AddWithValue("@id", rowId);
                cmd.ExecuteNonQuery();
                conn.Close();
                lblActionInfo.ForeColor = Color.Green;
                lblActionInfo.Text = "Data '" + columnName + "' úspěšně změněna pro ID = " + rowId + ".";
                //form.DataMain.Clear();
                //dataGrid1.DataSource = GetTableDataMain(conn, DataMain, bindMainData);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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
            lblLoadingData.Visible = false;
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
                this.bindMainData.Filter = "(CLM LIKE '%" + txtSearch.Text + "%') OR " +
                    "(State LIKE '%" + txtSearch.Text + "%') OR " +
                    "(CustomerRequire LIKE '%" + txtSearch.Text + "%') OR " +
                    "(DateOfCustomerSend LIKE '%" + txtSearch.Text + "%') OR " +
                    "(DateOfSaftAcceptance LIKE '%" + txtSearch.Text + "%') OR " +
                    "(DateOfRepair LIKE '%" + txtSearch.Text + "%') OR " +
                    "(DateOfSaftSend LIKE '%" + txtSearch.Text + "%') OR " +
                    "(ClaimedComponent LIKE '%" + txtSearch.Text + "%') OR " +
                    "(Type LIKE '%" + txtSearch.Text + "%') OR " +
                    "(SerialNumber LIKE '%" + txtSearch.Text + "%') OR " +
                    "(Fault LIKE '%" + txtSearch.Text + "%') OR " +
                    "(TypeCW LIKE '%" + txtSearch.Text + "%') OR " +
                    "(DefectBMS LIKE '%" + txtSearch.Text + "%') OR " +
                    "(LocationOfBattery LIKE '%" + txtSearch.Text + "%') OR " +
                    "(ReplacementSend LIKE '%" + txtSearch.Text + "%') OR " +
                    "(DateOfReplacementSend LIKE '%" + txtSearch.Text + "%') OR " +
                    "(Result LIKE '%" + txtSearch.Text + "%') OR " +
                    "(ResultDescription LIKE '%" + txtSearch.Text + "%') OR " +
                    "(Contact LIKE '%" + txtSearch.Text + "%')";
            }
            catch (Exception ex)
            {
                lblActionInfo.Text = ex.Message;
            }
        }

        DataGridView.HitTestInfo actualCell;

        private void dataGrid1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hti = dataGrid1.HitTest(e.X, e.Y);
                dataGrid1.ClearSelection();
                dataGrid1.Rows[hti.RowIndex].Selected = true;
                actualCell = hti;
            }
        }

        private void přidatKOpravámToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                string actualCellValue = dataGrid1[actualCell.ColumnIndex, actualCell.RowIndex].Value.ToString();

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
                        SqlCommand cmd = new SqlCommand("INSERT INTO DataRepairs values('" + actualCellValue + "', '', '', '', '', '', " +
                                "'','','','',''," +
                                "'','','','','')", conn);
                        if (cmd.ExecuteNonQuery() != 0)
                        {
                            form.DataRepair.Clear();
                            SqlCommand getDataRepair = new SqlCommand("SELECT * FROM DataRepairs", form.conn);
                            SqlDataAdapter daDataRepair = new SqlDataAdapter(getDataRepair);

                            daDataRepair.Fill(form.DataRepair);
                            form.bindRepairData.ResetBindings(true);

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
}
