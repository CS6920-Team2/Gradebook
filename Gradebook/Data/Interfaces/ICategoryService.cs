using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradebook.Data.DAO;

namespace Gradebook.Data.Interfaces
{
    interface ICategoryService
    {
        List<Category> findCategoriesByTaughtCourseID(int taughtCourseID);
        bool updateAllCategoriesForTaughtCourse(List<Category> categoriesList);
    }
}
