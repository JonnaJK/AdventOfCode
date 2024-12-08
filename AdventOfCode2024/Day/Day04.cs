namespace AdventOfCode2024.Day;

public class Day04
{
    private readonly string _path;
    public Day04(string path)
    {
        _path = Path.Combine(path, $"Input{GetType().Name}.txt");
        PartOne();
        PartTwo();
    }

    private void PartOne()
    {
        var reports = File.ReadAllText(_path);

        Console.WriteLine("Part one: " + "sum");
    }

    private void PartTwo()
    {
        var reports = File.ReadAllText(_path);

        Console.WriteLine("Part two: " + "sum");
    }
}
