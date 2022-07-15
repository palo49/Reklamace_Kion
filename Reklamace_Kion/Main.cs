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

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            SqlCommand getUserData = new SqlCommand("SELECT FirstName, LastName, Level FROM Users WHERE Name='" + MyName + "'", conn);
            SqlDataAdapter da = new SqlDataAdapter(getUserData);

            try
            {
                conn.Open();
                SqlDataReader reader = getUserData.ExecuteReader();

                while(reader.Read())
                {
                    lblFirstName.Text = reader.GetString(0);
                    lblLastName.Text = reader.GetString(1);
                    Level = reader.GetString(2);
                }

                if (Level != string.Empty)
                {
                    if (Level == "100") lblLevel.Text = "Administrátor";
                    if (Level == "20") lblLevel.Text = "Technik";
                    if (Level == "10") lblLevel.Text = "Příjem";
                    if (Level == "5") lblLevel.Text = "Opravář";
                    if (Level == "1") lblLevel.Text = "Pouze čtení";
                }

                conn.Close();

                dataGrid1.DataSource = GetTableDataMain(conn);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            tabControl1.TabPages[0].Text = "Data";

            TabPage pageDataMain = new TabPage("Opravy");
            tabControl1.TabPages.Add(pageDataMain);

            DataGridView dataGridOpravy = new DataGridView();
            pageDataMain.SuspendLayout();
            pageDataMain.Controls.Add(dataGridOpravy);
            pageDataMain.ResumeLayout();

            dataGridOpravy.Parent = pageDataMain;
            dataGridOpravy.Anchor = (AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom);
            dataGridOpravy.Size = new Size(822, 635);
            dataGridOpravy.ReadOnly = true;
            dataGridOpravy.AllowUserToAddRows = false;

            dataGridOpravy.DataSource = GetTableDataRepairs(conn);
        }

        public static DataTable GetTableDataMain(SqlConnection connection)
        {
            connection.Open();
            SqlCommand getDataMain = new SqlCommand("SELECT * FROM DataMain", connection);
            SqlDataAdapter daDataMain = new SqlDataAdapter(getDataMain);

            DataTable DataMain = new DataTable();

            try
            {
                daDataMain.Fill(DataMain);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            connection.Close();

            return DataMain;
        }

        public static DataTable GetTableDataRepairs(SqlConnection connection)
        {
            connection.Open();
            SqlCommand getDataRepairs = new SqlCommand("SELECT * FROM DataRepairs", connection);
            SqlDataAdapter daDataRepairs = new SqlDataAdapter(getDataRepairs);

            DataTable DataRepairs = new DataTable();

            try
            {
                daDataRepairs.Fill(DataRepairs);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            connection.Close();

            return DataRepairs;
        }

        private void btnReloadData_Click(object sender, EventArgs e)
        {
            dataGrid1.DataSource = GetTableDataMain(conn);
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
