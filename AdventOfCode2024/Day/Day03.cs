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
        var reports = File.ReadAllLines(_path)
            .Select(x =>
                x.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(y => int.Parse(y))
                .ToList())
            .ToList();

        Console.WriteLine("Part one: " + "sum");
    }

    private void PartTwo()
    {
        var reports = File.ReadAllLines(_path)
            .Select(x =>
                x.Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(y => int.Parse(y))
                .ToList())
            .ToList();

        Console.WriteLine("Part one: " + "sum");
    }
}
