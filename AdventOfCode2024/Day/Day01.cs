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

        var distances = text.Split("\r\n");

        var leftSide = new List<string>();
        var rightSide = new List<string>();

        foreach (var distance in distances)
        {
            leftSide.Add(distance.Split(' ').First());
            rightSide.Add(distance.Split(' ').Last());
        }
        leftSide.Sort();
        rightSide.Sort();

        var sum = 0;
        for (var i = 0; i < rightSide.Count; i++)
        {
            var left = leftSide[i];
            var right = rightSide[i];

            var distance = int.Parse(left) - int.Parse(right);
            sum += Math.Abs(distance);
        }

        Console.WriteLine("Part one: " + sum);
    }

    public void PartTwo()
    {
        var text = File.ReadAllText(_path);

        var distances = text.Split("\r\n");

        var leftSide = new List<string>();
        var rightSide = new List<string>();

        foreach (var distance in distances)
        {
            leftSide.Add(distance.Split(' ').First());
            rightSide.Add(distance.Split(' ').Last());
        }

        var sum = 0;
        foreach (var item in leftSide)
        {
            var asd = rightSide.FindAll(x => x == item);

            sum += int.Parse(item) * asd.Count;
        }

        Console.WriteLine("Part two: " + sum);
    }
}
