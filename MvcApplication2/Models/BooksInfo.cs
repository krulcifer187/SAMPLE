using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication2.Models
{
    public class BooksInfo
    {
        public List<Books> Book;
        private static BooksInfo _BooksInfo;
        public static BooksInfo Con
        {
            get
            {
                if (_BooksInfo == null)
                {
                    _BooksInfo = new BooksInfo();
                }
                return _BooksInfo;
            }
        }

        private BooksInfo()
        {
            
            Book = new List<Books>();
            Book.Add(new Books {bookID=1, title="Ang Balay Misakas Bukid", author="Taong Pahong" });
        }

        public int NextId()
        {
            return Book.Any() ? Book.Select(x => x.bookID).Max() + 1 : 1;
        }
    }
}