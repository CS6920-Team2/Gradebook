using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gradebook.Data.DAO
{
    public class User
    {
        public int UserID { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public int RoleID { get; set; }
        public int ResetPassword { get; set; }
    }
}
