using LibraryManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class SubjectController : Controller
    {
        SubjectService subjectService;
        public SubjectController()
        {
            subjectService = new SubjectService();
        }
        // GET: Subject
        public ActionResult Index()
        {
            var data = subjectService.DisplayData();
            return View(data);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            subjectService.DeleteData(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.SubjectModel subject)
        {
            subjectService.SaveData(subject);
            var data = subjectService.DisplayData();
            return View("index", data);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = subjectService.GetData(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(Models.SubjectModel subject)
        {
            subjectService.UpdateData(subject);
            var dataList = subjectService.DisplayData();
            return View("index", dataList);
        }
    }
}