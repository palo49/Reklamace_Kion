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

namespace Reklamace_Kion.Statistics
{
    public partial class Statistics : Form
    {

        SqlConnection conn = new SqlConnection(@"Data Source=CZ-RAS-SQL1\SQLEXPRESS;Initial Catalog=Reklamace_Kion;User ID=Kion_rekl;Password=Reklamace");

        public Statistics()
        {
            InitializeComponent();
        }

        private void Statistics_Load(object sender, EventArgs e)
        {
            string yearNow = DateTime.Now.Year.ToString();
            cmbYear.Text = yearNow;
        }

        private void UpdateGraph(ScottPlot.FormsPlot ctrl, double[] values, string[] names, string title)
        {
            ClearGraph(ctrl);

            List<double> tmpValues = new List<double>(values);
            List<string> tmpNames = new List<string>(names);

            //values = values.Where(val => val != 0).ToArray();
            int shorten = 0;
            for (int i = 0; i < values.Length; i++)
            {
                if (values[i] == 0)
                {
                    tmpValues.RemoveAt(i - shorten);
                    tmpNames.RemoveAt(i - shorten);
                    shorten++;
                }
            }

            values = tmpValues.ToArray();
            names = tmpNames.ToArray();

            var pie = ctrl.Plot.AddPie(values);

            pie.Explode = true;
            pie.ShowPercentages = true;
            pie.ShowValues = true;
            pie.SliceLabels = names;
            pie.Size = .8;

            ctrl.Plot.Title(title);
            ctrl.Configuration.LeftClickDragPan = false;
            ctrl.Configuration.ScrollWheelZoom = false;
            ctrl.Plot.Style(dataBackground: SystemColors.Control);
            ctrl.Plot.Legend(location: ScottPlot.Alignment.UpperRight);
            ctrl.Refresh();
        }

        private void ClearGraph(ScottPlot.FormsPlot ctrl)
        {
            ctrl.Plot.Clear();
            ctrl.Reset();
        }

