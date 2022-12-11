using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode.Day
{
    internal class Day04
    {
        private readonly string _path;

        public Day04(string path)
        {
            _path = Path.Combine(path, $"Input{this.GetType().Name}.txt");
            PartOne();
            PartTwo();
        }

        public void PartOne()
        {
            // Jimmys version
            var input = File.ReadAllLines(_path);
            var result = input
                .Select(x => x.Split(','))
                .Select(x =>
                {
                    var first = GetRange(x[0]);
                    var second = GetRange(x[1]);
                    var intersects = first.Intersect(second).Count();
                    return (intersects == first.Count || intersects == second.Count) ? 1 : 0;
                })
                .Sum();

            // Min version
            //foreach (var line in input)
            //{
            //    var split = line.Split(",");
            //    var firstElf = GetRange(split[0]);
            //    var secondElf = GetRange(split[1]);

            //    var intersected = firstElf.Intersect(secondElf).Count();
            //    result += (intersected == firstElf.Count() || intersected == secondElf.Count() ? 1 : 0);
            //}

            Console.WriteLine($"Advent of Code Day 04 part 1 : {result}");
        }

        private static List<int> GetRange(string x)
        {
            var numbers = x.Split('-').Select(x => int.Parse(x)).ToList();
            return Enumerable.Range(numbers[0], numbers[1] - numbers[0] + 1).ToList();
        }

        public void PartTwo()
        {
            var input = File.ReadAllLines(_path);
            var result = 0;
            foreach (var line in input)
            {
                var split = line.Split(",");
                var firstElf = GetRange(split[0]);
                var secondElf = GetRange(split[1]);

                if (firstElf.Intersect(secondElf).Count() > 0)
                {
                    result++;
                }
            }
            Console.WriteLine($"Advent of Code Day 04 part 2 : {result}");
        }
    }
}
