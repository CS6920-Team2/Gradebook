using Gradebook.Controls;
using Gradebook.Data.Services;
using Gradebook.Data.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gradebook.View
{
    public partial class ResetPasswordView : BaseForm
    {
        private UserService userService;

        public ResetPasswordView()
        {
            InitializeComponent();
            userService = new UserService();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            clearErrors();
            if (String.IsNullOrWhiteSpace(txtUserName.Text))
            {
                addError("Username is required");
            }

            if (String.IsNullOrWhiteSpace(txtPassword.Text))
            {
                addError("Current Password is required");
            }

            if (String.IsNullOrWhiteSpace(txtNewPassword.Text))
            {
                addError("New Password is required");
            }

            if (!isValid)
            {
                lblError.Text = getErrorText();
                return;
            }
            else
            {
                lblError.Text = String.Empty;
            }

            bool updated = userService.resetPassword(txtUserName.Text, txtPassword.Text, txtNewPassword.Text);
            if(updated)
            {
                LoginView loginView = FormManager.Current.CreateForm<LoginView>();
                loginView.SuccessMessage = "Password successfully changed!";
                loginView.Show();
                this.Close();
            } 
            else
            {
                addError("Username or Password is incorrect");
                lblError.Text = getErrorText();
            }
        }

        private void ResetPasswordView_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(SuccessMessage))
            {
                lblSuccess.Text = SuccessMessage;
            }
        }
    }
}
