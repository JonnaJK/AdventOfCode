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

        var sum = CalculateMul(matches);
        Console.WriteLine("Part one: " + sum);
    }

    private static int CalculateMul(List<Match> matches)
    {
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
        return sum;
    }

    private void PartTwo()
    {
        var reports = File.ReadAllText(_path);

        var pattern = new Regex("mul\\([0-9]+,[0-9]+\\)");
        var dontString = "don't()";
        var doString = "do()";

        var splittedByDont = reports.Split(new string[] { dontString.ToString() }, StringSplitOptions.RemoveEmptyEntries);

        var matches = pattern.Matches(splittedByDont[0]).ToList();
        var sum = CalculateMul(matches);
        for (int i = 0; i < splittedByDont.Length; i++)
        {
            var isContainingDo = splittedByDont[i].Contains(doString);
            if (isContainingDo is false)
                continue;

            var dos = splittedByDont[i].Split(new string[] { doString }, StringSplitOptions.RemoveEmptyEntries).Skip(1);
            foreach (var item in dos)
            {
                matches = pattern.Matches(item).ToList();
                sum += CalculateMul(matches);
            }
        }

        Console.WriteLine("Part two: " + sum);
    }
}
