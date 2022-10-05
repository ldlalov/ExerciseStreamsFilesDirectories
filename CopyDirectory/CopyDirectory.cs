namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";
            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            if (Directory.Exists(outputPath))
            {
            Directory.Delete(outputPath, true);
            }
            Directory.CreateDirectory(outputPath);
            DirectoryInfo input = new DirectoryInfo(inputPath);
            var files = input.GetFiles("*",SearchOption.TopDirectoryOnly);
            foreach (var file in files)
            {
                string newFile = $"{outputPath}\\{file.Name}";
                File.Copy(file.FullName,newFile);
            }
        }
    }
}
