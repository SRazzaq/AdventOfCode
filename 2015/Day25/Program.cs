using System.IO;

namespace Day25
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var input = File.ReadAllText("Input.txt");

            var part01 = new Part01(input);
            part01.Solve();
        }
    }
}