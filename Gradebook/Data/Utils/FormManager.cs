using Gradebook.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gradebook.Data.Utils
{
    public class FormManager : ApplicationContext
    {
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
            var ret = new T();
            ret.FormClosed += onFormClosed;
            return ret;
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
