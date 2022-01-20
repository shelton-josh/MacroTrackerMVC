using MacroTracker.Data;
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
    public class MealController : Controller
    {        
        // GET: Food
        public ActionResult Index()
        {
            var service = CreateMealService();
            var model = service.GetMeals();

            return View(model);
        }

        // GET

        public ActionResult Create()
        {
            var service = CreateMealService();
            var starterModel = service.CreateGet();
            return View(starterModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MealCreate model)
        {
            var service = CreateMealService();
            if (!ModelState.IsValid)
                return View(model);

            if (service.CreateMeal(model))
            {
                TempData["SaveResult"] = "Your Meal was created.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Meal could not be created.");
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateMealService();
            var model = svc.GetMealById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateMealService();
            var detail = service.GetMealById(id);
            var model =
                new MealEdit
                {
                    MealId = detail.MealId,
                    MealName = detail.MealName,
                    IntakeDetail = detail.IntakeDetail,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, MealEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.MealId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateMealService();

            if (service.UpdateMeal(model))
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
            var svc = CreateMealService();
            var model = svc.GetMealById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateMealService();

            service.DeleteMeal(id);

            TempData["SaveResult"] = "Your Meal was deleted.";

            return RedirectToAction("Index");
        }

        private MealService CreateMealService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MealService(userId);
            return service;
        }
    }
}