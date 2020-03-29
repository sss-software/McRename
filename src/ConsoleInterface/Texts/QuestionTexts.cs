using System;
using System.IO;
using Renamer;

namespace ConsoleInterface.Texts
{
    public class QuestionTexts
    {
        public static string RequestDirectory()
        {
            while(true) {
                Console.Write("Please provide the desktop folder to rename its content: ");
                string inputDirectory = Console.ReadLine().Replace(" ", "\u0020");
                string fullPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/" + inputDirectory;

                if(Directory.Exists(fullPath)) {
                    return fullPath;
                }
                else {
					StandardTexts.SimulateWaitingWithMessage("Input directory not found. Try again");
                    Console.WriteLine("");
                }
            }
		}

        public static RenameMode RequestMode()
        {
            Console.WriteLine("Specify the format of the new filenames:");
            Console.WriteLine("1) Numerical");
            Console.WriteLine("2) Date_Time: YYYYMMDD_HHMMSS");
            Console.WriteLine("3) Date: YYYMMDD");
            Console.WriteLine("------------");
            Console.Write("  Mode: ");

            string mode = Console.ReadLine();

            Console.WriteLine("");

			return (int.Parse(mode)) switch
			{
                1 => RenameMode.Numerical,
				_ => RenameMode.Unknown,
			};
		}

        public static bool AskPermission()
        {
            while(true) {
                Console.WriteLine("");
                Console.Write("Accept the proposed name changes (Y/n)? ");
                var answer = Console.ReadLine().ToLower();

                if(answer == string.Empty || answer == "y") {
                    return true;
                }
                else if(answer == "n") {
                    return false;
                }

                StandardTexts.SimulateWaitingWithMessage("Error parsing input. Retry.");
            }
        }
    }
}