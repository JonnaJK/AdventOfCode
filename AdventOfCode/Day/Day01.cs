using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day
{
    internal class Day01
    {
        private readonly string _path;

        public Day01(string path)
        {
            _path = Path.Combine(path, $"Input{GetType().Name}.txt");
            PartOne();
            PartTwo();
        }

        public void PartOne()
        {
            var text = File.ReadAllText(_path);

            var max = 0;
            var elves = text.Split("\r\n\r\n");
            foreach (var elf in elves)
            {
                var sum = 0;

                var calorie = elf.Split("\r\n");
                for (int i = 0; i < calorie.Length; i++)
                {
                    sum += int.Parse(calorie[i]);
                }
                max = Math.Max(sum, max);
            }
            Console.WriteLine("Part one: " + max);
        }

        public void PartTwo()
        {
            var text = File.ReadAllText(_path);

            List<int> sums = new();
            var elves = text.Split("\r\n\r\n");
            foreach (var elf in elves)
            {
                var sum = 0;

                var calorie = elf.Split("\r\n");
                for (int i = 0; i < calorie.Length; i++)
                {
                    sum += int.Parse(calorie[i]);
                }
                sums.Add(sum);
            }
            sums = sums.OrderByDescending(x => x).ToList();

            var result = 0;
            for (int i = 0; i < 3; i++)
            {
                result += sums[i];
            }
            Console.WriteLine("Part two: " + result);
        }
    }
}


/*  Jimmys lösning
         public void PartOne()
        {
            var result = File.ReadAllText(_path)
                .Split("\r\n\r\n")
                .Select(x => x.Split("\r\n").Sum(y => int.Parse(y)))
                .Max();

            Console.WriteLine($"Advent of Code Day 01 part 1 : {result}");
        }

        public void PartTwo()
        {
            var result = File.ReadAllText(_path)
                .Split("\r\n\r\n")
                .Select(x => x.Split("\r\n").Sum(y => int.Parse(y)))
                .OrderByDescending(x => x)
                .Take(3)
                .Sum();

            Console.WriteLine($"Advent of Code Day 01 part 2 : {result}");
        }
 */