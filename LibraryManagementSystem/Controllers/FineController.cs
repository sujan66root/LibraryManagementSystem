using LibraryManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class FineController : Controller
    {
        FineService fineService;
        public FineController()
        {
            fineService = new FineService();
        }
        // GET: Fine
        public ActionResult Index()
        {
            var data = fineService.DisplayData();
            return View(data);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            fineService.DeleteData(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.FineModel fine)
        {
            fineService.SaveData(fine);

            var data = fineService.DisplayData();
            return View("index", data);

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = fineService.GetData(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(Models.FineModel fine)
        {
            fineService.UpdateData(fine);
            var dataList = fineService.DisplayData(); 
            return View("index", dataList);
        }
    }
}