using System;
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

namespace Reklamace_Kion.AdminPanel
{
    public partial class AdminPanel : Form
    {
        public string MyName { get; set; }

        SqlConnection conn = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace"); // making connection

        bool loading = false;

        public AdminPanel()
        {
            InitializeComponent();
        }

        public bool GetService(string table, string col, string name)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select " + col + " from " + table + " where Name='" + name + "'", conn);
            bool res = Convert.ToBoolean(cmd.ExecuteScalar());
            conn.Close();
            return res;
        }

        public void SetService(string table, string col, string name, bool value)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("UPDATE " + table + " SET " + col + " = @newval WHERE Name = '" + name + "'", conn);
                cmd.Parameters.AddWithValue("@newval", value);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            try
            {
                loading = true;
                chckServiceMode.Checked = GetService("AppSettings", "Activated", "ServiceMode");
                loading = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void chckServiceMode_CheckedChanged(object sender, EventArgs e)
        {
            if (!loading) { SetService("AppSettings", "Activated", "ServiceMode", chckServiceMode.Checked); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Users UF = new Users();
            UF.MyName = MyName;
            UF.Show();
        }
    }
}
