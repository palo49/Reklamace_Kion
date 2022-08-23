using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reklamace_Kion.RepairAnalyze
{
    public partial class AnalysisForm : Form
    {
        SQL mysql = new SQL();

        public string PN { get; set; }
        string PNChar = string.Empty;
        public string CLM { get; set; }
        public string Level { get; set; }

        Font myFont = new Font("Microsoft Sans Serif", 9);
        Brush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

        public AnalysisForm()
        {
            InitializeComponent();
        }

        private void Buffering(TableLayoutPanel panel)
        {
            Type tlp = panel.GetType();
            PropertyInfo pi = tlp.GetProperty("DoubleBuffered",
              BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(panel, true, null);
        }

        private void AnalysisForm_Load(object sender, EventArgs e)
        {
            TextBox[] textBoxesA1 = { txt1, txt2, txt3, txt4, txt5, txt6, txt9, txt10,
                                        txt11, txt12, txt13, txt14, txt15, txt16, txt18, txt20,
                                        txt21, txt22, txt23, txt24, txt25, txt26, txt27, txt28, txt29, txt30,
                                        txt31, txt32, txt33, txt34, txt35, txt36, txt37, txt38, txt39, txt40,
                                        txt41, txt42, txt43, txt44, txt45, txt46, txt47, txt48, txt49, txt50,
                                        txt51, txt52, txt53, txt54, txt55, txt56, txt57, txt58, txt59, txt60,
                                        txt61, txt62, txt63, txt64
                                    };

            TextBox[] textBoxesA2 = { txt1, txt2, txt3, txt4, txt5, txt6, txt7, txt8, txt9, txt10,
                                        txt11, txt12, txt13, txt14, txt15, txt16, txt17, txt18, txt19, txt20,
                                        txt21, txt22, txt23, txt24, txt25, txt26, txt27, txt28, txt29, txt30,
                                        txt31, txt32, txt33, txt34, txt35, txt36, txt37, txt38, txt39, txt40,
                                        txt41, txt42, txt43, txt44, txt45, txt46, txt47, txt48, txt49, txt50,
                                        txt51, txt52, txt53, txt54, txt55, txt56, txt57, txt58, txt59, txt60,
                                        txt61, txt62, txt63, txt64, txt65, txt66, txt67, txt68, txt69, txt70,
                                        txt71, txt72, txt73, txt74, txt75, txt76, txt77, txt78, txt79, txt80,
                                        txt81, txt82, txt83, txt84, txt85, txt86, txt87, txt88, txt89, txt90,
                                        txt91, txt92, txt93, txt94, txt95, txt96, txt97, txt98, txt99, txt100,
                                        txt101, txt102, txt103, txt104, txt105, txt106, txt107, txt108, txt109
                                    };

            TextBox[] textBoxesB1 = { Btxt1, Btxt2, Btxt3, Btxt4, Btxt5, Btxt6, Btxt7, Btxt8, Btxt9, Btxt10,
                                        Btxt11, Btxt12, Btxt13, Btxt14, Btxt15, Btxt16, Btxt17, Btxt18, Btxt19, Btxt20,
                                        Btxt21, Btxt22, Btxt23, Btxt24, Btxt25, Btxt26, Btxt27, Btxt28, Btxt29, Btxt30,
                                        Btxt31, Btxt32, Btxt33, Btxt34, Btxt35, Btxt36, Btxt37, Btxt38, Btxt39, Btxt40,
                                        Btxt41, Btxt42, Btxt43, Btxt44, Btxt45, Btxt46, Btxt47, Btxt48, Btxt49, Btxt50,
                                        Btxt51, Btxt52, Btxt53, Btxt54, Btxt55, Btxt56, Btxt57, Btxt58, Btxt59, Btxt60,
                                        Btxt61, Btxt62, Btxt63, Btxt64, Btxt65, Btxt66, Btxt67, Btxt68, Btxt69, Btxt70,
                                        Btxt71, Btxt72, Btxt73, Btxt74, Btxt75, Btxt76, Btxt77, Btxt78, Btxt79, Btxt80,
                                        Btxt81, Btxt82, Btxt83, Btxt84, Btxt85, Btxt86, Btxt87
                                    };

            TextBox[] textBoxesB2 = { Btxt1, Btxt2, Btxt3, Btxt4, Btxt5, Btxt6, Btxt7, Btxt8, Btxt9, Btxt10,
                                        Btxt11, Btxt12, Btxt13, Btxt14, Btxt15, Btxt16, Btxt17, Btxt18, Btxt19, Btxt20,
                                        Btxt21, Btxt22, Btxt23, Btxt24, Btxt25, Btxt26, Btxt27, Btxt28, Btxt29, Btxt30,
                                        Btxt31, Btxt32, Btxt33, Btxt34, Btxt35, Btxt36, Btxt37, Btxt38, Btxt39, Btxt40,
                                        Btxt41, Btxt42, Btxt43, Btxt44, Btxt45, Btxt46, Btxt47, Btxt48, Btxt49, Btxt50,
                                        Btxt51, Btxt52, Btxt53, Btxt54, Btxt55, Btxt56, Btxt57, Btxt58, Btxt59, Btxt60,
                                        Btxt61, Btxt62, Btxt63, Btxt64, Btxt65, Btxt66, Btxt67, Btxt68, Btxt69, Btxt70,
                                        Btxt71, Btxt72, Btxt73, Btxt74, Btxt75, Btxt76, Btxt77, Btxt78, Btxt79, Btxt80,
                                        Btxt81, Btxt82, Btxt83, Btxt84, Btxt85, Btxt86, Btxt87, Btxt88, Btxt89, Btxt90,
                                        Btxt91, Btxt92, Btxt93, Btxt94, Btxt95, Btxt96, Btxt97, Btxt98, Btxt99, Btxt100,
                                        Btxt101, Btxt102, Btxt103, Btxt104, Btxt105, Btxt106, Btxt107, Btxt108, Btxt109, Btxt110,
                                        Btxt111, Btxt112, Btxt113, Btxt114, Btxt115, Btxt116, Btxt117, Btxt118, Btxt119, Btxt120,
                                        Btxt121, Btxt122, Btxt123, Btxt124, Btxt125, Btxt126, Btxt127, Btxt128, Btxt129, Btxt130,
                                        Btxt131, Btxt132, Btxt133, Btxt134, Btxt135, Btxt136, Btxt137, Btxt138, Btxt139, Btxt140,
                                        Btxt141, Btxt142, Btxt143, Btxt144, Btxt145, Btxt146, Btxt147, Btxt148, Btxt149, Btxt150,
                                        Btxt151, Btxt152, Btxt153, Btxt154, Btxt155, Btxt156, Btxt157, Btxt158
                                    };

            lblCLM.Text = CLM;
            lblPN.Text = PN;

            panel1.Size = new Size(940, 696);
            panelB.Location = new Point(2, 9);
            panelB.Size = new Size(940, 696);

            Buffering(tableLayoutPanel1);
            Buffering(tableLayoutPanel2);
            Buffering(tableLayoutPanel3);
            Buffering(tableLayoutPanel4);
            Buffering(tableLayoutPanel5);
            Buffering(tableLayoutPanel6);

            Buffering(tableLayoutPanel10);

            Buffering(tableLayoutPanelB1);
            Buffering(tableLayoutPanelB2);
            Buffering(tableLayoutPanelB2_2);

            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel3.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel4.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel5.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel6.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;

            tableLayoutPanel10.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;

            tableLayoutPanelB1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanelB2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanelB2_2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;

            PNChar = PN.Substring(PN.LastIndexOf('_') + 1);

            if (PNChar.Contains("A"))
            {
                panel1.Visible = true;

                if (PNChar == "A2")
                {
                    txt7.ReadOnly = false;
                    txt8.ReadOnly = false;
                    txt17.ReadOnly = false;
                    txt19.ReadOnly = false;
                    secondPanel.Visible = true;
                    LoadData(PNChar, CLM, textBoxesA2);
                }
                else
                {
                    LoadData(PNChar, CLM, textBoxesA1);
                }
            }
            if (PNChar.Contains("B"))
            {
                panelB.Visible = true;
                lblModule1.Text = "MODULE-23-VL41M-SFP-7S5P (Bottom position) SN";

                if (PNChar == "B2")
                {
                    lblModule1.Text = "MODULE-23-VL41M-SFP-7S5P (Top position) SN";
                    Btxt3.ReadOnly = false;
                    Btxt16.ReadOnly = false;
                    panelB2.Visible = true;
                    LoadData(PNChar, CLM, textBoxesB2);
                }
                else
                {
                    LoadData(PNChar, CLM, textBoxesB1);
                }
            }
        }

        private void LoadData(string PN, string CLM, TextBox[] boxes)
        {
            SqlDataReader data;
            try
            {
                string cmd = "SELECT * FROM " + PN + "_torques WHERE CLM='" + CLM + "'";
                mysql.OpenConection();
                int count = mysql.CountCols(PN + "_torques");
                data = mysql.DataReader(cmd);
                if (data.Read())
                {
                    for (int i = 0; i < count - 3; i++)
                    {
                        boxes[i].Text = data[i + 3].ToString();
                    }
                }
                mysql.CloseConnection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearImage()
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image = null;
            }
        }

        private void changebg(Label name, Color clr)
        {
            name.BackColor = clr;
        }

        double[] torques = { 13, 13, 5, 5, 13, 5, 13, 5, 5, 10, 10, 13, 13, 1, 1, 13, 13, 5, 5, 13, 13, 5, 5 };
        double[] torquesB = { 4,5,5,10,10,5,5,13,5,5,5,5,5,4,5,5 };

        private string TRQlbl(int val)
        {
            string result = torques[val - 1].ToString() + " Nm\n\u00B1 " + (torques[val - 1] / 10).ToString() + " Nm";
            return result;
        }

        private string TRQlblSecond(int val)
        {
            string result = torques[val - 48].ToString() + " Nm\n\u00B1 " + (torques[val - 48] / 10).ToString() + " Nm";
            return result;
        }

        private string TRQlblCell(int val)
        {
            string result = "\n" + torques[val].ToString() + " Nm \u00B1 " + (torques[val] / 10).ToString() + " Nm";
            return result;
        }

        private string TRQlblB(int val)
        {
            string result = torquesB[val - 1].ToString() + " Nm\n\u00B1 " + (torquesB[val - 1] / 10).ToString() + " Nm";
            return result;
        }

        Image[] imgs = { Reklamace_Kion.Properties.Resources.img1,
                         Reklamace_Kion.Properties.Resources.img2,
                         Reklamace_Kion.Properties.Resources.img3,
                         Reklamace_Kion.Properties.Resources.img4,
                         Reklamace_Kion.Properties.Resources.img5,
                         Reklamace_Kion.Properties.Resources.img6,
                         Reklamace_Kion.Properties.Resources.img7,
                         Reklamace_Kion.Properties.Resources.img8,
                         Reklamace_Kion.Properties.Resources.img9,
                         Reklamace_Kion.Properties.Resources.img10,
                         Reklamace_Kion.Properties.Resources.img11,
                         Reklamace_Kion.Properties.Resources.img12,
                         Reklamace_Kion.Properties.Resources.img13,
                         Reklamace_Kion.Properties.Resources.img14,
                         Reklamace_Kion.Properties.Resources.img15,
                         Reklamace_Kion.Properties.Resources.img16,
                         Reklamace_Kion.Properties.Resources.img17,
                         Reklamace_Kion.Properties.Resources.img18,
                         Reklamace_Kion.Properties.Resources.img19
                       };

        private void SetImg(int val)
        {
            try
            {
                if (pictureBox1.Image == null)
                {
                    pictureBox1.Image = imgs[val - 1];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void SetImgSecond(int val)
        {
            try
            {
                if (pictureBox1.Image == null)
                {
                    pictureBox1.Image = imgs[val - 48];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lblTRQ_Paint(object sender, PaintEventArgs e)
        {
            Label lb = (Label)sender;
            int res = Convert.ToInt16(lb.Name.Remove(0,6));

            e.Graphics.TranslateTransform(30, 20);
            e.Graphics.RotateTransform(90);
            if (res < 20)
            {
                e.Graphics.DrawString(TRQlbl(res), myFont, myBrush, 0, 0);
            }
            else if ((res >= 20) && (res < 48))
            {
                e.Graphics.DrawString(TRQlblCell(5), myFont, myBrush, 0, 0);
            }
            else if ((res >= 48) && (res < 67))
            {
                e.Graphics.DrawString(TRQlblSecond(res), myFont, myBrush, 0, 0);
            }
            else if ((res >= 67) && (res < 95))
            {
                e.Graphics.DrawString(TRQlblCell(5), myFont, myBrush, 0, 0);
            }
        }

        private void lblTRQ_MouseLeave(object sender, EventArgs e)
        {
            changebg((Label)sender, SystemColors.Control);
            ClearImage();
        }

        private void lblTRQ_MouseHover(object sender, EventArgs e)
        {
            Label lb = (Label)sender;
            int res = Convert.ToInt16(lb.Name.Remove(0, 6));

            changebg(lb, Color.FromArgb(254, 250, 224));

            if (res < 20) { SetImg(res); }
            else if (res >= 48) { SetImgSecond(res); }
        }

        private void lblTRQB_Paint(object sender, PaintEventArgs e)
        {
            Label lb = (Label)sender;
            int res = Convert.ToInt16(lb.Name.Remove(0, 7));

            e.Graphics.TranslateTransform(30, 20);
            e.Graphics.RotateTransform(90);
            if (res < 17)
            {
                e.Graphics.DrawString(TRQlblB(res), myFont, myBrush, 0, 0);
            }
            else if ((res >= 20) && (res < 48))
            {
                
            }
            else if ((res >= 48) && (res < 67))
            {
                
            }
            else if ((res >= 67) && (res < 95))
            {
                
            }
        }

        private void lblTRQB_MouseHover(object sender, EventArgs e)
        {

        }

        private void lblTRQB_MouseLeave(object sender, EventArgs e)
        {

        }

        private int _i = 0;

        private void AddComponentControl(Button btn)
        {
            try
            {
                _i++;
                ComboBox cmb = new ComboBox();
                cmb.Name = "cmbComponent_" + _i;
                cmb.Location = new Point(30, (btn.Location.Y) + _i * 40);
                mysql.OpenConection();
                cmb.DataSource = mysql.DataTable("SELECT Name FROM RepairComponents");
                mysql.CloseConnection();
                cmb.DisplayMember = "Name";
                cmb.ValueMember = "Name";
                panel1.Controls.Add(cmb);
                Label lbl = new Label();
                lbl.Text = "Počet:";
                lbl.Name = "lbl_" + _i;
                lbl.Location = new Point(160, cmb.Location.Y + 3);
                lbl.Width = 55;
                panel1.Controls.Add(lbl);
                TextBox txt = new TextBox();
                txt.Name = "txtComponent_" + _i;
                txt.Location = new Point(220, cmb.Location.Y + 2);
                txt.Width = 50;
                panel1.Controls.Add(txt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelComponents(object sender, EventArgs e)
        {

        }

        private void btnAddComponent_Click(object sender, EventArgs e)
        {
            AddComponentControl(btnAddComponent);
        }

        private void btnDelComponent_Click(object sender, EventArgs e)
        {
            try
            {
                if (_i != 0)
                {
                    foreach (Control item in panel1.Controls.OfType<Control>().ToList())
                    {
                        if (item.Name == "cmbComponent_" + _i)
                            panel1.Controls.Remove(item);
                        if (item.Name == "lbl_" + _i)
                            panel1.Controls.Remove(item);
                        if (item.Name == "txtComponent_" + _i)
                            panel1.Controls.Remove(item);
                        if (item.Name == "delBtnComponent_" + _i)
                            panel1.Controls.Remove(item);
                    }
                    _i--;
                }
                else
                {
                    MessageBox.Show("Není zde žádná komponenta ke smazání.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
