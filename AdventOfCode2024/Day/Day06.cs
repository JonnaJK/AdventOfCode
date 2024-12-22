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

    private void PartOne()
    {
        var input = File.ReadAllLines(_path);

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
        while (input.Any(x => x.Contains('^')) ||
            input.Any(x => x.Contains('v')) ||
            input.Any(x => x.Contains('<')) ||
            input.Any(x => x.Contains('>')))
        {
            for (int i = guardCordinates.x; i < input.Length; i++)
            {
                for (int j = guardCordinates.y; j < input[1].Length; j++)
                {
                    switch (direction)
                    {
                        case '^':
                            if (i - 1 < 0)
                                break;
                            var nextTile = input[i - 1][j];
                            if (nextTile == '.')
                            {
                                guardCordinates = (i - 1, j);
                                //input[i - 1][j] = 'X';
                            }
                            else if (nextTile == '#')
                            {

                            }
                            else if (nextTile == 'X')
                            {

                            }
                            break;
                        case 'v':
                            break;
                        case '<':
                            break;
                        case '>':
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

    private void PartTwo()
    {
        var input = File.ReadAllLines(_path);

        Console.WriteLine("Part two: " + "sum");
    }
}
