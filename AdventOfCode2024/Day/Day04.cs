using System.ComponentModel.Design;
using System.Data.Common;

namespace AdventOfCode2024.Day;

public class Day04
{
    private readonly string _path;
    private readonly string _m = "M";
    private readonly string _a = "A";
    private readonly string _s = "S";
    public Day04(string path)
    {
        _path = Path.Combine(path, $"Input{GetType().Name}.txt");
        PartOne();
        PartTwoasd();
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

    private int CheckNorth(string[,] matrix, int row, int col)
    {
        if (matrix[row - 1, col].Equals(_m, StringComparison.CurrentCultureIgnoreCase))
            if (matrix[row - 2, col].Equals(_a, StringComparison.CurrentCultureIgnoreCase))
                if (matrix[row - 3, col].Equals(_s, StringComparison.CurrentCultureIgnoreCase))
                    return 1;
        return 0;
    }

    private int CheckNorthEast(string[,] matrix, int row, int col, string second, string third, string? fourth)
    {
        if (matrix[row - 1, col + 1].Equals(second, StringComparison.CurrentCultureIgnoreCase))
        {
            if (matrix[row - 2, col + 2].Equals(third, StringComparison.CurrentCultureIgnoreCase))
            {
                if (string.IsNullOrEmpty(fourth))
                    return 1;

                if (matrix[row - 3, col + 3].Equals(fourth, StringComparison.CurrentCultureIgnoreCase))
                    return 1;
            }
        }
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

    private int CheckSouthEast(string[,] matrix, int row, int col, string second, string third, string? fourth)
    {
        if (matrix[row + 1, col + 1].Equals(second, StringComparison.CurrentCultureIgnoreCase))
        {
            if (matrix[row + 2, col + 2].Equals(third, StringComparison.CurrentCultureIgnoreCase))
            {
                if (string.IsNullOrEmpty(fourth))
                    return 1;

                if (matrix[row + 3, col + 3].Equals(fourth, StringComparison.CurrentCultureIgnoreCase))
                    return 1;
            }
        }
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

    private int CheckSouthWest(string[,] matrix, int row, int col, string second, string third, string? fourth)
    {
        if (matrix[row + 1, col - 1].Equals(second, StringComparison.CurrentCultureIgnoreCase))
        {
            if (matrix[row + 2, col - 2].Equals(third, StringComparison.CurrentCultureIgnoreCase))
            {
                if (string.IsNullOrEmpty(fourth))
                    return 1;

                if (matrix[row + 3, col - 3].Equals(fourth, StringComparison.CurrentCultureIgnoreCase))
                    return 1;
            }
        }
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

    private int CheckNorthWest(string[,] matrix, int row, int col, string second, string third, string? fourth)
    {
        if (matrix[row - 1, col - 1].Equals(_m, StringComparison.CurrentCultureIgnoreCase))
        {
            if (matrix[row - 2, col - 2].Equals(_a, StringComparison.CurrentCultureIgnoreCase))
            {
                if (string.IsNullOrEmpty(fourth))
                    return 1;

                if (matrix[row - 3, col - 3].Equals(_s, StringComparison.CurrentCultureIgnoreCase))
                    return 1;
            }
        }
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
        var reports = File.ReadAllLines(_path)
            .Select(x =>
                x.ToCharArray().ToList())
            .ToList();

        var matrix = ConvertToMatrix(reports);
        var lowestIndex = 0;
        var highestIndex = matrix.GetLength(0) - 1;

        var first = "M";
        var second = "A";
        var third = "S";

        var sum = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col].Equals(first, StringComparison.CurrentCultureIgnoreCase) is false)
                    continue;

                var rowNotToLow = (row - 2) >= lowestIndex;
                var colNotToLow = (col - 2) >= lowestIndex;
                var rowNotToHigh = (row + 2) <= highestIndex;
                var colNotToHigh = (col + 2) <= highestIndex;

                // index IN bounds if below is true !!!!!!!!!!!
                // - ROW:           row >= (lowestIndex + 2) &&             if 2 or more
                // - COL:           col >= (lowestIndex + 2) &&             if 2 or more              
                // + ROW:           row <= (highestIndex - 2) &&            if 7 or less
                // + COL:           col <= (highestIndex - 2) &&            if 7 or less

                // North East ↗ (-row +col)
                if (row >= (lowestIndex + 2) && col <= (highestIndex - 2))
                {
                    if (CheckNorthEast(matrix, row, col, second, third, null) == 1)
                    {
                        var result = 0;
                        if (row >= (lowestIndex + 2) && col >= (lowestIndex + 2)) // North West ↖ (-row -col)
                        {
                            result += CheckNorthWest(matrix, row, col, second, third, null);
                        }
                        else if (row <= (highestIndex - 2) && col <= (highestIndex - 2)) // South East ↘ (+col +col)
                        {
                            result += CheckSouthEast(matrix, row, col, second, third, null);
                        }
                        sum += result;
                    }
                }

                // South East ↘ (+row +col)
                if (row <= (highestIndex - 2) && col <= (highestIndex - 2))
                {
                    if (CheckSouthEast(matrix, row, col, second, third, null) == 1)
                    {
                        var result = 0;
                        if (row <= (highestIndex - 2) && col >= (lowestIndex + 2)) // South West ↙ (+row -col)
                        {
                            result += CheckSouthWest(matrix, row, col, second, third, null);
                        }
                        else if (row >= (lowestIndex + 2) && col <= (highestIndex - 2)) // North East ↗ (-row +col)
                        {
                            result += CheckNorthEast(matrix, row, col, second, third, null);
                        }
                        sum += result;
                    }
                }

                // South West ↙ (+row -col)
                if (row <= (highestIndex - 2) && col >= (lowestIndex + 2))
                {
                    if (CheckSouthWest(matrix, row, col, second, third, null) == 1)
                    {
                        var result = 0;
                        if (row >= (lowestIndex + 2) && col >= (lowestIndex + 2)) // North West ↖ (-row -col)
                        {
                            result += CheckNorthWest(matrix, row, col, second, third, null);
                        }
                        else if (row <= (highestIndex - 2) && col <= (highestIndex - 2)) // South East ↘ (+row +col)
                        {
                            result += CheckSouthEast(matrix, row, col, second, third, null);
                        }
                        sum += result;
                    }
                }

                // North West ↖ (-row -col)
                if (row >= (lowestIndex + 2) && col >= (lowestIndex + 2))
                {
                    if (CheckNorthWest(matrix, row, col, second, third, null) == 1)
                    {
                        var result = 0;
                        if (row >= (lowestIndex + 2) && col <= (highestIndex - 2)) // North East ↗ (-row +col)
                        {
                            result += CheckNorthEast(matrix, row, col, second, third, null);
                        }
                        else if (row <= (highestIndex - 2) && col >= (lowestIndex + 2)) // South West ↙ (+row -col)
                        {
                            result += CheckSouthWest(matrix, row, col, second, third, null);
                        }
                        sum += result;
                    }
                }
            }
            //if (row <= (lowestIndex + 1) && col >= (highestIndex - 1)) // row cant be 1 or less, col cant be 8 or more
            //{
            //    // North East ↗ (-row +col)
            //    if (CheckNorthEast(matrix, row, col, second, third, null) == 1)
            //    {
            //        if (row <= (lowestIndex + 1) && col <= (lowestIndex + 1))
            //        {
            //            // North West ↖ || South East ↘
            //            if (CheckNorthWestAndSothEast(matrix, row, col, second, third))
            //                sum++;
            //        }
            //    }
            //}

        }
        Console.WriteLine("Part two: " + sum);

        //private bool CheckNorthWestAndSothEast(string[,] matrix, int row, int col, string second, string third)
        //{
        //    return CheckNorthWest(matrix, row, col + 2, second, third, null) == 1 ||
        //        CheckSouthEast(matrix, row - 2, col, second, third, null) == 1;
        //}

        //private bool CheckSouthWestAndNorthEast(string[,] matrix, int row, int col, string second, string third)
        //{
        //    if (col == 9)
        //    {

        //    }
        //    return CheckSouthWest(matrix, row, col + 2, second, third, null) == 1 ||
        //        CheckNorthEast(matrix, row + 2, col, second, third, null) == 1;
        //}
    }

