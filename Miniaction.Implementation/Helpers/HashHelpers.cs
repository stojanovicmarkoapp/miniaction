using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Miniaction.Implementation.Helpers
{
    public static class HashHelpers
    {
        public static string HashToSHA512(string stringToHash)
        {
            using (SHA512 sha512 = new SHA512Managed())
            {
                byte[] stringToHashBytes = Encoding.UTF8.GetBytes(stringToHash);
                byte[] hashBytes = sha512.ComputeHash(stringToHashBytes);
                string hashedString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
                return hashedString;
            }
        }
    }
}
