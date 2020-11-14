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
        [InlineData(new string[] { "5", "hat 0", "19", "mad 1", "14", "hat 2", "1", "mad 3", "0", "hat 4" },0 , 58, 1330, 0.0187969925)]
        [InlineData(new string[] {"11", "bat 0", "6", "bat 1", "9", "weird 2", "19", "weird 3", "15", "weird 4" },0, 77, 169290, 0.0007147498)]
        public void Test1(string[] values, int neg, double sum, double mult, double div)
        {
            var dictionary = new Dictionary<string, double>();
            for (int i= 0; i < values.Length - 1; i += 2)
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
            Assert.True(outcome.Count==count+3-neg, "The negative elements were not removed");
            try
            {
            } catch (KeyNotFoundException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }
        
    }
}
