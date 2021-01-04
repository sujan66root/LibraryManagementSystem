using LibraryManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class BookCategoryController : Controller
    {
        BookCategoryService bookCategoryService;
        public BookCategoryController()
        {
            bookCategoryService = new BookCategoryService();
        }
        // GET: BookCategory
        public ActionResult Index()
        {
            var data = bookCategoryService.DisplayData();
            return View(data);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            bookCategoryService.DeleteData(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.BookCategoryModel bookCategory)
        {
            bookCategoryService.SaveData(bookCategory);

            var data = bookCategoryService.DisplayData();
            return View("index", data);

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = bookCategoryService.GetData(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(Models.BookCategoryModel bookCategory)
        {
            bookCategoryService.UpdateData(bookCategory);
            var dataList = bookCategoryService.DisplayData();
            return View("index", dataList);
        }
    }
}