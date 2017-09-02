using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication2.Models;

namespace MvcApplication2.Controllers
{
    public class BooksController : Controller
    {
   

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
        public ActionResult SaveBook(Books bb)
        {
            var selected = BooksInfo.Con.Book.FirstOrDefault(x => x.bookID == bb.bookID);
            if (selected != null)
            {
                selected.title = bb.title;
                selected.author = bb.author;
            }
            else
            {
                bb.bookID = BooksInfo.Con.NextId();
                BooksInfo.Con.Book.Add(bb);
            }
            return RedirectToAction("Books");
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
