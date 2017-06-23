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
    public partial class LoginView : BaseForm
    {
        private UserService userService;
        public LoginView()
        {
            InitializeComponent();
            userService = new UserService();
        }

        private void LoginView_Load(object sender, EventArgs e)
        {
            if(!String.IsNullOrWhiteSpace(SuccessMessage))
            {
                lblSuccess.Text = SuccessMessage;
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            clearErrors();
            if (String.IsNullOrWhiteSpace(txtUserName.Text))
            {
                addError("Username is required");
            }

            if (String.IsNullOrWhiteSpace(txtPassword.Text))
            {
                addError("Password is required");
            }

            if(!isValid)
            {
                lblError.Text = getErrorText();
                return;
            }
            else
            {
                lblError.Text = String.Empty;
            }

            bool validLogin = userService.isValidPassword(txtUserName.Text, txtPassword.Text);
            if (validLogin)
            {
                bool requirePasswordReset = userService.requirePasswordReset(txtUserName.Text);
                if(requirePasswordReset)
                {
                    var form = FormManager.Current.CreateForm<ResetPasswordView>();
                    form.SuccessMessage = "Please update your password prior to logging in.";
                    form.Show();
                    this.Close();
                    return;
                }

                //TODO Set Authentication context and user principal, for now just move on to the next page
                var main = FormManager.Current.CreateForm<MainMDI>();
                main.currentUser = userService.findUser(txtUserName.Text);
                main.Show();
                this.Close();
            }
            else
            {
                addError("Invalid Username or Password");
                lblError.Text = getErrorText();
            }
        }

        private void lnkResetPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormManager.Current.CreateForm<ResetPasswordView>().Show();
            this.Close();
        }
    }
}
