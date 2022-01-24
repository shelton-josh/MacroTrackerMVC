using MacroTracker.Data;
using MacroTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Services
{
    public class MealPlanService
    {
        private readonly Guid _userId;

        public MealPlanService(Guid userId)
        {
            _userId = userId;
        }

        public MealPlanCreate CreateGet()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var starterModel = new MealPlanCreate()
                {
                    DateTime = DateTime.Now,
                    Meal = ctx.Meals.OrderBy(x => x.MealName).Select(e => new MealComponent
                    {
                        MealId = e.MealId,
                        MealName = e.MealName,
                        Calories = (int)(e.Intake.Select(f => f.Food.Calories * f.FoodQty).Sum()),
                        Quantity = 0,
                    }).ToList(),
                };
                return starterModel;
            }
        }

        public bool CreateMealPlan(MealPlanCreate model)
        {
            var entity =
                new MealPlan()
                {
                    MealPlanName = model.MealPlanName,
                    MealPlanContent = model.MealPlanContent,
                    DateTime = model.DateTime,
                    OwnerId = _userId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                int savedItems = 0;
                ctx.MealPlans.Add(entity);
                if (ctx.SaveChanges() == 1)
                {
                    foreach (var item in model.Meal)
                    {
                        if (item.Quantity != 0)
                        {
                            var lastMealIntake = ctx.MealPlans.OrderByDescending(m => m.MealPlanId).First();
                            var mealRelation = new MealIntake
                            {
                                OwnerId = _userId,
                                MealId = item.MealId,
                                MealPlanId = lastMealIntake.MealPlanId,
                                MealQty = item.Quantity,
                            };
                            ++savedItems;
                            ctx.MealIntakes.Add(mealRelation);
                        }
                    }
                }
                return ctx.SaveChanges() == savedItems;
            }
        }

        public IEnumerable<MealPlanListItem> GetMealPlans()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .MealPlans
                        .Where(e => e.OwnerId == _userId)
                        .ToList()
                        .Select(
                            e =>

                                new MealPlanListItem
                                {
                                    MealPlanId = e.MealPlanId,
                                    MealPlanName = e.MealPlanName,
                                    DateTime = e.DateTime,
                                    TotalCalories = Decimal.ToInt32(e.MealIntake.Select(c => c.Meal.Intake.Select(f => f.Food.Calories * f.FoodQty).Sum() * c.MealQty).Sum()),
                                    TotalProteins = (e.MealIntake.Select(c => c.Meal.Intake.Select(f => f.Food.Proteins * f.FoodQty).Sum() * c.MealQty).Sum()),
                                    TotalCarbs = (e.MealIntake.Select(c => c.Meal.Intake.Select(f => f.Food.Fats * f.FoodQty).Sum() * c.MealQty).Sum()),
                                    TotalFats = (e.MealIntake.Select(c => c.Meal.Intake.Select(f => f.Food.Carbs * f.FoodQty).Sum() * c.MealQty).Sum()),
                                }
                        );
                return query.ToArray();
            }
        }
    }
}

