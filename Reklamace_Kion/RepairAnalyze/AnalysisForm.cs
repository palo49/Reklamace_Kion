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
        Font myFontCell = new Font("Microsoft Sans Serif", 8);
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

            Buffering(tableLayoutPanel1);
            Buffering(tableLayoutPanel2);
            Buffering(tableLayoutPanel3);
            Buffering(tableLayoutPanel4);
            Buffering(tableLayoutPanel5);
            Buffering(tableLayoutPanel6);

            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel2.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel3.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel4.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel5.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            tableLayoutPanel6.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;

            PNChar = PN.Substring(PN.LastIndexOf('_') + 1);
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

        private string TRQlbl(int val)
        {
            string result = torques[val - 1].ToString() + " Nm\n\u00B1 " + (torques[val - 1] / 10).ToString() + " Nm";
            return result;
        }

        private string TRQlblCell(int val)
        {
            string result = "\n" + torques[val].ToString() + " Nm \u00B1 " + (torques[val] / 10).ToString() + " Nm";
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

        private void lblTRQ_Paint(object sender, PaintEventArgs e)
        {
            Label lb = (Label)sender;
            int res = Convert.ToInt16(lb.Name.Remove(0,6));

            e.Graphics.TranslateTransform(30, 20);
            e.Graphics.RotateTransform(90);
            if (res >= 20)
            {
                e.Graphics.DrawString(TRQlblCell(5), myFont, myBrush, 0, 0);
            }
            else
            {
                e.Graphics.DrawString(TRQlbl(res), myFont, myBrush, 0, 0);
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

            SetImg(res);
        }
    }
}
