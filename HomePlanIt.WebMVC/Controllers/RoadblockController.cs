using HomePlanIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomePlanIt.WebMVC.Controllers
{
    [Authorize]
    public class RoadblockController : Controller
    {
        // GET: Roadblock
        public ActionResult Index()
        {
            var model = new RoadblockListItem[0];
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RoadblockCreate model)
        {
            if (ModelState.IsValid)
            {

            }
            return View(model);
        }
    }
}