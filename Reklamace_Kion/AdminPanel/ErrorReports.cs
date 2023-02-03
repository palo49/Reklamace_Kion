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
                string query = "SELECT Title, Login, FirstName, LastName, Date_time, ID, Solved FROM ErrorReports ORDER BY ID DESC";
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int y = 0;

                while (reader.Read())
                {
                    string solved = "Nevyřízené";
                    Color color = Color.Red;

                    if (reader.GetInt32(6) == 1) { 
                        solved = "Vyřízené";
                        color = Color.Green;
                    }

                    Panel p = new Panel();
                    p.Size = new Size(206,55);
                    p.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
                    p.Location = new Point(0,y);
                    p.BackColor = Color.FromArgb(255, 206, 212, 218);
                    p.Cursor = Cursors.Hand;
                    p.Click += new EventHandler(this.ShowContent);
                    p.Name = reader.GetInt32(5).ToString();
                    p.MouseEnter += (sender, e) => onEnter(p);
                    p.MouseLeave += (sender, e) => onLeave(p);
                    panelTitle.Controls.Add(p);

                    Label title = new Label();
                    title.Text = reader.GetString(0);
                    title.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                    title.Location = new Point(0, 5);
                    title.Size = new Size(195,15);
                    title.Cursor = Cursors.Hand;
                    title.Click += new EventHandler(this.ShowContent);
                    title.Name = reader.GetInt32(5).ToString();
                    title.Font = new Font(Font.FontFamily, Font.Size, FontStyle.Bold);
                    title.BackColor = Color.Transparent;
                    title.MouseEnter += (sender, e) => onEnter(p);
                    title.MouseLeave += (sender, e) => onLeave(p);
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
                    date_time.BackColor = Color.Transparent;
                    date_time.MouseEnter += (sender, e) => onEnter(p);
                    date_time.MouseLeave += (sender, e) => onLeave(p);
                    p.Controls.Add(date_time);

                    Label slv = new Label();
                    slv.Text = solved;
                    slv.Anchor = AnchorStyles.Left | AnchorStyles.Top;
                    slv.Location = new Point(0, 36);
                    slv.Size = new Size(195, 15);
                    slv.ForeColor = color;
                    slv.Cursor = Cursors.Hand;
                    slv.Click += new EventHandler(this.ShowContent);
                    slv.Name = reader.GetInt32(5).ToString();
                    slv.BackColor = Color.Transparent;
                    slv.MouseEnter += (sender, e) => onEnter(p);
                    slv.MouseLeave += (sender, e) => onLeave(p);
                    p.Controls.Add(slv);

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

        private void onEnter(Panel panel)
        {
            panel.BackColor = Color.AliceBlue;
        }

        private void onLeave(Panel panel)
        {
            panel.BackColor = Color.FromArgb(255, 206, 212, 218);
        }

        int actualID = -1;

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
            actualID = id;
            string query = "SELECT Title, Content, Solved FROM ErrorReports WHERE ID="+id+"";
            SqlCommand cmd = new SqlCommand(query, conn);

            conn.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                txtTitleRight.Text = reader.GetString(0);
                txtContentRight.Text = reader.GetString(1);

                if (reader.GetInt32(2) == 0)
                {
                    btnSolve.Text = "Vyřešit";
                    btnSolve.Enabled = true;
                }
                else
                {
                    btnSolve.Text = "Vyřešeno";
                    btnSolve.Enabled = false;
                }
            }
            reader.Close();
            conn.Close();
        }

        private void ErrorReports_Load(object sender, EventArgs e)
        {
            ListRows();
        }

        private void btnSolve_Click(object sender, EventArgs e)
        {
            string query = "UPDATE ErrorReports SET Solved=1 WHERE ID=" + actualID + "";
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            int res = cmd.ExecuteNonQuery();
            if (res == 0)
            {
                MessageBox.Show("Zápis do databáze se nepodařilo provést.");
                conn.Close();
            }
            else
            {
                conn.Close();
                this.Close();
            }
        }

        private void ErrorReports_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
        }
    }
}
