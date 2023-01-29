using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Day
{
    internal class Day02
    {
        private readonly string _path;

        public Day02(string path)
        {
            _path = Path.Combine(path, $"Input{GetType().Name}.txt");
            PartOne();
            PartTwo();
        }

        public void PartOne()
        {
            var input = File.ReadAllLines(_path);

            var result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                result += GetPointsForPartOne(input[i]);
            }

            Console.WriteLine($"Advent of Code Day 02 part 1 : {result}");
        }

        private static int GetPointsForPartOne(string text)
        {
            return text switch
            {
                "A X" => 4,         // rock-rock Draw = 4 (3 + 1)
                "A Y" => 8,         // rock-paper win = 8 (6 + 2)
                "A Z" => 3,         // rock-scissor loss = 3 (0 + 3)
                "B X" => 1,         // paper-rock loss = 1 (0 + 1)
                "B Y" => 5,         // paper-paper draw = 5 (3 + 2)
                "B Z" => 9,         // paper-scissor win = 9 (6 + 3)
                "C X" => 7,         // scissor-rock win = 7 (6 + 1)
                "C Y" => 2,         // scissor-paper loss = 2 (0 + 2)
                "C Z" => 6,         // scissor-scissor draw = 6 (3 + 3)
                _ => 0,
            };
        }

        public void PartTwo()
        {

            var input = File.ReadAllLines(_path);

            var result = 0;
            for (int i = 0; i < input.Length; i++)
            {
                result += GetPointsForPartTwo(input[i]);
            }

            Console.WriteLine($"Advent of Code Day 02 part 2 : {result}");
        }

        private static int GetPointsForPartTwo(string text)
        {
            // If (A X) --> Lose --> rock-scissor = 3 (0 + 3)
            // If (A Y) --> Draw --> rock-rock = 4 (3 + 1)
            // If (A Z) --> Win  --> rock-paper = 8 (6 + 2)
            // If (B X) --> Lose --> paper-rock = 1 (0 + 1)
            // If (B Y) --> Draw --> paper-paper = 5 (3 + 2)
            // If (B Z) --> Win --> paper-scissor = 9 (6 + 3)
            // If (C X) --> Lose --> scissor-paper = 2 (0 + 2)
            // If (C Y) --> Draw --> scissor-scissor = 6 (3 + 3)
            // If (C Z) --> Win --> scissor-rock = 7 (6 + 1)

            return text switch
            {
                "A X" => 3,
                "A Y" => 4,
                "A Z" => 8,
                "B X" => 1,
                "B Y" => 5,
                "B Z" => 9,
                "C X" => 2,
                "C Y" => 6,
                "C Z" => 7,
                _ => 0,
            };
        }
    }
}
