using C__Final.AuthorName;
using C__Final.Infrastructure;
using System.Collections;

namespace C__Final.Managers
{
    public class AuthorManager : IManager<Author>,IEnumerable<Author>
    {
        Author[] data = new Author[0];
        public void Add(Author item)
        {
            int len = data.Length;

            Array.Resize(ref data, len + 1);

            data[len] = item;
        }

        public void Edit(Author item)
        {
           var index = Array.IndexOf(data, item);

            if (index == -1) 
            {
                return;
            }
              var found = data[index];

            found.Name = item.Name;
        }
        public void Remove(Author item)
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

        public Author this[int index]
        {
            get
            {
                return data[index];
            }
        }

        public IEnumerator<Author> GetEnumerator()
        {
            foreach(var item in data)
            {
               yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void ShowAll(Author item)
        {
            throw new NotImplementedException();
        }

        internal void Remove(string name)
        {
            throw new NotImplementedException();
        }

        public Author[] FindByName(string name)
        {
            return Array.FindAll(data, item => item.Name.ToLower().StartsWith(name.ToLower()));
        }

        public Author GetbyID(int id)
        {
            return Array.Find(data, item => item.Id == id);
        }

        public void GetAll(Author item)
        {
            throw new NotImplementedException();
        }

    }
}
