using System;

namespace ARiMR_Parser
{
    class Program
    {
        public static String inputFilename = "Sylwia-2020.csv";
        public static String resultFilename = inputFilename + "-Result.csv";

        static void Main(string[] args)
        {
            Console.WriteLine("Otwieranie pliku...\n");
            var file = FileManager.OpenFile(inputFilename);
            Console.WriteLine("Otworzono pomyslnie\n");
            Console.WriteLine("Przetwarzanie danych...\n");
            Console.WriteLine("Rezultat:\n");
            Console.WriteLine(file.GetResult());
            
        }
    }
}

