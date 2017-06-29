using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Gradebook.Data.Utils
{
    public class Validator
    {

        private static string title = "Entry Error";

        // Returns title of the message box
        public static string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }

        // Checks that the information is present
        public static bool IsPresent(Control control)
        {
            if (control.GetType().ToString() == "System.Windows.Forms.TextBox")
            {
                TextBox textBox = (TextBox)control;
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    System.Windows.Forms.MessageBox.Show(textBox.Tag.ToString() + " is a required field.", Title);
                    textBox.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else if (control.GetType().ToString() == "System.Windows.Forms.ComboBox")
            {
                ComboBox comboBox = (ComboBox)control;
                if (comboBox.SelectedIndex == -1)
                {
                    System.Windows.Forms.MessageBox.Show(comboBox.Tag.ToString() + " is a required field.", Title);
                    comboBox.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
            return true;
        }

        public static bool IsInt32(TextBox textBox)
        {
            try
            {
                if (textBox.Text.All(char.IsDigit))
                {
                    Convert.ToInt32(textBox.Text);
                    return true;
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show(textBox.Tag.ToString() + " must be an integer value.", Title);
                    textBox.Focus();
                    return false;
                }
            }
            catch (FormatException)
            {
                System.Windows.Forms.MessageBox.Show(textBox.Tag.ToString() + " must be an integer value.", Title);
                textBox.Focus();
                return false;
            }
        }

        public static bool IsPresent (TextBox textBox, Label errorLabel)
        {
            if (String.IsNullOrWhiteSpace(textBox.Text))
            {
                errorLabel.Text = textBox.Tag + " is required.";
                textBox.Focus();
                return false;
            }
            return true;
        }
    }
}
