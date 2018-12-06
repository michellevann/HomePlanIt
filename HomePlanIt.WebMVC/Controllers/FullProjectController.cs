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
    public class FullProjectController : Controller
    {
        // GET: FullProject
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FullProjectService(userId);
            var model = service.GetFullProjects();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            var diyService = CreateDIYService();
            var supplyService = CreateSupplyService();
            var roadblockService = CreateRoadblockService();

            ViewBag.DIYId = new SelectList(diyService.GetDIYs(), "DIYId", "ProjectName");
            ViewBag.SupplyId = new SelectList(supplyService.GetItems(), "SupplyId", "SupplyName");
            ViewBag.RoadblockId = new SelectList(roadblockService.GetRoadblocks(), "RoadblockId", "RoadblockName");
            
            return View();
        }

        private DIYService CreateDIYService()
        {
            return new DIYService(Guid.Parse(User.Identity.GetUserId()));
        }

        private SupplyService CreateSupplyService()
        {
            return new SupplyService(Guid.Parse(User.Identity.GetUserId()));
        }

        private RoadblockService CreateRoadblockService()
        {
            return new RoadblockService(Guid.Parse(User.Identity.GetUserId()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FullProjectCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var service = CreateFullProjectService();

            if (service.CreateFullProject(model))
            {
                ViewBag.SaveResult = "Your project was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Project could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateFullProjectService();
            var model = svc.GetFullProjectById(id);

            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var svc = CreateFullProjectService();
            var model = svc.GetFullProjectById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateFullProjectService();
            service.DeleteFullProject(id);
            TempData["SaveResult"] = "Your project was deleted.";
            return RedirectToAction("Index");
        }

        private FullProjectService CreateFullProjectService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FullProjectService(userId);
            return service;
        }
    }
}