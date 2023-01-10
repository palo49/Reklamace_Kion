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

namespace Reklamace_Kion.ReportErrors
{
    public partial class ReportErrors : Form
    {

        public int      MyLevel     { get; set; }
        public string   MyLogin     { get; set; }
        public string   MyFirstName { get; set; }
        public string   MyLastName  { get; set; }

        SqlConnection conn = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace");

        public ReportErrors()
        {
            InitializeComponent();
        }

        private void ReportErrors_Load(object sender, EventArgs e)
        {
            txtLogin.Text = MyLogin;
            txtName.Text = MyFirstName;
            txtLastName.Text = MyLastName;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text;
            string text = txtContent.Text;

            if(text != string.Empty && title != string.Empty)
            {
                SqlCommand cmd = new SqlCommand("INSERT INTO ErrorReports values('" + title + "', '" + text + "', '" + MyLogin + "', '" + MyFirstName + "', '" + MyLastName + "', '" + DateTime.Now.ToString("yyyy.MM.dd HH:mm:ss") + "')", conn);
                conn.Open();
                int res = cmd.ExecuteNonQuery();
                conn.Close();
                
                if (res > 0)
                {
                    MessageBox.Show("Zpráva se odeslála.", "Hotovo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Někde se stala chyba. Zprávu nejde odeslat", "Nelze odeslat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Je potřeba vyplnit předmět a obsah zprávy.", "Nelze odeslat", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
