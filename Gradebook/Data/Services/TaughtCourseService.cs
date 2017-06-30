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
    class TaughtCourseService : ITaughtCourseService
    {
        public bool addTaughtCourseWithCategories(int teacherID, Course newCourse, List<Category> categoryList)
        {
            if (teacherID <= 0 || newCourse == null || categoryList == null)
                return false;

            using (var connection = ConnectionFactory.GetOpenSQLiteConnection())
            {
                using (var trans = connection.BeginTransaction())
                {
                    // Add the course
                    int rowsAffected = 0;

                    var sqlAddCourse =
                        @"insert into courses 
                          values (null, @creditID, @name, @description)";
                    rowsAffected += connection.Execute(sqlAddCourse,
                        new
                        {
                            creditID = newCourse.creditID,
                            name = newCourse.name,
                            description = newCourse.description
                        },
                        trans);

                    // Assign a teacher so it is a "taught course"
                    var sqlAddTaughtCourse =
                        @"insert into taughtCourses
                          values (null, @teacherID, (select max(courseID) from courses))";
                    rowsAffected += connection.Execute(sqlAddTaughtCourse,
                        new {teacherID = teacherID},
                        trans);

                    // Input category weights for taught course 
                    var sqlAddCategory =
                        @"insert into categories
                          values (null, (select max(taughtCourseID) from taughtCourses), @name, @weight)";

                    foreach (Category category in categoryList)
                    {
                        rowsAffected += connection.Execute(sqlAddCategory,
                            new
                            {
                                name = category.name,
                                weight = category.weight
                            },
                            trans);
                    }


                    // Commit only if all new additions have gone through
                    if (rowsAffected == 7)
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

        public bool deleteTaughtCourseWithCategories(TaughtCourse taughtCourse)
        {
            if (taughtCourse == null)
                return false;

            using (var connection = ConnectionFactory.GetOpenSQLiteConnection())
            {
                using (var trans = connection.BeginTransaction())
                {
                    // Delete taught course
                    int rowsAffected = 0;

                    var sqlDeleteTaughtCourse = @"delete from taughtCourses where taughtCourseID = @taughtCourseID";
                    rowsAffected += connection.Execute(sqlDeleteTaughtCourse,
                        new {taughtCourseID = taughtCourse.taughtCourseID}, trans);

                    // Delete course
                    var sqlDeleteCourse = @"delete from courses where courseID = @courseID";
                    rowsAffected += connection.Execute(sqlDeleteCourse, 
                        new {courseID = taughtCourse.courseID}, trans);

                    // Delete all categories for taught course
                    var sqlDeleteCategory = @"delete from categories where taughtCourseID = @taughtCourseID";
                    rowsAffected += connection.Execute(sqlDeleteCategory,
                        new {taughtCourseID = taughtCourse.taughtCourseID}, trans);

                    // Commit only if all new additions have gone through
                    if (rowsAffected == 7)
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
