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

        TabPage pageDataMain = new TabPage("Opravy");
        DataGridView dataGridOpravy = new DataGridView();

        private static Main form = null;

        public Main()
        {
            InitializeComponent();

            tabControl1.TabPages[0].Text = "Data";

            btnAddData.Visible = false;
            btnDelData.Visible = false;

            // Double buffering can make DGV slow in remote desktop
            if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
            {
                Type dgvType = dataGrid1.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(dataGrid1, true, null);
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

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                SqlCommand getUserData = new SqlCommand("SELECT FirstName, LastName, Level FROM Users WHERE Name='" + MyName + "'", conn);
                SqlDataAdapter da = new SqlDataAdapter(getUserData);
                SqlDataReader reader = getUserData.ExecuteReader();

                while(reader.Read())
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
                        GetTableDataMain(conn);
                        AddTabControl();
                        GetTableDataRepairs(conn);

                        btnUsers.Visible = true;
                        btnAddData.Visible = true;
                        btnDelData.Visible = true;
                    }
                    else if (Level == "20")
                    {
                        lblLevel.Text = "Technik";
                        GetTableDataMain(conn);
                        AddTabControl();
                        GetTableDataRepairs(conn);

                        btnAddData.Visible = true;
                        btnDelData.Visible = true;
                    }
                    else if (Level == "10")
                    {
                        lblLevel.Text = "Příjem";
                        AddTabControl();
                        GetTableDataMain(conn);

                        btnAddData.Visible = true;
                        btnDelData.Visible = true;
                    }
                    else if (Level == "5")
                    {
                        lblLevel.Text = "Opravář";
                        AddTabControl();
                        GetTableDataRepairs(conn);
                        btnDelData.Visible = true;
                        btnAddData.Visible = true;
                    }
                    else if (Level == "1")
                    {
                        lblLevel.Text = "Pouze čtení";
                        GetTableDataMain(conn);
                        AddTabControl();
                        GetTableDataRepairs(conn);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AddTabControl()
        {
            tabControl1.TabPages.Add(pageDataMain);

            pageDataMain.SuspendLayout();
            pageDataMain.Controls.Add(dataGridOpravy);
            pageDataMain.ResumeLayout();

            dataGridOpravy.Parent = pageDataMain;
            dataGridOpravy.Size = new Size(822, 621);
            dataGridOpravy.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);
            dataGridOpravy.ReadOnly = true;
            dataGridOpravy.AllowUserToAddRows = false;
            dataGridOpravy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            dataGridOpravy.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridOpravy.AllowUserToDeleteRows = false;

            if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
            {
                Type dgvType2 = dataGridOpravy.GetType();
                PropertyInfo pi = dgvType2.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(dataGridOpravy, true, null);
            }
        }

        public static void GetTableDataMain(SqlConnection connection)
        {
            DataTable DataMain = new DataTable();

            try
            {
                connection.Open();
                SqlCommand getDataMain = new SqlCommand("SELECT * FROM DataMain", connection);
                SqlDataAdapter daDataMain = new SqlDataAdapter(getDataMain);

                daDataMain.Fill(DataMain);

                connection.Close();

                form.dataGrid1.DataSource = DataMain;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void GetTableDataRepairs(SqlConnection connection)
        {
            DataTable DataRepairs = new DataTable();

            try
            {
                connection.Open();
                SqlCommand getDataRepairs = new SqlCommand("SELECT * FROM DataRepairs", connection);
                SqlDataAdapter daDataRepairs = new SqlDataAdapter(getDataRepairs);

                daDataRepairs.Fill(DataRepairs);

                connection.Close();

                form.dataGridOpravy.DataSource = DataRepairs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnReloadData_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Level == "100") || (Level == "20") || (Level == "1")) GetTableDataMain(conn); GetTableDataRepairs(conn);
                if (Level == "10") GetTableDataMain(conn);
                if (Level == "5") GetTableDataRepairs(conn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

                    DialogResult dialogResult = MessageBox.Show("Opravdu chcete smazat záznam " + CLM + "?", "Smazat záznam", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        conn.Open();
                        SqlCommand delData = new SqlCommand("DELETE FROM DataMain WHERE DataId=" + DataIdTab + "", conn);
                        delData.ExecuteNonQuery();
                        conn.Close();
                        GetTableDataMain(conn);
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

                    DialogResult dialogResult = MessageBox.Show("Opravdu chcete smazat záznam s ID " + RepairIdTab + "?", "Smazat záznam", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        conn.Open();
                        SqlCommand delData = new SqlCommand("DELETE FROM DataRepairs WHERE RepairId=" + RepairIdTab + "", conn);
                        delData.ExecuteNonQuery();
                        conn.Close();
                        GetTableDataRepairs(conn);
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

            string fileName = exportName + DateTime.Now.ToString("H:mm:ss") + ".xlsx";

            string filePath = string.Empty;

            FolderBrowserDialog SaveFileExport = new FolderBrowserDialog();

            fileName = fileName.Replace(":", "_");

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
            }
        }
    }
}
