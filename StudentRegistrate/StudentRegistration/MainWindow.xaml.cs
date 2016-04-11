using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentRegistration
{
    /// <summary>
    /// MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User user = new User("admin", "admin");
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            
            if ((this.username.Text.Trim() == user.UserName) && (this.password.Text.Trim() == user.PassWord))
            {
                user.resetTotal();
                
                StudentRegistrationForm win = new StudentRegistrationForm();
               
                this.Hide();
                win.Show();
               

            }
            else
            {

                int result = user.addTotal();
                if (result == 1)
                {
                    MessageBox.Show("Username or Password ERROR!");
                }
                else
                {
                    MessageBox.Show("Sorry,You have tried three times!");
                }


            } 
        }
    }
}
