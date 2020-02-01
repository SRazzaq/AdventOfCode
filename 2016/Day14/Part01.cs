using System;
using System.Security.Cryptography;
using System.Text;

namespace Day14
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
            var salt = input;

            var keyCount = 0;
            var index = 0;
            using (MD5 md5 = MD5.Create())
            {
                while (keyCount < 64)
                {
                    var hash = MD5Hash(md5, salt, index);
                    for (var i = 0; i < hash.Length - 2; i++)
                    {
                        if (hash[i] == hash[i + 1] && hash[i] == hash[i + 2])
                        {
                            var search = new string(hash[i], 5);
                            for (var j = index + 1; j < 1000 + index + 1; j++)
                            {
                                if (MD5Hash(md5, salt, j).Contains(search))
                                {
                                    keyCount++;
                                    break;
                                }
                            }

                            break;
                        }
                    }

                    index++;
                }
            }

            Console.WriteLine($"Index for 64th key is :{index-1}");
        }

        private string MD5Hash(MD5 md5, string salt, int index)
        {
            byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(salt + index));
            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }
    }
}