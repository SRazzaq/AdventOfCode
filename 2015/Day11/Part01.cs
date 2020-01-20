using System;

namespace Day11
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
            var password = FindNextPassword(input);
            Console.WriteLine($"Next Password: {password}");
        }

        internal static string FindNextPassword(string text)
        {
            char a = text[0], b = text[1], c = text[2], d = text[3], e = text[4], f = text[5], g = text[6], h = text[7];

            while (true)
            {
                h++;
                if (h > 'z') { h='a'; g++; } else if (h=='i' || h=='l' || h=='o') { h++; }
                if (g > 'z') { g='a'; f++; } else if (g=='i' || g=='l' || g=='o') { g++; h='a'; }
                if (f > 'z') { f='a'; e++; } else if (f=='i' || f=='l' || f=='o') { f++; g=h='a'; }
                if (e > 'z') { e='a'; d++; } else if (e=='i' || e=='l' || e=='o') { e++; f=g=h='a'; }
                if (d > 'z') { d='a'; c++; } else if (d=='i' || d=='l' || d=='o') { d++; e=f=g=h='a'; }
                if (c > 'z') { c='a'; b++; } else if (c=='i' || c=='l' || c=='o') { c++; d=e=f=g=h='a'; }
                if (b > 'z') { b='a'; a++; } else if (b=='i' || b=='l' || b=='o') { b++; c=d=e=f=g=h='a'; }
                if (a > 'z') { throw new Exception(); }

                var s = new string(new char[] { a, b, c, d, e, f, g, h });
                if (IsValidPassword(s)) return s;
            }
        }

        private static bool IsValidPassword(string s)
        {
            int twiceCount = 0;
            int twiceIndex = 0;
            bool increasing = false;

            int i = 2;
            while (i < s.Length)
            {
                increasing |= s[i - 2] == s[i - 1] - 1 && s[i - 1] == s[i] - 1;
                if (s[i - 1] == s[i] && twiceIndex != i - 1)
                {
                    twiceIndex = i;
                    twiceCount++;
                }
                i++;
            }
            return twiceCount >= 2 && increasing;
        }

    }
}