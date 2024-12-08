using System.Data.Common;

namespace AdventOfCode2024.Day;

public class Day04
{
    private readonly string _path;
    private readonly string _x = "X";
    private readonly string _m = "M";
    private readonly string _a = "A";
    private readonly string _s = "S";
    public Day04(string path)
    {
        _path = Path.Combine(path, $"Input{GetType().Name}.txt");
        PartOne();
        PartTwo();
    }

    private void PartOne()
    {
        var reports = File.ReadAllLines(_path)
            .Select(x =>
                x.ToCharArray().ToList())
            .ToList();

        var matrix = ConvertToMatrix(reports);
        var _lowestIndex = 0;
        var highestIndex = matrix.GetLength(0) - 1;

        var sum = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col].Equals(_x, StringComparison.CurrentCultureIgnoreCase) is false)
                    continue;

                // North ^
                if ((row - 3) >= _lowestIndex)
                    sum += CheckNorth(matrix, row, col);

                // North East ↗
                if ((row - 3) >= _lowestIndex && (col + 3) <= highestIndex)
                    sum += CheckNorthEast(matrix, row, col);

                // East ->
                if ((col + 3) <= highestIndex)
                    sum += CheckEast(matrix, row, col);

                // South East ↘
                if ((row + 3) <= highestIndex && (col + 3 <= highestIndex))
                    sum += CheckSouthEast(matrix, row, col);

                // South v
                if ((row + 3) <= highestIndex)
                    sum += CheckSouth(matrix, row, col);

                // South West ↙
                if ((row + 3 <= highestIndex) && (col - 3) >= _lowestIndex)
                    sum += CheckSouthWest(matrix, row, col);

                // West <-
                if ((col - 3) >= _lowestIndex)
                    sum += CheckWest(matrix, row, col);

                // North West ↖
                if ((row - 3) >= _lowestIndex && (col - 3) >= _lowestIndex)
                    sum += CheckNorthWest(matrix, row, col);

            }
        }
        Console.WriteLine("Part one: " + sum);
    }

    private int CheckNorth(string[,] matrix, int row, int col)
    {
        if (matrix[row - 1, col].Equals(_m, StringComparison.CurrentCultureIgnoreCase))
        {
            if (matrix[row - 2, col].Equals(_a, StringComparison.CurrentCultureIgnoreCase))
            {
                if (matrix[row - 3, col].Equals(_s, StringComparison.CurrentCultureIgnoreCase))
                {
                    return 1;
                }
            }
        }
        return 0;
    }

    private int CheckNorthEast(string[,] matrix, int row, int col)
    {
        if (matrix[row - 1, col + 1].Equals(_m, StringComparison.CurrentCultureIgnoreCase))
            if (matrix[row - 2, col + 2].Equals(_a, StringComparison.CurrentCultureIgnoreCase))
                if (matrix[row - 3, col + 3].Equals(_s, StringComparison.CurrentCultureIgnoreCase))
                    return 1;
        return 0;
    }

    private int CheckEast(string[,] matrix, int row, int col)
    {
        if (matrix[row, col + 1].Equals(_m, StringComparison.CurrentCultureIgnoreCase))
            if (matrix[row, col + 2].Equals(_a, StringComparison.CurrentCultureIgnoreCase))
                if (matrix[row, col + 3].Equals(_s, StringComparison.CurrentCultureIgnoreCase))
                    return 1;
        return 0;
    }

    private int CheckSouthEast(string[,] matrix, int row, int col)
    {
        if (matrix[row + 1, col + 1].Equals(_m, StringComparison.CurrentCultureIgnoreCase))
            if (matrix[row + 2, col + 2].Equals(_a, StringComparison.CurrentCultureIgnoreCase))
                if (matrix[row + 3, col + 3].Equals(_s, StringComparison.CurrentCultureIgnoreCase))
                    return 1;
        return 0;
    }

    private int CheckSouth(string[,] matrix, int row, int col)
    {
        if (matrix[row + 1, col].Equals(_m, StringComparison.CurrentCultureIgnoreCase))
            if (matrix[row + 2, col].Equals(_a, StringComparison.CurrentCultureIgnoreCase))
                if (matrix[row + 3, col].Equals(_s, StringComparison.CurrentCultureIgnoreCase))
                    return 1;
        return 0;
    }

    private int CheckSouthWest(string[,] matrix, int row, int col)
    {
        if (matrix[row + 1, col - 1].Equals(_m, StringComparison.CurrentCultureIgnoreCase))
            if (matrix[row + 2, col - 2].Equals(_a, StringComparison.CurrentCultureIgnoreCase))
                if (matrix[row + 3, col - 3].Equals(_s, StringComparison.CurrentCultureIgnoreCase))
                    return 1;
        return 0;
    }

    private int CheckWest(string[,] matrix, int row, int col)
    {
        if (matrix[row, col - 1].Equals(_m, StringComparison.CurrentCultureIgnoreCase))
            if (matrix[row, col - 2].Equals(_a, StringComparison.CurrentCultureIgnoreCase))
                if (matrix[row, col - 3].Equals(_s, StringComparison.CurrentCultureIgnoreCase))
                    return 1;
        return 0;
    }

    private int CheckNorthWest(string[,] matrix, int row, int col)
    {
        if (matrix[row - 1, col - 1].Equals(_m, StringComparison.CurrentCultureIgnoreCase))
            if (matrix[row - 2, col - 2].Equals(_a, StringComparison.CurrentCultureIgnoreCase))
                if (matrix[row - 3, col - 3].Equals(_s, StringComparison.CurrentCultureIgnoreCase))
                    return 1;
        return 0;
    }

    private static string[,] ConvertToMatrix(List<List<char>> reports)
    {
        var matrix = new string[reports.Count, reports[0].Count];

        for (int i = 0; i < reports.Count; i++)
        {
            for (int j = 0; j < reports[0].Count; j++)
            {
                matrix[i, j] = reports[i][j].ToString();
            }
        }
        return matrix;
    }

    private void PartTwo()
    {
        var reports = File.ReadAllText(_path);

        Console.WriteLine("Part two: " + "sum");
    }
}
