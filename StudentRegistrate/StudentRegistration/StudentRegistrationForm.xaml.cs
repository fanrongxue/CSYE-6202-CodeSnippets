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
using System.Windows.Shapes;

using System.ComponentModel;
using System.Data;


namespace StudentRegistration
{
    /// <summary>
    /// StudentRegistrationForm.xaml 的交互逻辑
    /// </summary>
    public partial class StudentRegistrationForm : Window
    {
        public event EventHandler DataChanged;
        private new List<Student> mockStudentList = new List<Student>()
			{
				new Student("111-11-1212", "Bart", "Simpson", "Information Systems", "Full Time"),
			
                new Student("123-12-1235", "Maggie", "Simpson", "International Affairs", "Part Time")
			};
        public StudentRegistrationForm()
		{
			InitializeComponent();
			Init();
		}

	

		// good software programming practice!!
		private void Init()
		{			
			LoadDepartments();
			LoadDataGridWithMockData();
			LoadDefaults();
		}

		private void LoadDepartments()
		{
			//cmbDpt.Items.AddRange(new[] { "Information Systems", "International Affairs", "Nursing", "Pharmacy",
			//	"Professional Studies", "Psychology", "Public Administration" });
         
            cmbDpt.ItemsSource=new[] { "Information Systems", "International Affairs", "Nursing", "Pharmacy",
				"Professional Studies", "Psychology", "Public Administration" };
            
		}

		// since we don't know ADO.NET and/or File I/O we will get static mock data
		private void LoadDataGridWithMockData()
		{
			

			// dirty workaround to make sure that we can bind to the static mock list
			var bindingList = new BindingList<Student>(mockStudentList);
            //var source = new BindingSource(bindingList, null);
            //dataGridViewStudents.DataSource = source;


            Studentstable.ItemsSource = bindingList;
			
          
		}

		private void LoadDefaults()
		{
			//radFTime.Select();
            radFTime.IsChecked=true;
			cmbDpt.SelectedIndex = 0;

		}

        private void newStu_Click(object sender, RoutedEventArgs e)
        {
            String sutID = this.stuID.Text.Trim();
            String fstName = this.fstName.Text.Trim();
            String lstName = this.lstName.Text.Trim();
            String cmbDpt = this.cmbDpt.Text.Trim();
            String radText;
            if (this.radFTime.IsChecked==true)
            {
                radText = this.radFTime.Content.ToString();
            }
            else
            {
                radText = this.radPTime.Content.ToString();
            }
            foreach (Student stx in mockStudentList)
            {
                if (stx.StudentID == sutID)
                {
                    MessageBox.Show("Student ID can not be repeated");
                    return;
                }

            }

            Student st = new Student(sutID, fstName, lstName, cmbDpt, radText);
            mockStudentList.Add(st);
            var bindingList = new BindingList<Student>(mockStudentList);

            Studentstable.ItemsSource = bindingList;
        }

        private void dataGridViewStudents_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
          //  DataGrid dg = sender as DataGrid;
          //  var cell = dg.CurrentCell;
           // DataRowView item = cell.Item as DataRowView;
            Student item = this.Studentstable.SelectedItem as Student;

            if (item != null)
            {
                this.stuID.Text = item.StudentID;
                fstName.Text = item.FirstName;
                lstName.Text = item.LastName;
                cmbDpt.Text = item.Department;
            }
            else
            {
                return;
            }
          
                var enrollmentType = item.EnrollmentType;

                if (radFTime.Content.ToString().Equals(enrollmentType))
                {
                    radFTime.IsChecked = true;

                }
                else if (radPTime.Content.ToString().Equals(enrollmentType))
                {
                    radPTime.IsChecked = true;

                }
            
           
        }

        private void removeStu_Click(object sender, RoutedEventArgs e)
        {
            
          

               Student item = this.Studentstable.SelectedItem as Student;
                    String stuId = item.StudentID;
                    foreach (Student st in mockStudentList)
                    {

                        if (st.StudentID == stuId)
                        {
                            mockStudentList.Remove(st);
                            var bindingList = new BindingList<Student>(mockStudentList);

                    Studentstable.ItemsSource = bindingList;
                            return;
                        }

                    }

                

            
        }

        private void editStu_Click(object sender, RoutedEventArgs e)
        {
            Student item = this.Studentstable.SelectedItem as Student;
            String stuId = item.StudentID;
            foreach (Student st in mockStudentList)
            {

                if (st.StudentID == stuId)
                {
                    mockStudentList.Remove(st);
                    String sutID = this.stuID.Text.Trim();
                    String fstName = this.fstName.Text.Trim();
                    String lstName = this.lstName.Text.Trim();
                    String cmbDpt = this.cmbDpt.Text.Trim();
                    String radText;
                    if (this.radFTime.IsChecked == true)
                    {
                        radText = this.radFTime.Content.ToString();
                    }
                    else
                    {
                        radText = this.radPTime.Content.ToString();
                    }

                    Student st1 = new Student(sutID, fstName, lstName, cmbDpt, radText);
                    mockStudentList.Add(st1);
                    var bindingList = new BindingList<Student>(mockStudentList);

                    Studentstable.ItemsSource = bindingList;
                    return;
                }
            }
        }
    }
}
