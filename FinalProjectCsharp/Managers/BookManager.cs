using C__Final.AuthorName;
using C__Final.Books;
using C__Final.Infrastructure;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Final.Managers
{
    public class BookManager : IManager<Book>, IEnumerable<Book>
    {
        Book[] data = new Book[0];
        public void Add(Book item)
        {
            int len = data.Length;

            Array.Resize(ref data, len + 1);

            data[len] = item;
        }

        public void Edit(Book item)
        {
            var index = Array.IndexOf(data, item);

            if (index == -1)
            {
                return;
            }
            var found = data[index];

            found.Name = item.Name;
            found.AuthorId = item.Id;
        }
       
      
        public Book this[int index]
        {
            get
            {
                return data[index];
            }
        }

        public IEnumerator<Book> GetEnumerator()
        {
            foreach (var item in data)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Remove(Book item)
        {
            int Aindex = Array.IndexOf(data, item);

            if (Aindex == -1)
            {
                return;
            }

            int len = data.Length - 1;

            for (int i = Aindex; i < len; i++)
            {
                data[i] = data[i + 1];
            }
            Array.Resize(ref data, len);
        }

        public Book GetbyID(int id)
        {
            return Array.Find(data, item => item.Id == id);
        }

        public void GetAll(Book item)
        {
            throw new NotImplementedException();
        }

        public Book[] FindByName(string name)
        {
            return Array.FindAll(data, item => item.Name.ToLower().StartsWith(name.ToLower()));
        }
    }
}
