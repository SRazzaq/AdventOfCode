namespace Day23
{
    internal class Computer
    {
        private int pc = 0;
        private string[] program;

        internal Computer(string[] program)
        {
            this.program = program;
        }

        internal uint a { get; set; }

        internal uint b { get; set; }

        internal bool Halt { get; set; }

        internal void Cycle()
        {
            var instruction = program[pc].Split(' ');
            switch (instruction[0])
            {
                case "hlf":
                    if (instruction[1] == "a")
                        a /= 2;
                    else
                        b /= 2;
                    pc++;
                    break;

                case "tpl":
                    if (instruction[1] == "a")
                        a *= 3;
                    else
                        b *= 3;
                    pc++;
                    break;

                case "inc":
                    if (instruction[1] == "a")
                        a++;
                    else
                        b++;
                    pc++;
                    break;

                case "jmp":
                    pc += int.Parse(instruction[1]);
                    break;

                case "jie":
                    if ((instruction[1].TrimEnd(',') == "a" && a % 2 == 0) ||
                        (instruction[1].TrimEnd(',') == "b" && b % 2 == 0))
                        pc += int.Parse(instruction[2]);
                    else
                        pc++;

                    break;

                case "jio":
                    if ((instruction[1].TrimEnd(',') == "a" && a == 1) ||
                        (instruction[1].TrimEnd(',') == "b" && b == 1))
                        pc += int.Parse(instruction[2]);
                    else
                        pc++;

                    break;
            }

            if (pc > program.Length - 1) Halt = true;
        }
    }
}