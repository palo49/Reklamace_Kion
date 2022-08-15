using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reklamace_Kion.RepairAnalyze
{
    public partial class RepairAnalyze : Form
    {

        SQL mysql = new SQL();

        public string PN { get; set; }
        public string CLM { get; set; }

        public string Level { get; set; }

        string PNChar = string.Empty;

        public DataTable DataTorque = new DataTable();
        BindingSource bindTorqueData = new BindingSource();

        public DataTable DataComponent = new DataTable();
        BindingSource bindComponentData = new BindingSource();

        public RepairAnalyze()
        {
            InitializeComponent();

            if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
            {
                Type dgvType = dgvTorque.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(dgvTorque, true, null);

                Type dgvType2 = dgvComponent.GetType();
                PropertyInfo pi2 = dgvType2.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
                pi2.SetValue(dgvComponent, true, null);
            }
        }

        public BindingSource GetTableData(DataTable dt, BindingSource src, string table, string clm)
        {
            try
            {

                mysql.OpenConection();
                SqlCommand getData = new SqlCommand("SELECT * FROM " + table + " WHERE CLM = '" + clm + "'", mysql.con);
                SqlDataAdapter daData = new SqlDataAdapter(getData);

                daData.Fill(dt);

                mysql.CloseConnection();
                src.DataSource = dt;
                return src;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private void RepairAnalyze_Load(object sender, EventArgs e)
        {
            int lvl = Convert.ToInt32(Level);
            if(lvl >= 5)
            {
                dgvTorque.ReadOnly = false;
                dgvComponent.ReadOnly = false;
            }

            PNChar = PN.Substring(PN.LastIndexOf('_') + 1);

            tabPage1.Text = PNChar + "_torque";
            tabPage2.Text = PNChar + "_component";

            try
            {
                dgvTorque.ColumnHeadersVisible = false;
                dgvComponent.ColumnHeadersVisible = false;
                dgvTorque.DataSource = GetTableData(DataTorque, bindTorqueData, "CLM_torques_" + PNChar, CLM);
                dgvComponent.DataSource = GetTableData(DataComponent, bindComponentData, "CLM_components_" + PNChar, CLM);
                dgvTorque.ColumnHeadersVisible = true;
                dgvComponent.ColumnHeadersVisible = true;
                dgvTorque.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
                dgvComponent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvTorque_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int curTab = tabControl.SelectedIndex;
            string columnName = dgvTorque.Columns[e.ColumnIndex].Name;
            string id = dgvComponent[1, e.RowIndex].Value.ToString();
            string CommandText = string.Empty;

            try
            {
                if (curTab == 0)
                {
                    CommandText = "UPDATE CLM_torques_" + PNChar + " SET [" + columnName + "] = @newval WHERE CLM = @id";
                }
                else if (curTab == 1)
                {
                    CommandText = "UPDATE CLM_components_" + PNChar + " SET [" + columnName + "] = @newval WHERE CLM = @id";
                }

                if ((columnName != "Analysis_Id") || (columnName != "CLM") || (columnName != "PN_Type"))
                {
                    mysql.OpenConection();
                    SqlCommand cmd = new SqlCommand(CommandText, mysql.con);
                    if (columnName.Contains("MODULE"))
                    {
                        cmd.Parameters.AddWithValue("@newval", dgvTorque[e.ColumnIndex, e.RowIndex].Value.ToString());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@newval", Decimal.Parse(dgvTorque[e.ColumnIndex, e.RowIndex].Value.ToString()));
                    }
                    
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.ExecuteNonQuery();
                    mysql.CloseConnection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvTorque_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int col = dgvTorque.Columns[e.ColumnIndex].Index;

            if ((col == 0) || (col == 1) || (col == 2))
            {
                
            }
            else
            {
                dgvTorque.BeginEdit(true);
            }
        }

        private void dgvTorque_FilterStringChanged(object sender, EventArgs e)
        {
            this.bindTorqueData.Filter = this.dgvTorque.FilterString;
        }

        private void dgvTorque_SortStringChanged(object sender, EventArgs e)
        {
            this.bindTorqueData.Sort = this.dgvTorque.SortString;
        }
    }
}
