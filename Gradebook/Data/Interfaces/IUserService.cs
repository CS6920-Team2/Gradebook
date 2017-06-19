using Gradebook.Data.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Data.Interfaces
{
    interface IUserService
    {
        User findUser(String userName);
        bool resetPassword(string userName, string oldPassword, string newPassword);
        bool isValidPassword(String userName, String password);
        bool requirePasswordReset(String userName);
    }
}
