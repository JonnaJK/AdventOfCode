using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AdventOfCode.Day
{
    internal class Day02
    {
        private readonly string _path;

        public Day02(string path)
        {
            _path = Path.Combine(path, $"Input{this.GetType().Name}.txt");
            PartOne();
            PartTwo();
        }

        public void PartOne()
        {
            var text = File.ReadAllLines(_path);

            var sumPoints = 0;
            // Split each row "AY" to 'A' and 'Y'
            for (int i = 0; i < text.Length; i++)
            {
                sumPoints += GetPointsForPartOne(text[i]);
            }

            Console.WriteLine("Part one: " + sumPoints);
        }

        private static int GetPointsForPartOne(string text)
        {
            switch (text)
            {
                case "A X":          // rock-rock Draw = 4 (3 + 1)
                    return 4;
                case "A Y":          // rock-paper win = 8 (6 + 2)
                    return 8;
                case "A Z":          // rock-scissor loss = 3 (0 + 3)
                    return 3;
                case "B X":          // paper-rock loss = 1 (0 + 1)
                    return 1;
                case "B Y":          // paper-paper draw = 5 (3 + 2)
                    return 5;
                case "B Z":          // paper-scissor win = 9 (6 + 3)
                    return 9;
                case "C X":          // scissor-rock win = 7 (6 + 1)
                    return 7;
                case "C Y":          // scissor-paper loss = 2 (0 + 2)
                    return 2;
                case "C Z":          // scissor-scissor draw = 6 (3 + 3)
                    return 6;
                default:
                    return 0;
            }
        }

        public void PartTwo()
        {

            var text = File.ReadAllLines(_path);

            var sumPoints = 0;
            for (int i = 0; i < text.Length; i++)
            {
                sumPoints += GetPointsForPartTwo(text[i]);
            }

            Console.WriteLine("Part two: " + sumPoints);
        }

        private int GetPointsForPartTwo(string text)
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

            switch (text)
            {
                case "A X":
                    return 3;
                case "A Y":
                    return 4;
                case "A Z":
                    return 8;
                case "B X":
                    return 1;
                case "B Y":
                    return 5;
                case "B Z":
                    return 9;
                case "C X":
                    return 2;
                case "C Y":
                    return 6;
                case "C Z":
                    return 7;
                default:
                    return 0;
            }
        }
    }
}
