using MoreLinq;
using MoreLinq.Extensions;
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

        private static AnalysisForm form = null;

        public AnalysisForm()
        {
            InitializeComponent();
            form = this;
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
                                        Btxt81, Btxt82, Btxt83, Btxt84, Btxt85, Btxt86, Btxt87,
                                        BtxtV1, BtxtV2, BtxtV3, BtxtV4, BtxtV5, BtxtV6, BtxtV7, BtxtV8, BtxtV9, BtxtV10,
                                        BtxtV11, BtxtV12, BtxtV13, BtxtV14, BtxtV15, BtxtV16, BtxtV17, BtxtV18, BtxtV19, BtxtV20,
                                        BtxtV21, BtxtV22, BtxtV23, BtxtV24, BtxtV25, BtxtV26, BtxtV27, BtxtV28, BtxtV29, BtxtV30,
                                        BtxtV31, BtxtV32, BtxtV33, BtxtV34, BtxtV35, BtxtVoltageSum1
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
                                        Btxt151, Btxt152, Btxt153, Btxt154, Btxt155, Btxt156, Btxt157, Btxt158,
                                        BtxtV1, BtxtV2, BtxtV3, BtxtV4, BtxtV5, BtxtV6, BtxtV7, BtxtV8, BtxtV9, BtxtV10, BtxtV11, BtxtV12, BtxtV13, BtxtV14, BtxtV15, BtxtV16, BtxtV17, BtxtV18, BtxtV19, BtxtV20, BtxtV21, BtxtV22, BtxtV23, BtxtV24, BtxtV25, BtxtV26, BtxtV27, BtxtV28, BtxtV29, BtxtV30, BtxtV31, BtxtV32, BtxtV33, BtxtV34, BtxtV35, BtxtV36, BtxtV37, BtxtV38, BtxtV39, BtxtV40, BtxtV41, BtxtV42, BtxtV43, BtxtV44, BtxtV45, BtxtV46, BtxtV47, BtxtV48, BtxtV49, BtxtV50, BtxtV51, BtxtV52, BtxtV53, BtxtV54, BtxtV55, BtxtV56, BtxtV57, BtxtV58, BtxtV59, BtxtV60, BtxtV61, BtxtV62, BtxtV63, BtxtV64, BtxtV65, BtxtV66, BtxtV67, BtxtV68, BtxtV69, BtxtV70, BtxtVoltageSum1, BtxtVoltageSum2
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
                    btnAddComponent.Location = new Point(btnAddComponent.Location.X, 1300);
                    btnDelComponent.Location = new Point(btnDelComponent.Location.X, 1300);
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
                panelB.Controls.Add(btnAddComponent);
                panelB.Controls.Add(btnDelComponent);
                panelB.Controls.Add(tlpComponents);
                btnAddComponent.Location = new Point(btnAddComponent.Location.X, 700);
                btnDelComponent.Location = new Point(btnDelComponent.Location.X, 700);

                if (PNChar == "B2")
                {
                    lblModule1.Text = "MODULE-23-VL41M-SFP-7S5P (Top position) SN";
                    Btxt3.ReadOnly = false;
                    Btxt16.ReadOnly = false;
                    panelB2.Visible = true;
                    btnAddComponent.Location = new Point(btnAddComponent.Location.X, 1200);
                    btnDelComponent.Location = new Point(btnDelComponent.Location.X, 1200);
                    LoadData(PNChar, CLM, textBoxesB2);
                }
                else
                {
                    LoadData(PNChar, CLM, textBoxesB1);
                }
            }

            tlpComponents.Location = new Point(btnAddComponent.Location.X, btnAddComponent.Location.Y + 50);
            tlpComponents.Width = 400;
            //tlpComponents.BackColor = Color.LightCoral;
        }

        private void LoadData(string PN, string CLM, TextBox[] boxes)
        {
            try
            {
                string cmds = "SELECT * FROM " + PN + "_torques WHERE CLM='" + CLM + "'";
                mysql.OpenConection();
                int count = mysql.CountCols(PN + "_torques");
                SqlDataReader dataa = mysql.DataReader(cmds);
                if (dataa.Read())
                {
                    for (int i = 0; i < count - 4; i++)
                    {
                        boxes[i].Text = dataa[i + 3].ToString();
                    }
                }
                dataa.Close();
                cmds = "SELECT RepairComponents FROM " + PN + "_torques WHERE CLM='" + CLM + "'";
                dataa = mysql.DataReader(cmds);
                dataa.Read();
                string dataStr = dataa[0].ToString();
                count = dataStr.Split(';').Length - 1;
                mysql.CloseConnection();
                string[] strList = dataStr.Split(';');
                
                for (int i = 0; i < count; i++)
                {
                    string[] sep = strList[i].Split('=');
                    AddComponentControl(btnAddComponent, sep[0], sep[1]);
                }
                dataa.Close();
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

        private void AddComponentControl(Button btn, string value, string count)
        {
            try
            {
                if ((Level == "5") || (Level == "20") || (Level == "100"))
                {
                    Panel p;
                    if (PNChar.Contains("B"))
                    {
                        p = panelB;
                    }
                    else
                    {
                        p = panel1;
                    }

                    _i++;
                    ComboBox cmb = new ComboBox();
                    cmb.Name = "cmbComponent_" + _i;
                    cmb.Location = new Point(30, (btn.Location.Y) + _i * 40);
                    mysql.OpenConection();
                    cmb.DataSource = mysql.DataTable("SELECT Name FROM RepairComponents ORDER BY Name ASC");
                    mysql.CloseConnection();
                    cmb.DisplayMember = "Name";
                    cmb.ValueMember = "Name";
                    cmb.DropDownStyle = ComboBoxStyle.DropDownList;
                    cmb.Dock = DockStyle.Fill;
                    //p.Controls.Add(cmb);
                    Label lbl = new Label();
                    lbl.Text = "Počet:";
                    lbl.Name = "lbl_" + _i;
                    lbl.Location = new Point(160, cmb.Location.Y + 3);
                    lbl.Dock = DockStyle.Fill;
                    lbl.AutoSize = false;
                    lbl.TextAlign = ContentAlignment.MiddleCenter;
                    //p.Controls.Add(lbl);
                    TextBox txt = new TextBox();
                    txt.Name = "txtComponent_" + _i;
                    txt.Location = new Point(220, cmb.Location.Y + 2);
                    txt.Width = 50;
                    txt.Dock = DockStyle.Fill;
                    //p.Controls.Add(txt);
                    
                    
                    Button btnDel = new Button();
                    btnDel.Name = "btnDel_" + _i;
                    btnDel.Location = new Point(300, cmb.Location.Y + 2);
                    btnDel.Width = 75;
                    btnDel.Text = "Delete";
                    btnDel.Cursor = Cursors.Hand;
                    btnDel.Dock = DockStyle.Fill;
                    btnDel.Click += new EventHandler(this.BtnDel_Click);
                    //p.Controls.Add(btnDel);

                    tlpComponents.SuspendLayout();
                    tlpComponents.RowCount++;
                    //tlpComponents.RowStyles.Add(new RowStyle(SizeType.Absolute, 30));
                    tlpComponents.Controls.Add(cmb, 0, tlpComponents.RowCount - 1);
                    tlpComponents.Controls.Add(lbl, 1, tlpComponents.RowCount - 1);
                    tlpComponents.Controls.Add(txt, 2, tlpComponents.RowCount - 1);
                    tlpComponents.Controls.Add(btnDel, 3, tlpComponents.RowCount - 1);
                    tlpComponents.ResumeLayout(true);

                    cmb.SelectedIndex = cmb.FindStringExact(value);
                    txt.Text = count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        Control selectedParent = null;
        private void BtnDel_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string str = btn.Name.ToString();
            int num = Convert.ToInt32(str.Substring(str.Length - 1));

            //for (int i = 0; i < 4; i++)
            //{
            //    tlpComponents.Controls.Remove(tlpComponents.GetControlFromPosition(i, num - 1));
            //}
            //tlpComponents.RowCount--;
            //tlpComponents.Height -= 30;

            TLPRemoveRow(tlpComponents, btn);
        }

        private void TLPRemoveRow(TableLayoutPanel tlp, Control control)
        {
            int ctlRow = tlp.GetRow(control);
            TLPRemoveRow(tlp, ctlRow);
        }

        private void TLPRemoveRow(TableLayoutPanel tlp, int row)
        {
            if (row < tlp.RowCount - 1)
            {
                for (int i = 0; i < 4; i++)
                {
                    tlp.Controls.Remove(tlp.GetControlFromPosition(i, row));
                }
                for (int i = row; i < tlp.RowCount - 1; i++)
                {
                    for (int y = 0; y < 4; y++)
                    {
                        tlp.SetRow(tlp.GetControlFromPosition(y, i + 1), i);
                    }
                }
            }
            else
            {
                for (int i = 0; i < 4; i++)
                {
                    tlp.Controls.Remove(tlp.GetControlFromPosition(i, row));
                }
            }
            tlp.RowCount -= 1;
        }

        private void btnAddComponent_Click(object sender, EventArgs e)
        {
            AddComponentControl(btnAddComponent, null, null);
        }

        private void btnDelComponent_Click(object sender, EventArgs e)
        {
            try
            {
                if ((Level == "5") || (Level == "20") || (Level == "100"))
                {
                    Panel p;
                    if (PNChar.Contains("B"))
                    {
                        p = panelB;
                    }
                    else
                    {
                        p = panel1;
                    }

                    if (_i != 0)
                    {
                        foreach (Control item in p.Controls.OfType<Control>().ToList())
                        {
                            if (item.Name == "cmbComponent_" + _i)
                                p.Controls.Remove(item);
                            if (item.Name == "lbl_" + _i)
                                p.Controls.Remove(item);
                            if (item.Name == "txtComponent_" + _i)
                                p.Controls.Remove(item);
                            if (item.Name == "delBtnComponent_" + _i)
                                p.Controls.Remove(item);
                        }
                        _i--;
                    }
                    else
                    {
                        MessageBox.Show("Není zde žádná komponenta ke smazání.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        string[] namesA1 = {
                                "PP_Cover_P_1","PP_Cover_P_2","PP_Cover_N_1","PP_Cover_N_2","PP_Module_1_P","PP_Module_1_N",
                                "Power_Plate_1","Power_Plate_2","Power_Plate_3","Power_Plate_4","Power_Plate_5","Power_Plate_6","Power_Plate_7",
                                "Module_P_1","Module_N_1","Module_SN","Cell_1_N","Cell_1_P","Cell_2_N","Cell_2_P","Cell_3_N","Cell_3_P","Cell_4_N","Cell_4_P","Cell_5_N",
                                "Cell_5_P","Cell_6_N","Cell_6_P","Cell_7_N","Cell_7_P","Cell_8_N","Cell_8_P","Cell_9_N","Cell_9_P",
                                "Cell_10_N","Cell_10_P","Cell_11_N","Cell_11_P","Cell_12_N","Cell_12_P","Cell_13_N","Cell_13_P","Cell_14_N","Cell_14_P",
                                "Cell_1_Voltage","Cell_2_Voltage","Cell_3_Voltage","Cell_4_Voltage","Cell_5_Voltage","Cell_6_Voltage","Cell_7_Voltage",
                                "Cell_8_Voltage","Cell_9_Voltage","Cell_10_Voltage","Cell_11_Voltage","Cell_12_Voltage","Cell_13_Voltage","Cell_14_Voltage","Total_Voltage",
                                "Information"
                            };

        string[] namesA2 = {
                                "PP_Cover_P_1","PP_Cover_P_2","PP_Cover_N_1","PP_Cover_N_2","PP_Module_1_P","PP_Module_1_N","PP_Module_2_P",
                                "PP_Module_2_N","Power_Plate_1","Power_Plate_2","Power_Plate_3","Power_Plate_4","Power_Plate_5","Power_Plate_6",
                                "Power_Plate_7","Module_P_1","Module_P_2","Module_N_1","Module_N_2","Module_A_SN","A_Cell_1_N","A_Cell_1_P",
                                "A_Cell_2_N","A_Cell_2_P","A_Cell_3_N","A_Cell_3_P","A_Cell_4_N","A_Cell_4_P","A_Cell_5_N","A_Cell_5_P",
                                "A_Cell_6_N","A_Cell_6_P","A_Cell_7_N","A_Cell_7_P","A_Cell_8_N","A_Cell_8_P","A_Cell_9_N","A_Cell_9_P",
                                "A_Cell_10_N","A_Cell_10_P","A_Cell_11_N","A_Cell_11_P","A_Cell_12_N","A_Cell_12_P","A_Cell_13_N","A_Cell_13_P","A_Cell_14_N","A_Cell_14_P",
                                "A_Cell_1_Voltage","A_Cell_2_Voltage","A_Cell_3_Voltage","A_Cell_4_Voltage","A_Cell_5_Voltage","A_Cell_6_Voltage",
                                "A_Cell_7_Voltage","A_Cell_8_Voltage","A_Cell_9_Voltage","A_Cell_10_Voltage","A_Cell_11_Voltage","A_Cell_12_Voltage",
                                "A_Cell_13_Voltage","A_Cell_14_Voltage","A_Total_Voltage","A_Information","Module_B_SN","B_Cell_1_N","B_Cell_1_P",
                                "B_Cell_2_N","B_Cell_2_P","B_Cell_3_N","B_Cell_3_P","B_Cell_4_N","B_Cell_4_P","B_Cell_5_N","B_Cell_5_P",
                                "B_Cell_6_N","B_Cell_6_P","B_Cell_7_N","B_Cell_7_P","B_Cell_8_N","B_Cell_8_P","B_Cell_9_N","B_Cell_9_P",
                                "B_Cell_10_N","B_Cell_10_P","B_Cell_11_N","B_Cell_11_P","B_Cell_12_N","B_Cell_12_P","B_Cell_13_N","B_Cell_13_P",
                                "B_Cell_14_N","B_Cell_14_P","B_Cell_1_Voltage","B_Cell_2_Voltage","B_Cell_3_Voltage","B_Cell_4_Voltage","B_Cell_5_Voltage",
                                "B_Cell_6_Voltage","B_Cell_7_Voltage","B_Cell_8_Voltage","B_Cell_9_Voltage","B_Cell_10_Voltage","B_Cell_11_Voltage",
                                "B_Cell_12_Voltage","B_Cell_13_Voltage","B_Cell_14_Voltage","B_Total_Voltage","B_Information"
                            };

        string[] namesB1 = { "Rigid_Connection_P_1", "Rigid_Connection_P_2A", "Rigid_Connection_P_2B", "Contactor_1", "Contactor_2", "Cover_1", "Cover_2", "Cover_3", "Cover_4", "Cable", "Fuse_1", "Fuse_2", "Conn_Fuse", "Rigid_Connection_N_1", "Rigid_Connection_N_2A", "Rigid_Connection_N_2B", "Module_SN", "PL_1", "PL_2", "PL_3", "PL_4", "PL_5", "PL_6", "PL_7", "PL_8", "PL_9", "PL_10", "PL_11", "PL_12", "PL_13", "PL_14", "PL_15", "PL_16", "PL_17", "PL_18", "PL_19", "PL_20", "PL_21", "PL_22", "PL_23", "PL_24", "PL_25", "PL_26", "PL_27", "PL_28", "PL_29", "PL_30", "PL_31", "PL_32", "PL_33", "PL_34", "PL_35", "PL_36", "PL_37", "PL_38", "PL_39", "PL_40", "PL_41", "PL_42", "PL_43", "PL_44", "PL_45", "PL_46", "PL_47", "PL_48", "PL_49", "PL_50", "PL_51", "PL_52", "PL_53", "PL_54", "PL_55", "PL_56", "PL_57", "PL_58", "PL_59", "PL_60", "PL_61", "PL_62", "PL_63", "PL_64", "PL_65", "PL_66", "PL_67", "PL_68", "PL_69", "PL_70", "Cell_1_Voltage", "Cell_2_Voltage", "Cell_3_Voltage", "Cell_4_Voltage", "Cell_5_Voltage", "Cell_6_Voltage", "Cell_7_Voltage", "Cell_8_Voltage", "Cell_9_Voltage", "Cell_10_Voltage", "Cell_11_Voltage", "Cell_12_Voltage", "Cell_13_Voltage", "Cell_14_Voltage", "Cell_15_Voltage", "Cell_16_Voltage", "Cell_17_Voltage", "Cell_18_Voltage", "Cell_19_Voltage", "Cell_20_Voltage", "Cell_21_Voltage", "Cell_22_Voltage", "Cell_23_Voltage", "Cell_24_Voltage", "Cell_25_Voltage", "Cell_26_Voltage", "Cell_27_Voltage", "Cell_28_Voltage", "Cell_29_Voltage", "Cell_30_Voltage", "Cell_31_Voltage", "Cell_32_Voltage", "Cell_33_Voltage", "Cell_34_Voltage", "Cell_35_Voltage", "Total_Voltage" };

        string[] namesB2 = { "Rigid_Connection_P_1", "Rigid_Connection_P_2A", "Rigid_Connection_P_2B", "Contactor_1", "Contactor_2", "Cover_1", "Cover_2", "Cover_3", "Cover_4", "Cable", "Fuse_1", "Fuse_2", "Conn_Fuse", "Rigid_Connection_N_1", "Rigid_Connection_N_2A", "Rigid_Connection_N_2B", "Module_A_SN", "A_PL_1", "A_PL_2", "A_PL_3", "A_PL_4", "A_PL_5", "A_PL_6", "A_PL_7", "A_PL_8", "A_PL_9", "A_PL_10", "A_PL_11", "A_PL_12", "A_PL_13", "A_PL_14", "A_PL_15", "A_PL_16", "A_PL_17", "A_PL_18", "A_PL_19", "A_PL_20", "A_PL_21", "A_PL_22", "A_PL_23", "A_PL_24", "A_PL_25", "A_PL_26", "A_PL_27", "A_PL_28", "A_PL_29", "A_PL_30", "A_PL_31", "A_PL_32", "A_PL_33", "A_PL_34", "A_PL_35", "A_PL_36", "A_PL_37", "A_PL_38", "A_PL_39", "A_PL_40", "A_PL_41", "A_PL_42", "A_PL_43", "A_PL_44", "A_PL_45", "A_PL_46", "A_PL_47", "A_PL_48", "A_PL_49", "A_PL_50", "A_PL_51", "A_PL_52", "A_PL_53", "A_PL_54", "A_PL_55", "A_PL_56", "A_PL_57", "A_PL_58", "A_PL_59", "A_PL_60", "A_PL_61", "A_PL_62", "A_PL_63", "A_PL_64", "A_PL_65", "A_PL_66", "A_PL_67", "A_PL_68", "A_PL_69", "A_PL_70", "Module_B_SN", "B_PL_1", "B_PL_2", "B_PL_3", "B_PL_4", "B_PL_5", "B_PL_6", "B_PL_7", "B_PL_8", "B_PL_9", "B_PL_10", "B_PL_11", "B_PL_12", "B_PL_13", "B_PL_14", "B_PL_15", "B_PL_16", "B_PL_17", "B_PL_18", "B_PL_19", "B_PL_20", "B_PL_21", "B_PL_22", "B_PL_23", "B_PL_24", "B_PL_25", "B_PL_26", "B_PL_27", "B_PL_28", "B_PL_29", "B_PL_30", "B_PL_31", "B_PL_32", "B_PL_33", "B_PL_34", "B_PL_35", "B_PL_36", "B_PL_37", "B_PL_38", "B_PL_39", "B_PL_40", "B_PL_41", "B_PL_42", "B_PL_43", "B_PL_44", "B_PL_45", "B_PL_46", "B_PL_47", "B_PL_48", "B_PL_49", "B_PL_50", "B_PL_51", "B_PL_52", "B_PL_53", "B_PL_54", "B_PL_55", "B_PL_56", "B_PL_57", "B_PL_58", "B_PL_59", "B_PL_60", "B_PL_61", "B_PL_62", "B_PL_63", "B_PL_64", "B_PL_65", "B_PL_66", "B_PL_67", "B_PL_68", "B_PL_69", "B_PL_70", "Cell_1_Voltage", "Cell_2_Voltage", "Cell_3_Voltage", "Cell_4_Voltage", "Cell_5_Voltage", "Cell_6_Voltage", "Cell_7_Voltage", "Cell_8_Voltage", "Cell_9_Voltage", "Cell_10_Voltage", "Cell_11_Voltage", "Cell_12_Voltage", "Cell_13_Voltage", "Cell_14_Voltage", "Cell_15_Voltage", "Cell_16_Voltage", "Cell_17_Voltage", "Cell_18_Voltage", "Cell_19_Voltage", "Cell_20_Voltage", "Cell_21_Voltage", "Cell_22_Voltage", "Cell_23_Voltage", "Cell_24_Voltage", "Cell_25_Voltage", "Cell_26_Voltage", "Cell_27_Voltage", "Cell_28_Voltage", "Cell_29_Voltage", "Cell_30_Voltage", "Cell_31_Voltage", "Cell_32_Voltage", "Cell_33_Voltage", "Cell_34_Voltage", "Cell_35_Voltage", "Cell_36_Voltage", "Cell_37_Voltage", "Cell_38_Voltage", "Cell_39_Voltage", "Cell_40_Voltage", "Cell_41_Voltage", "Cell_42_Voltage", "Cell_43_Voltage", "Cell_44_Voltage", "Cell_45_Voltage", "Cell_46_Voltage", "Cell_47_Voltage", "Cell_48_Voltage", "Cell_49_Voltage", "Cell_50_Voltage", "Cell_51_Voltage", "Cell_52_Voltage", "Cell_53_Voltage", "Cell_54_Voltage", "Cell_55_Voltage", "Cell_56_Voltage", "Cell_57_Voltage", "Cell_58_Voltage", "Cell_59_Voltage", "Cell_60_Voltage", "Cell_61_Voltage", "Cell_62_Voltage", "Cell_63_Voltage", "Cell_64_Voltage", "Cell_65_Voltage", "Cell_66_Voltage", "Cell_67_Voltage", "Cell_68_Voltage", "Cell_69_Voltage", "Cell_70_Voltage", "A_Total_Voltage", "B_Total_Voltage" };

        private void btnSave_Click(object sender, EventArgs e)
        {
            if ((Level == "5") || (Level == "20") || (Level == "100"))
            {
                Cursor.Current = Cursors.WaitCursor;

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
                                        Btxt81, Btxt82, Btxt83, Btxt84, Btxt85, Btxt86, Btxt87,
                                        BtxtV1, BtxtV2, BtxtV3, BtxtV4, BtxtV5, BtxtV6, BtxtV7, BtxtV8, BtxtV9, BtxtV10,
                                        BtxtV11, BtxtV12, BtxtV13, BtxtV14, BtxtV15, BtxtV16, BtxtV17, BtxtV18, BtxtV19, BtxtV20,
                                        BtxtV21, BtxtV22, BtxtV23, BtxtV24, BtxtV25, BtxtV26, BtxtV27, BtxtV28, BtxtV29, BtxtV30,
                                        BtxtV31, BtxtV32, BtxtV33, BtxtV34, BtxtV35, BtxtVoltageSum1
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
                                        Btxt151, Btxt152, Btxt153, Btxt154, Btxt155, Btxt156, Btxt157, Btxt158,
                                        BtxtV1, BtxtV2, BtxtV3, BtxtV4, BtxtV5, BtxtV6, BtxtV7, BtxtV8, BtxtV9, BtxtV10, BtxtV11, BtxtV12, BtxtV13, BtxtV14, BtxtV15, BtxtV16, BtxtV17, BtxtV18, BtxtV19, BtxtV20, BtxtV21, BtxtV22, BtxtV23, BtxtV24, BtxtV25, BtxtV26, BtxtV27, BtxtV28, BtxtV29, BtxtV30, BtxtV31, BtxtV32, BtxtV33, BtxtV34, BtxtV35, BtxtV36, BtxtV37, BtxtV38, BtxtV39, BtxtV40, BtxtV41, BtxtV42, BtxtV43, BtxtV44, BtxtV45, BtxtV46, BtxtV47, BtxtV48, BtxtV49, BtxtV50, BtxtV51, BtxtV52, BtxtV53, BtxtV54, BtxtV55, BtxtV56, BtxtV57, BtxtV58, BtxtV59, BtxtV60, BtxtV61, BtxtV62, BtxtV63, BtxtV64, BtxtV65, BtxtV66, BtxtV67, BtxtV68, BtxtV69, BtxtV70, BtxtVoltageSum1, BtxtVoltageSum2
                                    };

                try
                {
                    Panel p;
                    if (PNChar.Contains("B"))
                    {
                        p = panelB;
                    }
                    else
                    {
                        p = panel1;
                    }

                    string cmd = string.Empty;
                    string buildStr = string.Empty;

                    //MessageBox.Show(namesB1.Length.ToString() + " | " + textBoxesB1.Length.ToString());
                    mysql.OpenConection();
                    if (PNChar == "A1")
                    {
                        for (int i = 0; i < namesA1.Length; i++)
                        {
                            string val = textBoxesA1[i].Text.Replace(',', '.');
                            cmd = "UPDATE " + PNChar + "_torques SET " + namesA1[i] + " = '" + val + "' WHERE CLM = '" + CLM + "'";
                            mysql.ExecuteQueries(cmd);
                        }
                    }

                    if (PNChar == "A2")
                    {
                        for (int i = 0; i < namesA2.Length; i++)
                        {
                            string val = textBoxesA2[i].Text.Replace(',', '.');
                            cmd = "UPDATE " + PNChar + "_torques SET " + namesA2[i] + " = '" + val + "' WHERE CLM = '" + CLM + "'";
                            mysql.ExecuteQueries(cmd);
                        }
                    }

                    if (PNChar == "B1")
                    {
                        for (int i = 0; i < namesB1.Length; i++)
                        {
                            string val = textBoxesB1[i].Text.Replace(',', '.');
                            cmd = "UPDATE " + PNChar + "_torques SET " + namesB1[i] + " = '" + val + "' WHERE CLM = '" + CLM + "'";
                            mysql.ExecuteQueries(cmd);
                        }
                    }

                    if (PNChar == "B2")
                    {
                        for (int i = 0; i < namesB2.Length; i++)
                        {
                            string val = textBoxesB2[i].Text.Replace(',', '.');
                            cmd = "UPDATE " + PNChar + "_torques SET " + namesB2[i] + " = '" + val + "' WHERE CLM = '" + CLM + "'";
                            mysql.ExecuteQueries(cmd);
                        }
                    }


                    foreach (Control item in tlpComponents.Controls.OfType<Control>().ToList())
                    {

                        if (item.Name.Contains("cmbComponent_"))
                            buildStr += item.Text + "=";
                        if (item.Name.Contains("txtComponent_"))
                            buildStr += item.Text + ";";

                    }
                    cmd = "UPDATE " + PNChar + "_torques SET RepairComponents = '" + buildStr + "' WHERE CLM = '" + CLM + "'";


                    mysql.ExecuteQueries(cmd);
                    mysql.CloseConnection();

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
