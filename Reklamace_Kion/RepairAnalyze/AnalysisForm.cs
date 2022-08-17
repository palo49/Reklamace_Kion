using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
                    txtPPModule2_1.ReadOnly = false;
                    txtPPModule2_2.ReadOnly = false;
                    secondPanel.Visible = true;
                }
            }
            if (PNChar.Contains("B"))
            {
                panelB.Visible = true;
                lblModule1.Text = "MODULE-23-VL41M-SFP-7S5P (Bottom position) SN";

                if (PNChar == "B2")
                {
                    lblModule1.Text = "MODULE-23-VL41M-SFP-7S5P (Top position) SN";
                    txtB2B.ReadOnly = false;
                    txtB14B.ReadOnly = false;
                    panelB2.Visible = true;
                }
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
    }
}
