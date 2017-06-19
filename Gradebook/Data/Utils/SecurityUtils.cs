using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Gradebook.Data.Factories.ConnectionFactory;

namespace Gradebook.Data.Utils
{
    public class SecurityUtils
    {
        public byte[] GetHash(String password)
        {
            String salt = ConfigurationManager.AppSettings[AppKeys.PasswordSalt].ToString();
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(salt + password);
            return sha256.ComputeHash(bytes);
        }

        public String GetStringFromHash(byte[] hash)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X2"));
            }
            return result.ToString();
        }

        public String GetStringFromHash(String password)
        {
            return GetStringFromHash(GetHash(password));
        }
    }
}
