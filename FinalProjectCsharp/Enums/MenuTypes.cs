using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C__Final.Enums
{
    internal enum MenuTypes : byte
    {
        AuthorAdd = 1,
        AuthorEdit,
        AuthorRemove,
        AuthorGetAll,
        AuthorGetById,
        AuthorFindByName,

        BookAdd,
        BookEdit,
        BookRemove,
        BookGetAll,
        BookGetById,
        BookFindByName,
        Exit,
      


    }
}
