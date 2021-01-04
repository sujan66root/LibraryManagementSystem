using LibraryManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class AuthorController : Controller
    {
        AuthorService authorService;
        public AuthorController()
        {
            authorService = new AuthorService();
        }
        // GET: Author
        public ActionResult Index()
        {
            var data = authorService.DisplayData();
            return View(data);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            authorService.DeleteData(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.AuthorModel author)
        {
            authorService.SaveData(author);
            var data = authorService.DisplayData();
            return View("index", data);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = authorService.GetData(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(Models.AuthorModel author)
        {
            authorService.UpdateData(author);
            var dataList = authorService.DisplayData();
            return View("index", dataList);
        }

    }
}