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
    public partial class Formupdateintake : Form
    {
        public static int intakenum = 0;

        public Formupdateintake()
        {
            InitializeComponent();
        }

        private void btnsaveupdatedintake_Click(object sender, EventArgs e)
        {
            intakenum = int.Parse(texupdateintake.Text.Trim());
            MessageBox.Show("Successfully Updated");
        }
    }
}
