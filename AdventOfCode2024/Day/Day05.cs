using System.Data;
using System.Linq;
using System.Text;

namespace AdventOfCode2024.Day;

public class Day05
{
    private readonly string _path;
    public Day05(string path)
    {
        _path = Path.Combine(path, $"Input{GetType().Name}.txt");
        PartOne();
        PartTwoTest1();
        PartTwoTest2();
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

    //private void PartTwo()
    //{
    //    var input = File.ReadAllLines(_path);

    //    var rules = input.TakeWhile(x => x != "").Select(x => x.Split('|').ToList()).ToList();
    //    var updates = input.TakeLast(input.Length - rules.Count - 1).ToList();

    //    var incorrectlyOrderedUpdates = new List<string>();
    //    var correctlyOrderedUpdates = new List<string>();
    //    var sum = 0;
    //    foreach (var update in updates)
    //    {
    //        var pagesPerUpdate = update.Split(',').ToList();

    //        sum += CheckCorrectlyOrdered(pagesPerUpdate, rules, correctlyOrderedUpdates);

    //        #region asd
    //        //for (int i = 0; i < pagesPerUpdate.Count; i++)
    //        //{
    //        //    var page = pagesPerUpdate[i]; // 75
    //        //    var ruleForPage = rules.Where(x => x.First().Contains(page)).Select(x => x.Last()).ToList();

    //        //    //var ruleForPage = rules.Where(x => x.First().Contains(page)).ToList();

    //        //    var pagesBeforePage = pagesPerUpdate[..pagesPerUpdate.IndexOf(page)];

    //        //    var isPageViolatingRule = ruleForPage.Any(pagesBeforePage.Contains);
    //        //    var pagesToMove = ruleForPage.FindAll(pagesBeforePage.Contains).ToList();
    //        //    if (isPageViolatingRule)
    //        //    {

    //        //        var indexOfViolations = new List<int>();
    //        //        foreach (var pageToMove in pagesToMove)
    //        //        {
    //        //            //indexOfViolations.Add(pagesPerUpdate.FindIndex(asda.Contains));
    //        //            var indexOfPageToMove = pagesPerUpdate.FindIndex(pageToMove.Contains);

    //        //            correctlyOrderedUpdates = pagesBeforePage;
    //        //            correctlyOrderedUpdates.RemoveAt(indexOfPageToMove);
    //        //            correctlyOrderedUpdates.Add(page);
    //        //            correctlyOrderedUpdates.Add(pageToMove);

    //        //            var isCorrectlyOrdered = false;
    //        //            while (isCorrectlyOrdered is false)
    //        //            {
    //        //                // Add the rest
    //        //                var test = pagesPerUpdate[(correctlyOrderedUpdates.Count)..];
    //        //                correctlyOrderedUpdates.AddRange(test);

    //        //                // test if it violates other rules

    //        //                // i--;
    //        //                // continue;
    //        //            }
    //        //        }
    //        //        //.ToList()
    //        //        //.Where(x => x != -1);
    //        //        var asd = ruleForPage[pagesPerUpdate.IndexOf(page)];
    //        //    }
    //        //}



    //        //for (int i = 0; i < pagesPerUpdate.Count; i++)
    //        //{
    //        //    var page = pagesPerUpdate[i]; // 75
    //        //    var ruleForPage = rules.Where(x => x.First().Contains(page)).Select(x => x.Last()).ToList();

    //        //    //var ruleForPage = rules.Where(x => x.First().Contains(page)).ToList();

    //        //    var pagesBeforePage = pagesPerUpdate[..pagesPerUpdate.IndexOf(page)];

    //        //    var isPageViolatingRule = ruleForPage.Any(pagesBeforePage.Contains);
    //        //    var pagesToMove = ruleForPage.FindAll(pagesBeforePage.Contains).ToList();
    //        //    if (isPageViolatingRule)
    //        //    {

    //        //        var indexOfViolations = new List<int>();
    //        //        foreach (var pageToMove in pagesToMove)
    //        //        {
    //        //            //indexOfViolations.Add(pagesPerUpdate.FindIndex(asda.Contains));
    //        //            var indexOfPageToMove = pagesPerUpdate.FindIndex(pageToMove.Contains);

    //        //            correctlyOrderedUpdates = pagesBeforePage;
    //        //            correctlyOrderedUpdates.RemoveAt(indexOfPageToMove);
    //        //            correctlyOrderedUpdates.Add(page);
    //        //            correctlyOrderedUpdates.Add(pageToMove);

    //        //            var isCorrectlyOrdered = false;
    //        //            while (isCorrectlyOrdered is false)
    //        //            {
    //        //                // Add the rest
    //        //                var test = pagesPerUpdate[(correctlyOrderedUpdates.Count)..];
    //        //                correctlyOrderedUpdates.AddRange(test);

    //        //                // test if it violates other rules

    //        //                // i--;
    //        //                // continue;
    //        //            }
    //        //        }
    //        //        //.ToList()
    //        //        //.Where(x => x != -1);
    //        //        var asd = ruleForPage[pagesPerUpdate.IndexOf(page)];
    //        //    }
    //        //}


    //        //var correctlyOrdered = "";
    //        //var incorrectlyOrderedUpdate = updates.Split(',');
    //        //foreach (var update in incorrectlyOrderedUpdate)
    //        //{

    //        //}
    //        //return correctlyOrdered;
    //        #endregion
    //    }

    //    Console.WriteLine("Part two: " + sum);
    //}

    //private static int CheckCorrectlyOrdered(List<string> pagesPerUpdate, List<List<string>> rules, List<string> correctlyOrderedUpdates)
    //{
    //    var sum = 0;
    //    for (int i = 0; i < pagesPerUpdate.Count; i++)
    //    {
    //        var page = pagesPerUpdate[i];
    //        var ruleForPage = rules.Where(x => x.First().Contains(page)).Select(x => x.Last()).ToList();

    //        var pagesBeforePage = pagesPerUpdate[..pagesPerUpdate.IndexOf(page)];

    //        if (ruleForPage.Any(pagesBeforePage.Contains))
    //        {
    //            var pagesToMove = ruleForPage.FindAll(pagesBeforePage.Contains).ToList();

    //            foreach (var pageToMove in pagesToMove)
    //            {
    //                correctlyOrderedUpdates = pagesBeforePage;
    //                var isCorrectlyOrdered = false;
    //                while (isCorrectlyOrdered is false)
    //                {
    //                    // Add the rest
    //                    var indexOfPageToMove = pagesPerUpdate.FindIndex(pageToMove.Contains);

    //                    correctlyOrderedUpdates.RemoveAt(indexOfPageToMove);
    //                    correctlyOrderedUpdates.Add(page);
    //                    correctlyOrderedUpdates.Add(pageToMove);

    //                    var test = pagesPerUpdate[(correctlyOrderedUpdates.Count)..];
    //                    correctlyOrderedUpdates.AddRange(test);




    //                    isCorrectlyOrdered = IsPageViolatingRules(correctlyOrderedUpdates, rules);
    //                    // test if it violates other rules

    //                    // i--;
    //                    // continue;
    //                }


    //                //var asd = update.Split(',');
    //                var middlePage = int.Parse(correctlyOrderedUpdates[correctlyOrderedUpdates.Count / 2]);
    //                sum += middlePage;
    //                break;
    //            }
    //        }
    //    }
    //    return sum;
    //}

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

            //var pagesBefore = pagesPerUpdateRow[..i];

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
            /*
                         //while (IsPageViolatingRules(updateRows[j], rules))
            //{
            var pagesBefore = pagesPerUpdateRow[..pagesPerUpdateRow.IndexOf(page)];

            //    //if (rulesForPage.Any(pagesBefore.Contains))
            //    //{
            //    // IM HERE
            //    //var violatedRules = rulesForPage.Where(pagesBefore.Contains).ToList();
            //    //updateRows[j] = MakeCorrectlyOrdered([.. updateRows[j].Split(',')], violatedRules, i);
            //}
             */
        }

