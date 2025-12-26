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

        var up = '^';
        var down = 'v';
        var left = '<';
        var right = '>';
        var startingDirection = up;

        if (input.Any(x => x.Contains(up)))
            startingDirection = up;
        else if (input.Any(x => x.Contains(down)))
            startingDirection = down;
        else if (input.Any(x => x.Contains(left)))
            startingDirection = left;
        else if (input.Any(x => x.Contains(right)))
            startingDirection = right;


        (int x, int y) guardCordinates =
        (
            input.ToList().FindIndex(x => x.Contains(startingDirection)),
            Array.IndexOf(input.First(x => x.Contains(startingDirection)).ToCharArray(), startingDirection)
        );

        while (input.Any(x => x.Contains(up)) ||
            input.Any(x => x.Contains(down)) ||
            input.Any(x => x.Contains(left)) ||
            input.Any(x => x.Contains(right)))
        {
            for (int i = 0; i < input.Length; i++)
            {

            }
        }
        Console.WriteLine("Part one: " + "sum");
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
