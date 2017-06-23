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
    class RoleService : IRoleService
    {
        public string findRole(int roleID)
        {
            Role roleObject;
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                roleObject = connection.Query<Role>("select role from Roles where roleID = @roleID", new {roleID = roleID}).FirstOrDefault();
            }
            return roleObject.role;
        }
    }
}
