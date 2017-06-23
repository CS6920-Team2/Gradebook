using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gradebook.Data.DAO;
using Gradebook.Data.Interfaces;
using Gradebook.Data.Factories;
using Dapper;

namespace Gradebook.Data.Services
{
    class PersonService : IPersonService
    {
        public Person getPersonByPersonID(int personID)
        {
            Person person;
            using (var connection = ConnectionFactory.GetOpenSQLiteConnection())
            {
                person = connection.Query<Teacher>("select * from Persons where personID = @personID", new { personID = personID }).FirstOrDefault();
            }
            return person;
        }
    }
}
