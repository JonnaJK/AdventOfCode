using System.Data;

namespace AdventOfCode2024.Day;

public class Day05
{
    private readonly string _path;
    public Day05(string path)
    {
        _path = Path.Combine(path, $"Input{GetType().Name}.txt");
        //PartOne();
        Test();
        //PartTwoTest1();
        //PartTwoTest2();
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

    private void Test()
    {
        var input = File.ReadAllLines(_path);

        var rules = input.TakeWhile(x => x != "").Select(x => x.Split('|').ToList()).ToList();
        var updates = input.TakeLast(input.Length - rules.Count - 1).ToList();

        // go row for row to check for violations
        var sum = 0;
        for (int i = 0; i < updates.Count; i++)
        {
            var isViolatingRule = CheckIfUpdatesViolatesRules(updates[i], rules);

            if (isViolatingRule)
                sum += GetRightlyOrderedMiddlePageNumber(updates[i], rules);
        }


        // if violation then send to method to make right
        // only exit when the row is correct
        // return the middle sum

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

            if (ruleForPage.Any(pagesBefore.Contains))
            {
                var updatesInNewOrder = new List<string>();
                var pagesToAddAfter = new List<string>();
                var violatedRules = ruleForPage.Where(pagesBefore.Contains).ToList();
                updatesInNewOrder = pagesBefore;
                foreach (var rule in violatedRules)
                {
                    updatesInNewOrder.Remove(rule);

                    //wrong number first? try sort the other way?
                    pagesToAddAfter.Add(rule);
                }
                updatesInNewOrder.Add(pageInUpdate);
                updatesInNewOrder.AddRange(pagesToAddAfter);
                updatesInNewOrder.AddRange(pagesAfter);
                pagesInUpdate = updatesInNewOrder;
                i = -1;
            }
        }
        var middlePage = int.Parse(pagesInUpdate[pagesInUpdate.Count / 2]);
        result += middlePage;

        return result;
    }

    // TODO: Make int = 1 instead of 0?
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

    private void PartTwoTest2()
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
                {

                }
            }
        }
    }

    private void PartTwoTest1()
    {
        var input = File.ReadAllLines(_path);

        var rules = input.TakeWhile(x => x != "").Select(x => x.Split('|').ToList()).ToList();
        var updateRows = input.TakeLast(input.Length - rules.Count - 1).ToList();

        var allRulesPerUpdateRow = new List<List<string>>();
        var isMadeCorrectly = false;
        var sum = 0;
        for (int i = 0; i < updateRows.Count; i++)
        {
            var pagesPerUpdateRow = updateRows[i].Split(',').ToList();
            for (int j = 0; j < pagesPerUpdateRow.Count; j++)
            {
                var page = pagesPerUpdateRow[j];
                var rulesForPage = rules.Where(x => x.First().Contains(page)).Select(x => x.Last()).ToList(); // eg 15
                allRulesPerUpdateRow.Add(rulesForPage);
            }

            var rule = allRulesPerUpdateRow[i];

            while (IsPageViolatingRules(updateRows[i], rules))
            {
                updateRows[i] = MakeCorrectlyOrdered(updateRows[i].Split(',').ToList(), rules);
                isMadeCorrectly = true;
            }


            if (isMadeCorrectly)
            {
                var asd = updateRows[i].Split(",").ToList();
                var middlePage = int.Parse(asd[asd.Count / 2]);
                sum += middlePage;
            }
        }
        Console.WriteLine("Part two: " + sum);
    }

    private static string MakeCorrectlyOrdered(List<string> pagesPerUpdateRow, List<List<string>> rules)
    {
        var newList = new List<string>();

        for (int i = 0; i < pagesPerUpdateRow.Count; i++)
        {
            var toAddAfter = new List<string>();
            var page = pagesPerUpdateRow[i];

            var rulesPerPage = rules.Where(x => x.First().Contains(page)).Select(x => x.Last()).ToList();

            var pagesBeforePage = pagesPerUpdateRow[..pagesPerUpdateRow.IndexOf(page)];
            var pagesAfterPage = pagesPerUpdateRow[(pagesPerUpdateRow.IndexOf(page) + 1)..];

            var violatedRules = rulesPerPage.Where(x => pagesBeforePage.Contains(x)).ToList();

            if (violatedRules.Count == 0)
                continue;

            newList = pagesBeforePage;
            foreach (var rule in violatedRules)
            {
                newList.Remove(rule);
                toAddAfter.Add(rule);
            }
            newList.Add(page);
            newList.AddRange(toAddAfter);
            newList.AddRange(pagesAfterPage);
            pagesPerUpdateRow = newList;
            i = -1;
        }

        return string.Join(',', newList);
    }

    private static bool IsPageViolatingRules(string update, List<List<string>> rules)
    {
        var pages = update.Split(',').ToList();
        for (int i = 0; i < pages.Count; i++)
        {
            var page = pages[i];
            var rulesPerPage = rules.Where(x => x.First().Contains(page)).Select(x => x.Last()).ToList();

            var pagesBefore = pages[..pages.IndexOf(page)];

            if (rulesPerPage.Any(pagesBefore.Contains))
                return true;
        }
        return false;
    }
}
