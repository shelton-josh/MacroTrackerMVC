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
    public class MealIntakeController : Controller
    {

        public ActionResult Index()
        {
            var service = CreateMealIntakeService();
            var model = service.GetMealIntakes();

            return View(model);
        }

        // GET

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MealIntakeCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateMealIntakeService();

            if (service.MealIntakeCreate(model))
            {
                TempData["SaveResult"] = "Your Intake was created.";
                return RedirectToAction("Index");
            };

            ModelState.AddModelError("", "Intake could not be created.");
            return View(model);
        }

        //public ActionResult Details(int id)
        //{
        //    var svc = CreateMealIntakeService();
        //    var model = svc.GetMealIntakeById(id);

        //    return View(model);
        //}

        //public ActionResult Edit(int id)
        //{
        //    var service = CreateMealIntakeService();
        //    var detail = service.GetMealIntakeById(id);
        //    var model =
        //        new MealIntakeEdit
        //        {
        //            IntakeId = detail.IntakeId,
        //            MealId = detail.MealId,
        //            FoodId = detail.Food.FoodId,
        //            FoodQty = detail.FoodQty,
        //        };
        //    return View(model);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IntakeEdit model)
        //{
        //    if (!ModelState.IsValid) return View(model);

        //    if (model.IntakeId != id)
        //    {
        //        ModelState.AddModelError("", "Id Mismatch");
        //        return View(model);
        //    }

        //    var service = CreateIntakeService();

        //    if (service.UpdateIntake(model))
        //    {
        //        TempData["SaveResult"] = "Your Meal was updated.";
        //        return RedirectToAction("Index");
        //    }

        //    ModelState.AddModelError("", "Your Meal could not be updated.");
        //    return View(model);
        //}

        //[ActionName("Delete")]
        //public ActionResult Delete(int id)
        //{
        //    var svc = CreateIntakeService();
        //    var model = svc.GetIntakeById(id);

        //    return View(model);
        //}

        //[HttpPost]
        //[ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public ActionResult DeletePost(int id)
        //{
        //    var service = CreateIntakeService();

        //    service.DeleteIntake(id);

        //    TempData["SaveResult"] = "Your Meal was deleted.";

        //    return RedirectToAction("Index");
        //}

        private MealIntakeService CreateMealIntakeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new MealIntakeService(userId);
            return service;
        }
    } 
}