using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reklamace_Kion
{
    public partial class PickerCmbRepairs : Form
    {
        public string dt { get; set; }
        public int row { get; set; }
        public int col { get; set; }

        public PickerCmbRepairs()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dt = cmb.Text;
            Main.PutRepairState(row, col, dt);
            this.Close();
        }

        private void PickerCmbRepairs_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }

        private void PickerCmbRepairs_Load(object sender, EventArgs e)
        {
            cmb.SelectedIndex = 0;
        }
    }
}
