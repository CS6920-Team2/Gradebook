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
    public class RoleService : IRoleService
    {
        public string findRoleByRoleID(int roleID)
        {
            Role roleObject;
            using (var connection = ConnectionFactory.GetOpenSQLiteConnection())
            {
                roleObject = connection.Query<Role>("select role from Roles where roleID = @roleID", new {roleID = roleID}).FirstOrDefault();
            }

            return roleObject != null ? roleObject.role : null;
        }
    }
}
