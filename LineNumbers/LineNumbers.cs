namespace LineNumbers
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            var lines1 = File.ReadAllLines(inputFilePath);
            Regex regex = new Regex(@"[A-Za-z]");
            Regex regex1 = new Regex(@"[.,?!\-']");
            for (int i = 0; i < lines1.Length; i++)
            {
                var match = regex.Matches(lines1[i]);
                var match1 = regex1.Matches(lines1[i]);
                regex.Match(lines1[i]);
                regex1.Match(lines1[i]);
                lines1[i] = $"{i+1}: {lines1[i]} ({match.Count})({match1.Count})";
            }
            File.WriteAllLines(outputFilePath, lines1);
        }
    }
}
