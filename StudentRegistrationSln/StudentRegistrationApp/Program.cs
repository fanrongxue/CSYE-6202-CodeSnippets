using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudentRegistration.MVP;

namespace StudentRegistrationApp
{
	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		

            static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new StudentRegistrationForm());

            IModel model = new Model();
            // IView view = new StudentRegistrationForm();
            IView view = new LoginForm();
            var presenter = new Presenter(model, view);

            //var form = view as StudentRegistrationForm;

            //if (form != null)
            //{
            //	form.ShowDialog();
            //}

            presenter.ShowLoginForm();
        }
    }
}
