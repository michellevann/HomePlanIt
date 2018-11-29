using HomePlanIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomePlanIt.WebMVC.Controllers
{
    [Authorize]
    public class DIYController : Controller
    {
        // GET: DIY
        public ActionResult Index()
        {
            var model = new DIYListItem[0];
            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            return View();
        }
    }
}