using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GENERICS_
{
    internal class BookStore
    {
        STUDENT[] books = new STUDENT[0];

        public void Add(STUDENT book)
        {
            Array.Resize(ref books, books.Length + 1);
            books[books.Length - 1] = book;
        }

        public void RemoveAt(int index)
        {
            if (index >= books.Length || index < 0)
                return;

            for(int i = index; i < books.Length; i++)
            {
                books[index] = books[index + 1];
            }

            Array.Resize(ref books, books.Length - 1);

        }    

        public STUDENT[] GetAll()
        {
            return books;
        }
    }
}
