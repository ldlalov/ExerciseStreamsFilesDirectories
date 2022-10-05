namespace EvenLines
{
    using System.IO;
    using System;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            using (StreamReader streamReader = new StreamReader(inputFilePath))
            {
                string line; ;
                int raw = 0;
                Regex regex1 = new Regex(@"[-,.!,?]");
                while ((line = streamReader.ReadLine()) != null)
                {
                    if (raw % 2 == 0)
                    {
                        MatchCollection matches = regex1.Matches(line);
                        foreach (var match in matches)
                        {
                            line = line.Replace(char.Parse(match.ToString()), char.Parse("@"));
                        }
                        string[] reversed = line.Split(" ").Reverse().ToArray();
                        Console.WriteLine(string.Join(" ", reversed));
                    }
                    raw++;
                }
                return null;
            }
        }
    }
}
