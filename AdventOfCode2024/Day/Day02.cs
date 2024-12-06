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

    public void PartOne()
    {
        var text = File.ReadAllText(_path);

        var reports = text.Split("\r\n");

        var sum = 0;
        foreach (var report in reports)
        {
            var valuesPerReport = report.Split(" ");

            var decreaseCounter = 0;
            var increaseCounter = 0;
            var isSafeReport = true;
            for (int i = 0; i < valuesPerReport.Length - 1; i++)
            {
                if (isSafeReport is false)
                    break;

                //if (i == valuesPerReport.Count - 1)
                //    break;

                var first = int.Parse(valuesPerReport[i]);
                var second = int.Parse(valuesPerReport[i + 1]);

                if (first == second)
                {
                    // Unsafe neither an increase or a decrease
                    isSafeReport = false;
                    break;
                }

                var isIncreasing = first < second;
                var isDecreasing = first > second;

                if (isIncreasing && isDecreasing)
                {
                    // Unsafe neither an increase or a decrease
                    isSafeReport = false;
                    break;
                }

                if (isIncreasing) // increase
                {
                    var diff = second - first;
                    if (diff >= 1 && diff <= 3)
                    {
                        // Safe
                        increaseCounter++;
                    }
                    else
                    {
                        // Unsafe increaseing by more than 3
                        isSafeReport = false;
                        break;
                    }
                }
                else // decrease
                {
                    var diff = first - second;
                    if (diff >= 1 && diff <= 3)
                    {
                        // Safe
                        decreaseCounter++;
                    }
                    else
                    {
                        // Unsafe decreaseing by more than 3
                        isSafeReport = false;
                        break;
                    }
                }
            }
            if (isSafeReport && (increaseCounter > 0 && decreaseCounter > 0) is false)
            {
                sum += 1;
            }
        }

        Console.WriteLine("Part one: " + sum);
    }

    public void PartTwo()
    {
        var text = File.ReadAllText(_path);


        Console.WriteLine("Part one: " + "sum");
    }
}
