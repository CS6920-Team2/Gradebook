using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Gradebook.Data.DAO;
using Gradebook.Data.Factories;
using Gradebook.Data.Interfaces;

namespace Gradebook.Data.Services
{
    class CategoryService : ICategoryService
    {
        public List<Category> findCategoriesByTaughtCourseID(int taughtCourseID)
        {
            List<Category> categories;
            using (var connection = ConnectionFactory.GetOpenSQLiteConnection())
            {
                var sql = @"SELECT c.categoryID, c.name, c.weight
	                            FROM  TaughtCourses tc 
	                            JOIN Categories c ON  tc.taughtCourseID = c.taughtCourseID
	                            WHERE c.taughtCourseID = @taughtCourseID;";
                categories = (List<Category>) connection.Query<Category>(sql, new {taughtCourseID = taughtCourseID});
            }
            return categories;
        }

        // Updates all categories for a class or rolls back if one doesn't update. 
        public bool updateAllCategoriesForTaughtCourse(List<Category> categoriesList)
        {
            using (var connection = ConnectionFactory.GetOpenSQLiteConnection())
            {
                using (var trans = connection.BeginTransaction())
                {
                    if (categoriesList == null)
                        return false;

                    int rowsAffected = 0;

                    var sql = "update Categories set weight = @newWeight where categoryID = @categoryID";

                    foreach (Category category in categoriesList)
                    {
                        rowsAffected += connection.Execute(sql, new { newWeight = category.weight, categoryID = category.categoryID }, trans);
                    }

                    if (rowsAffected == 5)
                    {
                        trans.Commit();
                        return true;
                    }
                    else
                    {
                        trans.Rollback();
                        return false;
                    }
                        
                }
            }
        }
    }
}
