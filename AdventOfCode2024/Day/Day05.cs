namespace AdventOfCode2024.Day;

public class Day05
{
    private readonly string _path;
    public Day05(string path)
    {
        _path = Path.Combine(path, $"Input{GetType().Name}.txt");
        PartOne();
        PartTwo();
    }

    private void PartOne()
    {
        var text = File.ReadAllLines(_path);

        Console.WriteLine("Part one: " + "sum");
    }

    private void PartTwo()
    {
        var text = File.ReadAllLines(_path);

        Console.WriteLine("Part two: " + "sum");
    }
}
