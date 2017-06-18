using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Data.DAO
{
    class Category
    {
        public int categoryID { get; set; }
        public int taughtCourseID { get; set; }
        public string name { get; set; }
        public int weight { get; set; }
    }
}
