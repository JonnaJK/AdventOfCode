namespace AdventOfCode2024.Day;

public class Day02
{
    private readonly string _path;

    public Day02(string path)
    {
        _path = Path.Combine(path, $"Input{GetType().Name}.txt");
        PartOne();
        PartTwo();
    }

    private void PartOne()
    {
        var reports = File.ReadAllLines(_path)
            .Select(x =>
                x.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(y => int.Parse(y))
                .ToList())
            .ToList();

        var sum = 0;
        foreach (var report in reports)
        {
            sum += IsSafeReport(report, false);
        }

        Console.WriteLine("Part one: " + sum);
    }

    private static int IsSafeReport(List<int> report, bool isUsingProblemDampener)
    {
        var isAscending = (report[0] - report[1]) < 0;

        for (int i = 0; i < report.Count - 1; i++)
        {
            var diff = report[i] - report[i + 1];

            if (Math.Abs(diff) > 3 || diff == 0) // Unsafe - To much or no in-/decrease
            {
                if (isUsingProblemDampener is false)
                    return 0;

                return IsSafeReportWithProblemDampener(report, i);
            }
            if ((isAscending ^ diff < 0)) // Unsafe - report is increasing and decreasing
            {
                if (isUsingProblemDampener is false)
                    return 0;

                return IsSafeReportWithProblemDampener(report, i);
            }
        }
        return 1;
    }

    private void PartTwo()
    {
        var reports = File.ReadAllLines(_path)
            .Select(x =>
                x.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(y => int.Parse(y))
                .ToList())
            .ToList();

        var sum = 0;
        foreach (var report in reports)
        {
            sum += IsSafeReport(report, true);
        }

        Console.WriteLine("Part one: " + sum);
    }

    private static int IsSafeReportWithProblemDampener(List<int> report, int i)
    {
        var start = Math.Max(0, i - 1);
        for (int j = start; j <= i + 1; j++)
        {
            var newReport = report.Select(x => x).ToList();
            newReport.RemoveAt(j);
            if (IsSafeReport(newReport, false) is 1)
                return 1;
        }
        return 0;
    }
}
