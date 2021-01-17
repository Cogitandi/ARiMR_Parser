using Parser;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ARiMR_Parser
{
    public class FileManager
    {
        public static ParsedFile OpenFile(String filename)
        {
            // Create a temporary file, and put some data into it.
            string appDirectory = Directory.GetCurrentDirectory();
            string pathToOpen = Path.Combine(appDirectory, filename);

            //using (FileStream fs = File.Open(pathToOpen, FileMode.Open, FileAccess.Write, FileShare.None))
            //{
            //    Byte[] info = new UTF8Encoding(true).GetBytes("This is some text in the file.");
            //    // Add some information to the file.
            //    fs.Write(info, 0, info.Length);
            //}

            var parsedFile = new ParsedFile();
            foreach (string line in File.ReadLines(pathToOpen).Skip(1))
            {

                parsedFile.Entries.Add(new FileEntry(line));
                //Console.WriteLine("START "+ line + " KONIEC");
            }

            return parsedFile;

            // Open the stream and read it back.
            //using (FileStream fs = File.Open(pathToOpen, FileMode.Open))
            //{
            //    var parsedFile = new ParsedFile();
            //    byte[] b = new byte[1024];
            //    UTF8Encoding temp = new UTF8Encoding(true);

            //    while (fs.Read(b, 0, b.Length) > 0)
            //    {
            //        //parsedFile.Entries.Add(new FileEntry(temp.GetString(b)));
            //        Console.WriteLine("START "+temp.GetString(b)+" KONIEC");
            //    }
                
            //}

        }
    }
}
