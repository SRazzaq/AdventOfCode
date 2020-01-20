using System;
using System.Security.Cryptography;
using System.Text;

namespace Day04
{
    internal class AdventCoin
    {
        internal static int Mine(string key, int length)
        {
            var i = 0;

            var zeros = new string('0', length);
            var hashString = new string(' ', length);

            using (MD5 md5Hash = MD5.Create())
            {
                while (hashString.Substring(0, length) != zeros)
                {
                    var input = key + i.ToString();

                    byte[] hash = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
                    hashString = BitConverter.ToString(hash).Replace("-", "");

                    i++;
                }
            }

            return i;
        }
    }
}