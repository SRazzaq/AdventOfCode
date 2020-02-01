using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Day05
{
    internal class Part02
    {
        private string input;

        public Part02(string input)
        {
            this.input = input;
        }

        internal void Solve()
        {
            var password = new char[8];
            using (MD5 md5 = MD5.Create())
            {
                int i = 0;
                while (password.Any(x => x == 0))
                {
                    var hash = MD5Hash(md5, input + i);
                    if (hash.StartsWith("00000"))
                    {
                        var location = hash[5] - '0';
                        if (location >= 0 && location <= 7 && password[location] == 0)
                            password[location] = hash[6];
                    }

                    i++;
                }
            }

            Console.WriteLine($"Password is: {new string(password).ToLower()}");
        }

        private string MD5Hash(MD5 md5, string input)
        {
            byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }
    }
}