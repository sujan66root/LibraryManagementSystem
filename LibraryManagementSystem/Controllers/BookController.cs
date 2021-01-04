using LibraryManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class BookController : Controller
    {
        BookService bookService;
        public BookController()
        {
            bookService = new BookService();
        }
        // GET: Book
        public ActionResult Index()
        {
            var data = bookService.DisplayData();
            return View(data);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            bookService.DeleteData(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.BookModel book)
        {
            bookService.SaveData(book);

            var data = bookService.DisplayData();
            return View("index", data);

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = bookService.GetData(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(Models.BookModel book)
        {
            bookService.UpdateData(book);
            var dataList = bookService.DisplayData();
            return View("index", dataList);
        }
    }
}