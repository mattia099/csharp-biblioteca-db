using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csharp_biblioteca.Classes
{
    internal class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Year { get; set; }
        public string Plot { get; set; }
        public string AgeRange { get; set; }
        public Book(string title, string author, string year, string plot, string ageRange)
        {
            Title = title;
            Author = author;
            Year = year;
            Plot = plot;
            AgeRange = ageRange;
        }    
      
    }
}
