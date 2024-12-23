namespace AdventOfCode2024.Day;

public class Day06
{
    private readonly string _path;
    public Day06(string path)
    {
        _path = Path.Combine(path, $"Input{GetType().Name}.txt");
        PartOne();
        PartTwo();
    }

    private static (int x, int y) GetDirection(char input) => input switch
    {
        '^' => (0, -1),
        'v' => (0, 1),
        '<' => (-1, 0),
        '>' => (1, 0),
        _ => throw new NotImplementedException()
    };

    private void PartOne()
    {
        var input = File.ReadAllLines(_path);
        var map = ConvertToMatrix(input);

        var direction = '^';
        if (input.Any(x => x.Contains('^')))
            direction = '^';
        else if (input.Any(x => x.Contains('v')))
            direction = 'v';
        else if (input.Any(x => x.Contains('<')))
            direction = '<';
        else if (input.Any(x => x.Contains('>')))
            direction = '>';

        (int x, int y) guardCordinates =
        (
            input.ToList().FindIndex(x => x.Contains(direction)),
            Array.IndexOf(input.First(x => x.Contains(direction)).ToCharArray(), direction)
        );


        // Continue while the guard is in map
        //while (input.Any(x => x.Contains('^')) ||
        //    input.Any(x => x.Contains('v')) ||
        //    input.Any(x => x.Contains('<')) ||
        //    input.Any(x => x.Contains('>')))
        //{
        var guardIsInMap = true;
        while (guardIsInMap)
        {
            for (int i = guardCordinates.y; i < map.Length; i++)
            {
                if (guardIsInMap is false)
                    break;

                for (int j = guardCordinates.x; j < map.Length; j++)
                {
                    if (guardIsInMap is false)
                        break;

                    if (map[i, j] != direction.ToString())
                        continue;

                    switch (direction)
                    {
                        case '^':
                            if (i - 1 < 0)
                            {
                                guardIsInMap = false;
                                break;
                            }

                            var nextTile = map[i - 1, j];
                            if (nextTile == "." || nextTile == "X")
                            {
                                guardCordinates = (i - 1, j);
                                map[i - 1, j] = "^";
                                map[i, j] = "X";
                            }
                            else if (nextTile == "#")
                            {
                                direction = '>';
                            }
                            //else if (nextTile == "X")
                            //{
                            //    guardCordinates = (i - 1, j);
                            //    map[i - 1, j] = "^";
                            //    map[i, j] = "X";
                            //}
                            break;
                        case 'v':
                            if (i + 1 > map.Length)
                                break;

                            var nextTile2 = map[i + 1, j];
                            if (nextTile2 == "." || nextTile2 == "X")
                            {
                                guardCordinates = (i + 1, j);
                                map[i + 1, j] = "v";
                                map[i, j] = "X";
                            }
                            else if (nextTile2 == "#")
                            {
                                direction = '<';
                            }
                            break;
                        case '<':
                            if (j - 1 < 0)
                                break;

                            var nextTile3 = map[i, j - 1];
                            if (nextTile3 == "." || nextTile3 == "X")
                            {
                                guardCordinates = (i, j - 1);
                                map[i, j - 1] = "<";
                                map[i, j] = "X";
                            }
                            else if (nextTile3 == "#")
                            {
                                direction = '^';
                            }
                            break;
                        case '>':
                            if (j + 1 > map.Length)
                                break;

                            var nextTile4 = map[i, j + 1];
                            if (nextTile4 == "." || nextTile4 == "X")
                            {
                                guardCordinates = (i, j + 1);
                                map[i, j + 1] = ">";
                                map[i, j] = "X";
                            }
                            else if (nextTile4 == "#")
                            {
                                direction = 'v';
                            }
                            break;
                        default:
                            break;
                    }

                }
            }
        }

        /*
         first find the guard, a char that is not '.' or '#'
        determine which way the guard is going (^ up, v down, < left, > right)
        check the next tile, (if out of bounds the guard has left the map
            if '#' turn right
            if '.' move the guard and convert the tile she left from an '.' to an 'X'
            if 'X' move the guard
            REPEAT until the next tile is out of bounds
        
         if guard has left the map
            count all X's
         */

        Console.WriteLine("Part one: " + "sum");
    }

    private static string[,] ConvertToMatrix(string[] reports)
    {
        var matrix = new string[reports.Length, reports[1].Length];

        for (int i = 0; i < reports.Length; i++)
        {
            for (int j = 0; j < reports[0].Length; j++)
            {
                matrix[i, j] = reports[i][j].ToString();
            }
        }
        return matrix;
    }

    private void PartTwo()
    {
        var input = File.ReadAllLines(_path);

        Console.WriteLine("Part two: " + "sum");
    }
}
