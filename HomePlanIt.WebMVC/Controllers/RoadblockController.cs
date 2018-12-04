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

        public ActionResult Edit(int id)
        {
            var service = CreateRoadblockService();
            var detail = service.GetRoadblockById(id);
            var model = new RoadblockEdit
            {
                RoadblockId = detail.RoadblockId,
                RoadblockName = detail.RoadblockName,
                IsComplete = detail.IsComplete,
                Plan = detail.Plan
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RoadblockEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.RoadblockId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateRoadblockService();

            if (service.UpdateRoadblock(model))
            {
                TempData["SaveResult"] = "Your roadblock was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your roadblock could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRoadblockService();
            var model = svc.GetRoadblockById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateRoadblockService();

            service.DeleteRoadblock(id);

            TempData["SaveResult"] = "Your roadblock was deleted.";

            return RedirectToAction("Index");
        }

        private RoadblockService CreateRoadblockService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RoadblockService(userId);
            return service;
        }
    }
}