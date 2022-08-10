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

namespace Reklamace_Kion.Defekty
{
    public partial class ListDefects : Form
    {
        public ListDefects()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace");
        DataTable DataDefects = new DataTable();
        BindingSource bindDefects = new BindingSource();

        private void ListDefects_Load(object sender, EventArgs e)
        {
            RefData();
        }

        public void RefData()
        {
            conn.Open();
            SqlCommand getDataComponents = new SqlCommand("SELECT * FROM DataDefects", conn);
            SqlDataAdapter daDataComponents = new SqlDataAdapter(getDataComponents);

            daDataComponents.Fill(DataDefects);

            conn.Close();
            bindDefects.DataSource = DataDefects;
            dgvDefects.DataSource = bindDefects;
        }

        private void dgvDefects_SortStringChanged(object sender, EventArgs e)
        {
            this.bindDefects.Sort = this.dgvDefects.SortString;
        }

        private void dgvDefects_FilterStringChanged(object sender, EventArgs e)
        {
            this.bindDefects.Filter = this.dgvDefects.FilterString;
        }

        private void dgvDefects_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDefects.BeginEdit(true);
        }

        private void dgvDefects_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string CommandText = string.Empty;
            string columnName = dgvDefects.Columns[e.ColumnIndex].Name;
            int rowId = Convert.ToInt32(dgvDefects[0, e.RowIndex].Value);
            string newValue = dgvDefects[e.ColumnIndex, e.RowIndex].Value.ToString();

            if (columnName == "Name") { CommandText = "UPDATE DataDefects SET Name = @newval WHERE DefectId = @id"; }

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
                int DataIdTab = (int)dgvDefects.CurrentRow.Cells[0].Value;
                string Name = (string)dgvDefects.CurrentRow.Cells[1].Value;

                DialogResult dialogResult = MessageBox.Show("Opravdu chcete smazat záznam " + Name + "?", "Smazat záznam", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    conn.Open();
                    SqlCommand delData = new SqlCommand("DELETE FROM DataDefects WHERE DefectId=" + DataIdTab + "", conn);
                    delData.ExecuteNonQuery();
                    conn.Close();
                    DataDefects.Clear();
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
