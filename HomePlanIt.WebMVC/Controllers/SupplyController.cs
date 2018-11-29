﻿using HomePlanIt.Models;
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
            var model = new SupplyListItem[0];
            return View(model);
        }
    }
}