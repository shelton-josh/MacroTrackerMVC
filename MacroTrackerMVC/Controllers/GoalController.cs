using MacroTracker.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MacroTrackerMVC.Controllers
{
    public class GoalController : Controller
    {

        private GoalService CreateIntakeService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GoalService(userId);
            return service;
        }

        // GET: Daily
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());

          

           return View();
        }
    }
}