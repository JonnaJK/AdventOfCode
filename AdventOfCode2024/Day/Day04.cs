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
        PartTwo1();
        PartTwo2();
        PartTwo3();
        PartTwo4();
        PartTwo5();
        PartTwo6();
        PartTwo7();
        PartTwo8();
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

    private int CheckNorth(string[,] matrix, int row, int col)
    {
        if (matrix[row - 1, col].Equals(_m, StringComparison.CurrentCultureIgnoreCase))
            if (matrix[row - 2, col].Equals(_a, StringComparison.CurrentCultureIgnoreCase))
                if (matrix[row - 3, col].Equals(_s, StringComparison.CurrentCultureIgnoreCase))
                    return 1;
        return 0;
    }

    // North East ↗ (-row +col)
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

    // South East ↘ (+row +col)
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

    // South West ↙ (+row -col)
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

    // North West ↖ (-row -col)
    private int CheckNorthWest(string[,] matrix, int row, int col, string second, string third, string? fourth)
    {
        if (matrix[row - 1, col - 1].Equals(second, StringComparison.CurrentCultureIgnoreCase))
        {
            if (matrix[row - 2, col - 2].Equals(third, StringComparison.CurrentCultureIgnoreCase))
            {
                if (string.IsNullOrEmpty(fourth))
                    return 1;

                if (matrix[row - 3, col - 3].Equals(fourth, StringComparison.CurrentCultureIgnoreCase))
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

    private void PartTwo1()
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

        }
        Console.WriteLine("Part two version 1: " + sum);

    }
    private bool CheckNorthWestAndSothEast(string[,] matrix, int row, int col, string second, string third)
    {
        return CheckNorthWest(matrix, row, col + 2, second, third, null) == 1 ||
            CheckSouthEast(matrix, row - 2, col, second, third, null) == 1;
    }

    private bool CheckSouthWestAndNorthEast(string[,] matrix, int row, int col, string second, string third)
    {
        if (col == 9)
        {

        }
        return CheckSouthWest(matrix, row, col + 2, second, third, null) == 1 ||
            CheckNorthEast(matrix, row + 2, col, second, third, null) == 1;
    }

    private void PartTwo2()
    {
        var reports = File.ReadAllLines(_path)
            .Select(x =>
                x.ToCharArray().ToList())
            .ToList();

        var matrix = ConvertToMatrix(reports);
        var lowestIndex = 0;
        var highestIndex = matrix.GetLength(0) - 1;

        var letterM = "M";
        var letterA = "A";
        var letterS = "S";

        var sum = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col].Equals(letterM, StringComparison.CurrentCultureIgnoreCase) is false)
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

                // North East ↗ (-row + col)
                if (row >= (lowestIndex + 2) && col <= (highestIndex - 2))
                {
                    if (CheckNorthEast(matrix, row, col, letterA, letterS, null) == 1)
                    {
                        var valueM = matrix[row, col];
                        var valueA = matrix[row - 1, col + 1];
                        var valueS = matrix[row - 2, col + 2];
                        var valueMorS = matrix[row, col + 2];
                        var valueSorM = matrix[row - 2, col];

                        if (valueM == letterM && valueA == letterA && valueS == letterS
                            && (valueMorS == letterM && valueSorM == letterS || valueMorS == letterS && valueSorM == letterM))
                            sum++;
                    }
                }

                // South East ↘ (+row + col)
                if (row <= (highestIndex - 2) && col <= (highestIndex - 2))
                {
                    if (CheckSouthEast(matrix, row, col, letterA, letterS, null) == 1)
                    {
                        var valueM = matrix[row, col];
                        var valueA = matrix[row + 1, col + 1];
                        var valueS = matrix[row + 2, col + 2];
                        var valueMorS = matrix[row, col + 2];
                        var valueSorM = matrix[row + 2, col];

                        if (valueM == letterM && valueA == letterA && valueS == letterS
                            && (valueMorS == letterM && valueSorM == letterS || valueMorS == letterS && valueSorM == letterM))
                            sum++;
                    }
                }

                // South West ↙ (+row - col)
                if (row <= (highestIndex - 2) && col >= (lowestIndex + 2))
                {
                    if (CheckSouthWest(matrix, row, col, letterA, letterS, null) == 1)
                    {
                        var valueM = matrix[row, col];
                        var valueA = matrix[row + 1, col - 1];
                        var valueS = matrix[row + 2, col - 2];
                        var valueMorS = matrix[row, col - 2];
                        var valueSorM = matrix[row + 2, col];

                        if (valueM == letterM && valueA == letterA && valueS == letterS
                            && (valueMorS == letterM && valueSorM == letterS || valueMorS == letterS && valueSorM == letterM))
                            sum++;
                    }
                }

                // North West ↖ (-row -col)
                if (row >= (lowestIndex + 2) && col >= (lowestIndex + 2))
                {
                    if (CheckNorthWest(matrix, row, col, letterA, letterS, null) == 1)
                    {
                        var valueM = matrix[row, col];
                        var valueA = matrix[row - 1, col - 1];
                        var valueS = matrix[row - 2, col - 2];
                        var valueMorS = matrix[row, col - 2];
                        var valueSorM = matrix[row - 2, col];

                        if (valueM == letterM && valueA == letterA && valueS == letterS
                            && (valueMorS == letterM && valueSorM == letterS || valueMorS == letterS && valueSorM == letterM))
                            sum++;
                    }
                }
            }
        }
        Console.WriteLine("Part two version 2: " + sum);
    }

    private void PartTwo3()
    {
        var reports = File.ReadAllLines(_path)
            .Select(x =>
                x.ToCharArray().ToList())
            .ToList();

        var matrix = ConvertToMatrix(reports);
        var lowestIndex = 0;
        var highestIndex = matrix.GetLength(0) - 1;

        var letterM = "M";
        var letterA = "A";
        var letterS = "S";

        var sum = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col].Equals(letterA, StringComparison.CurrentCultureIgnoreCase) is false)
                    continue;

                // index IN bounds if below is true !!!!!!!!!!!
                // - ROW:           row >= (lowestIndex + 2) &&             if 2 or more
                // - COL:           col >= (lowestIndex + 2) &&             if 2 or more              
                // + ROW:           row <= (highestIndex - 2) &&            if 7 or less
                // + COL:           col <= (highestIndex - 2) &&            if 7 or less


                // North East ↗ (-row + col)
                if (row >= (lowestIndex + 2) && col <= (highestIndex - 2))
                {
                    if (CheckNorthEast(matrix, row, col, letterA, letterS, null) == 1)
                    {
                        var firstTileToCheck = matrix[row - 2, col];
                        var secondTileToCheck = matrix[row, col + 2];
                        if (firstTileToCheck.Equals(letterM, StringComparison.CurrentCultureIgnoreCase) is true)
                        {
                            if (secondTileToCheck.Equals(letterS, StringComparison.CurrentCultureIgnoreCase) is true)
                                sum += 1;
                        }
                        else if (firstTileToCheck.Equals(letterS, StringComparison.CurrentCultureIgnoreCase) is true)
                        {
                            if (secondTileToCheck.Equals(letterM, StringComparison.CurrentCultureIgnoreCase) is true)
                                sum += 1;
                        }
                    }
                }

                // South East ↘ (+row + col)
                if (row <= (highestIndex - 2) && col <= (highestIndex - 2))
                {
                    if (CheckSouthEast(matrix, row, col, letterA, letterS, null) == 1)
                    {
                        var firstTileToCheck = matrix[row + 2, col];
                        var secondTileToCheck = matrix[row, col + 2];
                        if (firstTileToCheck.Equals(letterM, StringComparison.CurrentCultureIgnoreCase) is true)
                        {
                            if (secondTileToCheck.Equals(letterS, StringComparison.CurrentCultureIgnoreCase) is true)
                                sum += 1;
                        }
                        else if (firstTileToCheck.Equals(letterS, StringComparison.CurrentCultureIgnoreCase) is true)
                        {
                            if (secondTileToCheck.Equals(letterM, StringComparison.CurrentCultureIgnoreCase) is true)
                                sum += 1;
                        }
                    }
                }

                // South West ↙ (+row - col)
                if (row <= (highestIndex - 2) && col >= (lowestIndex + 2))
                {
                    if (CheckSouthWest(matrix, row, col, letterA, letterS, null) == 1)
                    {
                        var firstTileToCheck = matrix[row + 2, col];
                        var secondTileToCheck = matrix[row, col - 2];
                        if (firstTileToCheck.Equals(letterM, StringComparison.CurrentCultureIgnoreCase) is true)
                        {
                            if (secondTileToCheck.Equals(letterS, StringComparison.CurrentCultureIgnoreCase) is true)
                                sum += 1;
                        }
                        else if (firstTileToCheck.Equals(letterS, StringComparison.CurrentCultureIgnoreCase) is true)
                        {
                            if (secondTileToCheck.Equals(letterM, StringComparison.CurrentCultureIgnoreCase) is true)
                                sum += 1;
                        }
                    }
                }

                // North West ↖ (-row -col)
                if (row >= (lowestIndex + 2) && col >= (lowestIndex + 2))
                {
                    if (CheckNorthWest(matrix, row, col, letterA, letterS, null) == 1)
                    {
                        var asd = matrix[row, col];
                        var theother1 = matrix[row, col];
                        var theother2 = matrix[row, col];

                        var firstTileToCheck = matrix[row - 2, col];
                        var secondTileToCheck = matrix[row, col - 2];
                        if (firstTileToCheck.Equals(letterM, StringComparison.CurrentCultureIgnoreCase) is true)
                        {
                            if (secondTileToCheck.Equals(letterS, StringComparison.CurrentCultureIgnoreCase) is true)
                                sum += 1;
                        }
                        else if (firstTileToCheck.Equals(letterS, StringComparison.CurrentCultureIgnoreCase) is true)
                        {
                            if (secondTileToCheck.Equals(letterM, StringComparison.CurrentCultureIgnoreCase) is true)
                                sum += 1;
                        }
                    }
                }
            }
        }
        Console.WriteLine("Part two 3 version 3: " + sum);
    }

    private void PartTwo4()
    {
        var reports = File.ReadAllLines(_path)
            .Select(x =>
                x.ToCharArray().ToList())
            .ToList();

        var matrix = ConvertToMatrix(reports);
        var lowestIndex = 0;
        var highestIndex = matrix.GetLength(0) - 1;

        var letterM = "M";
        var letterA = "A";
        var letterS = "S";

        var sum = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col].Equals(letterA, StringComparison.CurrentCultureIgnoreCase) is false)
                    continue;

                // index IN bounds if below is true !!!!!!!!!!!
                // - ROW:           row >= (lowestIndex + 2) &&             if 2 or more
                // - COL:           col >= (lowestIndex + 2) &&             if 2 or more              
                // + ROW:           row <= (highestIndex - 2) &&            if 7 or less
                // + COL:           col <= (highestIndex - 2) &&            if 7 or less

                if ((row - 1) < 0 || (row + 1) > highestIndex ||
                    (col - 1) < 0 || (col + 1) > highestIndex)
                    continue;

                var upperLeft = matrix[row - 1, col - 1];
                var upperRight = matrix[row - 1, col + 1];
                var lowerRight = matrix[row + 1, col + 1];
                var lowerLeft = matrix[row + 1, col - 1];

                var asd = new List<string>()
                {
                    upperLeft, upperRight, lowerLeft, lowerRight
                };

                if (asd.Where(x => x.Equals(letterM)).Count() == 2 &&
                    asd.Where(x => x.Equals(letterS)).Count() == 2)
                    sum++;

                if (upperLeft == letterM && lowerRight == letterS)
                {
                    if (upperRight == letterM)
                    {
                        if (lowerLeft == letterS)
                            sum++;
                    }
                    else if (upperRight == letterS)
                    {
                        if (lowerLeft == letterM)
                            sum++;
                    }
                }
            }
        }
        Console.WriteLine("Part two version 4: " + sum);
    }

    private void PartTwo5()
    {
        var reports = File.ReadAllLines(_path)
            .Select(x =>
                x.ToCharArray().ToList())
            .ToList();

        var matrix = ConvertToMatrix(reports);
        var lowestIndex = 0;
        var highestIndex = matrix.GetLength(0) - 1;

        var letterM = "M";
        var letterA = "A";
        var letterS = "S";

        var sum = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col].Equals(letterM, StringComparison.CurrentCultureIgnoreCase) is false)
                    continue;

                //var rowNotToLow = (row - 2) >= lowestIndex;
                //var colNotToLow = (col - 2) >= lowestIndex;
                //var rowNotToHigh = (row + 2) <= highestIndex;
                //var colNotToHigh = (col + 2) <= highestIndex;

                // index IN bounds if below is true !!!!!!!!!!!
                // - ROW:           row >= (lowestIndex + 2) &&             if 2 or more
                // - COL:           col >= (lowestIndex + 2) &&             if 2 or more              
                // + ROW:           row <= (highestIndex - 2) &&            if 7 or less
                // + COL:           col <= (highestIndex - 2) &&            if 7 or less

                // North East ↗ (-row +col)
                if (row >= (lowestIndex + 2) && col <= (highestIndex - 2))
                {
                    if (CheckNorthEast(matrix, row, col, letterA, letterS, null) == 1)
                    {
                        var result = 0;
                        if (row >= (lowestIndex + 2) && (col + 2) >= (lowestIndex + 2)) // North West ↖ (-row -col)
                        {
                            result += CheckNorthWest(matrix, row, col + 2, letterA, letterS, null);
                        }
                        if ((row - 2) <= (highestIndex - 2) && col <= (highestIndex - 2)) // South East ↘ (+row +col)
                        {
                            result += CheckSouthEast(matrix, row - 2, col, letterA, letterS, null);
                        }
                        sum += result;
                    }
                }

                // South East ↘ (+row +col)
                if (row <= (highestIndex - 2) && col <= (highestIndex - 2))
                {
                    if (CheckSouthEast(matrix, row, col, letterA, letterS, null) == 1)
                    {
                        var result = 0;
                        if (row <= (highestIndex - 2) && (col + 2) >= (lowestIndex + 2)) // South West ↙ (+row -col) // FIXAT
                        {
                            result += CheckSouthWest(matrix, row, col + 2, letterA, letterS, null);
                        }
                        if ((row + 2) >= (lowestIndex + 2) && col <= (highestIndex - 2)) // North East ↗ (-row +col) // FIXAT
                        {
                            result += CheckNorthEast(matrix, row + 2, col, letterA, letterS, null);
                        }
                        sum += result;
                    }
                }

                // South West ↙ (+row -col)
                if (row <= (highestIndex - 2) && col >= (lowestIndex + 2))
                {
                    if (CheckSouthWest(matrix, row, col, letterA, letterS, null) == 1)
                    {
                        var result = 0;
                        if ((row + 2) >= (lowestIndex + 2) && col >= (lowestIndex + 2)) // North West ↖ (-row -col)
                        {
                            result += CheckNorthWest(matrix, row + 2, col, letterA, letterS, null);
                        }
                        else if (row <= (highestIndex - 2) && (col - 2) <= (highestIndex - 2)) // South East ↘ (+row +col)
                        {
                            result += CheckSouthEast(matrix, row, col - 2, letterA, letterS, null);
                        }
                        sum += result;
                    }
                }

                // North West ↖ (-row -col)
                if (row >= (lowestIndex + 2) && col >= (lowestIndex + 2))
                {
                    if (CheckNorthWest(matrix, row, col, letterA, letterS, null) == 1)
                    {
                        var result = 0;
                        if ((row - 2) >= (lowestIndex + 2) && col <= (highestIndex - 2)) // North East ↗ (-row +col)
                        {
                            result += CheckNorthEast(matrix, row - 2, col, letterA, letterS, null);
                        }
                        else if (row <= (highestIndex - 2) && (col - 2) >= (lowestIndex + 2)) // South West ↙ (+row -col)
                        {
                            result += CheckSouthWest(matrix, row, col - 2, letterA, letterS, null);
                        }
                        sum += result;
                    }
                }
            }
        }
        Console.WriteLine("Part two version 5: " + sum);
    }

    private void PartTwo6()
    {
        var reports = File.ReadAllLines(_path)
            .Select(x =>
                x.ToCharArray().ToList())
            .ToList();

        var matrix = ConvertToMatrix(reports);
        var lowestIndex = 0;
        var highestIndex = matrix.GetLength(0) - 1;

        var letterM = "M";
        var letterA = "A";
        var letterS = "S";

        var sum = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col].Equals(letterM, StringComparison.CurrentCultureIgnoreCase) is false)
                    continue;

                //var rowNotToLow = (row - 2) >= lowestIndex;
                //var colNotToLow = (col - 2) >= lowestIndex;
                //var rowNotToHigh = (row + 2) <= highestIndex;
                //var colNotToHigh = (col + 2) <= highestIndex;

                // index IN bounds if below is true !!!!!!!!!!!
                // - ROW:           row >= (lowestIndex + 2) &&             if 2 or more
                // - COL:           col >= (lowestIndex + 2) &&             if 2 or more              
                // + ROW:           row <= (highestIndex - 2) &&            if 7 or less
                // + COL:           col <= (highestIndex - 2) &&            if 7 or less
                var rowNotToLow = (row - 2) >= lowestIndex;
                var colNotToLow = (col - 2) >= lowestIndex;
                var rowNotToHigh = (row + 2) <= highestIndex;
                var colNotToHigh = (col + 2) <= highestIndex;

                // North East ↗
                if (rowNotToLow && colNotToHigh)
                {
                    if (CheckNorthEast(matrix, row, col, letterA, letterS, null) == 1)
                    {
                        // South East ↘
                        if (rowNotToHigh && colNotToHigh)
                            sum += CheckSouthEast(matrix, row, col, letterA, letterS, null);
                        // North West ↖
                        else if (rowNotToLow && colNotToLow)
                            sum += CheckNorthWest(matrix, row, col, letterA, letterS, null);
                    }
                }

                // South East ↘
                if (rowNotToHigh && colNotToHigh)
                {
                    if (CheckSouthEast(matrix, row, col, letterA, letterS, null) == 1)
                    {
                        // North East ↗
                        if (rowNotToLow && colNotToHigh)
                            sum += CheckNorthEast(matrix, row, col, letterA, letterS, null);
                        // South West ↙
                        else if (rowNotToHigh && colNotToLow)
                            sum += CheckSouthWest(matrix, row, col, letterA, letterS, null);
                    }
                }

                // South West ↙
                if (rowNotToHigh && colNotToLow)
                {
                    if (CheckSouthWest(matrix, row, col, letterA, letterS, null) == 1)
                    {
                        // South East ↘
                        if (rowNotToHigh && colNotToHigh)
                            sum += CheckSouthEast(matrix, row, col, letterA, letterS, null);
                        // North West ↖
                        else if (rowNotToLow && colNotToLow)
                            sum += CheckNorthWest(matrix, row, col, letterA, letterS, null);
                    }
                }

                // North West ↖
                if (rowNotToLow && colNotToLow)
                {
                    if (CheckNorthWest(matrix, row, col, letterA, letterS, null) == 1)
                    {
                        // North East ↗
                        if (rowNotToLow && colNotToHigh)
                            sum += CheckNorthEast(matrix, row, col, letterA, letterS, null);
                        // South West ↙
                        else if (rowNotToHigh && colNotToLow)
                            sum += CheckSouthWest(matrix, row, col, letterA, letterS, null);
                    }
                }
            }
        }
        Console.WriteLine("Part two version 6: " + sum);
    }

    private void PartTwo7()
    {
        var reports = File.ReadAllLines(_path)
            .Select(x =>
                x.ToCharArray().ToList())
            .ToList();

        var matrix = ConvertToMatrix(reports);
        var lowestIndex = 0;
        var highestIndex = matrix.GetLength(0) - 1;

        var letterM = "M";
        var letterA = "A";
        var letterS = "S";

        var sum = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col].Equals(letterM, StringComparison.CurrentCultureIgnoreCase) is false)
                    continue;

                // index IN bounds if below is true !!!!!!!!!!!
                // - ROW:           row >= (lowestIndex + 2) &&             if 2 or more
                // - COL:           col >= (lowestIndex + 2) &&             if 2 or more              
                // + ROW:           row <= (highestIndex - 2) &&            if 7 or less
                // + COL:           col <= (highestIndex - 2) &&            if 7 or less
                var rowNotToLow = (row - 2) >= lowestIndex;
                var colNotToLow = (col - 2) >= lowestIndex;
                var rowNotToHigh = (row + 2) <= highestIndex;
                var colNotToHigh = (col + 2) <= highestIndex;



                // North East ↗
                if (rowNotToLow && colNotToHigh)
                {
                    if (CheckNorthEast(matrix, row, col, letterA, letterS, null) == 1)
                    {
                        var firstTile = matrix[row - 2, col];
                        var secondTile = matrix[row, col + 2];

                        // South East ↘
                        if (firstTile.Equals(letterM, StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (secondTile.Equals(letterS, StringComparison.CurrentCultureIgnoreCase))
                                sum++;
                        }
                        // North West ↖
                        else if (secondTile.Equals(letterM, StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (firstTile.Equals(letterS, StringComparison.CurrentCultureIgnoreCase))
                                sum++;
                        }
                    }
                }

                // South East ↘
                if (rowNotToHigh && colNotToHigh)
                {
                    if (CheckSouthEast(matrix, row, col, letterA, letterS, null) == 1)
                    {
                        var firstTile = matrix[row, col + 2];
                        var secondTile = matrix[row + 2, col];

                        // South West ↙
                        if (firstTile.Equals(letterM, StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (secondTile.Equals(letterS, StringComparison.CurrentCultureIgnoreCase))
                                sum++;
                        }
                        // North East ↗
                        else if (secondTile.Equals(letterM, StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (firstTile.Equals(letterS, StringComparison.CurrentCultureIgnoreCase))
                                sum++;
                        }
                    }
                }

                // South West ↙
                if (rowNotToHigh && colNotToLow)
                {
                    if (CheckSouthWest(matrix, row, col, letterA, letterS, null) == 1)
                    {
                        var firstTile = matrix[row, col - 2];
                        var secondTile = matrix[row + 2, col];

                        // South East ↘
                        if (firstTile.Equals(letterM, StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (secondTile.Equals(letterS, StringComparison.CurrentCultureIgnoreCase))
                                sum++;
                        }
                        // North West ↖
                        else if (secondTile.Equals(letterM, StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (firstTile.Equals(letterS, StringComparison.CurrentCultureIgnoreCase))
                                sum++;
                        }
                    }
                }

                // North West ↖
                if (rowNotToLow && colNotToLow)
                {
                    if (CheckNorthWest(matrix, row, col, letterA, letterS, null) == 1)
                    {
                        var firstTile = matrix[row - 2, col];
                        var secondTile = matrix[row, col - 2];

                        // South East ↘
                        if (firstTile.Equals(letterM, StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (secondTile.Equals(letterS, StringComparison.CurrentCultureIgnoreCase))
                                sum++;
                        }
                        // North West ↖
                        else if (secondTile.Equals(letterM, StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (firstTile.Equals(letterS, StringComparison.CurrentCultureIgnoreCase))
                                sum++;
                        }
                    }
                }
            }
        }
        Console.WriteLine("Part two version 7: " + sum);
    }

    private void PartTwo8()
    {
        var reports = File.ReadAllLines(_path)
            .Select(x =>
                x.ToCharArray().ToList())
            .ToList();

        var matrix = ConvertToMatrix(reports);
        var lowestIndex = 0;
        var highestIndex = matrix.GetLength(0) - 1;

        var letterM = "M";
        var letterA = "A";
        var letterS = "S";

        var sum = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col].Equals(letterM, StringComparison.CurrentCultureIgnoreCase) is false)
                    continue;

                // index IN bounds if below is true !!!!!!!!!!!
                // - ROW:           row >= (lowestIndex + 2) &&             if 2 or more
                // - COL:           col >= (lowestIndex + 2) &&             if 2 or more              
                // + ROW:           row <= (highestIndex - 2) &&            if 7 or less
                // + COL:           col <= (highestIndex - 2) &&            if 7 or less
                var rowNotToLow = (row - 2) >= lowestIndex;
                var colNotToLow = (col - 2) >= lowestIndex;
                var rowNotToHigh = (row + 2) <= highestIndex;
                var colNotToHigh = (col + 2) <= highestIndex;

                if (rowNotToLow && colNotToHigh)
                {
                    // North East ↗
                    if (matrix[row, col].Equals(letterM, StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (matrix[row - 1, col + 1].Equals(letterA, StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (matrix[row - 2, col + 2].Equals(letterS, StringComparison.CurrentCultureIgnoreCase))
                            {
                                if (rowNotToLow && colNotToHigh)
                                {
                                    // South East ↘
                                    var firstTile = matrix[row - 2, col];
                                    var thirdTile = matrix[row, col + 2];
                                    if (firstTile == letterM)
                                    {
                                        if (thirdTile == letterS)
                                        {
                                            sum++;
                                        }
                                    }
                                }
                                // North West ↖
                                if (rowNotToLow && colNotToHigh)
                                {
                                    var firstTile = matrix[row, col + 2];
                                    var thirdTile = matrix[row - 2, col];
                                    if (firstTile == letterM)
                                    {
                                        if (thirdTile == letterS)
                                        {
                                            sum++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (rowNotToHigh && colNotToHigh)
                {
                    // South East ↘
                    if (matrix[row, col].Equals(letterM, StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (matrix[row + 1, col + 1].Equals(letterA, StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (matrix[row + 2, col + 2].Equals(letterS, StringComparison.CurrentCultureIgnoreCase))
                            {
                                if (rowNotToHigh && colNotToHigh)
                                {
                                    // North East ↗
                                    var firstTile = matrix[row + 2, col];
                                    var thirdTile = matrix[row, col + 2];
                                    if (firstTile == letterM)
                                    {
                                        if (thirdTile == letterS)
                                        {
                                            sum++;
                                        }
                                    }
                                }
                                if (rowNotToHigh && colNotToHigh)
                                {
                                    // South West ↙
                                    var firstTile = matrix[row, col + 2];
                                    var thirdTile = matrix[row + 2, col];
                                    if (firstTile == letterM)
                                    {
                                        if (thirdTile == letterS)
                                        {
                                            sum++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

                if (rowNotToHigh && colNotToLow)
                {
                    // South West ↙
                    if (matrix[row, col].Equals(letterM, StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (matrix[row + 1, col - 1].Equals(letterA, StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (matrix[row + 2, col - 2].Equals(letterS, StringComparison.CurrentCultureIgnoreCase))
                            {
                                if (rowNotToHigh && colNotToLow)
                                {
                                    // South East ↘
                                    var firstTile = matrix[row, col - 2];
                                    var thirdTile = matrix[row + 2, col];
                                    if (firstTile == letterM)
                                    {
                                        if (thirdTile == letterS)
                                        {
                                            sum++;
                                        }
                                    }
                                }
                                if (rowNotToHigh && colNotToLow)
                                {
                                    // North West ↖
                                    var firstTile = matrix[row + 2, col];
                                    var thirdTile = matrix[row, col - 2];
                                    if (firstTile == letterM)
                                    {
                                        if (thirdTile == letterS)
                                        {
                                            sum++;
                                        }
                                    }

                                }
                            }
                        }
                    }
                }

                if (rowNotToLow && colNotToLow)
                {
                    // North West ↖
                    if (matrix[row, col].Equals(letterM, StringComparison.CurrentCultureIgnoreCase))
                    {
                        if (matrix[row - 1, col - 1].Equals(letterA, StringComparison.CurrentCultureIgnoreCase))
                        {
                            if (matrix[row - 2, col - 2].Equals(letterS, StringComparison.CurrentCultureIgnoreCase))
                            {
                                if (rowNotToLow && colNotToLow)
                                {
                                    // North East ↗
                                    var firstTile = matrix[row, col - 2];
                                    var thirdTile = matrix[row - 2, col];
                                    if (firstTile == letterM)
                                    {
                                        if (thirdTile == letterS)
                                        {
                                            sum++;
                                        }
                                    }
                                }
                                if (rowNotToLow && colNotToLow)
                                {
                                    // South West ↙
                                    var firstTile = matrix[row - 2, col];
                                    var thirdTile = matrix[row, col - 2];
                                    if (firstTile == letterM)
                                    {
                                        if (thirdTile == letterS)
                                        {
                                            sum++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
        Console.WriteLine("Part two version 8: " + sum);
    }

    private void PartTwo9()
    {
        var reports = File.ReadAllLines(_path)
            .Select(x =>
                x.ToCharArray().ToList())
            .ToList();

        string[] asd = File.ReadAllLines(_path);

        var matrix = ConvertToMatrix(reports);
        var lowestIndex = 0;
        var highestIndex = matrix.GetLength(0) - 1;

        var letterM = "M";
        var letterA = "A";
        var letterS = "S";

        var sum = 0;
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] != letterA)
                    continue;

                // Check upper-left + lower-right diagonal combined with upper-right + lower-left diagonal
                var topLeftMAS = row > 0 && col > 0 && matrix[row - 1, col - 1] == "M" && matrix[row + 1, col + 1] == "S";

                var topLeftSAM = row > 0 && col > 0 && matrix[row - 1, col - 1] == "S" && matrix[row + 1, col + 1] == "M";

                var topRightMAS = row > 0 && col < highestIndex && matrix[row - 1, col + 1] == "M" && matrix[row + 1, col - 1] == "S";

                var topRightSAM = row > 0 && col < highestIndex && matrix[row - 1, col + 1] == "S" && matrix[row + 1, col - 1] == "M";


                //      var topRightSAM = i > 0 && j < cols - 1 && input[i - 1][j + 1] == 'S' && input[i + 1][j - 1] == 'M';
            }
        }
        Console.WriteLine("Part two version 9: " + sum);
    }

    private void PartTwo()
    {
        string[] reports = File.ReadAllLines(_path);

        var rows = reports.Length;
        var cols = reports[0].Length;
        var sum = 0;

        for (int i = 1; i < rows - 1; i++)
        {
            for (int j = 1; j < cols - 1; j++)
            {
                if (reports[i][j] != 'A')
                    continue;

                var asd = reports[i][j];
                // Check upper-left + lower-right diagonal combined with upper-right + lower-left diagonal
                var topLeftMAS = i > 0 && j > 0 && reports[i - 1][j - 1] == 'M' && reports[i + 1][j + 1] == 'S';
                var topLeftSAM = i > 0 && j > 0 && reports[i - 1][j - 1] == 'S' && reports[i + 1][j + 1] == 'M';
                var topRightMAS = i > 0 && j < cols - 1 && reports[i - 1][j + 1] == 'M' && reports[i + 1][j - 1] == 'S';
                var topRightSAM = i > 0 && j < cols - 1 && reports[i - 1][j + 1] == 'S' && reports[i + 1][j - 1] == 'M';

                if ((topLeftMAS || topLeftSAM) && (topRightMAS || topRightSAM))
                {
                    sum++;
                }
            }
        }
        Console.WriteLine("Part two version 10: " + sum);
    }
}
