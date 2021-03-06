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
    public class MealPlanController : Controller
    {
        // GET: Meal
        public ActionResult Index()
        {
            var service = CreateMealPlanService();
            var model = service.GetMealPlans();

            return View(model);
        }

        //GET

        public ActionResult Create()
        {
            var service = CreateMealPlanService();
            var starterModel = service.CreateGet();
            return View(starterModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MealPlanCreate model)
        {
            var service = CreateMealPlanService();
            if (!ModelState.IsValid)
                return View(model);

            if (service.CreateMealPlan(model))
            {
                TempData["SaveResult"] = "Your Meal was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Meal could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateMealPlanService();
            var model = svc.GetMealPlanById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateMealPlanService();
            var detail = service.GetMealPlanById(id);
            var model =
                new MealPlanEdit
                {
                    MealPlanId = detail.MealPlanId,
                    MealPlanName = detail.MealPlanName,
                    MealIntakeDetail = detail.MealIntakeDetail,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MealPlanEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MealPlanId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateMealPlanService();

            if (service.UpdateMealPlan(model))
            {
                TempData["SaveResult"] = "Your Meal Plan was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your Meal Plan could not be updated.");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateMealPlanService();
            var model = svc.GetMealPlanById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateMealPlanService();

            service.DeleteMealPlan(id);

            TempData["SaveResult"] = "Your Meal Plan was deleted.";

            return RedirectToAction("Index");
        }

        private MealPlanService CreateMealPlanService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MealPlanService(userId);
            return service;
        }
    }
}