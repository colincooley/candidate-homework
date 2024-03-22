using System;
using System.Collections.Generic;

namespace _2.Puzzle.Medium
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             *  Write code that meets the following requirements:
             *      - takes input of an arbitrary list of strings (examples provided in Resource.cs
             *      - for each string, looks at the other strings to search for anagrams (ignoring case)
             *      - returns a list of lists, where
             *          - each list contains the anagrams of the first string (not case sensitive)
             *          - list of lists is sorted alphabetically by the first item in each list
             *          - each list is also sorted alphabetically
             *          - the string occurs only once in any of the output lists
             *          - the list of lists contains all the strings in the input, but only once
             *          - does not contain duplicates or whitespace values
             *      - if the word does not have an anagram, it is still added as the only element
             *      - does NOT use any NuGet packages or 3rd party libraries (only stuff that comes with .Net)
             *      - however, feel free to add methods or classes as you see fit
             *
             *
             *
             *  example output:
             *
             *  given a list such as:  { "Kyoto", "London", "Portland", "Tokyo", "Wichita", "Donlon", "Anchorage" }
             *
             *  proper output should be:
             *
             *      Anchorage
             *      Donlon, London
             *      Kyoto, Tokyo
             *      Portland
             *      Wichita
             *
             *  improper output would be:
             *      Kyoto, Tokyo
             *      London, Donlon
             *      Tokyo, Kyoto
             *      Wichita
             *      Donlon, London
             *      Anchorage
             *
             *
             *  Example lists of anagrams are included in Resources.cs, but your code should work for ANY list of strings
             *
             *
             *
             *  Your code should be in the Output method below.
             *
             *  You can do this challenge without using any 3rd party libraries - remember - we want to see YOUR work
             */


            foreach (var list in Output(Resource.SimpleList))
            {
                Console.WriteLine(string.Join(",", list));
            }

            Console.WriteLine("\r\n\r\nSimpleList complete.\r\n");

            foreach (var list in Output(Resource.HarderList))
            {
                Console.WriteLine(string.Join(",", list));
            }

            Console.WriteLine("\r\n\r\nHarderList complete.\r\n\r\n");

            Console.ReadKey();

        }

        static IEnumerable<IEnumerable<string>> Output(IEnumerable<string> input)
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
