using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day
{
    internal class Day03
    {
        private readonly string _path;

        public Day03(string path)
        {
            _path = Path.Combine(path, $"Input{GetType().Name}.txt");
            PartOne();
            PartTwo();
        }

        public void PartOne()
        {
            var input = File.ReadAllLines(_path);

            var result = 0;
            foreach (var line in input)
            {
                var length = line.Length;
                var split1 = line[..(length / 2)];
                var split2 = line[(length / 2)..];

                var character = split1
                    .Intersect(split2)
                    .First();

                if (char.IsLower(character))
                    result += character - 96;
                else
                    result += character - (64 - 26);
            }
            Console.WriteLine($"Advent of Code Day 03 part 1 : {result}");
        }

        public void PartTwo()
        {
            var input = File.ReadAllLines(_path).Chunk(3);
            var result = 0;

            foreach (var group in input)
            {
                var intersected = group[0]
                    .Intersect(group[1])
                    .Intersect(group[2])
                    .First();

                if (char.IsLower(intersected))
                    result += intersected - 96;
                else
                    result += intersected - (64 - 26);
            }

            Console.WriteLine($"Advent of Code Day 03 part 2 : {result}");
        }
    }
}
