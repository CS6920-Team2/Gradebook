using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Gradebook.Data.Interfaces;
using Gradebook.Data.DAO;
using Gradebook.Data.Factories;

namespace Gradebook.Data.Services
{
    public class AdminService : IAdminService
    {
        public Admin getAdminByUserID(int userID)
        {
            Admin admin;
            using (var connection = ConnectionFactory.GetOpenSQLiteConnection())
            {
                admin = connection.Query<Admin>("select * from Admins where userID = @userID", new { userID = userID }).First();
            }
            return admin;
        }
    }
}
