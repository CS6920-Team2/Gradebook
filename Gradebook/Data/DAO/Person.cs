using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Data.DAO
{
    public class Person
    {
        // Columns only hosted in the Persons table
        public int personID { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public DateTime DOB { get; set; }
        public string gender { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zip { get; set; }
        public string phoneNumber { get; set; }
        public string email { get; set; }

        // Columns that all users have that aren't from Persons table
        public string userName { get; set; }
        public string role { get; set; }

        // Teacher
        public int teacherID { get; set; }

        // Administrator
        public int adminID { get; set; }

        // Student
        public int studentID { get; set; }

        public string fullName
        {
            get { return firstName + " " + lastName; }
        }
    }
}
