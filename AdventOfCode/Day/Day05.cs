using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day
{
    internal class Day05
    {
        private readonly string _path;

        public Day05(string path)
        {
            _path = Path.Combine(path, $"Input{this.GetType().Name}.txt");
            PartOne();
            PartTwo();
        }

        public void PartOne()
        {
            var input = File.ReadAllLines(_path);
            var seperatorLine = input.ToList().IndexOf("");
            //var length = input[..(seperatorLine - 1)];
            var numberOfCrates = input[seperatorLine - 1]
                .TrimEnd()
                .Last();
            var crates = input[..(seperatorLine - 1)]
                .Select((x) => x.Replace("[", "")
                .Replace("]", "")
                .Replace("    ", ".")
                .Replace(" ", ""))
                .Reverse().ToList();

            var stacks = new List<Stack<char>>();
            for (int i = 0; i < int.Parse(numberOfCrates.ToString()); i++)
            {
                var stack = new Stack<char>();
                foreach (var crate in crates)
                {
                    if (crate[i] is not '.')
                        stack.Push(crate[i]);
                }
                stacks.Add(stack);
            }

            var instructions = input.Skip(seperatorLine + 1);
            foreach (var instruction in instructions)
            {
                var test2 = instruction
                    .Replace("move ", "")
                    .Replace(" from ", ",")
                    .Replace(" to ", ",")
                    .Split(',');
                var move = int.Parse(test2[0]);
                var from = int.Parse(test2[1]) - 1;
                var to = int.Parse(test2[2]) - 1;
                for (int i = 0; i < move; i++)
                {
                    stacks[to].Push(stacks[from].Pop());
                }
            }
            var result = "";
            for (int i = 0; i < stacks.Count; i++)
            {
                result += stacks[i].Pop();
            }

            Console.WriteLine($"Advent of Code Day 05 part 1 : {result}");
        }

        public void PartTwo()
        {
            var input = File.ReadAllLines(_path);

            var seperatorLine = input.ToList().IndexOf("");
            //var length = input[..(seperatorLine - 1)];
            var numberOfCrates = input[seperatorLine - 1]
                .TrimEnd()
                .Last();
            var crates = input[..(seperatorLine - 1)]
                .Select((x) => x.Replace("[", "")
                .Replace("]", "")
                .Replace("    ", ".")
                .Replace(" ", ""))
                .Reverse();

            var stacks = new List<List<char>>();
            for (int i = 0; i < int.Parse(numberOfCrates.ToString()); i++)
            {
                var stack = new List<char>();
                foreach (var crate in crates)
                {
                    if (crate[i] is not '.')
                        stack.Add(crate[i]);
                }
                stacks.Add(stack);
            }
            var instructions = input.Skip(seperatorLine + 1);
            foreach (var instruction in instructions)
            {
                var test2 = instruction
                    .Replace("move ", "")
                    .Replace(" from ", ",")
                    .Replace(" to ", ",")
                    .Split(',');
                var move = int.Parse(test2[0]);
                var from = int.Parse(test2[1]) - 1;
                var to = int.Parse(test2[2]) - 1;

                var test = new char[move];
                stacks[from].CopyTo(stacks[from].Count - move, test, 0, move);
                stacks[from].RemoveRange(stacks[from].Count - move, move);
                stacks[to].AddRange(test);
            }
            var result = "";
            for (int i = 0; i < stacks.Count; i++)
            {
                result += stacks[i].Last().ToString();
            }

            Console.WriteLine($"Advent of Code Day 05 part 2 : {result}");
        }
    }
}
