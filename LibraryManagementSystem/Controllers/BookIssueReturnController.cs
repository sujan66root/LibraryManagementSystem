using LibraryManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class BookIssueReturnController : Controller
    {
        BookIssueReturnService bookIssueReturnService;
        public BookIssueReturnController()
        {
            bookIssueReturnService = new BookIssueReturnService();
        }
        // GET: BookIssueReturn
        public ActionResult Index()
        {
            var data = bookIssueReturnService.DisplayData();
            return View(data);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            bookIssueReturnService.DeleteData(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.BookIssueReturnModel bookIssueReturn)
        {
            bookIssueReturnService.SaveData(bookIssueReturn);

            var data = bookIssueReturnService.DisplayData();
            return View("index", data);

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = bookIssueReturnService.GetData(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(Models.BookIssueReturnModel bookIssueReturn)
        {
            bookIssueReturnService.UpdateData(bookIssueReturn);
            var dataList = bookIssueReturnService.DisplayData();
            return View("index", dataList);
        }
    }
}