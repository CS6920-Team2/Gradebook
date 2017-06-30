using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Data
{
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public ComboBoxItem(String text, object value)
        {
            this.Text = text;
            this.Value = value;
        }
        public override string ToString()
        {
            return Text;
        }
    }
}
