using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestingStub
{
	public class Student
	{
		public string StudentID { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Department { get; set; }
		public string EnrollmentType { get; set; }

		private int age;
		public int Age { get { return -1;/*-1;*/ } set { age = value; } }

		public Student() { }

		public Student(string studentID, string firstName, string lastName, string department, string enrollmentType)
		{
			StudentID = studentID;
			FirstName = firstName;
			LastName = lastName;
			Department = department;
			EnrollmentType = enrollmentType;
		}

		public override string ToString()
		{
			return string.Format("StudentID: {0}, FirstName: {1}, LastName: {2}, Department: {3}, EnrollmentType: {4}", StudentID, FirstName, LastName, Department, EnrollmentType);
		}
	}

}
