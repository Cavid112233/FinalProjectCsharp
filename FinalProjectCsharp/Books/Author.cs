using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCsharp.Books
{
    public class Author : IEquatable<Author>
    {
        static int counter = 0;
        public Author()
        {
            counter++;
            Id = counter;
        }

        public Author(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public bool Equals(Author? other)
        {
            return other?.Id == Id;
        }

        public override string ToString()
        {
            return $"Author Id:{Id} Soyad:{Surname} Ad:{Name}";
        }
    }
}
