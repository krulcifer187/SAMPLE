using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication2.Models;
using MvcApplication2.Entity;
using Book = MvcApplication2.Models.Books;

namespace MvcApplication2.Utils
{
    public class BooksUtils
    {
        public static void Save(Book acc)
        {
            using (var db = new MyDatabaseEntities())
            {
                var book = db.Books.FirstOrDefault(x => x.id == acc.bookID);
                if (book != null)
                {
                    book.author = acc.author;
                    book.title = acc.title;
                }
                else
                {
                    db.Books.AddObject(new Entity.Book { BookAuthor = acc.author, BookTitle = acc.title });
                }
                db.SaveChanges();
            }
        }
        public static void Delete(int id)
        {
            using (var db = new MyDatabaseEntities())
            {
                var selected = db.Books.FirstOrDefault(x => x.id == id);
                if (selected != null)
                {

                    db.DeleteObject(selected);
                    db.SaveChanges();
                }
            }

        }
        public static List<Book> GetBooks(int id = 0)
        {
            using (var db = new MyDatabaseEntities())
            {

                if (id != 0)
                {
                    var a = db.Books.Where(i => i.id == id);
                    return a.Select(b => new Book { bookID = b.id, author = b.author, title = b.title }).ToList();
                }
                else
                {
                    return db.Books.Select(b => new Book {bookID = b.id, author = b.BookAuthor, title = b.BookTitle }).ToList();
                }
            }


        }
    }
}