using LibraryManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class MemberCategoryController : Controller
    {
        MemberCategoryService memberCategoryService;
        public MemberCategoryController()
        {
            memberCategoryService = new MemberCategoryService();
        }
        // GET: MemberCategory
        public ActionResult Index()
        {
            var data = memberCategoryService.DisplayData();
            return View(data);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            memberCategoryService.DeleteData(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.MemberCategoryModel memberCategory)
        {
            memberCategoryService.SaveData(memberCategory);

            var data = memberCategoryService.DisplayData();
            return View("index", data);

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = memberCategoryService.GetData(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(Models.MemberCategoryModel memberCategory)
        {
            memberCategoryService.UpdateData(memberCategory);
            var dataList = memberCategoryService.DisplayData();
            return View("index", dataList);
        }
    }
}