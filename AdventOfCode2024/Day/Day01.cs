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

    private void PartOne()
    {
        var text = File.ReadAllText(_path);
        var distances = text.Split("\r\n");

        var leftSide = new List<int>();
        var rightSide = new List<int>();
        foreach (var distance in distances)
        {
            leftSide.Add(int.Parse(distance.Split(' ').First()));
            rightSide.Add(int.Parse(distance.Split(' ').Last()));
        }
        leftSide.Sort();
        rightSide.Sort();

        var sum = 0;
        for (var i = 0; i < rightSide.Count; i++)
        {
            sum += Math.Abs(leftSide[i] - rightSide[i]);
        }

        Console.WriteLine("Part one: " + sum);
    }

    private void PartTwo()
    {
        var text = File.ReadAllText(_path);
        var distances = text.Split("\r\n");

        var leftSide = new List<int>();
        var rightSide = new List<int>();
        foreach (var distance in distances)
        {
            leftSide.Add(int.Parse(distance.Split(' ').First()));
            rightSide.Add(int.Parse(distance.Split(' ').Last()));
        }

        var sum = 0;
        foreach (var item in leftSide)
        {
            var similarities = rightSide.FindAll(x => x == item);
            sum += item * similarities.Count;
        }

        Console.WriteLine("Part two: " + sum);
    }
}
