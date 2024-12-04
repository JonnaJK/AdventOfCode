namespace AdventOfCode2024.Day;

public class Day01
{
    private readonly string _path;

    public Day01(string path)
    {
        _path = Path.Combine(path, $"Input{GetType().Name}.txt");
        PartOne();
        PartTwo();
    }

    public void PartOne()
    {
        var text = File.ReadAllText(_path);



        Console.WriteLine("Part one: " + "");
    }

    public void PartTwo()
    {
        var text = File.ReadAllText(_path);

        Console.WriteLine("Part two: " + "");
    }
}
