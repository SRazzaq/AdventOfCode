﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day15
{
    internal class State : IEquatable
    {
        public State()
        {
            this.Items = new Dictionary<string, int>();
        }

        public State(string[] lines) : this()
        {
            foreach (var line in lines)
            {
                var matches = Regex.Matches(line, @"(\w+-compatible\smicrochip|\w+\sgenerator)");
                foreach (Match match in matches)
                {
                    var item = match.Groups[0].Value.Substring(0, 2);
                    if (match.Groups[0].Value.Contains("microchip"))
                        item += "-M";
                    else
                        item += "-G";

                    if (line.Contains("first")) Items.Add(item, 0);
                    if (line.Contains("second")) Items.Add(item, 1);
                    if (line.Contains("third")) Items.Add(item, 2);
                    if (line.Contains("fourth")) Items.Add(item, 3);
                }
            }
        }

        internal State Clone()
        {
            var newState = new State();
            newState.Elevator = this.Elevator;
            newState.MoveCount = this.MoveCount;
            foreach (var item in Items)
            {
                newState.Items.Add(item.Key, item.Value);
            }
            return newState;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is State)) return false;
            var other = (State)obj;

            foreach (var key in Items.Keys)
            {
                if (Items[key] != other.Items[key]) return false;
            }

            return this.Elevator == other.Elevator;
        }

        internal int MoveCount { get; set; }
        internal int Elevator { get; set; }

        internal Dictionary<string, int> Items { get; private set; }

        internal List<string> FloorItems
        {
            get
            {
                return Items.Where(x => x.Value == Elevator).Select(x => x.Key).ToList();
            }
        }

        internal void Move(int level, string item1, string item2 = null)
        {
            this.MoveCount++;

            Elevator += level;

            Items[item1] = Elevator;
            if (item2 != null) Items[item2] = Elevator;
        }

        internal bool Good
        {
            get
            {
                if (Elevator < 0 || Elevator > 3) return false;

                var good = true; 
                for (int floor = 0; floor < 4; floor++)
                {
                    var floorItems = Items.Where(x => x.Value == floor).Select(x => x.Key);

                    // if floor items has microchip without generator && generator without microchip
                    good &= !(floorItems.Any(x => x.EndsWith("-M") && !floorItems.Contains(x.Substring(0, 2) + "-G")) &&
                              floorItems.Any(x => x.EndsWith("-G") && !floorItems.Contains(x.Substring(0, 2) + "-M")));
                }

                return good;
            }
        }

        internal bool Final
        {
            get
            {
                return Items.All(x => x.Value == 4);
            }
        }

        public override string ToString()
        {
            var s = string.Empty;

            for (var i = 3; i >= 0; i--)
            {
                s += $"F{i + 1}";
                s += " ";
                s += Elevator == i ? "E" : ".";
                s += " ";

                foreach (var key in Items.Keys)
                {
                    s += Items[key] == i ? key : ".   ";
                    s += " ";
                }

                s += Environment.NewLine;
            }

            return s;
        }
    }
}