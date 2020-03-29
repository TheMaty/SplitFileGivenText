using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitFileGivenText
{
    class Program
    {
        static void Main(string[] args)
        {
            // Declare variables and then initialize to zero.
            string filePath = ""; string searchKey = "";

            // Display title as the C# console calculator app.
            Console.WriteLine("split given file into subfiles by given key in C# \r");
            Console.WriteLine("------------------------\n");
            try
            {
                // Ask the user to type the file path.
                Console.WriteLine("File name with full path, and then press Enter");
                filePath = Convert.ToString(Console.ReadLine());

                // Ask the user to type the key to be used.
                Console.WriteLine("Type search key, and then press Enter");
                searchKey = Convert.ToString(Console.ReadLine());

                // This text is added only once to the file.
                if (File.Exists(filePath))
                {
                    // Create a file to write to.
                    string createText = "Hello and Welcome" + Environment.NewLine;
                    string context = File.ReadAllText(filePath);

                    string[] splitted = context.Split(new string[] { searchKey }, StringSplitOptions.None);

                    int iCounter = 0;

                    foreach (string str in splitted)
                    
                    {
                        File.WriteAllText(Path.GetDirectoryName(filePath) + Path.DirectorySeparatorChar + Path.GetFileNameWithoutExtension(filePath) + iCounter.ToString() + ".txt", str, Encoding.UTF8);
                        iCounter++;
                    }

                    Console.Write("completed sucessfully...");
                }
                else
                    Console.WriteLine("File is not found.");

                // Wait for the user to respond before closing.
                Console.ReadKey();
            }
            catch (Exception exp)
            {
                Console.Write("error is occured : " + exp.Message);
                // Wait for the user to respond before closing.
                Console.ReadKey();
            }
        }
    }
}
