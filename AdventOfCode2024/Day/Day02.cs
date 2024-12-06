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
            var isAscending = (report[0] - report[1]) < 0;
            var isSafeReport = true;
            for (int i = 0; i < report.Count - 1; i++)
            {
                var diff = report[i] - report[i + 1];

                if (Math.Abs(diff) > 3 || diff == 0) // Unsafe - To much or no in-/decrease
                {
                    isSafeReport = false;
                    break;
                }
                if ((isAscending ^ diff < 0)) // Unsafe - report is increasing and decreasing
                {
                    isSafeReport = false;
                    break;
                }
            }

            if (isSafeReport)
                sum += 1;
        }

        Console.WriteLine("Part one: " + sum);
    }

    private void PartTwo()
    {
        var text = File.ReadAllText(_path);


        Console.WriteLine("Part one: " + "sum");
    }
}
