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

namespace Reklamace_Kion.FaultCodes
{
    public partial class ListFaultCodes : Form
    {
        public ListFaultCodes()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace");
        DataTable DataFaultCodes = new DataTable();
        BindingSource bindFaultCodes = new BindingSource();

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ListFaultCodes_Load(object sender, EventArgs e)
        {
            RefData();
        }

        public void RefData()
        {
            conn.Open();
            SqlCommand getFaultCodes = new SqlCommand("SELECT * FROM FaultCodes", conn);
            SqlDataAdapter daFaultCodes = new SqlDataAdapter(getFaultCodes);

            daFaultCodes.Fill(DataFaultCodes);

            conn.Close();
            bindFaultCodes.DataSource = DataFaultCodes;
            dgvCodes.DataSource = bindFaultCodes;
        }

        private void dgvCodes_SortStringChanged(object sender, EventArgs e)
        {
            this.bindFaultCodes.Sort = this.dgvCodes.SortString;
        }

        private void dgvCodes_FilterStringChanged(object sender, EventArgs e)
        {
            this.bindFaultCodes.Filter = this.dgvCodes.FilterString;
        }

        private void dgvCodes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvCodes.BeginEdit(true);
        }

        private void dgvCodes_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string CommandText = string.Empty;
            string columnName = dgvCodes.Columns[e.ColumnIndex].Name;
            int rowId = Convert.ToInt32(dgvCodes[0, e.RowIndex].Value);
            string newValue = dgvCodes[e.ColumnIndex, e.RowIndex].Value.ToString();

            if (columnName == "Name") { CommandText = "UPDATE FaultCodes SET Name = @newval WHERE Id = @id"; }
            else if (columnName == "Saft_Code") { CommandText = "UPDATE FaultCodes SET Saft_Code = @newval WHERE Id = @id"; }
            else if (columnName == "Kion_Code") { CommandText = "UPDATE FaultCodes SET Kion_Code = @newval WHERE Id = @id"; }
            else if (columnName == "Kion_DTC") { CommandText = "UPDATE FaultCodes SET Kion_DTC = @newval WHERE Id = @id"; }

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(CommandText, conn);
                cmd.Parameters.AddWithValue("@newval", newValue);
                cmd.Parameters.AddWithValue("@id", rowId);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                int DataIdTab = (int)dgvCodes.CurrentRow.Cells[0].Value;
                string Name = (string)dgvCodes.CurrentRow.Cells[1].Value;

                DialogResult dialogResult = MessageBox.Show("Opravdu chcete smazat záznam " + Name + "?", "Smazat záznam", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    conn.Open();
                    SqlCommand delData = new SqlCommand("DELETE FROM FaultCodes WHERE Id=" + DataIdTab + "", conn);
                    delData.ExecuteNonQuery();
                    conn.Close();
                    DataFaultCodes.Clear();
                    RefData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
