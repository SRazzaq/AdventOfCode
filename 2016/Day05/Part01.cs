using System;
using System.Security.Cryptography;
using System.Text;

namespace Day05
{
    internal class Part01
    {
        private string input;

        public Part01(string input)
        {
            this.input = input;
        }

        internal void Solve()
        {
            var password = string.Empty;
            using (MD5 md5 = MD5.Create())
            {
                int i = 0;
                while (password.Length < 8)
                {
                    var hash = MD5Hash(md5, input + i);
                    if (hash.StartsWith("00000"))
                        password += hash[5];

                    i++;
                }
            }

            Console.WriteLine($"Password is: {password.ToLower()}");
        }

        private string MD5Hash(MD5 md5, string input)
        {
            byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }
    }
}