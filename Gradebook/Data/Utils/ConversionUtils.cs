using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Gradebook.Data.Utils
{
    class ConversionUtils
    {
        public static int TextBoxToInt(System.Windows.Forms.TextBox textBox)
        {
            try
            {
                if (textBox.Text != "")
                {
                    int number = int.Parse(textBox.Text);
                    return number;
                }
                return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
