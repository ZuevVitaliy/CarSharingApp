using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApp.Helpers
{
    public class Encryptor
    {
        public string GenerateHash(string source)
        {
            var md5 = MD5.Create();

            var bytes = Encoding.ASCII.GetBytes(source);
            var hash = md5.ComputeHash(bytes);

            var sb = new StringBuilder();
            foreach (var b in hash)
            {
                sb.Append(b.ToString("X2"));
            }

            return sb.ToString();
        }
    }
}
