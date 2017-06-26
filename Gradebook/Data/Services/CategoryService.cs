using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
