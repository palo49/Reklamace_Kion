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
    public partial class BoxDTPicker : Form
    {

        public string dt { get; set; }
        public int row { get; set; }
        public int col { get; set; }

        public BoxDTPicker()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dt = dateTimePicker1.Value.Date.ToString("dd.MM.yyyy");
            Main.PutDate(row, col, dt);
            this.Close();
        }

        private void BoxDTPicker_FormClosed(object sender, FormClosedEventArgs e)
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
        }
    }
}
