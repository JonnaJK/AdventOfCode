namespace AdventOfCode2024.Day;

public class Day04
{
    private readonly string _path;
    private readonly char _letterX = 'X';
    private readonly char _letterM = 'M';
    private readonly char _letterA = 'A';
    private readonly char _letterS = 'S';
    public Day04(string path)
    {
        _path = Path.Combine(path, $"Input{GetType().Name}.txt");
        PartOne();
        PartTwo();
    }

    private void PartOne()
    {
        var reports = File.ReadAllLines(_path);

        var rows = reports.Length;
        var cols = reports[0].Length;
        var sum = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                sum += GetXMASFromAllDirections(reports, i, j, rows - 1);
            }
        }
        Console.WriteLine("Part one: " + sum);
    }

    private int GetXMASFromAllDirections(string[] reports, int i, int j, int maxIndex)
    {
        if (reports[i][j] != _letterX)
            return 0;

        var sum = 0;
        // Up ^
        if (i - 3 >= 0 && reports[i - 1][j] == _letterM && reports[i - 2][j] == _letterA && reports[i - 3][j] == _letterS)
            sum++;

        // Down v
        if (i + 3 <= maxIndex && reports[i + 1][j] == _letterM && reports[i + 2][j] == _letterA && reports[i + 3][j] == _letterS)
            sum++;

        // Left <-
        if (j - 3 >= 0 && reports[i][j - 1] == _letterM && reports[i][j - 2] == _letterA && reports[i][j - 3] == _letterS)
            sum++;

        // Right ->
        if (j + 3 <= maxIndex && reports[i][j + 1] == _letterM && reports[i][j + 2] == _letterA && reports[i][j + 3] == _letterS)
            sum++;

        // Up-left ↖
        if (i - 3 >= 0 && j - 3 >= 0 && reports[i - 1][j - 1] == _letterM && reports[i - 2][j - 2] == _letterA && reports[i - 3][j - 3] == _letterS)
            sum++;

        // Up-right ↗
        if (i - 3 >= 0 && j + 3 <= maxIndex && reports[i - 1][j + 1] == _letterM && reports[i - 2][j + 2] == _letterA && reports[i - 3][j + 3] == _letterS)
            sum++;

        // Down-left ↙
        if (i + 3 <= maxIndex && j - 3 >= 0 && reports[i + 1][j - 1] == _letterM && reports[i + 2][j - 2] == _letterA && reports[i + 3][j - 3] == _letterS)
            sum++;

        // Down-right ↘
        if (i + 3 <= maxIndex && j + 3 <= maxIndex && reports[i + 1][j + 1] == _letterM && reports[i + 2][j + 2] == _letterA && reports[i + 3][j + 3] == _letterS)
            sum++;

        return sum;
    }

    private void PartTwo()
    {
        var reports = File.ReadAllLines(_path);

        var rows = reports.Length;
        var cols = reports[0].Length;

        var sum = 0;
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                if (reports[i][j] != _letterA)
                    continue;

                sum += GetX_MASFromFourDirections(reports, i, j);
            }
        }
        Console.WriteLine("Part two: " + sum);
    }

    private int GetX_MASFromFourDirections(string[] reports, int i, int j)
    {
        var highestIndex = reports.Length - 1;

        var rowCanGoNegative = i - 1 >= 0;
        var colCanGoNegative = j - 1 >= 0;
        var rowCanGoPositive = i + 1 <= highestIndex;
        var colCanGoPositive = j + 1 <= highestIndex;

        if (!rowCanGoNegative || !rowCanGoPositive || !colCanGoPositive || !colCanGoNegative)
            return 0;

        var upperLeft = reports[i - 1][j - 1] == _letterM && reports[i + 1][j + 1] == _letterS;
        var upperRight = reports[i - 1][j + 1] == _letterM && reports[i + 1][j - 1] == _letterS;
        var lowerLeft = reports[i + 1][j - 1] == _letterM && reports[i - 1][j + 1] == _letterS;
        var lowerRight = reports[i + 1][j + 1] == _letterM && reports[i - 1][j - 1] == _letterS;

        if ((upperLeft && (upperRight || lowerRight)) ||
            (upperRight && (upperLeft || lowerRight)) ||
            (lowerLeft && (upperLeft || lowerRight)) ||
            (lowerRight && (lowerLeft || upperRight)))
        {
            return 1;
        }
        return 0;
    }
}
