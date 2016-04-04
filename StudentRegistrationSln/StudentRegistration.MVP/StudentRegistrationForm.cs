#region Using Directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using StudentRegistration.Domain;

#endregion

namespace StudentRegistration.MVP
{
	public partial class StudentRegistrationForm : Form, IStudentRegistrationForm
	{

		public event EventHandler DataChanged;
        private new List<Student> students = new List<Student>()
            {
                new Student("111-11-1212", "Bart", "Simpson", "Information Systems", "Full Time"),
                new Student("123-12-1234", "Maggie", "Simpson", "International Affairs", "Part Time"),
            };
        #region Constructors

        public StudentRegistrationForm()
		{
			InitializeComponent();
			Init();
		}

		#endregion

		#region Methods

		// good software programming practice!!
		private void Init()
		{			
			LoadDepartments();
			LoadDataGridWithMockData();
			LoadDefaults();
		}

		private void LoadDepartments()
		{
			comboBoxDepartment.Items.AddRange(new[] { "Information Systems", "International Affairs", "Nursing", "Pharmacy",
				"Professional Studies", "Psychology", "Public Administration" });
		}

        // since we don't know ADO.NET and/or File I/O we will get static mock data
        private void LoadDataGridWithMockData()
        {


            // dirty workaround to make sure that we can bind to the static mock list
            var bindingList = new BindingList<Student>(students);
            var source = new BindingSource(bindingList, null);
            dataGridViewStudents.DataSource = source;
        }

        private void LoadDefaults()
		{
			radioButtonFullTime.Select();
			comboBoxDepartment.SelectedIndex = 0;

		}

		#endregion

		private void HandleDataGridViewStudentsSelectionChanged(object sender, EventArgs e)
		{
			foreach (DataGridViewRow row in dataGridViewStudents.SelectedRows)
			{
				textBox2.Text = row.Cells[0].Value.ToString();
				textBox3.Text = row.Cells[1].Value.ToString();
				textBox4.Text = row.Cells[2].Value.ToString();

				comboBoxDepartment.SelectedIndex = comboBoxDepartment.Items.IndexOf(row.Cells[3].Value.ToString());

                // enrollment type selection driven by the grid itself
         
                var enrollmentType = row.Cells[4].Value.ToString();
                if (radioButtonFullTime.Text == enrollmentType)
				{
					radioButtonFullTime.Checked = true;
				}
				else if (radioButtonPartTime.Text == enrollmentType)
				{
					radioButtonPartTime.Checked = true;
				}
			}
		}

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure want to remove this student?", "Remove Student Registration Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {

                foreach (DataGridViewRow row in dataGridViewStudents.SelectedRows)
                {
                    String stuId = row.Cells[0].Value.ToString();
                    foreach (Student st in students)
                    {

                        if (st.StudentID == stuId)
                        {
                            students.Remove(st);
                            this.dataGridViewStudents.DataSource = null;
                            LoadDataGridWithMockData();
                            return;
                        }

                    }

                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String id= this.textBox2.Text.Trim();
            String fstName = this.textBox3.Text.Trim();
            String lstName = this.textBox4.Text.Trim();
            String department = this.comboBoxDepartment.SelectedItem.ToString();
            String etype;
            if (this.radioButtonFullTime.Checked == true)
            {
                etype = this.radioButtonFullTime.Text;
            }
            else {
                etype = this.radioButtonPartTime.Text;
            }
            foreach (Student stx in students)
            {
                if (stx.StudentID == id)
                {
                    MessageBox.Show("Student ID can not be repeated");
                    return;
                }

            }

            Student st = new Student(id, fstName, lstName, department, etype);
            students.Add(st);
            MessageBox.Show("sucess");
            this.dataGridViewStudents.DataSource = null;
            LoadDataGridWithMockData();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure want to update this student?", "remove", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                foreach (DataGridViewRow row in dataGridViewStudents.SelectedRows)
                {
                    String stuId = row.Cells[0].Value.ToString();
                    foreach (Student st in students)
                    {

                        if (st.StudentID == stuId)
                        {
                            students.Remove(st);
                            String sutID = this.textBox2.Text.Trim();
                            String fstName = this.textBox3.Text.Trim();
                            String lstName = this.textBox4.Text.Trim();
                            String cmbDpt = this.comboBoxDepartment.Text.Trim();
                            String etype;
                            if (this.radioButtonFullTime.Checked == true)
                            {
                                etype = this.radioButtonFullTime.Text;
                            }
                            else
                            {
                                etype = this.radioButtonPartTime.Text;
                            }

                            Student st1 = new Student(sutID, fstName, lstName, cmbDpt, etype);
                            students.Add(st1);
                            this.dataGridViewStudents.DataSource = null;
                            LoadDataGridWithMockData();
                            return;
                        
                        }

                    }
                }
            }
        }

        private void radioButtonFullTime_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