    private void PartTwoasd()
    {
        var reports = File.ReadAllLines(_path)
            .Select(x =>
                x.ToCharArray().ToList())
            .ToList();

        var matrix = ConvertToMatrix(reports);
        var lowestIndex = 0;
        var highestIndex = matrix.GetLength(0) - 1;

        var first = "M";
        var second = "A";
        var third = "S";

        var sum = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col].Equals(first, StringComparison.CurrentCultureIgnoreCase) is false)
                    continue;

                var rowNotToLow = (row - 2) >= lowestIndex;
                var colNotToLow = (col - 2) >= lowestIndex;
                var rowNotToHigh = (row + 2) <= highestIndex;
                var colNotToHigh = (col + 2) <= highestIndex;

                // index IN bounds if below is true !!!!!!!!!!!
                // - ROW:           row >= (lowestIndex + 2) &&             if 2 or more
                // - COL:           col >= (lowestIndex + 2) &&             if 2 or more              
                // + ROW:           row <= (highestIndex - 2) &&            if 7 or less
                // + COL:           col <= (highestIndex - 2) &&            if 7 or less

                // North East ↗ (-row +col)
                if (row >= (lowestIndex + 2) && col <= (highestIndex - 2))
                {
                    if (CheckNorthEast(matrix, row, col, second, third, null) == 1)
                    {
                        var result = 0;
                        if (row >= (lowestIndex + 2) && (col + 2) >= (lowestIndex + 2)) // North West ↖ (-row -col)
                        {
                            result += CheckNorthWest(matrix, row, col + 2, second, third, null);
                        }
                        if ((row - 2) <= (highestIndex - 2) && col <= (highestIndex - 2)) // South East ↘ (+row +col)
                        {
                            result += CheckSouthEast(matrix, row - 2, col, second, third, null);
                        }
                        sum += result;
                    }
                }

                // South East ↘ (+row +col)
                if (row <= (highestIndex - 2) && col <= (highestIndex - 2))
                {
                    if (CheckSouthEast(matrix, row, col, second, third, null) == 1)
                    {
                        var result = 0;
                        if (row <= (highestIndex - 2) && (col + 2) >= (lowestIndex + 2)) // South West ↙ (+row -col) // FIXAT
                        {
                            result += CheckSouthWest(matrix, row, col + 2, second, third, null);
                        }
                        if ((row + 2) >= (lowestIndex + 2) && col <= (highestIndex - 2)) // North East ↗ (-row +col) // FIXAT
                        {
                            result += CheckNorthEast(matrix, row + 2, col, second, third, null);
                        }
                        sum += result;
                    }
                }

                // South West ↙ (+row -col)
                if (row <= (highestIndex - 2) && col >= (lowestIndex + 2))
                {
                    if (CheckSouthWest(matrix, row, col, second, third, null) == 1)
                    {
                        var result = 0;
                        if ((row + 2) >= (lowestIndex + 2) && col >= (lowestIndex + 2)) // North West ↖ (-row -col)
                        {
                            result += CheckNorthWest(matrix, row + 2, col, second, third, null);
                        }
                        else if (row <= (highestIndex - 2) && (col - 2) <= (highestIndex - 2)) // South East ↘ (+row +col)
                        {
                            result += CheckSouthEast(matrix, row, col - 2, second, third, null);
                        }
                        sum += result;
                    }
                }

                // North West ↖ (-row -col)
                if (row >= (lowestIndex + 2) && col >= (lowestIndex + 2))
                {
                    if (CheckNorthWest(matrix, row, col, second, third, null) == 1)
                    {
                        var result = 0;
                        if ((row - 2) >= (lowestIndex + 2) && col <= (highestIndex - 2)) // North East ↗ (-row +col)
                        {
                            result += CheckNorthEast(matrix, row- 2, col, second, third, null);
                        }
                        else if (row <= (highestIndex - 2) && (col - 2) >= (lowestIndex + 2)) // South West ↙ (+row -col)
                        {
                            result += CheckSouthWest(matrix, row, col - 2, second, third, null);
                        }
                        sum += result;
                    }
                }
            }
        }
        Console.WriteLine("Part two: " + sum);
    }
}
