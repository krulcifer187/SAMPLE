using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;
using MvcApplication2.Entity;

namespace MvcApplication2.Controllers
{
    public class BooksController : Controller
    {
        private string title;
   

        public ActionResult AddBook()
        {
            return View();
        }
        public ActionResult DeleteBook(int id)
        {
            var selected = BooksInfo.Con.Book.FirstOrDefault(x => x.bookID == id);
            if (selected != null)
            {

                BooksInfo.Con.Book.Remove(selected);

            }
            return RedirectToAction("Books");
        }
        public static void SaveBook(Books bb)
        {
         using (var db = new MyDatabaseEntities()){
            var selected = db.Books.FirstOrDefault(x => x.bookID == bb.bookID);
            if (selected != null)
            {
                selected.title = bb.title;
                selected.author = bb.author;
            }
            else
            {
                db.Books.AddObject(new Entity.Book{title = bb.title,author=bb.author});

            }
                db.SaveChanges();
            }
        }
        public ActionResult Books()
        {
            return View(BooksInfo.Con.Book);
        }
        public ActionResult EditBook(Books bb)
        {

            return View(BooksInfo.Con.Book.FirstOrDefault(x => x.bookID == bb.bookID));
        }

        public ActionResult toHomePage()
        {
            return RedirectToAction("HomePage", "Home");
        }

    }
}
