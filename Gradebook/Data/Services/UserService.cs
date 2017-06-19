using Dapper;
using Gradebook.Data.DAO;
using Gradebook.Data.Factories;
using Gradebook.Data.Interfaces;
using Gradebook.Data.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Data.Services
{
    public class UserService : IUserService
    {
        private SecurityUtils securityUtils;

        public UserService()
        {
            securityUtils = new SecurityUtils();
        }

        public User findUser(string userName)
        {
            if(String.IsNullOrWhiteSpace(userName))
            {
                throw new NotSupportedException("Password cannot be empty!");
            }

            User user;
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                //create the sql query, send in an anonymous object which contains the parameters, then select the first result
                user = connection.Query<User>("select * from Users where userName = @userName", new { userName = userName }).FirstOrDefault();
            }

            return user;
        }

        public bool isValidPassword(string userName, string password)
        {
            User user = findUser(userName);

            if (user == null)
            {
                return false;
            }

            return user.Password == securityUtils.GetStringFromHash(password);
        }

        public bool requirePasswordReset(string userName)
        {
            User user;
            using (var connection = ConnectionFactory.GetOpenConnection())
            {
                user = findUser(userName);
            }

            return user.ResetPassword == 1;
        }

        public bool resetPassword(string userName, string oldPassword, string newPassword)
        {
            if (String.IsNullOrWhiteSpace(userName))
            {
                throw new NotSupportedException("Password cannot be empty!");
            }

            bool isValidLogin = isValidPassword(userName, oldPassword);

            int rowsAffected = 0;

            if (isValidLogin)
            {
                String hashedPassword = securityUtils.GetStringFromHash(newPassword);

                using (var connection = ConnectionFactory.GetOpenConnection())
                {
                    rowsAffected = connection.Execute("update Users set password = @password, resetPassword = 0 where userName=@userName",
                        new { password = hashedPassword, userName = userName });
                }
            }

            return rowsAffected > 0;
        }
    }
}
