using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace HelloWorld
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var regions = new List<string>();
            regions.Add("Absheron");
            regions.AddRange(new[] { "Sekhi", "Quba", "Gobustan", "Lankaran", "Qarabag" });
            foreach (var rayons in regions)
            {
                Console.WriteLine(rayons);
            }
            Console.WriteLine(regions.Contains("Qaradag")); // Check if element exist
            regions.Insert(0, "Zengatala"); // Insert at some index
            Console.WriteLine(regions.Count);
            if (regions.Remove("Sumqait"))
                Console.WriteLine("Sumqait doesn't exist");
            else
                Console.WriteLine("Sumqait was removed");
            // System.Math.

        }
    }
}