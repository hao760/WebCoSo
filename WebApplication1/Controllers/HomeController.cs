using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

using PagedList;
using PagedList.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        
        Model1 db = new Model1();
        [HttpGet]
        public ActionResult Index(int ? page)
        {
            
            int pageSize = 6;
            int pageNum = (page ?? 1);
            return View(db.HangHoas.ToList().ToPagedList(pageNum,pageSize));
        }
        public ActionResult Logout()
        {
            Session["Taikhoan"] = null;
            return RedirectToAction("Index", "Home");
        }
        

    }
}