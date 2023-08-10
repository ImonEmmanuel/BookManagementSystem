using Newtonsoft.Json;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json; 

namespace BookManagementSystem
{
    public class Program
    {
        static void Main(string[] args)
        {
            Driver.Initialization();
            Int32.TryParse(Console.ReadLine(), out int input);

            BookModel book = new BookModel();

            //view list of books 1
            //edit list of books 2
            //add new books 3
            //delete book 4
            string path = Driver.ReturnFilePath(); //get the file path
            string jsonContent = File.ReadAllText(path);
            // Deserialize the JSON content into an object
            List<BookModel> books = JsonConvert.DeserializeObject<List<BookModel>>(jsonContent);
            if (input == 1)
            {


                if (books.Count() == 0)
                {
                    Console.WriteLine("No Book has been added try and add a new Book");
                    Driver.Continue();

                }
                else
                {
                    Console.WriteLine("Loading Book:");
                    foreach (var item in books)
                    {
                        Console.WriteLine($"Book Id: {item.Id.ToString()}\nBook Name: {item.Name}\nDescription: {item.Description}\nAuthor: {item.Author}\nPage Number:{item.Pages}\nDate Added:{item.dateAdded}\n");
                    }
                }

            }
            else if (input == 2)
            {
                //Edit the Book using the Id
                if (books.Count() == 0)
                {
                    Console.WriteLine("List of Book is Empty");
                }
                else
                {
                    foreach (var item in books)
                    {
                        Console.WriteLine(item);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Enter the book Id: ");
                    Int32.TryParse(Console.ReadLine(), out int Id);
                    BookModel editBook = books.Where(x => x.Id == Id).FirstOrDefault();
                    Console.WriteLine("Enter the Details to be Edited");
                    Console.WriteLine("i.e -- Name/Description/Author");
                    var data = Console.ReadLine().Split("/");
                    string name = data[0];
                    string desc = data[1];
                    string Author = data[2];
                    editBook.Author = Author;
                    editBook.Name = name;
                    editBook.Description = desc;
                    Int32.TryParse(data[2], out int page);
                    editBook.dateAdded = DateTime.Now.ToString("dd-MM-yy");
                    editBook.Pages = page;
                    Console.WriteLine($"Updated Book Data: {editBook}");
                }
            }

            else if (input == 3)
            {
                //Add a new Book 
                Random rand = new Random();
                int Id = rand.Next(1, 100000);
                Console.WriteLine("Enter the Details of Book to be Added");
                Console.WriteLine("i.e -- Name/Description/Author/Page");
                var data = Console.ReadLine().Split("/");
                string name = data[0];
                string desc = data[1];
                string Author = data[2];
                Int32.TryParse(data[2], out int page);
                BookModel newBokk = new()
                {
                    dateAdded = DateTime.Now.ToString("dd-MM-yy"),
                    Author = Author,
                    Name = name,
                    Pages = page,
                    Id = Id,
                    Description = desc
                };
                books.Add(newBokk);
                string json = JsonConvert.SerializeObject(books);
                File.WriteAllText(path, json);
                Console.WriteLine("You have successfully added a new book");

            }
            else if (input == 4)
            {
                if (books.Count() == 0)
                {
                    Console.WriteLine("List of Book is Empty");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Enter the book Id: ");
                    Int32.TryParse(Console.ReadLine(), out int Id);
                    BookModel delBook = books.Where(x => x.Id == Id).FirstOrDefault();
                    if (delBook is null)
                    {
                        Console.WriteLine("No Id exist with such Book Details");
                    }
                    books.RemoveAll(x => x.Id == Id);
                    Console.WriteLine("Book has been deleted Successfully");
                }
            }
            else
            {
                Driver.Runner();
            }

        }

    }
}