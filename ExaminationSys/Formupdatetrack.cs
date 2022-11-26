using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExaminationSys
{
    public partial class Formupdatetrack : Form
    {
        public static string trackname = "";

        public Formupdatetrack()
        {
            InitializeComponent();
        }

        private void btnsaveupdatetrack_Click(object sender, EventArgs e)
        {
            trackname = texupdatetrack.Text.Trim();
            MessageBox.Show("Successfully Updated");
        }
    }
}
