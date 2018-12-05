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
            return View();
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