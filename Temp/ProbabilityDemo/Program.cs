using System;
using System.Collections.Generic;
using System.Linq;

namespace GenderProblem
{
    class Program
    {
        private const int SampleCount = 1000000;
        private static Random _random = new Random();

        static void Main(string[] args)
        {
            AtLeastOneGirlCase();
            AtLeastOneGirlWithKnownNameCase();

            Console.ReadLine();
        }

        private static void AtLeastOneGirlCase()
        {
            Console.WriteLine("AtLeastOneGirlCase **********************************************");

            var childGroups = new List<string>();

            for (int i = 0; i < SampleCount; i++)
            {
                childGroups.Add(GetRandomChild() + GetRandomChild()); // One of "GG", "GB", "BG", "BB"
            }

            var atleastOneGirlGroups = childGroups.Where(g => g != "BB").ToList();
            Console.WriteLine("Ratio of atleastOneGirlGroups / childGroups: " + (atleastOneGirlGroups.Count * 100.0 / childGroups.Count).ToString("0.00"));

            var twoGirlsCount = atleastOneGirlGroups.Count(g => g == "GG");

            Console.WriteLine("Ratio of twoGirlsCount / atleastOneGirlGroups: " + (twoGirlsCount * 100.0 / atleastOneGirlGroups.Count).ToString("0.00"));
            Console.WriteLine();
        }

        private static void AtLeastOneGirlWithKnownNameCase()
        {
            Console.WriteLine("AtLeastOneGirlWithKnownNameCase **********************************************");

            var childGroups = new List<string>();

            for (int i = 0; i < SampleCount; i++)
            {
                childGroups.Add(GetRandomChild() + GetRandomChild()); // One of "GG", "GB", "BG", "BB"
            }

            var atleastOneGirlGroups = childGroups.Where(g => g != "BB").ToList();
            Console.WriteLine("Ratio of atleastOneGirlGroups / childGroups: " + (atleastOneGirlGroups.Count * 100.0 / childGroups.Count).ToString("0.00"));

            var namedGroups = atleastOneGirlGroups.Select(g =>
            {
                if (g == "GG") //Two [G]irls
                {
                    if (_random.Next(1, 100001) <= 50000) // 50%
                    {
                        return "AG"; //[A]yşe & another [G]irl
                    }
                    else
                    {
                        return "GA"; //Another [G]irl and [A]yşe
                    }
                }
                else if (g == "GB") //[G]irl and [B]oy
                {
                    return "AB"; //[A]yşe and a [B]oy
                }
                else // if (g == "BG") //[B]oy and [G]irl
                {
                    return "BA"; //[B]oy and [A]yşe
                }
            }).ToList();

            var twoGirlsCount = namedGroups.Count(g => g == "GA" || g == "AG");

            Console.WriteLine("Ratio of twoGirlsCount / namedGroups: " + (twoGirlsCount * 100.0 / namedGroups.Count).ToString("0.00"));
        }

        private static string GetRandomChild()
        {
            if (_random.Next(1, 100001) <= 50000) // 50%
            {
                return "G"; // Girl
            }
            else
            {
                return "B"; // Boy
            }
        }
    }
}

/* EXAMPLE OUTPUT:

AtLeastOneGirlCase **********************************************
Ratio of atleastOneGirlGroups / childGroups: 74.96
Ratio of twoGirlsCount / atleastOneGirlGroups: 33.37

AtLeastOneGirlWithKnownNameCase **********************************************
Ratio of atleastOneGirlGroups / childGroups: 75.03
Ratio of twoGirlsCount / namedGroups: 33.34

 */
