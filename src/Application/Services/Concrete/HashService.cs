using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Concrete
{
    internal class HashService : IHashService
    {
        public void Create(string value, out byte[] hashedValue, out byte[] key)
        {
            using (var alghoritm = new HMACSHA512())
            {
                key = alghoritm.Key;
                hashedValue = alghoritm.ComputeHash(Encoding.UTF8.GetBytes(value));
            }
        }
        public bool Verify(string value, byte[] hashedValueToCompare, byte[] keyToCompare)
        {
            using (var alghoritm = new HMACSHA512(keyToCompare))
            {
                var computedPassword = alghoritm.ComputeHash(Encoding.UTF8.GetBytes(value));
                for (int i = 0; i < computedPassword.Length; i++)
                {
                    if (computedPassword[i] != hashedValueToCompare[i])
                        return false;
                }
            }
            return true;
        }
    }
}
