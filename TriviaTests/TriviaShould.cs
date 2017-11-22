
using System;
using System.IO;
using System.Reflection;
using NUnit.Framework;
using Trivia;

namespace TriviaTests
{
    [TestFixture]
    public class TriviaShould
    {
        private const string DirectoryPath =
            @"C:\Users\Christina\Source\Repos\LegacyCodeRetreat\trivia\C#\Trivia\TriviaTests";

        [TestCase(4)]
        [TestCase(1234)]
        [TestCase(4321)]
        [TestCase(3241)]
        [TestCase(7658)]
        public void PlayTheGame(int seedValue)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"TriviaTests.GameOutputs.CapturedOutput{seedValue}.txt";
            string expected;
            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                using (var reader = new StreamReader(stream))
                {
                    expected = reader.ReadToEnd();
                }
            }

            string actual;
            using (var writer = new StringWriter())
            {
                Console.SetOut(writer);
                new GameRunner().PlayGame(new Random(seedValue));
                actual = writer.ToString();
            }

            Assert.AreEqual(expected, actual);
        }

        public void TestSuiteBuilder()
        {
            var testInts = new[] { 4, 1234, 4321, 3241, 7658 };
            foreach (var testInt in testInts)
            {
                using (FileStream fs = new FileStream(DirectoryPath + $@"\GameOutputs\CapturedOutput{testInt}.txt", FileMode.OpenOrCreate))
                {
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        Console.SetOut(writer);
                        new GameRunner().PlayGame(new Random(testInt));

                    }
                }
            }
        }

        [TearDown]
        public void TearDown()
        {
            ResetConsoleToStandardOutput();
        }

        private static void ResetConsoleToStandardOutput()
        {
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()));
        }
    }
}
