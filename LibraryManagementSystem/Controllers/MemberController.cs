using LibraryManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem.Controllers
{
    public class MemberController : Controller
    {
        MemberService memberService;
        public MemberController()
        {
            memberService = new MemberService();
        }
        // GET: Member
        public ActionResult Index()
        {
            var data = memberService.DisplayData();
            return View(data);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            memberService.DeleteData(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Models.MemberModel member)
        {
            memberService.SaveData(member);

            var data = memberService.DisplayData();
            return View("index", data);

        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var result = memberService.GetData(id);
            return View(result);
        }
        [HttpPost]
        public ActionResult Edit(Models.MemberModel member)
        {      
            memberService.UpdateData(member);
            var dataList = memberService.DisplayData();
            return View("index", dataList);
        }
    }
}