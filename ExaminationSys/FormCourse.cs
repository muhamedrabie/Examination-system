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
    public partial class FormCourse : Form
    {
      

        public static string _title = "";
        public static string _decription = "";
        public static int _maxdegree = 0;
        public static int _mindegree = 0;
        public static int _instructorid = 0;

        public FormCourse()
        {
            InitializeComponent();
         
        }
        public void Clear()
        {
            txtcoursedes.Text= txtcoursetitle.Text= txtmindegreeupdate.Text= txtmaxdegreeupdate.Text= txtinstcourseid.Text=string.Empty;
            //metroSetTextBox6.Text= txtcoursetitle.Text= metroSetTextBox3.Text= metroSetTextBox4.Text= metroSetTextBox5.Text=String.Empty;
        }
        private void metroSetButton1_Click(object sender, EventArgs e)
        {
            _title= txtcoursetitle.Text.Trim();
            _decription= txtcoursedes.Text.Trim();
            _mindegree  = int.Parse(txtmindegreeupdate.Text.Trim());
            _maxdegree = int.Parse(txtmaxdegreeupdate.Text.Trim());
            _instructorid = int.Parse(txtinstcourseid.Text.Trim());
            MessageBox.Show("Successfully Updated");

            //Clear();

        }

        //private void FormCourse_Load(object sender, EventArgs e)
        //{

        //}
    }
}
