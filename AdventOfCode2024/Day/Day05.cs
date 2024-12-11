using System.Data;

namespace AdventOfCode2024.Day;

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
            var pages = update.Split(',');
            var middleNumber = int.Parse(pages[pages.Length / 2]);
            sum += middleNumber;
        }

        Console.WriteLine("Part one: " + sum);
    }

    private void PartTwo()
    {
        var input = File.ReadAllLines(_path);

        var rules = input.TakeWhile(x => x != "").Select(x => x.Split('|').ToList()).ToList();
        var updates = input.TakeLast(input.Length - rules.Count - 1).ToList();

        var sum = 0;
        for (int i = 0; i < updates.Count; i++)
        {
            var isViolatingRule = CheckIfUpdatesViolatesRules(updates[i], rules);

            if (isViolatingRule)
                sum += GetRightlyOrderedMiddlePageNumber(updates[i], rules);
        }

        Console.WriteLine("Part twooooo: " + sum);
    }

    private static int GetRightlyOrderedMiddlePageNumber(string update, List<List<string>> rules)
    {
        var pagesInUpdate = update.Split(',').ToList();

        var result = 0;
        for (int i = 0; i < pagesInUpdate.Count; i++)
        {
            var pageInUpdate = pagesInUpdate[i];
            var pagesBefore = pagesInUpdate[..i];
            if (pagesBefore.Count == 0)
                continue;

            var pagesAfter = pagesInUpdate[(i + 1)..];
            var ruleForPage = rules.Where(x => x.First().Contains(pageInUpdate)).Select(x => x.Last()).ToList();

            if (!ruleForPage.Any(pagesBefore.Contains))
                continue;

            pagesInUpdate = MakeNewUpdateRow(ruleForPage, pagesBefore, pageInUpdate, pagesAfter);
            i = -1;
        }
        var middlePage = int.Parse(pagesInUpdate[pagesInUpdate.Count / 2]);
        result += middlePage;

        return result;
    }

    private static List<string> MakeNewUpdateRow(List<string> ruleForPage, List<string> pagesBefore, string pageInUpdate, List<string> pagesAfter)
    {
        var updatesInNewOrder = new List<string>();
        var pagesToAddAfter = new List<string>();
        var violatedRules = ruleForPage.Where(pagesBefore.Contains).ToList();
        updatesInNewOrder = pagesBefore;
        foreach (var rule in violatedRules)
        {
            updatesInNewOrder.Remove(rule);
            pagesToAddAfter.Add(rule);
        }
        updatesInNewOrder.Add(pageInUpdate);
        updatesInNewOrder.AddRange(pagesToAddAfter);
        updatesInNewOrder.AddRange(pagesAfter);
        return updatesInNewOrder;
    }

    private static bool CheckIfUpdatesViolatesRules(string update, List<List<string>> rules)
    {
        var pagesInUpdate = update.Split(',').ToList();

        for (int i = 0; i < pagesInUpdate.Count; i++)
        {
            var pageInUpdate = pagesInUpdate[i];
            var pagesBefore = pagesInUpdate[..i];
            if (pagesBefore.Count == 0)
                continue;

            var pagesAfter = pagesInUpdate[(i + 1)..];
            var ruleForPage = rules.Where(x => x.First().Contains(pageInUpdate)).Select(x => x.Last()).ToList();

            if (ruleForPage.Any(pagesBefore.Contains))
                return true;
        }
        return false;
    }
}
