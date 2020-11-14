using System;
using System.Collections.Generic;
using Xunit;

namespace Exercise.Tests
{
    public class UnitTest1
    {
        private Exercise.Program prog;
        public UnitTest1()
        {
            prog = new Program();
        }

        [Theory]
        [InlineData(new string[] { "6", "bed 0", "8", "bed 1", "4", "head 2", "7", "bed 3", "8", "head 4" }, 0, 33, 10752, 0.0033482143)]
        [InlineData(new string[] { "9", "head 0", "3", "head 1", "0", "head 2", "8", "head 3", "9", "head 4", "5", "head 5", "9", "head 6", "8", "head 7", "6", "head 8", "-1", "head 9" }, 2, 57, 4199040, 1.92901E-05)]
        [InlineData(new string[] { "3", "head 0", "0", "head 1", "-7", "head 2", "-2", "head 3", "-8", "head 4", "-2", "head 5", "-10", "head 6", "-7", "head 7", "0", "head 8", "-7", "head 9", "-7", "head 10", "7", "head 11", "-4", "head 12", "9", "head 13", "6", "head 14", "6", "head 15", "8", "head 16", "-10", "head 17", "-3", "head 18", "5", "head 19", "1", "head 20", "-8", "head 21", "-4", "head 22", "-10", "head 23", "7", "head 24", "-2", "head 25", "-9", "head 26", "4", "head 27", "-9", "head 28", "7", "head 29", "9", "head 30", "0", "head 31", "-8", "head 32", "8", "head 33", "0", "head 34", "-5", "head 35", "8", "head 36", "-2", "head 37", "5", "head 38", "3", "head 39", "4", "head 40", "7", "head 41", "-10", "head 42", "-6", "head 43", "-4", "head 44", "-5", "head 45", "-1", "head 46", "-2", "head 47", "9", "head 48", "-3", "head 49", "-9", "head 50", "0", "head 51", "3", "head 52", "5", "head 53", "7", "head 54", "9", "head 55", "7", "head 56", "5", "head 57", "5", "head 58", "2", "head 59", "9", "head 60", "3", "head 61", "0", "head 62", "4", "head 63", "-3", "head 64", "2", "head 65", "9", "head 66", "-5", "head 67", "-2", "head 68", "-7", "head 69", "-4", "head 70", "5", "head 71", "-4", "head 72", "8", "head 73", "1", "head 74", "-7", "head 75", "7", "head 76", "-7", "head 77", "-4", "head 78", "0", "head 79", "0", "head 80", "7", "head 81", "-1", "head 82", "4", "head 83", "-5", "head 84", "2", "head 85", "-1", "head 86", "2", "head 87", "0", "head 88", "8", "head 89", "0", "head 90", "-9", "head 91", "-3", "head 92", "-2", "head 93", "-4", "head 94", "-3", "head 95", "-4", "head 96", "-5", "head 97", "-10", "head 98", "5", "head 99" }, 58, 235, 9.367567036192658E+28, 0)]
        [InlineData()]
        public void Test1(string[] values, int neg, double sum, double mult, double div)
        {
            var dictionary = new Dictionary<string, double>();
            for (int i = 0; i < values.Length - 1; i += 2)
            {
                double number = 0;
                double.TryParse(values[i], out number);
                dictionary.Add(values[i + 1], number);
            }
            var count = dictionary.Count;
            var outcome = prog.RetrieveCalValues(dictionary);
            Assert.True(outcome.ContainsKey("sum"), "Missing key for the sum of the entries");
            Assert.True(outcome.ContainsKey("mult"), "Missing key for the product of the entries");
            Assert.True(outcome.ContainsKey("div"), "Missing key for the division result of the entries");
            Assert.True(outcome.Count == count + 3 - neg, "The negative elements were not removed");
            try
            {
            } catch (KeyNotFoundException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
        
    }
}
