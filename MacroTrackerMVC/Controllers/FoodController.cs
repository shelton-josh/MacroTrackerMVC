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
    public class FoodController : Controller
    {
        // GET: Food
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FoodService(userId);
            var model = service.GetFoods();

            return View(model);
        }

        // GET

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FoodCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateFoodService();

            if (service.CreateFood(model))
            {
                TempData["SaveResult"] = "Your food was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Food could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateFoodService();
            var model = svc.GetFoodById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateFoodService();
            var detail = service.GetFoodById(id);
            var model =
                new FoodEdit
                {
                    FoodId = detail.FoodId,
                    FoodName = detail.FoodName,
                    Content = detail.Content,
                    Calories = detail.Calories,
                    Proteins = detail.Proteins,
                    Fats = detail.Fats,
                    Carbs = detail.Carbs
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FoodEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.FoodId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateFoodService();

            if (service.UpdateFood(model))
            {
                TempData["SaveResult"] = "Your food was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your food could not be updated.");
            return View(model);
        }

        private FoodService CreateFoodService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new FoodService(userId);
            return service;
        }
    }
}