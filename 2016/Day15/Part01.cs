using System;
using System.Collections.Generic;

namespace Day15
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
            var state = new State(lines);

            var final = BFS(state);
            Console.WriteLine(final.MoveCount);
        }

        private State BFS(State initialState)
        {
            var queue = new Queue<State>();
            queue.Enqueue(initialState);

            var visited = new HashSet<State>();

            while (queue.Count > 0)
            {
                var state = queue.Dequeue();

                if (state.Final) return state;
                if (!state.Good) continue;
                if (visited.Contains(state)) continue;

                visited.Add(state);
                foreach (var item in state.FloorItems)
                {
                    var upState = state.Clone();
                    upState.Move(+1, item);
                    queue.Enqueue(upState);

                    var downState = state.Clone();
                    downState.Move(-1, item);
                    queue.Enqueue(downState);
                }

                foreach (var item1 in state.FloorItems)
                {
                    foreach (var item2 in state.FloorItems)
                    {
                        if (item1 != item2)
                        {
                            var upState = state.Clone();
                            upState.Move(+1, item1, item2);
                            queue.Enqueue(upState);

                            var downState = state.Clone();
                            upState.Move(-1, item1, item2);
                            queue.Enqueue(upState);

                        }
                    }
                }
            }

            return null;
        }
    }
}