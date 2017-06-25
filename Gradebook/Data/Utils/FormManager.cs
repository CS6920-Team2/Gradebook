using Gradebook.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gradebook.Data.Utils
{
    /// <summary>
    /// This class will manage all Forms.
    /// </summary>
    public class FormManager : ApplicationContext
    {
        private MainView mainView;
        private List<Form> openForms = new List<Form>();
        private static FormManager current;

        public FormManager()
        {
            LoginView loginView = CreateForm<LoginView>();
            loginView.Show();
        }

        private void onFormClosed(object sender, EventArgs e)
        {
            if (Application.OpenForms.Count == 0)
            {
                ExitThread();
            }
        }

        public T CreateForm<T>() where T : Form, new()
        {
            var newForm = new T();
            newForm.FormClosed += onFormClosed;
            openForms.Add(newForm);
            return newForm;
        }

        public MainView CreateMainForm()
        {
            var mainView = CreateForm<MainView>();
            this.mainView = mainView;

            return this.mainView;
        }

        public T UpdateMainViewContent<T>() where T : Form, new()
        {
            var form = FormManager.Current.CreateForm<T>();
            form.MdiParent = mainView;

            mainView.updateContentPanel(form);
            form.Show();
            return form;
        }

        /// <summary>
        /// Create and Show the incoming form.  This will close any open any previously open forms.
        /// </summary>
        /// <typeparam name="T">Type of form to show</typeparam>
        /// <returns></returns>
        public T CreateAndShowForm<T>() where T : Form, new()
        {
            var newForm = CreateForm<T>();
            newForm.Show();
            CloseAllForms(newForm);

            return newForm;
        }

        /// <summary>
        /// Closes all registered forms
        /// </summary>
        public void CloseAllForms(Form currentForm)
        {
            foreach(Form form in openForms)
            {
                if(!form.Equals(currentForm))
                {
                    form.Close();
                }
            }
            openForms = new List<Form>();
            openForms.Add(currentForm);
        }

        public static FormManager Current
        {
            get
            {
                if(current == null)
                {
                    current = new FormManager();
                }

                return current;
            }
        }
    }
}
