using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroSet_UI.Forms;
using Microsoft.Win32;

namespace ExaminationSys
{
    public partial class Form1 : MetroSetForm
    {
        public Form1()
        {
            string role = "";

            InitializeComponent();
            /*
            key.SetValue("UserType", "This is our setting 2");
            */

            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\OurSettings");

            //if it does exist, retrieve the stored values  
            if (key != null)
            {
                role = (string) key.GetValue("UserType");
                key.Close();
            }
            /*
            role = "InsTMan";
            role = "Ins";
            role = "Std";
            */
            if (role == "InsTMan")
            {
                Tabs.TabPages.Remove(Exams);
            }
            else if (role == "Ins")
            {
                Tabs.TabPages.Remove(Instructor);
                Tabs.TabPages.Remove(Student);
                Tabs.TabPages.Remove(Department);
                Tabs.TabPages.Remove(Branch);
                Tabs.TabPages.Remove(Intake);
                Tabs.TabPages.Remove(Track);
                Tabs.TabPages.Remove(Exams);
            }
            else if(role == "Std")
            {
                Tabs.TabPages.Remove(Instructor);
                Tabs.TabPages.Remove(Student);
                Tabs.TabPages.Remove(Department);
                Tabs.TabPages.Remove(Branch);
                Tabs.TabPages.Remove(Intake);
                Tabs.TabPages.Remove(Track);
                Tabs.TabPages.Remove(Creat_Exam);
                Tabs.TabPages.Remove(Student_for_Exam);
                Tabs.TabPages.Remove(Question_Pools);
            }
            else
            {
                Tabs.Visible = false;
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            this.Hide();
            login.ShowDialog();
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void metroSetPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //private void metroSetButton1_Click(object sender, EventArgs e)
        //{
        //    FormCourse form = new FormCourse();
        //    form.ShowDialog();
        //}
        Context context = new Context();
        //SqlConnection con = new SqlConnection("Data Source=DESKTOP-LS0DQEE;Initial Catalog=ExaminationSystemCF;Integrated Security=True");

        private void metroSetButton1_Click_1(object sender, EventArgs e)
        {
          
            // insert
            string deptname=dptname.Text;
            var department= new Department() { DeptName=deptname};
            context.Departments.Add(department);
            context.SaveChanges();
            MessageBox.Show("Successfully Inserted");
            loaddepartmentData();


        }
        void loadcoursedata()
        {
            var courses = (from cr in context.Courses select cr).ToList();
            dataGridViewcourse.DataSource = courses;
            dataGridViewcourse.Columns["Instructor"].Visible=false;
        }
        void loadtrackdata()
        {
            var track=(from tr in context.Tracks select tr).ToList();
            dataGridViewtrack.DataSource = track;
        }
        void loadintakedata()
        {
            var intake = (from inta in context.Intakes select inta).ToList();
            dataGridViewintake.DataSource = intake;
        }
        void loaddepartmentData()
        {            
            var department=(from dpt in context.Departments select dpt).ToList();
            dataGridViewdepartment.DataSource = department;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loaddepartmentData();
            loadtrackdata();
            loadintakedata();
            loadcoursedata();
        }
        
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==0)
            {
                //Edit
                FormUpdateDepartment formUpdateDepartment = new FormUpdateDepartment();
                formUpdateDepartment.ShowDialog();
                int _id = Convert.ToInt32(dataGridViewdepartment.Rows[e.RowIndex].Cells[2].Value);
                Department dept = context.Departments.Where(d => d.DeptId == _id).FirstOrDefault();
                string deptname = FormUpdateDepartment.departname;
                dept.DeptName = deptname;
                context.SaveChanges();
                loaddepartmentData();


            }
            if (e.ColumnIndex == 1)
            {
                //Delete
                if (MessageBox.Show("Are You Sure To Delete Department Record?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information)==DialogResult.Yes)
                {
                    int _id = Convert.ToInt32(dataGridViewdepartment.Rows[e.RowIndex].Cells[2].Value);
                    Department dept = context.Departments.Where(d => d.DeptId == _id).FirstOrDefault();
                    context.Departments.Remove(dept);
                    context.SaveChanges();
                    loaddepartmentData();
                    
                }
            }
        }

        private void btndeptsearch_Click(object sender, EventArgs e)
        {
            //search
            var department = (from dpt in context.Departments 
                              where dpt.DeptName== txtdeptsearch.Text
                              select dpt).ToList();
            dataGridViewdepartment.DataSource = department;


        }

        private void btnintakeinsert_Click(object sender, EventArgs e)
        {
            // insert
            int intakenum = int.Parse(txtintakename.Text);
            var intake = new Intake() { IntakeNumber=intakenum };
            context.Intakes.Add(intake);
            context.SaveChanges();
            MessageBox.Show("Successfully Inserted");
            loadintakedata();
        }

        private void dataGridViewintake_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                //Edit
                Formupdateintake formUpdateintake = new Formupdateintake();
                formUpdateintake.ShowDialog();
                int _id = Convert.ToInt32(dataGridViewintake.Rows[e.RowIndex].Cells[2].Value);
                Intake intake = context.Intakes.Where(d => d.IntakeId == _id).FirstOrDefault();
                int intakenum = Formupdateintake.intakenum;
                intake.IntakeNumber = intakenum;         
                context.SaveChanges();
                loadintakedata();


            }
            if (e.ColumnIndex == 1)
            {
                //Delete
                if (MessageBox.Show("Are You Sure To Delete Intake Record?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    int _id = Convert.ToInt32(dataGridViewintake.Rows[e.RowIndex].Cells[2].Value);
                    Intake intake = context.Intakes.Where(d => d.IntakeId == _id).FirstOrDefault();
                    context.Intakes.Remove(intake);
                    context.SaveChanges();
                    loadintakedata();

                }
            }
        }

        private void btnintakesearch_Click(object sender, EventArgs e)
        {
            int intakenum = int.Parse(txtsearchintake.Text);
            var intake = (from inta in context.Intakes 
                          where inta.IntakeNumber == intakenum
                          select inta).ToList();
            dataGridViewintake.DataSource = intake;
        }

        private void btninserttrack_Click(object sender, EventArgs e)
        {
            // insert
            string trackname = txttrackname.Text;
            var track = new Track() { TrackName= trackname };
            context.Tracks.Add(track);
            context.SaveChanges();
            MessageBox.Show("Successfully Inserted");
            loadtrackdata();
        }

        private void dataGridViewtrack_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                //Edit
                Formupdatetrack formUpdatetrack = new Formupdatetrack();
                formUpdatetrack.ShowDialog();
                int _id = Convert.ToInt32(dataGridViewtrack.Rows[e.RowIndex].Cells[2].Value);
                Track track = context.Tracks.Where(d => d.TrackId == _id).FirstOrDefault();
                string trackname = Formupdatetrack.trackname;
                track.TrackName = trackname;
                context.SaveChanges();
                loadtrackdata();



            }
            if (e.ColumnIndex == 1)
            {
                //Delete
                if (MessageBox.Show("Are You Sure To Delete track Record?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    int _id = Convert.ToInt32(dataGridViewtrack.Rows[e.RowIndex].Cells[2].Value);
                    Track track = context.Tracks.Where(d => d.TrackId == _id).FirstOrDefault();
                    context.Tracks.Remove(track);
                    context.SaveChanges();
                    loadtrackdata();

                }
            }
        }

