namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            DirectoryInfo dir = new DirectoryInfo(inputFolderPath);
            StringBuilder reportContent = new StringBuilder();
            var files = dir.GetFiles("*", SearchOption.TopDirectoryOnly).OrderByDescending(file => (file.Name,file.Extension));
            HashSet<string> extentions = new HashSet<string>();
            foreach (var file in files)
            {
                extentions.Add(file.Extension);
            }
            foreach (var ext in extentions)
            {

                reportContent.Append(ext + Environment.NewLine);
                foreach (var file in files)
                {
                    if (file.Extension == ext)
                    {
                    reportContent.Append($"--{file.Name} - {file.Length/1024}kb\n");
                    }
                }
            }
            return reportContent.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            string path = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}{reportFileName}";
            File.WriteAllText(path, textContent);
        }
    }
}
