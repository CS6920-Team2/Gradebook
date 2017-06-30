using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Data.DAO
{
    public class Assignment
    {
        public int assignmentID { get; set; }
        public int categoryID { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string assignedDate { get; set; }
        public string dueDate { get; set; }
        public int possiblePoints { get; set; }
    }
}
