using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Beautifuls.Helper
{
    public class Utility
    {
        // Get Password Hash sha-256
        public static string GetPasswordHash(string password)
        {
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            SHA256 sha256 = SHA256.Create();
            byte[] hashbytes = sha256.ComputeHash(passwordBytes);
            string hashString = BitConverter.ToString(hashbytes).Replace("-", "");
            return hashString;
        }
    }
}