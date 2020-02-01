using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Day14
{
    internal class Part02
    {
        private string input;
        private new Dictionary<int, string> cache;

        public Part02(string input)
        {
            this.input = input;
            this.cache = new Dictionary<int, string>();
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
                    var hash = ElongatedHash(md5, salt, index);
                    for (var i = 0; i < hash.Length - 2; i++)
                    {
                        if (hash[i] == hash[i + 1] && hash[i] == hash[i + 2])
                        {
                            var search = new string(hash[i], 5);
                            for (var j = index + 1; j < 1000 + index + 1; j++)
                            {
                                if (ElongatedHash(md5, salt, j).Contains(search))
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

            Console.WriteLine($"Index for 64th key is :{index - 1}");
        }

        private string ElongatedHash(MD5 md5, string salt, int index)
        {
            if (cache.ContainsKey(index)) return cache[index];

            var s = salt + index;
            for (int i = 0; i <= 2016; i++)
            {
                s = MD5Hash(md5, s);
            }
            
            cache.Add(index, s);
            return s;
        }

        private string MD5Hash(MD5 md5, string input)
        {
            byte[] hash = md5.ComputeHash(Encoding.ASCII.GetBytes(input));
            return BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
        }
    }
}