using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace SortFile
{
    class Program
    {
        static void Main(string[] args)
        {
            var fileName = ValidateArgs(args);
            IEnumerable<string> lines = ReadFile(fileName);
            IEnumerable<string> sortedLines = SortLines(lines);
            OverwriteFile(fileName, sortedLines);
        }

        private static void OverwriteFile(string fileName, IEnumerable<string> sortedLines)
        {
            File.WriteAllLines(fileName, sortedLines);
        }

        private static string ValidateArgs(string[] args)
        {
            if (args.Length != 1)
                PrintUsage();

            return args[0];
        }

        private static void PrintUsage()
        {
            Console.WriteLine("Usage: SortFile.exe <FileToSort>");
            Environment.Exit(1);
        }

        private static string[] ReadFile(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            return lines;
        }

        private static IEnumerable<string> SortLines(IEnumerable<string> unsoredLines)
        {
            return unsoredLines.OrderBy(line => line);
        }
    }
}
