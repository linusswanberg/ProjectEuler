namespace ProjectEuler
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;

    internal class Program
    {
        private static void Main()
        {
            var time = Stopwatch.StartNew();

            Console.WriteLine($"\n The value of all names is: {GetTheCalculatedValueFromAllNames(GetCharacterValueOfAllNames(SortNames(GetTrimmedNamesFromFile())))}");

            Console.WriteLine($"\n Totalt time: {time.ElapsedMilliseconds}ms");

            Console.ReadKey();
        }

        private static IEnumerable<string> GetTrimmedNamesFromFile()
        {
            const string fileName = @"\names.txt";
            var path = Path.GetDirectoryName(AppDomain.CurrentDomain.BaseDirectory);

            if (path == null) return new List<string>();

            path = Directory.GetParent(Directory.GetParent(path).FullName).FullName + fileName;

            var namesFromFileInOneString = File.ReadAllText(path);

            var splittedNames = namesFromFileInOneString.Split(',');
            var trimmedNames = splittedNames.Select(name => name.Trim('"').Trim()).ToList();

            return trimmedNames;
        }

        private static IEnumerable<string> SortNames(IEnumerable<string> names)
        {
            var sortedNames = names as string[] ?? names.ToArray();

            Array.Sort(sortedNames, new CompareSort());

            return sortedNames;
        }

        private static IEnumerable<int> GetCharacterValueOfAllNames(IEnumerable<string> names)
        {
            var listWithNamesAsCalculatedValues = names.Select(name => name.ToUpper().ToCharArray()).Select(nameInCharArray => nameInCharArray.Sum(AlphabeticValues)).ToList();

            return listWithNamesAsCalculatedValues;
        }

        private static int AlphabeticValues(char character)
        {
            switch (character)
            {
                case 'A':
                    return 1;
                case 'B':
                    return 2;
                case 'C':
                    return 3;
                case 'D':
                    return 4;
                case 'E':
                    return 5;
                case 'F':
                    return 6;
                case 'G':
                    return 7;
                case 'H':
                    return 8;
                case 'I':
                    return 9;
                case 'J':
                    return 10;
                case 'K':
                    return 11;
                case 'L':
                    return 12;
                case 'M':
                    return 13;
                case 'N':
                    return 14;
                case 'O':
                    return 15;
                case 'P':
                    return 16;
                case 'Q':
                    return 17;
                case 'R':
                    return 18;
                case 'S':
                    return 19;
                case 'T':
                    return 20;
                case 'U':
                    return 21;
                case 'V':
                    return 22;
                case 'W':
                    return 23;
                case 'X':
                    return 24;
                case 'Y':
                    return 25;
                case 'Z':
                    return 26;
                default:
                    return 0;
            }
        }

        private static ulong GetTheCalculatedValueFromAllNames(IEnumerable<int> listOfNamesAsValues)
        {
            ulong totalValueOfAllNames = 0;

            var namesAsValues = listOfNamesAsValues as IList<int> ?? listOfNamesAsValues.ToList();

            for (var i = 0; i < namesAsValues.Count; i++)
            {
                totalValueOfAllNames += (uint)namesAsValues[i] * ((uint)i + 1);
            }

            return totalValueOfAllNames;
        }
    }
}
