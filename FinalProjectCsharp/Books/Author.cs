using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Final.AuthorName
{
    public  class Author : IEquatable<Author>
    {
        static int counter = 0;
        public Author()
        {
            counter++;
            this.Id = counter;
        }

        public Author(int id)
        {
            this.Id=id;
        }
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        public bool Equals(Author? other)
        {
            return other?.Id == this.Id;
        }

        public override string ToString()
        {
            return $"Author Id:{Id} Soyad:{Surname} Ad:{Name}";
        }
    }
}
