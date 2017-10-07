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
        public ActionResult Index(string search = "", string BookID = "")
        {

            return View();
        }
        public ActionResult AddBook(Books bb)
        {
            SaveBook(bb);
            if (bb.author!= null)
            {
                return RedirectToAction("Books");

            }
            return View();
        }
        public ActionResult EditBook(Books bb)
        {

            return View(BooksInfo.Con.Book.FirstOrDefault(x => x.bookID == bb.bookID));
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
            var selected = BooksInfo.Con.Book.FirstOrDefault(x => bb.bookID == bb.bookID);
            if (selected != null)
            {
                selected.title = bb.title;
                selected.author = bb.author;
                selected.bookID = bb.bookID;
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
    
        public ActionResult toHomePage()
        {
            return RedirectToAction("HomePage", "Home");
        }

    }
}
