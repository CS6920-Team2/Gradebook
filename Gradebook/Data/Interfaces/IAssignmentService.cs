using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Data.Interfaces
{
    interface IAssignmentService
    {
        DataSet CreateAssignmentDataSet(int taughtCourseID);
        bool updateAssignment(int newAssignmentID, int newCategoryID, string newName, string newDescription,
            DateTime newAssignedDate, DateTime newDueDate, int newPossiblePoints);
        void addAssignment(int newCategoryID, string newName, string newDescription,
            DateTime newAssignedDate, DateTime newDueDate, int newPossiblePoints);
        void deleteAssignment(int newAssignmentID);
    }
}
