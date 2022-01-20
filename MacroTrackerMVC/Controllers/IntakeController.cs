﻿using MacroTracker.Data;
using MacroTracker.Models;
using MacroTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MacroTrackerMVC.Controllers
{
    [Authorize]
    public class IntakeController : Controller
    {

        public IEnumerable<SelectListItem> GetFoods()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var Service = new FoodService(userId);
            var List = Service.GetFoods();

            var SelectList = List.Select(
                                        e =>
                                            new SelectListItem
                                            {
                                                Value = e.FoodId.ToString(),
                                                Text = e.FoodName
                                            }
                                        ).ToList();
            return SelectList;
        }
        
        // GET: Food
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new IntakeService(userId);
            var model = service.GetIntakes();

            return View(model);
        }

        // GET

        public ActionResult Create()
        {
            return View();
            //var starterModel = Service().CreateGet();
            //return View(starterModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IntakeCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateIntakeService();

            if (service.CreateIntake(model))
            //if (Service().CreateIntake(model))
            {
                TempData["SaveResult"] = "Your Intake was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Intake could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateIntakeService();
            var model = svc.GetIntakeById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateIntakeService();
            var detail = service.GetIntakeById(id);
            var model =
                new IntakeEdit
                {
                    IntakeId = detail.IntakeId,
                    IntakeName = detail.IntakeName,
                    FoodDetail = detail.FoodDetail,
                    FoodQty = detail.FoodQty,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IntakeEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.IntakeId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateIntakeService();

            if (service.UpdateIntake(model))
            {
                TempData["SaveResult"] = "Your Meal was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Meal could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateIntakeService();
            var model = svc.GetIntakeById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateIntakeService();

            service.DeleteIntake(id);

            TempData["SaveResult"] = "Your Meal was deleted.";

            return RedirectToAction("Index");
        }

        private IntakeService CreateIntakeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new IntakeService(userId);
            return service;
        }
    }
}