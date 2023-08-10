using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem
{
    public static class Driver
    {
        public static void Initialization()
        {
            Console.WriteLine("Welcome to this Book Management System");
            Console.WriteLine("Which of this Operation would you want to perform");
            Console.WriteLine("View List of Books Enter 1");
            Console.WriteLine("Edit a Books Enter 2");
            Console.WriteLine("Add a New Book Enter 3");
            Console.WriteLine("Delete a Books Enter 4");
            Console.WriteLine("Enter your Input: ");

        }
        public static void Continue()
        {
            Console.WriteLine("Would you want to continue or close the program");
            Console.WriteLine("Yes to Continue and No to kill");
            string input = Console.ReadLine().ToLower();
            if (input == "no")
            {
                Environment.Exit(0);
            }
            else
            {
                Initialization();
            }
        }

        public static void Runner()
        {
            bool init = true;
            while (init)
            {
                const string terminate = "stop";
                Console.WriteLine("You Entered a Wrong Input");
                Console.WriteLine("If you want to end the program enter Stop");
                string end = Console.ReadLine().ToString().ToLower();
                if (end != terminate)
                {
                    Initialization();
                }
                init = false;

            }
        }

        public static string ReturnFilePath()
        {
            string fileName = "file.json";
            List<BookModel> book = new();
            //file extension should have .json
            string path = Directory.GetCurrentDirectory().Split("bin")[0];

            string fileextension = path + $"/{fileName}";
            if (!File.Exists(fileextension))
            {
                string json = JsonConvert.SerializeObject(book);
                File.WriteAllText(fileextension, json);
                return fileextension;
            }
            return fileextension;
        }
    }

}
