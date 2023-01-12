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

namespace Reklamace_Kion.AdminPanel
{
    public partial class ErrorReports : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace");

        public ErrorReports()
        {
            InitializeComponent();
        }

        public void ListRows()
        {
            try
            {
                string query = "SELECT Title, Login, FirstName, LastName, Date_time, ID FROM ErrorReports ORDER BY ID DESC";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int y = 0;

                while (reader.Read())
                {
                    Panel p = new Panel();
                    p.Size = new Size(206,55);
                    p.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    p.Location = new Point(0,y);
                    p.BackColor = Color.FromArgb(255, 206, 212, 218);
                    p.Cursor = Cursors.Hand;
                    p.Click += new EventHandler(this.ShowContent);
                    p.Name = reader.GetInt32(5).ToString();
                    panelTitle.Controls.Add(p);

                    Label title = new Label();
                    title.Text = reader.GetString(0);
                    title.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                    title.Location = new Point(0, 5);
                    title.Size = new Size(195,15);
                    title.Cursor = Cursors.Hand;
                    title.Click += new EventHandler(this.ShowContent);
                    title.Name = reader.GetInt32(5).ToString();
                    p.Controls.Add(title);

                    Label date_time = new Label();
                    date_time.Text = reader.GetString(4);
                    date_time.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                    date_time.Location = new Point(0, 20);
                    date_time.Size = new Size(195, 15);
                    date_time.ForeColor = SystemColors.ControlDark;
                    date_time.Cursor = Cursors.Hand;
                    date_time.Click += new EventHandler(this.ShowContent);
                    date_time.Name = reader.GetInt32(5).ToString();
                    p.Controls.Add(date_time);

                    Label login = new Label();
                    login.Text = reader.GetString(1);
                    login.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                    login.Location = new Point(0, 36);
                    login.Size = new Size(195, 15);
                    login.ForeColor = SystemColors.ControlDark;
                    login.Cursor = Cursors.Hand;
                    login.Click += new EventHandler(this.ShowContent);
                    login.Name = reader.GetInt32(5).ToString();
                    p.Controls.Add(login);

                    y += 57;
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void ShowContent(object sender, EventArgs e)
        {
            string idstring = string.Empty;
            if (sender is Panel)
            {
                idstring = ((Panel)sender).Name;
            }
            else
            {
                idstring = ((Label)sender).Name;
            }
            
            int id = Convert.ToInt32(idstring);
            string query = "SELECT Title, Content FROM ErrorReports WHERE ID="+id+"";
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                txtTitleRight.Text = reader.GetString(0);
                txtContentRight.Text = reader.GetString(1);
            }
            reader.Close();
            conn.Close();
        }

        private void ErrorReports_Load(object sender, EventArgs e)
        {
            ListRows();
        }
    }
}
