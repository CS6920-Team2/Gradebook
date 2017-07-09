using Gradebook.Data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Gradebook.Data.Factories;
using Gradebook.Data.Interfaces;

namespace Gradebook.Data.Services
{
    public class RegisteredStudentService : IRegisteredStudentService
    {
        public List<RegisteredStudent> getAllStudentsAsRegisteredStudents()
        {
            List<RegisteredStudent> registeredStudents;

            using (var connection = ConnectionFactory.GetOpenSQLiteConnection())
            {
                var sql = @"select * from students s join persons p on s.personID = p.personID";

                registeredStudents = (List<RegisteredStudent>)connection.Query<RegisteredStudent>(sql);
            }

            return registeredStudents;
        }

        public List<RegisteredStudent> getRegisteredStudentsInTaughtCourse(int taughtCourseID)
        {
            List<RegisteredStudent> registeredStudents;

            using (var connection = ConnectionFactory.GetOpenSQLiteConnection())
            {
                var sql = @"select rs.*, p.firstName, p.lastName from students s 
	                            join persons p on s.studentID = p.personID
	                            join registeredStudents rs on s.studentID = rs.studentID
	                            join taughtCourses tc on rs.taughtCourseID = tc.taughtCourseID
	                            where tc.taughtCourseID = @taughtCourseID";

                registeredStudents = (List<RegisteredStudent>)connection.Query<RegisteredStudent>(sql, new { taughtCourseID = taughtCourseID });
            }

            return registeredStudents;
        }

        public bool updateRegisteredStudentsInTaughtCourse(int taughtCourseID, List<int> addStudentIDs, List<int> removeStudentIDs)
        {

            int numberRowsShouldChange = addStudentIDs.Count + removeStudentIDs.Count;

            if (taughtCourseID <= 0 || numberRowsShouldChange <= 0)
            {
                return false;
            }

            using (var connection = ConnectionFactory.GetOpenSQLiteConnection())
            {
                using (var trans = connection.BeginTransaction())
                {
                    int rowsAffected = 0;

                    // Add new
                    foreach (int studentID in addStudentIDs)
                    {
                        var sqlAddStu = @"insert into registeredStudents values (null, @sID, @tcID)";

                        rowsAffected += connection.Execute(sqlAddStu, 
                            new
                            {
                                sID = studentID,
                                tcID = taughtCourseID
                            },
                            trans);
                    }

                    // Delete removed
                    foreach (int studentID in removeStudentIDs)
                    {
                        var sqlDelStu = @"delete from registeredStudents 
	                                    where studentID = @sID and taughtCourseID = @tcID ";

                        rowsAffected += connection.Execute(sqlDelStu,
                            new
                            {
                                sID = studentID, 
                                tcID = taughtCourseID
                            },
                            trans);
                    }

                    // Commit only if all were added/removed
                    if (rowsAffected == numberRowsShouldChange)
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
