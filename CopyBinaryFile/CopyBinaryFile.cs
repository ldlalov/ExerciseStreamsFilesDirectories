namespace CopyBinaryFile
{
    using System;
    using System.IO;

    public class CopyBinaryFile
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\copyMe.png";
            string outputFilePath = @"..\..\..\copyMe-copy.png";

            CopyFile(inputFilePath, outputFilePath);
        }

        public static void CopyFile(string inputFilePath, string outputFilePath)
        {
            using (FileStream sourceStream = new FileStream(inputFilePath, FileMode.Open))
            {
                long sourceFileLenght = sourceStream.Length;
                var buffer = new byte[sourceFileLenght];
                sourceStream.Read(buffer, 0, buffer.Length);
                int inputFileLenght = buffer.Length;
                using (FileStream splited1 = new FileStream(outputFilePath, FileMode.CreateNew))
                {
                    splited1.Write(buffer, 0, inputFileLenght);
                }
            }
        }
    }
}
