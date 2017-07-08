using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradebook.Data.DAO;

namespace Gradebook.Data.Interfaces
{
    public interface ITaughtCourseService
    {
        bool addTaughtCourseWithCategories(int teacherID, Course newCourse, List<Category> categoryList);
        bool deleteTaughtCourseWithCategories(TaughtCourse taughtCourse);
        List<TaughtCourse> getTaughtCourses();
    }
}
