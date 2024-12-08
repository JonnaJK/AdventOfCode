using System.Text.RegularExpressions;

namespace AdventOfCode2024.Day;

public class Day03
{
    private readonly string _path;

    public Day03(string path)
    {
        _path = Path.Combine(path, $"Input{GetType().Name}.txt");
        PartOne();
        PartTwo();
    }

    private void PartOne()
    {
        var reports = File.ReadAllText(_path);

        var pattern = new Regex("mul\\([0-9]+,[0-9]+\\)");
        var matches = pattern.Matches(reports).ToList();

        var sum = 0;
        foreach (var match in matches)
        {
            var reducesText = match.Value.ToString().Substring(4);
            var delimitor = reducesText.IndexOf(',');

            var firstValue = int.Parse(reducesText[0..delimitor]);
            var secondValues = reducesText[(delimitor + 1)..].SkipLast(1);

            var second = string.Empty;
            foreach (var value in secondValues)
            {
                second += value;
            }
            var resultPerMul = firstValue * int.Parse(second);
            sum += resultPerMul;
        }

        Console.WriteLine("Part one: " + sum);
    }

    private void PartTwo()
    {
        var reports = File.ReadAllText(_path);

        var dontPattern = "don't()";
        var doPattern = "do()";
        //var dontPattern = new Regex("don't\\(\\)");

        var splittedByDont = reports.Split(new string[] { dontPattern.ToString() }, StringSplitOptions.RemoveEmptyEntries);

        var pattern = new Regex("mul\\([0-9]+,[0-9]+\\)");
        var doOneTime = true;
        var sum = 0;
        for (int i = 0; i < splittedByDont.Length; i++)
        {
            // do the first always
            if (doOneTime)
            {
                var matches = pattern.Matches(splittedByDont[i]).ToList();

                foreach (var match in matches)
                {
                    var reducesText = match.Value.ToString().Substring(4);
                    var delimitor = reducesText.IndexOf(',');

                    var firstValue = int.Parse(reducesText[0..delimitor]);
                    var secondValues = reducesText[(delimitor + 1)..].SkipLast(1);

                    var second = string.Empty;
                    foreach (var value in secondValues)
                    {
                        second += value;
                    }
                    var resultPerMul = firstValue * int.Parse(second);
                    sum += resultPerMul;
                }
                doOneTime = false;
                continue;
            }

            var stringContainsDo = splittedByDont[i].Contains(doPattern);
            if (stringContainsDo is false)
                continue;

            var dos = splittedByDont[i].Split(new string[] { doPattern }, StringSplitOptions.RemoveEmptyEntries).Skip(1);
            foreach (var item in dos)
            {
                var matches = pattern.Matches(item).ToList();

                foreach (var match in matches)
                {
                    var reducesText = match.Value.ToString().Substring(4);
                    var delimitor = reducesText.IndexOf(',');

                    var firstValue = int.Parse(reducesText[0..delimitor]);
                    var secondValues = reducesText[(delimitor + 1)..].SkipLast(1);

                    var second = string.Empty;
                    foreach (var value in secondValues)
                    {
                        second += value;
                    }
                    var resultPerMul = firstValue * int.Parse(second);
                    sum += resultPerMul;
                }
            }
        }

        Console.WriteLine("Part two: " + sum);
    }
}
