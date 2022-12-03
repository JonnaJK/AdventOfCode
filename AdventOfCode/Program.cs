using AdventOfCode.Day;

namespace AdventOfCode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = Path.Combine(Path.GetFullPath(@"..\..\..\"), "Inputs");
            //_ = new Day01(path);
            //_ = new Day02(path);
            _ = new Day03(path);

            Console.ReadLine();
        }
    }
}