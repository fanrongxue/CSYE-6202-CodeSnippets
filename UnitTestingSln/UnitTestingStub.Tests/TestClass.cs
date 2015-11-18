using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace UnitTestingStub.Tests
{
	[TestFixture]
	public class TestClass
	{
		Student student;
		[TestFixtureSetUp]
		public void Setup()
		{
			// create the student here..
			student = new Student();
		}

		[Test]
		public void When_StudentAgeAssigned_ResultShouldBeGreaterThanZero()
		{
			// prepare
			var expected = 0;

			// action	- this should be replaced with the actual method call
			var actual = student.Age;

			// assert
			Assert.That(actual, Is.GreaterThanOrEqualTo(expected));


		}
	}
}
