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

    private static int GetXMASFromAllDirections(string[] reports, int i, int j, int maxIndex)
    {
        if (reports[i][j] != 'X')
            return 0;

        var sum = 0;
        // Up ^
        if (i - 3 >= 0 && reports[i - 1][j] == 'M' && reports[i - 2][j] == 'A' && reports[i - 3][j] == 'S')
            sum++;

        // Down v
        if (i + 3 <= maxIndex && reports[i + 1][j] == 'M' && reports[i + 2][j] == 'A' && reports[i + 3][j] == 'S')
            sum++;

        // Left <-
        if (j - 3 >= 0 && reports[i][j - 1] == 'M' && reports[i][j - 2] == 'A' && reports[i][j - 3] == 'S')
            sum++;

        // Right ->
        if (j + 3 <= maxIndex && reports[i][j + 1] == 'M' && reports[i][j + 2] == 'A' && reports[i][j + 3] == 'S')
            sum++;

        // Up-left ↖
        if (i - 3 >= 0 && j - 3 >= 0 && reports[i - 1][j - 1] == 'M' && reports[i - 2][j - 2] == 'A' && reports[i - 3][j - 3] == 'S')
            sum++;

        // Up-right ↗
        if (i - 3 >= 0 && j + 3 <= maxIndex && reports[i - 1][j + 1] == 'M' && reports[i - 2][j + 2] == 'A' && reports[i - 3][j + 3] == 'S')
            sum++;

        // Down-left ↙
        if (i + 3 <= maxIndex && j - 3 >= 0 && reports[i + 1][j - 1] == 'M' && reports[i + 2][j - 2] == 'A' && reports[i + 3][j - 3] == 'S')
            sum++;

        // Down-right ↘
        if (i + 3 <= maxIndex && j + 3 <= maxIndex && reports[i + 1][j + 1] == 'M' && reports[i + 2][j + 2] == 'A' && reports[i + 3][j + 3] == 'S')
            sum++;

        return sum;
    }

    private void PartTwo()
    {
        var reports = File.ReadAllLines(_path);

        var rows = reports.Length;
        var cols = reports[0].Length;
        var sum = 0;

        for (int i = 1; i < rows - 1; i++)
        {
            for (int j = 1; j < cols - 1; j++)
            {
                if (reports[i][j] != 'A')
                    continue;

                // Check upper-left + lower-right diagonal combined with upper-right + lower-left diagonal
                var topLeftMAS = i > 0 && j > 0 && reports[i - 1][j - 1] == 'M' && reports[i + 1][j + 1] == 'S';
                var topLeftSAM = i > 0 && j > 0 && reports[i - 1][j - 1] == 'S' && reports[i + 1][j + 1] == 'M';
                var topRightMAS = i > 0 && j < cols - 1 && reports[i - 1][j + 1] == 'M' && reports[i + 1][j - 1] == 'S';
                var topRightSAM = i > 0 && j < cols - 1 && reports[i - 1][j + 1] == 'S' && reports[i + 1][j - 1] == 'M';

                if ((topLeftMAS || topLeftSAM) && (topRightMAS || topRightSAM))
                    sum++;
            }
        }
        Console.WriteLine("Part two: " + sum);
    }
}
