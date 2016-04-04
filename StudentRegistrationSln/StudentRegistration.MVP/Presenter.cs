namespace StudentRegistration.MVP
{
    public class Presenter
    {
        private IModel model;
        private IView view;

        private Presenter() { }

        public Presenter(IModel model, IView view)
        {
            this.model = model;
            this.view = view;
        }

        public void Show()
        {
            var form = view as StudentRegistrationForm;

            if (form != null)
            {
                form.ShowDialog();
            }
        }

        public void ShowLoginForm()
        {
            var form = view as LoginForm;

            if (form != null)
            {
                form.ShowDialog();
            }
        }
    }
}
