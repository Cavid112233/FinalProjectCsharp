using C__Final.AuthorName;
using C__Final.Books;
using C__Final.Enums;
using C__Final.Helper;
using C__Final.Managers;

namespace C__Final
{
    internal class Program
    {
      
        static void Main(string[] args)
        {

            /*
              - Author CRUD

                AuthorStructure :
                                    Id             number (++)
                                    Name      text
                                    Surname text
               =========================
                - CREATE    (Add)
                - READ        (GetAll | FindByName | GetById)
                - UPDATE   (Edit)
                - DELETE    (Remove)

             - Book CRUD
 
                   BookStructure :
                                    Id                 number (++)
                                    Name          text
                                    AuthorId      number
                                    Genre          enum
                                    PageCount number
                                    Price            number(decimal)
               =========================
                - CREATE   (Add)
                - READ     (GetAll | FindByName | GetById)
                - UPDATE   (Edit)
                - DELETE   (Remove)

             */
        
            int Id;
            
            MenuTypes sm;
            var Author = new Author();
            AuthorManager authormanager = new AuthorManager();
            var Book = new Book();
            BookManager bookmanager = new BookManager();

        l1:
            Console.WriteLine("Choose one of them");
            sm = EnumHelper.ReadEnum<MenuTypes>("Menu:");
            switch (sm)
            {
                case MenuTypes.AuthorAdd:
                
                    Author.Name = PrimitiveHelper.Readstring("Author Name:");
                    Author.Surname = PrimitiveHelper.Readstring("Author Surname:");
                    authormanager.Add(Author);
                    Console.Clear();
                    goto case MenuTypes.BookAdd;

                case MenuTypes.AuthorEdit:
                    Console.Clear();
                    Console.WriteLine("What you want to edit?");
                    foreach (var item in authormanager)
                    {
                        Console.WriteLine(item);
                    }
                    Id = PrimitiveHelper.ReadInt("Author Id:");

                    if (Id == 0)
                    {
                        goto l1;
                    }
                    Author = authormanager.GetbyID(Id);

                    if (Author == null)
                    {
                        Console.Clear();
                        Console.WriteLine("Not found");
                        goto case MenuTypes.AuthorEdit;
                    }

                    Author.Name = PrimitiveHelper.Readstring("Author Name:");
                    Author.Surname = PrimitiveHelper.Readstring("Author Surname:");
                    goto case MenuTypes.BookEdit;


                case MenuTypes.AuthorRemove:
                    Console.Clear();
                    Console.WriteLine("What you want to remove");
                    foreach (var item in authormanager)
                    {
                        Console.WriteLine(item);
                    }
                    Id = PrimitiveHelper.ReadInt("Author Id:");
                    Author = authormanager.GetbyID(Id);
                    if (Author == null)
                    {
                        Console.Clear();
                        goto case MenuTypes.AuthorAdd;
                    }
                    authormanager.Remove(Author);
                    Console.Clear();
                    goto case MenuTypes.AuthorGetAll;
                  

                case MenuTypes.AuthorGetAll:
                    Console.Clear();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("=============== Authors ==============");
                    Console.ForegroundColor = ConsoleColor.White;
                    
                    foreach (var item in authormanager)
                    {
                        Console.WriteLine($"{item}");   
                    }

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("=============== ======= ============");
                    Console.ForegroundColor = ConsoleColor.White;
                    
                    goto l1;

                case MenuTypes.AuthorGetById:
                    Id = PrimitiveHelper.ReadInt("Author Id");
                    Author = authormanager.GetbyID(Id);
                    if (Id == 0)
                    {
                        Console.Clear();
                        goto l1;
                    }
                    Console.WriteLine("Write Author Id want you want");
                    if (Author == null)
                    {
                        Console.Clear();
                        Console.WriteLine("Not found");
                        goto case MenuTypes.AuthorGetById;
                    }

                    Console.WriteLine(Author);
                    break;
                case MenuTypes.AuthorFindByName:
                    string name = PrimitiveHelper.Readstring("Write minimum 3 letter:");
                    var data = authormanager.FindByName(name);

                    if (data.Length == 0)
                    {
                        Console.WriteLine("Not found");

                        goto l1;
                    }
                    foreach (var item in data)
                    {
                        Console.WriteLine(item);
                    }
                    goto l1;

                case MenuTypes.BookAdd:
                    if(authormanager == null)
                    {
                        goto case MenuTypes.AuthorAdd;
                    }
                    
                    Book.Name = PrimitiveHelper.Readstring("Book Name:");
                    Book.Genre = PrimitiveHelper.Readstring("Book Genre:");
                    Book.PageCount = PrimitiveHelper.ReadInt("Book Page Count:");
                    Book.Price = PrimitiveHelper.ReadInt("Book Price:");
                    Book.AuthorId = Author.Id;
                    bookmanager.Add(Book);
                    Console.Clear();
                    goto l1;


                case MenuTypes.BookEdit:
                    Console.Clear();
                    Console.WriteLine("What you want to edit?");
                    foreach (var item in bookmanager)
                    {
                        Console.WriteLine(item);
                    }
                    Id = PrimitiveHelper.ReadInt("Book Id:");

                    if (Id == 0)
                    {
                        goto l1;
                    }
                    Book = bookmanager.GetbyID(Id);

                    if (Book == null)
                    {
                        Console.Clear();
                        Console.WriteLine("Not found");
                        goto case MenuTypes.BookEdit;
                    }

                    Book.Name = PrimitiveHelper.Readstring("Book Name:");
                    Book.Genre = PrimitiveHelper.Readstring("Book Genre:");
                    Book.PageCount = PrimitiveHelper.ReadInt("Book Page Count:");
                    Book.Price = PrimitiveHelper.ReadInt("Book Price:");

                    goto case MenuTypes.BookGetAll;
                    break;
                case MenuTypes.BookRemove:
                    Console.Clear();
                    Console.WriteLine("What you want to remove");
                    foreach (var item in bookmanager)
                    {
                        Console.WriteLine(item);
                    }
                    Id = PrimitiveHelper.ReadInt("Author Id:");
                    Book = bookmanager.GetbyID(Id);
                    if (Book == null)
                    {
                        Console.Clear();
                        goto case MenuTypes.AuthorRemove;
                    }
                    bookmanager.Remove(Book);
                    Console.Clear();
                    goto case MenuTypes.BookGetAll;
          
                case MenuTypes.BookGetAll:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("=============== Books ==============");
                    Console.ForegroundColor = ConsoleColor.White;

                    foreach (var item in authormanager)
                    {
                        Console.WriteLine($"Author Id{item.Id}");
                    }
                    foreach (var item in bookmanager)
                    {
                        Console.WriteLine(item);
                    }

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("=============== ======= ============");
                    Console.ForegroundColor = ConsoleColor.White;
                    goto l1;

                case MenuTypes.BookGetById:
                    Id = PrimitiveHelper.ReadInt("Author Id");
                    Book = bookmanager.GetbyID(Id);
                    if (Id == 0)
                    {
                        Console.Clear();
                        goto l1;
                    }
                    Console.WriteLine("Write Author Id want you want");
                    if (Book == null)
                    {
                        Console.Clear();
                        Console.WriteLine("Not found");
                        goto case MenuTypes.AuthorGetById;
                    }

                    Console.WriteLine(Book);
                    goto l1;
  
                case MenuTypes.BookFindByName:
                    string name1 = PrimitiveHelper.Readstring("Write minimum 3 letter:");
                    var data1 = bookmanager.FindByName(name1);

                    if (data1.Length == 0)
                    {
                        Console.WriteLine("Not found");

                        goto l1;
                    }
                    foreach (var item in data1)
                    {
                        Console.WriteLine(item);
                    }
                    goto l1;
                case MenuTypes.Exit:
                    return;
                    break;
                default: goto l1;

            }
           
        }

    }
}