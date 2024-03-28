using System.Web.Mvc;
using System.Collections.Generic;
using System;

namespace _3.BonusChallenge
{
    public class HomeController : Controller {

            public ActionResult Index()
        {
            return View();
        }
        public ActionResult SimpleList()
        {
            var processedList = ProcessAnagrams(Resource.SimpleList);
            var viewModel = new BonusModel { AnagramGroups = processedList };
            return View(viewModel);
        }

        public ActionResult HarderList()
        {
            var processedList = ProcessAnagrams(Resource.HarderList);
            var viewModel = new BonusModel { AnagramGroups = processedList };
            return View(viewModel);
        }

        private List<List<string>> ProcessAnagrams(IEnumerable<string> input)
        {
            var output = new List<List<string>>();

            // YOUR CODE GOES HERE
            List<string> normalizedInput = new List<string>();
            foreach (var item in input)
            {
                if (item == null) continue;
                var trimmedLoweredItem = item.Trim().ToLower();
                if (!string.IsNullOrEmpty(trimmedLoweredItem) && !Contains(normalizedInput, trimmedLoweredItem))
                {
                    normalizedInput.Add(trimmedLoweredItem);
                }
            }

            while (normalizedInput.Count > 0)
            {
                string currentWord = normalizedInput[0];
                string sortedCurrentWord = SortString(currentWord);
                List<string> currentGroup = new List<string>();

                for (int i = normalizedInput.Count - 1; i >= 0; i--)
                {
                    string word = normalizedInput[i];
                    if (SortString(word) == sortedCurrentWord)
                    {
                        currentGroup.Add(word);
                        normalizedInput.RemoveAt(i);
                    }
                }

                SortWords(currentGroup);
                output.Add(currentGroup);
            }

            SortLists(output);

            return output;
        }

        static string SortString(string input)
        {
            char[] characters = input.Replace(" ", string.Empty).ToCharArray();
            Array.Sort(characters);
            return new string(characters);
        }

        static bool Contains(List<string> list, string value)
        {
            foreach (var item in list)
            {
                if (item == value)
                    return true;
            }
            return false;
        }

        static void SortWords(List<string> list)
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < list.Count - 1; i++)
                {
                    if (string.Compare(list[i], list[i + 1], StringComparison.OrdinalIgnoreCase) > 0)
                    {

                        var temp = list[i];
                        list[i] = list[i + 1];
                        list[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }

        static void SortLists(List<List<string>> listOfLists)
        {
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 0; i < listOfLists.Count - 1; i++)
                {
                    if (string.Compare(listOfLists[i][0], listOfLists[i + 1][0], StringComparison.OrdinalIgnoreCase) > 0)
                    {
                        var temp = listOfLists[i];
                        listOfLists[i] = listOfLists[i + 1];
                        listOfLists[i + 1] = temp;
                        swapped = true;
                    }
                }
            } while (swapped);
        }
    }
}
