using System;

namespace Day07
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
            var lines = input.Split(Environment.NewLine);

            var tlsCount = 0;
            foreach (var line in lines)
            {
                var parts = line.Split('[', ']');

                var goodInBracket = true; var goodOutOfBracket = false;
                for (int i = 0; i < parts.Length; i++)
                {
                    if (i % 2 == 0)
                        goodOutOfBracket = goodOutOfBracket || hasABBA(parts[i]);
                    else
                        goodInBracket = goodInBracket && !hasABBA(parts[i]);
                }

                if (goodInBracket && goodOutOfBracket) tlsCount++;
            }

            Console.WriteLine($"IPs supporting TLS: {tlsCount}");
        }

        private bool hasABBA(string s)
        {
            for (var i = 0; i <= s.Length - 4; i++)
            {
                if (s[i] == s[i + 3] && s[i + 1] == s[i + 2] && s[i] != s[i + 1]) return true;
            }

            return false;
        }
    }
}