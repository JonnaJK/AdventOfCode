﻿namespace AdventOfCode2024.Day;

public class Day05
{
    private readonly string _path;
    public Day05(string path)
    {
        _path = Path.Combine(path, $"Input{GetType().Name}.txt");
        PartOne();
        PartTwo();
    }

    private void PartOne()
    {
        var input = File.ReadAllLines(_path);

        var rules = input.TakeWhile(x => x != "").Select(x => x.Split('|').ToList()).ToList();
        var updates = input.TakeLast(input.Length - rules.Count - 1).ToList();

        var correctlyOrderedUpdates = new List<string>();
        foreach (var update in updates)
        {
            var pages = update.Split(',').ToList();
            for (int i = 0; i < pages.Count; i++)
            {
                var page = pages[i];
                var ruleForUpdate = rules.Where(x => x.First().Contains(page)).Select(x => x.Last()).ToList(); // eg 15

                var pagesBefore = pages[..pages.IndexOf(page)];

                if (ruleForUpdate.Any(pagesBefore.Contains))
                    break;

                if (i == pages.Count - 1)
                    correctlyOrderedUpdates.Add(update);
            }
        }

        var sum = 0;
        foreach (var update in correctlyOrderedUpdates)
        {
            var asd = update.Split(',');
            var asdasd = int.Parse(asd[asd.Length / 2]);
            sum += asdasd;
        }

        Console.WriteLine("Part one: " + sum);
    }

    private void PartTwo()
    {
        var input = File.ReadAllLines(_path);

        var rules = input.TakeWhile(x => x != "").Select(x => x.Split('|').ToList()).ToList();
        var updates = input.TakeLast(input.Length - rules.Count - 1).ToList();

        var incorrectlyOrderedUpdates = new List<string>();
        var correctlyOrderedUpdates = new List<string>();
        foreach (var update in updates)
        {
            var pages = update.Split(',').ToList();
            for (int i = 0; i < pages.Count; i++)
            {
                var page = pages[i]; // 75
                var ruleForPage = rules.Where(x => x.First().Contains(page)).Select(x => x.Last()).ToList();

                //var ruleForPage = rules.Where(x => x.First().Contains(page)).ToList();

                var pagesBefore = pages[..pages.IndexOf(page)];

                var isViolatingRule = ruleForPage.Any(pagesBefore.Contains);
                if (isViolatingRule)
                {
                    var indexOfViolations = ruleForPage.FindIndex(x => ruleForPage.Any(pagesBefore.Contains));
                        //.ToList()
                        //.Where(x => x != -1);
                    var asd = ruleForPage[pages.IndexOf(page)];
                }

                //if (ruleForPage.Any(pagesBefore.Contains))
                //{
                //    var correctlyOrdered = "";
                //    var incorrectlyOrderedUpdate = updates.Split(',');
                //    foreach (var update in incorrectlyOrderedUpdate)
                //    {

                //    }

                //    incorrectlyOrderedUpdates.Add(update);
                //    var correctlyOrderedUpdate = MakeCorrectlyOrdered(update, rules.Where(x => x.First().Contains(page)).ToList());
                //    correctlyOrderedUpdates.Add(correctlyOrderedUpdate);
                //    break;
                //}
            }
        }

        var sum = 0;
        foreach (var update in correctlyOrderedUpdates)
        {
            var asd = update.Split(',');
            var asdasd = int.Parse(asd[asd.Length / 2]);
            sum += asdasd;
        }

        Console.WriteLine("Part two: " + sum);
    }

    private static string MakeCorrectlyOrdered(string updates, List<string> ruleForUpdate)
    {
        var correctlyOrdered = "";
        var incorrectlyOrderedUpdate = updates.Split(',');
        foreach (var update in incorrectlyOrderedUpdate)
        {

        }
        return correctlyOrdered;
    }
}
