using System.IO;

namespace Day07
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var input = File.ReadAllText("Input.txt");

            var part01 = new Part01(input);
            part01.Solve();

            var part02 = new Part02(input);
            part02.Solve();
        }
    }
}