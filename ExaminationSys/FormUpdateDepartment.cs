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
    public partial class FormUpdateDepartment : Form
    {
        public static string departname="";
        public FormUpdateDepartment()
        {
            InitializeComponent();
        }

        private void btnsaveupdatedeot_Click(object sender, EventArgs e)
        {
            departname= texupdatedept.Text.Trim();
            MessageBox.Show("Successfully Updated");

            
        }
    }
}
