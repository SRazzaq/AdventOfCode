using System;

namespace Day12
{
    internal class Assembunny
    {
        private string[] program;

        public Assembunny(string input)
        {
            this.program = input.Split(Environment.NewLine);
            this.Registers = new int[4];
        }

        public int[] Registers { get; set; }

        public void Run()
        {
            int val;
            var pc = 0;
            while (pc < program.Length)
            {
                var inst = program[pc].Split(' ');
                switch (inst[0])
                {
                    case "cpy":
                        if (int.TryParse(inst[1], out val))
                            Registers[inst[2][0] - 'a'] = val;
                        else
                            Registers[inst[2][0] - 'a'] = Registers[inst[1][0] - 'a'];
                        pc++;
                        break;

                    case "inc":
                        Registers[inst[1][0] - 'a']++;
                        pc++;
                        break;

                    case "dec":
                        Registers[inst[1][0] - 'a']--;
                        pc++;
                        break;

                    case "jnz":
                        if (int.TryParse(inst[1], out val) && val != 0)
                        {
                            pc += int.Parse(inst[2]);
                        }
                        else if (Registers[inst[1][0] - 'a'] != 0)
                        {
                            pc += int.Parse(inst[2]);
                        }
                        else
                        {
                            pc++;
                        }
                        break;
                }
            }
        }
    }
}