        private void btnsearchtrack_Click(object sender, EventArgs e)
        {
            var tracks = (from tr in context.Tracks
                              where tr.TrackName == txttracksearch.Text
                              select tr).ToList();
            dataGridViewtrack.DataSource = tracks;
        }

        private void btninsertcourse_Click(object sender, EventArgs e)
        {
            //insert
            string title = txtcoursetitleins.Text;
            string des= txtcoursedesins.Text;
            int mindegree = int.Parse(txtmindegreeinsert.Text);
            int maxdegree = int.Parse(txtmaxdegreeinsert.Text);
            int insid=int.Parse(txtinstcourseidins.Text);

            var course=new Course() { CrsTitle=title,CrsDesc=des, CrsMinDegree = mindegree, CrsMaxDegree =maxdegree,InsId= insid };
            context.Courses.Add(course);
            context.SaveChanges();
            loadcoursedata();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            var course = (from cr in context.Courses
                              where cr.CrsTitle == txtcoursesearch.Text
                              select cr).ToList();
            dataGridViewcourse.DataSource = course;
        }



        private void dataGridViewcourse_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                //Edit
                FormCourse formcourse = new FormCourse();
                formcourse.ShowDialog();
                int _id = Convert.ToInt32(dataGridViewcourse.Rows[e.RowIndex].Cells[2].Value);
                Course course = context.Courses.Where(d => d.CrsId == _id).FirstOrDefault();
                string coursetitle = FormCourse._title;
                string coursedes = FormCourse._decription;
                int mindeg = FormCourse._mindegree;
                int maxdeg = FormCourse._maxdegree;
                int insid = FormCourse._instructorid;
                course.CrsTitle = coursetitle;
                course.CrsDesc = coursedes;
                course.InsId = insid;
                course.CrsMaxDegree = maxdeg;
                course.CrsMinDegree = mindeg;
                context.SaveChanges();
                loadcoursedata();
            }
            if (e.ColumnIndex == 1)
            {
                //Delete
                if (MessageBox.Show("Are You Sure To Delete course Record?", "Information", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    int _id = Convert.ToInt32(dataGridViewcourse.Rows[e.RowIndex].Cells[2].Value);
                    Course course = context.Courses.Where(d => d.CrsId == _id).FirstOrDefault();
                    context.Courses.Remove(course);
                    context.SaveChanges();
                    loadcoursedata();

                }
            }
        }

        //private void metroSetButton2_Click(object sender, EventArgs e)
        //{

        //}

        //private void txtsearchintake_Click(object sender, EventArgs e)
        //{

        //}

        //private void metroSetLabel1_Click(object sender, EventArgs e)
        //{

        //}

        //private void metroSetButton2_Click(object sender, EventArgs e)
        //{
        //    con.Open();
        //    SqlCommand command = new SqlCommand("update Departments set DeptName= '"+dptname.Text+ "'where DeptId='" + int.Parse(metroSetTextBox2.Text) +"'", con);
        //    command.ExecuteNonQuery();
        //    MessageBox.Show("Successfully Updated");
        //    con.Close();
        //    BindData();
        //}

        //private void Department_load(object sender, EventArgs e)
        //{

        //}

        //private void metroSetButton1_Click(object sender, EventArgs e)
        //{

        //}
    }
}
