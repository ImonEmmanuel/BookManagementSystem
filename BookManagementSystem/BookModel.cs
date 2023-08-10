using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagementSystem
{
    public class BookModel
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public string dateAdded { get; set; }
        public int Pages { get; set; }


        public BookModel(string Name, string date, string Description, string Author, int Pages)
        {
            this.Name = Name;
            this.dateAdded = date;
            this.Description = Description;
            this.Pages = Pages;
            this.Author = Author;
        }
        public BookModel()
        {

        }
    }
}
