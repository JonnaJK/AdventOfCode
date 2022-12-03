using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day
{
    internal class Day03
    {
        private readonly string _path;

        public Day03(string path)
        {
            _path = Path.Combine(path, $"Input{this.GetType().Name}.txt");
            PartOne();
            PartTwo();
        }

        public void PartOne()
        {
            var input = File.ReadAllLines(_path);

            var result = 0;
            foreach (var line in input)
            {
                //var first = x[..(x.Length / 2)];
                //var second = x[(x.Length / 2)..];
                var length = line.Length;
                var split1 = line[..(length / 2)];
                var split2 = line[(length / 2)..];

                var character = split1.Intersect(split2).First();
                if (char.IsLower(character))
                    result += character - 96;
                else
                    result += character - (64 - 26);
            }
            // Length (1-based)
            //                   1 1 1 1 1 1 1 1 1 1 2 2 2 2 2
            // 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4
            // v J r w p W t w J g W r h c s F M M f F F h F p
            // Index (0-based)
            //                     1 1 1 1 1 1 1 1 1 1 2 2 2 2
            // 0 1 2 3 4 5 6 7 8 9 0 1 2 3 4 5 6 7 8 9 0 1 2 3

            // Shoould look like:
            // split1: vJrwpWtwJgWr
            // split2: hcsFMMfFFhFp
            Console.WriteLine($"Advent of Code Day 03 part 1 : {result}");
        }

        public void PartTwo()
        {
            var input = File.ReadAllLines(_path);
            var result = 0;

            Console.WriteLine($"Advent of Code Day 03 part 2 : {result}");
        }
    }
}
