using LibraryManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class AssesionMappingController : Controller
    {
        AssesionMappingService assesionMappingService;
        public AssesionMappingController()
        {
            assesionMappingService = new AssesionMappingService();
        }
        // GET: AssesionMapping
        public ActionResult Index()
        {
            var data = assesionMappingService.DisplayData();
            return View(data);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            assesionMappingService.DeleteData(id);
            return RedirectToAction("index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.AssesionMappingModel assesionMapping)
        {
            assesionMappingService.SaveData(assesionMapping);

            var data = assesionMappingService.DisplayData();
            return View("index", data);

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = assesionMappingService.GetData(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(Models.AssesionMappingModel assesionMapping)
        {
            assesionMappingService.UpdateData(assesionMapping);
            var dataList = assesionMappingService.DisplayData();
            return View("index", dataList);
        }
    }
}