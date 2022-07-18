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

namespace Reklamace_Kion
{
    public partial class Main : Form
    {
        public string MyName { get; set; }

        string FirstName = string.Empty;
        string LastName = string.Empty;
        string Level = string.Empty;

        SqlConnection conn = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace");

        TabPage pageDataMain = new TabPage("Opravy");
        DataGridView dataGridOpravy = new DataGridView();

        public Main()
        {
            InitializeComponent();

            tabControl1.TabPages[0].Text = "Data";
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
                        dataGrid1.DataSource = GetTableDataMain(conn);
                        AddTabControl();
                        dataGridOpravy.DataSource = GetTableDataRepairs(conn);

                        btnUsers.Visible = true;
                    }
                    else if (Level == "20")
                    {
                        lblLevel.Text = "Technik";
                        dataGrid1.DataSource = GetTableDataMain(conn);
                        AddTabControl();
                        dataGridOpravy.DataSource = GetTableDataRepairs(conn);
                    }
                    else if (Level == "10")
                    {
                        lblLevel.Text = "Příjem";
                        dataGrid1.DataSource = GetTableDataMain(conn);
                    }
                    else if (Level == "5")
                    {
                        lblLevel.Text = "Opravář";
                        tabControl1.TabPages[0].Text = "Opravy";
                        dataGrid1.DataSource = GetTableDataRepairs(conn);
                    }
                    else if (Level == "1")
                    {
                        lblLevel.Text = "Pouze čtení";
                        dataGrid1.DataSource = GetTableDataMain(conn);
                        AddTabControl();
                        dataGridOpravy.DataSource = GetTableDataRepairs(conn);
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
            dataGridOpravy.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);
            dataGridOpravy.Size = new Size(822, 635);
            dataGridOpravy.ReadOnly = true;
            dataGridOpravy.AllowUserToAddRows = false;
            dataGridOpravy.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public static DataTable GetTableDataMain(SqlConnection connection)
        {
            DataTable DataMain = new DataTable();

            try
            {
                connection.Open();
                SqlCommand getDataMain = new SqlCommand("SELECT * FROM DataMain", connection);
                SqlDataAdapter daDataMain = new SqlDataAdapter(getDataMain);

                daDataMain.Fill(DataMain);

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return DataMain;
        }

        public static DataTable GetTableDataRepairs(SqlConnection connection)
        {
            DataTable DataRepairs = new DataTable();

            try
            {
                connection.Open();
                SqlCommand getDataRepairs = new SqlCommand("SELECT * FROM DataRepairs", connection);
                SqlDataAdapter daDataRepairs = new SqlDataAdapter(getDataRepairs);

                daDataRepairs.Fill(DataRepairs);

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return DataRepairs;
        }

        private void btnReloadData_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Level == "100") || (Level == "20") || (Level == "1")) dataGrid1.DataSource = GetTableDataMain(conn); dataGridOpravy.DataSource = GetTableDataRepairs(conn);
                if (Level == "10") dataGrid1.DataSource = GetTableDataMain(conn);
                if (Level == "5") dataGridOpravy.DataSource = GetTableDataRepairs(conn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {
            Users UserForm = new Users();

            UserForm.MyName = MyName;

            UserForm.Show();
        }
    }
}
