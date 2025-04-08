using System;
using System.IO;

class Program
{
    static void Main()
    {
        string inputPath = "input.txt";
        string outputPath = "output.txt";

        try
        {
            int lineCount = File.ReadAllLines(inputPath).Length;
            string content = File.ReadAllText(inputPath);

            string[] words = content.Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            int wordCount = words.Length;

            File.WriteAllText(outputPath, $"Line Count: {lineCount}");
            File.AppendAllText(outputPath, $"\nWord Count: {wordCount}");

            Console.WriteLine("Done! Check output.txt");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File not found.");
        }
        catch (IOException ex)
        {
            Console.WriteLine($"IO Error: {ex.Message}");
        }
    }
}