        private void indexChanged()
        {
            try
            {
                dgvClaims.Rows.Clear();

                int year = Convert.ToInt32(cmbYear.Text);

                SqlCommand cmdCountd = new SqlCommand("SELECT COUNT(*) FROM StatisticsClaims WHERE YearIn=" + year, conn);

                string query = "SELECT * FROM StatisticsClaims WHERE YearIn=" + year;
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                int count = (int)cmdCountd.ExecuteScalar();
                SqlDataReader reader = cmd.ExecuteReader();

                bool NextRow = false;

                int acceptedTotal = 0;
                int notAcceptedTotal = 0;
                int inProcTotal = 0;
                int total = 0;

                int acceptedTotalBat = 0;
                int notAcceptedTotalBat = 0;
                int inProcTotalBat = 0;
                int totalBat = 0;

                string[] namesToChart = new string[count];
                double[] valsToChart = new double[count];

                if (reader.HasRows)
                {
                    lblNoData.Text = string.Empty;
                    int i = 0;
                    while (reader.Read())
                    {
                        dgvClaims.Rows.Add(reader.GetString(1), reader.GetInt32(2).ToString(), reader.GetInt32(3).ToString(), reader.GetInt32(4).ToString(), reader.GetInt32(5).ToString());
                        acceptedTotal += reader.GetInt32(2);
                        notAcceptedTotal += reader.GetInt32(3);
                        inProcTotal += reader.GetInt32(4);
                        total += reader.GetInt32(5);
                        namesToChart[i] = reader.GetString(1);
                        valsToChart[i] = reader.GetInt32(2);
                        if (NextRow)
                        {
                            acceptedTotalBat += reader.GetInt32(2);
                            notAcceptedTotalBat += reader.GetInt32(3);
                            inProcTotalBat += reader.GetInt32(4);
                            totalBat += reader.GetInt32(5);
                        }
                        NextRow = true;
                        i++;
                    }
                    dgvClaims.Rows.Add("Total claims", acceptedTotal.ToString(), notAcceptedTotal.ToString(), inProcTotal.ToString(), total.ToString());
                    dgvClaims.Rows.Add("Total claims battery", acceptedTotalBat.ToString(), notAcceptedTotalBat.ToString(), inProcTotalBat.ToString(), totalBat.ToString());

                    UpdateGraph(formsPlot1, valsToChart, namesToChart, "KION claims " + year.ToString());
                }
                else
                {
                    lblNoData.Text = "Pro tento rok zde nejsou žádné data.";
                    ClearGraph(formsPlot1);
                }
                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show(ex.Message);
            }

            try
            {
                dgvParts.Rows.Clear();

                int year = Convert.ToInt32(cmbYear.Text);

                SqlCommand cmdCountd = new SqlCommand("SELECT COUNT(*) FROM StatisticsParts WHERE YearIn=" + year, conn);

                string query = "SELECT * FROM StatisticsParts WHERE YearIn=" + year;
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                int count = (int)cmdCountd.ExecuteScalar();
                SqlDataReader reader = cmd.ExecuteReader();

                string[] namesToChart = new string[count];
                double[] valsToChart = new double[count];

                if (reader.HasRows)
                {
                    lblNoData.Text = string.Empty;
                    int i = 0;
                    while (reader.Read())
                    {
                        dgvParts.Rows.Add(reader.GetString(1), reader.GetInt32(2).ToString(), reader.GetInt32(3).ToString(), reader.GetInt32(4).ToString(), reader.GetInt32(5).ToString());

                        namesToChart[i] = reader.GetString(1);
                        valsToChart[i] = reader.GetInt32(2);

                        i++;
                    }

                    UpdateGraph(formsPlot2, valsToChart, namesToChart, "KION claims parts accepted " + year.ToString());
                }
                else
                {
                    ClearGraph(formsPlot2);
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show(ex.Message);
            }

            try
            {
                dgvFaults.Rows.Clear();

                int year = Convert.ToInt32(cmbYear.Text);

                SqlCommand cmdCountd = new SqlCommand("SELECT COUNT(*) FROM StatisticsBMSFault WHERE YearIn=" + year, conn);


                string query = "SELECT * FROM StatisticsBMSFault WHERE YearIn=" + year;
                SqlCommand cmd = new SqlCommand(query, conn);

                conn.Open();
                int count = (int)cmdCountd.ExecuteScalar();
                SqlDataReader reader = cmd.ExecuteReader();

                string[] namesToChart = new string[count];
                double[] valsToChart = new double[count];

                int totalAccepted = 0;
                int totalNotAccepted = 0;
                int totalInProc = 0;

                if (reader.HasRows)
                {
                    lblNoData.Text = string.Empty;
                    int i = 0;
                    while (reader.Read())
                    {
                        dgvFaults.Rows.Add(reader.GetString(1), reader.GetInt32(2).ToString(), reader.GetInt32(3).ToString(), reader.GetInt32(4).ToString(), reader.GetInt32(5).ToString());

                        namesToChart[i] = reader.GetString(1);
                        valsToChart[i] = reader.GetInt32(2);

                        totalAccepted += reader.GetInt32(2);
                        totalNotAccepted += reader.GetInt32(3);
                        totalInProc += reader.GetInt32(4);

                        i++;
                    }

                    UpdateGraph(formsPlot3, valsToChart, namesToChart, "KION BMS RCA accepted " + year.ToString());
                }
                else
                {
                    ClearGraph(formsPlot3);
                }

                reader.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                if (conn.State == ConnectionState.Open)
                {
                    conn.Close();
                }
                MessageBox.Show(ex.Message);
            }
        }

        private void cmbYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            indexChanged();
        }

        class Accepted {
            public string name;
            public int value;
        }

        class Accepted_as_goodwill
        {
            public string name;
            public int value;
        }

        class Not_accepted
        {
            public string name;
            public int value;
        }


