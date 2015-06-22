using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Interface.Services;
namespace WebApplication.Controllers
{
    public class DocumentController : Controller
    {
        private readonly IUserService userService;
        //
        // GET: /Document/
        public ActionResult Index()
        {
            return View();
        }
        //[HttpGet]
        //public ActionResult CreateDocument()
        //{
        //    return View();
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult CreateDocument()
        //{
            
        //    return View(model);
        //}
	}
}