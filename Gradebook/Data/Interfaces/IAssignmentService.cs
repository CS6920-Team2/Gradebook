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
        DataSet CreateDataSet();
        bool updateAssignment(int newAssignmentID, int newCategoryID, string newName, string newDescription,
            DateTime newAssignedDate, DateTime newDueDate, int newPossiblePoints);
    }
}
