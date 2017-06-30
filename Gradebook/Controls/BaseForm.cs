﻿using Gradebook.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Gradebook.Data.DAO;

namespace Gradebook.Controls
{
    public class BaseForm : Form
    {
        private List<String> errors;
        public String SuccessMessage { get; set; }
        public User AuthenticatedUser { get; set; }
        public Teacher AuthenticatedTeacher { get; set; }
        public MainView MainView { get; set; }
        public Boolean isValid { get; set; }

        public BaseForm()
        {
            errors = new List<String>();
            isValid = true;
        }

        public String getErrorText()
        {
            return String.Join(",", errors);
        }

        public void addError(String error)
        {
            errors.Add(error);
            isValid = false;
        }

        public void clearErrors()
        {
            errors = new List<String>();
            isValid = true;
        }
    }
}