        /// <summary>
        /// Rozdělí data do sloupcu podle accepted, accepted as goodwill a not accepted.
        /// </summary>
        /// <param name="data">Data z databáze.</param>
        /// <param name="result">Hodnoty accepted apod.</param>
        /// <param name="year">Rok z ComboBox.</param>
        /// <param name="dbTable">Název databáze, do které se uloží výsledky.</param>
        /// <param name="names">Název kategorii.</param>
        private void RefreshData(List<string> data, List<string> result, int year, string dbTable, List<string> names)
        {
            var dataAccepted              = new List<Accepted>();
            var dataAccepted_as_goodwill  = new List<Accepted_as_goodwill>();
            var dataNot_accepted          = new List<Not_accepted>();

            try
            {
                for (int i = 0; i < data.Count; i++)
                {
                    if (result[i] == "Accepted")
                    {
                        int index = dataAccepted.FindIndex(item => item.name == data[i]);
                        if (index >= 0)
                        {
                            dataAccepted[index].value++;
                        }
                        else
                        {
                            Accepted accepted = new Accepted();
                            accepted.name = data[i];
                            accepted.value++;
                            dataAccepted.Add(accepted);
                        }
                    }
                    else if (result[i] == "Accepted_as_goodwill")
                    {
                        int index = dataAccepted_as_goodwill.FindIndex(item => item.name == data[i]);
                        if (index >= 0)
                        {
                            dataAccepted_as_goodwill[index].value++;
                        }
                        else
                        {
                            Accepted_as_goodwill aag = new Accepted_as_goodwill();
                            aag.name = data[i];
                            aag.value++;
                            dataAccepted_as_goodwill.Add(aag);
                        }
                    }
                    else
                    {
                        int index = dataNot_accepted.FindIndex(item => item.name == data[i]);
                        if (index >= 0)
                        {
                            dataNot_accepted[index].value++;
                        }
                        else
                        {
                            Not_accepted na = new Not_accepted();
                            na.name = data[i];
                            na.value++;
                            dataNot_accepted.Add(na);
                        }
                    }
                }

                for (int i = 0; i < names.Count; i++)
                {
                    int davalue = 0;
                    int aagvalue = 0;
                    int navalue = 0;

                    int indexda = dataAccepted.FindIndex(item => item.name == names[i]);
                    if (indexda >= 0)
                    {
                        davalue = dataAccepted[indexda].value;
                    }
                    int indexaag = dataAccepted_as_goodwill.FindIndex(item => item.name == names[i]);
                    if (indexaag >= 0)
                    {
                        aagvalue = dataAccepted_as_goodwill[indexaag].value;
                    }
                    int indexna = dataNot_accepted.FindIndex(item => item.name == names[i]);
                    if (indexna >= 0)
                    {
                        navalue = dataNot_accepted[indexna].value;
                    }

                    SqlCommand cmd = new SqlCommand("INSERT INTO " + dbTable + " VALUES ('" + names[i] + "', " + davalue + ", " + navalue + ", " + aagvalue + ", " + (davalue + navalue + aagvalue) + ", " + year + ")", conn);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(cmbYear.Text) <= 2022)
            {
                MessageBox.Show("Data z tohoto roku (" + cmbYear.Text + ") nelze tímto způsobem aktualizovat.");
            }
            else
            {
                List<string> CLM = new List<string>();
                List<string> State = new List<string>();
                List<string> PN_Battery = new List<string>();
                List<string> PN_Claimed_Component = new List<string>();
                List<string> Defect_BMS = new List<string>();
                List<string> Result = new List<string>();

                List<string> claimNames = new List<string>() { "BMS", "775369_A1", "774166_A2", "776445_B1", "774100_B2" };
                List<string> PartsNames = new List<string>();
                List<string> BMSFaultNames = new List<string>();

                DialogResult res = MessageBox.Show("Tímto dojde k obnovení a znovu nahrání dat do databáze statistik, pro vybraný rok " + cmbYear.Text + ".\nPřejete si pokračovat?", "Upozornění", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (res == DialogResult.Yes)
                {
                    try
                    {
                        string year = cmbYear.Text.Substring(2, 2);
                        string CLMYear = "CLM" + year;

                        SqlCommand cmd = new SqlCommand("SELECT CLM, State, PN_Battery, PN_Claimed_Component, Defect_BMS, Result FROM DataMain WHERE CLM LIKE '%" + CLMYear + "%'", conn);
                        SqlCommand cmdParts = new SqlCommand("SELECT Name FROM DataComponents", conn);
                        SqlCommand cmdBMSFaults = new SqlCommand("SELECT Name FROM DataDefects", conn);
                        conn.Open();

                        SqlDataReader reader = cmd.ExecuteReader();

                        while (reader.Read())
                        {
                            if (!reader.IsDBNull(0)) { CLM.Add(reader.GetString(0)); } else { CLM.Add(string.Empty); }
                            if (!reader.IsDBNull(1)) { State.Add(reader.GetString(1)); } else { State.Add(string.Empty); }
                            if (!reader.IsDBNull(2)) { PN_Battery.Add(reader.GetString(2)); } else { PN_Battery.Add(string.Empty); }
                            if (!reader.IsDBNull(3)) { PN_Claimed_Component.Add(reader.GetString(3)); } else { PN_Claimed_Component.Add(string.Empty); }
                            if (!reader.IsDBNull(4)) { Defect_BMS.Add(reader.GetString(4)); } else { Defect_BMS.Add(string.Empty); }
                            if (!reader.IsDBNull(5))
                            {
                                if (reader.GetString(5) == "Not accepted") { Result.Add(reader.GetString(5).Replace(" ", "_")); }
                                else if (reader.GetString(5) == "Accepted as goodwill") { Result.Add(reader.GetString(5).Replace(" ", "_")); }
                                else { Result.Add(reader.GetString(5)); }
                            }
                            else { Result.Add(string.Empty); }
                        }
                        reader.Close();

                        SqlDataReader rdrParts = cmdParts.ExecuteReader();

                        while (rdrParts.Read())
                        {
                            PartsNames.Add(rdrParts.GetString(0));
                        }
                        rdrParts.Close();

                        SqlDataReader rdrFaults = cmdBMSFaults.ExecuteReader();

                        while (rdrFaults.Read())
                        {
                            BMSFaultNames.Add(rdrFaults.GetString(0));
                        }
                        rdrFaults.Close();

                        SqlCommand deleteClaims = new SqlCommand("DELETE FROM StatisticsClaims WHERE YearIn=" + cmbYear.Text, conn);
                        SqlCommand deleteParts = new SqlCommand("DELETE FROM StatisticsParts WHERE YearIn=" + cmbYear.Text, conn);
                        SqlCommand deleteBMSFault = new SqlCommand("DELETE FROM StatisticsBMSFault WHERE YearIn=" + cmbYear.Text, conn);

                        deleteClaims.ExecuteNonQuery();
                        deleteParts.ExecuteNonQuery();
                        deleteBMSFault.ExecuteNonQuery();

                        if (PN_Battery.Count > 0)
                        {
                            RefreshData(PN_Battery, Result, Convert.ToInt32(cmbYear.Text), "StatisticsClaims", claimNames);
                        }

                        if (PN_Claimed_Component.Count > 0)
                        {
                            RefreshData(PN_Claimed_Component, Result, Convert.ToInt32(cmbYear.Text), "StatisticsParts", PartsNames);
                        }

                        if (Defect_BMS.Count > 0)
                        {
                            RefreshData(Defect_BMS, Result, Convert.ToInt32(cmbYear.Text), "StatisticsBMSFault", BMSFaultNames);
                        }

                        conn.Close();
                        indexChanged();
                    }
                    catch (Exception ex)
                    {
                        if (conn.State == ConnectionState.Open)
                        {
                            conn.Close();
                        }
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }
    }
}
