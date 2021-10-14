using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculations.Test
{
    public static class TestDataShare
    {
        public static IEnumerable<Object[]> isOddOrEvenData {
            get
            {
                yield return new object[] { 1, true };
                yield return new object[] { 200, false };
            }
        }

        public static IEnumerable<Object[]> isOddOrEvenExternalData
        {
            get
            {
                var allLines = System.IO.File.ReadAllLines("isOddOrEvenTestData.txt");
                return allLines.Select(x =>
                {
                    var lineSplit = x.Split(",");
                    return new object[] { int.Parse(lineSplit[0]), bool.Parse(lineSplit[1]) };
                });
            }
        }
    }
}
