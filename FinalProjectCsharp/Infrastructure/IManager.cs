using FinalProjectCsharp.Books;

namespace FinalProjectCsharp.Infrastructure
{
    public interface IManager<T>
    {
        void Add(T item);
        // void ShowAll(T item);
        void Edit(T item);
        void Remove(T item);
        T[] FindByName(string name);
        T GetbyID(int item);
        void GetAll(T item);

    }
}
