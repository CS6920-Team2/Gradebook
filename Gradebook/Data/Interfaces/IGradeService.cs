using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Data.Interfaces
{
    public interface IGradeService
    {
        DataTable findCourseGrades(int taughtCourseID);
    }
}
