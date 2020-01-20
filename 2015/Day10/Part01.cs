using System;
using System.Text;

namespace Day10
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
            var text = input;
            for (int i = 0; i < 40; i++)
            {
                text = LookAndSay(text);
            }

            Console.WriteLine($"Length of result: {text.Length}");
        }

        internal static string LookAndSay(string text)
        {
            var lookAndSay = new StringBuilder();

            int i = 0;
            while (i < text.Length)
            {
                var length = 1;
                var current = text[i];
                i++;

                while (i < text.Length && current == text[i])
                {
                    length++;
                    i++;
                }

                lookAndSay.Append(length.ToString() + current);
            }

            return lookAndSay.ToString();
        }
    }
}