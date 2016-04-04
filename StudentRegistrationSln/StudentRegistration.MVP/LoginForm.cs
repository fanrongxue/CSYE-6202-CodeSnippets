using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRegistration.MVP
{
    public partial class LoginForm : Form, ILoginForm
    {
        int count;
        string password1;
        string username1;

        public LoginForm()
        {
            InitializeComponent();
             count = 0;
            password1 = "123456";
            username1 = "123456";
        }
   

    private void button1_Click(object sender, EventArgs e)
        {
            string str1 = txt_user.Text;
            string str2 = txt_pass.Text;

            if (str1 != "" && str2 != "")
            {
                if (str1 == username1 && str2 == password1)
                {
                    MessageBox.Show("Login success!");
                    this.Visible = false;
                    StudentRegistrationForm form = new StudentRegistrationForm();
                    form.ShowDialog();
                }
                else
                {
                    count++;
                    if (count == 3)
                    {
                        MessageBox.Show("Sorry!Press ok to quit!");
                        Application.Exit();
                    }
                    else
                    {
                        MessageBox.Show("Login failed!You have " + (3 - count).ToString() + " times");
                        txt_user.Text = "";
                        txt_pass.Text = "";
                    }
                }
            }
        }
    

        private void txt_pass_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_user_TextChanged(object sender, EventArgs e)
        {

        }

        private void password_Click(object sender, EventArgs e)
        {

        }

        private void username_Click(object sender, EventArgs e)
        {

        }
    }
}

