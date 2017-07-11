using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradebook.Data.DAO;

namespace Gradebook.Data.Interfaces
{
    interface IReportService
    {

        DataSet CreateProgressReportDataSet(int studentID, int taughtCourseID);
        DataTable GetFailureReportDataSet(int teacherID, int taughtCourseID);
    }
}
