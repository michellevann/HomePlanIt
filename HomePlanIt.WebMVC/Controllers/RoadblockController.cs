using HomePlanIt.Models;
using HomePlanIt.Services;
using Microsoft.AspNet.Identity;
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
            var ownerId = Guid.Parse(User.Identity.GetUserId());
            var service = new RoadblockService(ownerId);
            var model = service.GetRoadblocks();
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
            if (!ModelState.IsValid) return View(model);
           
            var service = CreateRoadblockService();

            if (service.CreateRoadblock(model))
            {
                TempData["SaveResult"] = "Your roadblock was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Roadblock could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRoadblockService();
            var model = svc.GetRoadblockById(id);

            return View(model);
        }

        private RoadblockService CreateRoadblockService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RoadblockService(userId);
            return service;
        }
    }
}