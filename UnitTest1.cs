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
        [InlineData(new string[] { "-24", "cat 0 running", "-146", "cat 1 running", "-927", "cat 2 running", "-592", "little 3", "55", "cat 4 running", "-551", "cat 5 running", "-828", "cat 6 running", "-7", "little 7", "-17", "cat 8 running", "-230", "cat 9 running" }, 9, 55, 55, 55)]
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
                var vsum = Math.Round(outcome["sum"], 10);
                var vmult = Math.Round(outcome["mult"], 10);
                var vdiv = Math.Round(outcome["div"], 10);
                Assert.True(vsum == Math.Round(sum, 10), $"You should have returned sum: {sum}, but did return sum: {vsum}.");
                Assert.True(vsum == Math.Round(mult, 10), $"You should have returned mult: {mult} but did return mult: {vmult}.");
                Assert.True(vsum == Math.Round(div, 10), $"You should have returned div: {div} but did return div: {vdiv}.");
            }
            catch (KeyNotFoundException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        [Theory]
        [InlineData(new string[] {"-1", "cat 0", "-4", "lille 1", "3", "cat 2", "-4", "cat 3", "2", "lille 4", },2,-2, 12, "lille")]
        [InlineData(new string[] { "4", "cat 0", "2", "cat 1", "1", "cat 2", "-1", "cat 3", "4", "cat 4" }, 0, 10, -32, "mouse")]
        [InlineData(new string[] { "7", "lille 0", "-7", "lille 1", "0", "lille 2", "-7", "lille 3", "3", "lille 4" }, 5, 0, 0, "lille")]
        [InlineData(new string[] { "-5", "cat 0", "-4", "cat 1 mouse", "2", "cat 2 mouse", "-5", "cat 3", "3", "cat 4", "-3", "cat 5", "1", "cat 6", "2", "cat 7 mouse", "-1", "cat 8", "0", "cat 9 mouse", "-4", "cat 10 mouse", "1", "cat 11", "4", "cat 12 mouse", "-1", "cat 13", "-3", "cat 14 mouse", "-3", "cat 15", "4", "cat 16", "0", "cat 17 mouse", "3", "cat 18 mouse", "-2", "cat 19", "2", "cat 20", "-2", "cat 21", "-4", "cat 22", "4", "cat 23", "1", "cat 24", "-4", "cat 25 mouse", "2", "cat 26 mouse", "-4", "cat 27", "0", "cat 28", "0", "cat 29 mouse", "-2", "cat 30 mouse", "-5", "cat 31", "3", "cat 32", "-2", "cat 33", "1", "cat 34 mouse", "4", "cat 35", "4", "cat 36", "-5", "cat 37 mouse", "-2", "cat 38", "4", "cat 39 mouse", "-5", "cat 40", "-1", "cat 41", "-2", "cat 42 mouse", "0", "cat 43", "4", "cat 44", "-1", "cat 45 mouse", "-2", "cat 46 mouse", "-5", "cat 47 mouse", "-3", "cat 48", "0", "cat 49", "2", "cat 50", "1", "cat 51 mouse", "-3", "cat 52 mouse", "0", "cat 53 mouse", "0", "cat 54", "3", "cat 55", "-4", "cat 56 mouse", "2", "cat 57", "0", "cat 58 mouse", "4", "cat 59", "0", "cat 60", "0", "cat 61", "-2", "cat 62", "-5", "cat 63", "-4", "cat 64", "-1", "cat 65", "1", "cat 66 mouse", "-4", "cat 67 mouse", "-1", "cat 68 mouse", "3", "cat 69 mouse", "-5", "cat 70 mouse", "3", "cat 71 mouse", "-1", "cat 72", "1", "cat 73 mouse", "3", "cat 74 mouse", "-3", "cat 75", "-4", "cat 76", "1", "cat 77 mouse", "4", "cat 78", "0", "cat 79", "1", "cat 80", "-1", "cat 81", "4", "cat 82 mouse", "0", "cat 83", "-1", "cat 84", "2", "cat 85", "-4", "cat 86", "-5", "cat 87 mouse", "-3", "cat 88 mouse", "4", "cat 89", "-1", "cat 90", "-1", "cat 91", "-5", "cat 92", "-4", "cat 93", "-3", "cat 94", "0", "cat 95", "4", "cat 96 mouse", "-5", "cat 97 mouse", "0", "cat 98 mouse", "1", "cat 99 mouse" }, 41, -35, 0, "mouse")]
        public void Test2(string[] values, int neg, double sum, double mult, string remove)
        {
            var dictionary = new Dictionary<string, double>();
            for (int i = 0; i < values.Length - 1; i += 2)
            {
                double number = 0;
                double.TryParse(values[i], out number);
                dictionary.Add(values[i + 1], number);
            }
            var count = dictionary.Count;
            prog.RetrieveCalValues(dictionary,remove);
            Assert.True(dictionary.ContainsKey("sum"), "Missing key for the sum of the entries");
            Assert.True(dictionary.ContainsKey("mult"), "Missing key for the product of the entries");
            Assert.True(dictionary.Count == count + 2 - neg, "The selected elements were not removed");
            try
            {
                var vsum = Math.Round(dictionary["sum"], 10);
                var vmult = Math.Round(dictionary["mult"], 10);
                Assert.True(vsum == Math.Round(sum, 10), $"You should have returned sum: {sum}, but did return sum: {vsum}.");
                Assert.True(vsum == Math.Round(mult, 10), $"You should have returned mult: {mult} but did return mult: {vmult}.");
            }
            catch (KeyNotFoundException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        [Theory]
        [InlineData(new string[] { "-1", "rupt cor0", "-4", "cor rupt1", "3", "cat 2", "-4", "corupt 3", "2", " 4 cor ru pt4", }, 2, -2, 12, "corrupt")]
        [InlineData(new string[] { "4", "cat 0hous", "2", "cat 1 mouse", "1", "hat 2 ous", "-1", "cat 3", "4", "hou cat 4e" }, 0, 10, -32, "house")]
        [InlineData(new string[] { "7", "Lli belle 0", "-7", "lAiBlClDe 1", "0", "lie downlle 2", "-7", "lilL le 3", "3", "l ill e 4", "3", "lile 4" }, 5, 3, 3, "lille")]
        public void Test3(string[] values, int neg, double sum, double mult, string remove)
        {
            var dictionary = new Dictionary<string, double>();
            for (int i = 0; i < values.Length - 1; i += 2)
            {
                double number = 0;
                double.TryParse(values[i], out number);
                dictionary.Add(values[i + 1], number);
            }
            var count = dictionary.Count;
            prog.RetrieveCalValuesRigour(dictionary, remove);
            Assert.True(dictionary.ContainsKey("sum"), "Missing key for the sum of the entries");
            Assert.True(dictionary.ContainsKey("mult"), "Missing key for the product of the entries");
            Assert.True(dictionary.Count == count + 2 - neg, "The selected elements were not removed");
            try
            {
                var vsum = Math.Round(dictionary["sum"], 10);
                var vmult = Math.Round(dictionary["mult"], 10);
                Assert.True(vsum == Math.Round(sum, 10), $"You should have returned sum: {sum}, but did return sum: {vsum}.");
                Assert.True(vsum == Math.Round(mult, 10), $"You should have returned mult: {mult} but did return mult: {vmult}.");
            }
            catch (KeyNotFoundException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }


    }
}
