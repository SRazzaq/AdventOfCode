using System;
using System.Collections.Generic;

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

                var floorItems = state.FloorItems;

                // Move one item
                foreach (var floorItem in floorItems)
                {
                    var upState = state.Clone();
                    upState.Move(+1, floorItem);
                    queue.Enqueue(upState);

                    var downState = state.Clone();
                    downState.Move(-1, floorItem);
                    queue.Enqueue(downState);
                }

                // Move two items
                for (var i = 0; i< floorItems.Count; i++)
                {
                    for (var j = i + 1; j < floorItems.Count; j++)
                    {
                            var upState = state.Clone();
                            upState.Move(+1, floorItems[i], floorItems[j]);
                            queue.Enqueue(upState);

                            var downState = state.Clone();
                            downState.Move(-1, floorItems[i], floorItems[j]);
                            queue.Enqueue(downState);

                    }
                }
            }

            return null;
        }
    }
}