        return string.Join(',', newList);
    }

    //private static string MakeCorrectlyOrdered(List<string> pagesPerUpdate, List<string> violatedRules, int index)
    //{
    //    var toAddAfter = new List<string>();
    //    var page = pagesPerUpdate[index];
    //    var pagesBeforePage = pagesPerUpdate[..pagesPerUpdate.IndexOf(page)];
    //    var pagesAfterPage = pagesPerUpdate[(pagesPerUpdate.IndexOf(page) + 1)..];

    //    var newList = pagesBeforePage;
    //    foreach (var rule in violatedRules)
    //    {
    //        newList.Remove(rule);
    //        toAddAfter.Add(rule);
    //    }
    //    newList.Add(page);
    //    newList.AddRange(toAddAfter);
    //    newList.AddRange(pagesAfterPage);
    //    return string.Join(',', newList);
    //}



    //private static bool IsPageViolatingRules(string update, List<string> rules)
    //{
    //    var pages = update.Split(',').ToList();
    //    for (int i = 0; i < pages.Count; i++)
    //    {
    //        var page = pages[i];
    //        var rulesForPage = rules.Where(x => x.First().Contains(page)).Select(x => x.Last()).ToList(); // eg 15

    //        var pagesBefore = pages[..pages.IndexOf(page)];

    //        if (rulesForPage.Any(pagesBefore.Contains))
    //            return true;
    //    }
    //    return false;
    //}

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
