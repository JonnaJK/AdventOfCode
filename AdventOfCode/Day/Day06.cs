using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day
{
    internal class Day06
    {
        private readonly string _path;

        public Day06(string path)
        {
            _path = Path.Combine(path, $"Input{GetType().Name}.txt");
            PartOne();
            PartTwo();
        }

        public void PartOne()
        {
            var input = File.ReadAllLines(_path);

            foreach (var row in input)
            {
                var test = row.Take(4).ToList();
                test.Sort();
                for (int j = 0; j < test.Count() - 1; j++)
                {
                    if (test[j] == test[j + 1])
                    {
                        break;
                    }
                    else
                    {

                    }
                }
            }


            var result = 0;

            Console.WriteLine($"Advent of Code Day 06 part 1 : {result}");
        }

        public void PartTwo()
        {
            var input = File.ReadAllLines(_path);

            var result = "";

            Console.WriteLine($"Advent of Code Day 06 part 2 : {result}");
        }
    }
}
