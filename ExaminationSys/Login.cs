using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroSet_UI.Forms;
using Microsoft.Win32;

namespace ExaminationSys
{
    public partial class Login : MetroSetForm
    {
        Context db = new Context();
        public Login()
        {
            InitializeComponent();
        }

        private void metroSetButton1_Click(object sender, EventArgs e)
        {
            bool isAuthorized = false;
            string userName = txtUserName.Text;
            User currentUser = db.Users.FirstOrDefault(i => i.UserName == userName);

            if(currentUser != null)
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\OurSettings");
                string password = txtPassword.Text;

                if (currentUser.HasRole(UserType.Student))
                {
                    Student student = db.Students
                        .FirstOrDefault(i => i.StdUserName == userName && i.StdPassword == password);
                    if(student != null)
                    {
                        key.SetValue("UserType", "Std");
                        isAuthorized = true;
                    }
                    else
                    {
                        MetroSetMessageBox.Show(this, "Wrong Password");
                    }
                }
                else if (currentUser.HasRole(UserType.TrainingManager) && currentUser.HasRole(UserType.Instructor))
                {
                    Instructor instructor = db.Instructors
                        .FirstOrDefault(i => i.InsUserName == userName && i.InsPassword == password);
                    if (instructor != null)
                    {
                        key.SetValue("UserType", "InsTMan");
                        isAuthorized = true;
                    }
                    else
                    {
                        MetroSetMessageBox.Show(this, "Wrong Password");
                    }
                }
                else if (currentUser.HasRole(UserType.Instructor))
                {
                    Instructor instructor = db.Instructors
                        .FirstOrDefault(i => i.InsUserName == userName && i.InsPassword == password);
                    if (instructor != null)
                    {
                        key.SetValue("UserType", "Ins");
                        isAuthorized = true;
                    }
                    else
                    {
                        MetroSetMessageBox.Show(this, "Wrong Password");
                    }
                }
            }
            else
            {
                MetroSetMessageBox.Show(this, "Wrong User Name");
            }
            if (isAuthorized)
            {
                Form1 form = new Form1();
                this.Hide();
                form.ShowDialog();
            }
        }
    }
}
