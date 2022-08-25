﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reklamace_Kion.Opravy
{
    public partial class ListComponentsRepair : Form
    {
        public ListComponentsRepair()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace");
        DataTable DataComponents = new DataTable();
        BindingSource bindComponents = new BindingSource();

        private void ListComponentsRepair_Load(object sender, EventArgs e)
        {
            RefData();
        }

        public void RefData()
        {
            conn.Open();
            SqlCommand getRepairComponents = new SqlCommand("SELECT * FROM RepairComponents", conn);
            SqlDataAdapter daRepairComponents = new SqlDataAdapter(getRepairComponents);

            daRepairComponents.Fill(DataComponents);

            conn.Close();
            bindComponents.DataSource = DataComponents;
            dgvComponents.DataSource = bindComponents;
        }

        private void dgvComponents_SortStringChanged(object sender, EventArgs e)
        {
            this.bindComponents.Sort = this.dgvComponents.SortString;
        }

        private void dgvComponents_FilterStringChanged(object sender, EventArgs e)
        {
            this.bindComponents.Filter = this.dgvComponents.FilterString;
        }

        private void dgvComponents_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvComponents.BeginEdit(true);
        }

        private void dgvComponents_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            string CommandText = string.Empty;
            string columnName = dgvComponents.Columns[e.ColumnIndex].Name;
            int rowId = Convert.ToInt32(dgvComponents[0, e.RowIndex].Value);
            string newValue = dgvComponents[e.ColumnIndex, e.RowIndex].Value.ToString();

            if (columnName == "Name") { CommandText = "UPDATE RepairComponents SET Name = @newval WHERE Id = @id"; }

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
                int DataIdTab = (int)dgvComponents.CurrentRow.Cells[0].Value;
                string Name = (string)dgvComponents.CurrentRow.Cells[1].Value;

                DialogResult dialogResult = MessageBox.Show("Opravdu chcete smazat záznam " + Name + "?", "Smazat záznam", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    conn.Open();
                    SqlCommand delData = new SqlCommand("DELETE FROM RepairComponents WHERE Id=" + DataIdTab + "", conn);
                    delData.ExecuteNonQuery();
                    conn.Close();
                    DataComponents.Clear();
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
