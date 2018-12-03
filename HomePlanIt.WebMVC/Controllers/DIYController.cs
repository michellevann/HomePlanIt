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
    public class DIYController : Controller
    {
        // GET: DIY
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DIYService(userId);
            var model = service.GetDIYs();
            return View(model);
        }

        // GET
        public ActionResult Create()
        {
            {
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DIYCreate model)
        {
            if (!ModelState.IsValid) return View(model);
           
            var service = CreateDIYService();

            if (service.CreateDIY(model))
            {
                TempData["SaveResult"] = "Your project was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Project could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateDIYService();
            var model = svc.GetDIYById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateDIYService();
            var detail = service.GetDIYById(id);
            var model =
                new DIYEdit
                {
                    DIYId = detail.ProjectId,
                    ProjectName = detail.ProjectName,
                    StartDate = detail.StartDate,
                    EndDate = detail.EndDate,
                    BudgetedAmount = detail.BudgetedAmount,
                    FinalCost = detail.FinalCost
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, DIYEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.DIYId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateDIYService();

            if (service.UpdateDIY(model))
            {
                TempData["SaveResult"] = "Your project was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your project could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateDIYService();
            var model = svc.GetDIYById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateDIYService();

            service.DeleteDIY(id);

            TempData["SaveResult"] = "Your project was deleted.";

            return RedirectToAction("Index");
        }
        private DIYService CreateDIYService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new DIYService(userId);
            return service;
        }
    }
}