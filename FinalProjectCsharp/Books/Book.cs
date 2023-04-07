using C__Final.AuthorName;
using C__Final.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Final.Books
{
    public class Book : IEquatable<Book> 
    {
        static int counter = 0;
        public Book()
        {
            counter++;
            this.Id = counter;

        }
     
        public int Id { get; private set; }
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int PageCount {get; set; }
        public int Price { get; set; }

        public bool Equals(Book? other)
        {
            return other?.Id == this.Id;
        }
        public override string ToString()
        {
            return $"Book Id:{Id}\nBook Name:{Name}\nBook Genre:{Genre}\nBook Page Count:{PageCount}\nBook Price{Price}\n";
        }
    }
}
