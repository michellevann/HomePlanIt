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
    public class SupplyController : Controller
    {
        // GET: Item
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SupplyService(userId);
            var model = service.GetItems();
            return View(model);
        }

        //GET
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SupplyCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var service = CreateSupplyService();

            if (service.CreateSupply(model))
            {
                TempData["SaveResult"] = "Your item was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Item could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateSupplyService();
            var model = svc.GetItemById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateSupplyService();
            var detail = service.GetItemById(id);
            var model =
                new SupplyEdit
                {
                    SupplyId = detail.SupplyId,
                    SupplyName = detail.SupplyName,
                    Brand = detail.Brand,
                    Color = detail.Color,
                    Quantity = detail.Quantity,
                    TotalCost = detail.TotalCost,
                    AlreadyHave = detail.AlreadyHave
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SupplyEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.SupplyId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }
            var service = CreateSupplyService();

            if (service.UpdateSupply(model))
            {
                TempData["SaveResult"] = ("Your supply was updated.");
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your supply could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateSupplyService();
            var model = svc.GetItemById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateSupplyService();

            service.DeleteSupply(id);

            TempData["SaveResult"] = "Your supply was deleted.";

            return RedirectToAction("Index");
        }

        private SupplyService CreateSupplyService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SupplyService(userId);
            return service;
        }
    }
}