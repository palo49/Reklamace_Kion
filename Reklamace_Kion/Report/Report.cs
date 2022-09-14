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

namespace Reklamace_Kion.Report
{
    public partial class Report : Form
    {
        SQL sql = new SQL();

        public Report()
        {
            InitializeComponent();
        }

        public string[] getColumnsName(string tableName)
        {
            try
            {
                List<string> listacolumnas = new List<string>();

                string cmd = "select c.name from sys.columns c inner join sys.tables t on t.object_id = c.object_id and t.name = '" + tableName + "' and t.type = 'U'";
                SqlCommand command = new SqlCommand(cmd, sql.con);
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listacolumnas.Add(reader.GetString(0));
                    }
                }

                return listacolumnas.ToArray();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        public void getAllChecked(Panel panel)
        {
            string names = string.Empty;
            foreach (CheckBox c in panel.Controls)
            {
                if (c.Checked)
                {
                    names += c.Name + ", ";
                }
            }
            //MessageBox.Show(names);
        }

        private void Report_Load(object sender, EventArgs e)
        {
            try
            {
                sql.OpenConection();

                int cMain = sql.CountCols("DataMain");
                int cRepairs = sql.CountCols("DataRepairs");

                string[] namesMain = getColumnsName("DataMain");
                string[] namesRepairs = getColumnsName("DataRepairs");

                for (int i = 0; i < cMain; i++)
                {
                    CheckBox chckMain = new CheckBox();
                    chckMain.Height = 30;
                    chckMain.Width = 280;
                    chckMain.Cursor = Cursors.Hand;
                    chckMain.Location = new Point(10, (chckMain.Height * i));
                    chckMain.Name = namesMain[i];
                    chckMain.Text = namesMain[i];
                    panelReklamation.Controls.Add(chckMain);
                }

                for (int i = 0; i < cRepairs; i++)
                {
                    CheckBox chckMain = new CheckBox();
                    chckMain.Height = 30;
                    chckMain.Width = 280;
                    chckMain.Cursor = Cursors.Hand;
                    chckMain.Location = new Point(10, (chckMain.Height * i));
                    chckMain.Name = namesRepairs[i];
                    chckMain.Text = namesRepairs[i];
                    panelRepairs.Controls.Add(chckMain);
                }

                sql.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCreateExcel_Click(object sender, EventArgs e)
        {
            getAllChecked(panelReklamation);
            getAllChecked(panelRepairs);
        }
    }
}
