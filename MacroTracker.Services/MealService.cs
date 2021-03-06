using MacroTracker.Data;
using MacroTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Services
{
    public class MealService
    {
        private readonly Guid _userId;

        public MealService(Guid userId)
        {
            _userId = userId;
        }

        public MealCreate CreateGet()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var starterModel = new MealCreate()
                {
                    DateTime = DateTime.Now,
                    Food = ctx.Foods.OrderBy(x => x.FoodName).Select(e => new FoodComponent
                    {
                        FoodId = e.FoodId,
                        FoodName = e.FoodName,
                        Serving = e.Serving,
                        Calories = e.Calories,
                        Proteins = e.Proteins,
                        Fats = e.Fats,
                        Carbs = e.Carbs,
                        Quantity = 0,
                    }).ToList(),
                };
                return starterModel;
            }
        }

        public bool CreateMeal(MealCreate model)
        {
            var entity =
                new Meal()
                {
                    MealName = model.MealName,
                    MealContent = model.MealContent,
                    DateTime = model.DateTime,
                    OwnerId = _userId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                int savedItems = 0;
                ctx.Meals.Add(entity);
                if (ctx.SaveChanges() == 1)
                {
                    foreach (var item in model.Food)
                    {
                        if (item.Quantity != 0)
                        {
                            var lastMeal = ctx.Meals.OrderByDescending(m => m.MealId).First();
                            var foodRelation = new Intake
                            {
                                OwnerId = _userId,
                                FoodId = item.FoodId,
                                MealId = lastMeal.MealId,
                                FoodQty = item.Quantity,
                            };
                            ++savedItems;
                            ctx.Intakes.Add(foodRelation);
                        }
                    }
                }
                return ctx.SaveChanges() == savedItems;
            }
        }

        public IEnumerable<MealListItem> GetMeals()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Meals
                        .Where(e => e.OwnerId == _userId)
                        .ToList()
                        .Select(
                            e =>

                                new MealListItem
                                {
                                    MealId = e.MealId,
                                    MealName = e.MealName,
                                    DateTime = e.DateTime,
                                    Calories = Decimal.ToInt32(e.Intake.Select(c => c.Food.Calories * c.FoodQty).Sum()),
                                    Proteins = (e.Intake.Select(c => c.Food.Proteins * c.FoodQty).Sum()),
                                    Carbs = (e.Intake.Select(c => c.Food.Carbs * c.FoodQty).Sum()),
                                    Fats = (e.Intake.Select(c => c.Food.Fats * c.FoodQty).Sum()),
                                }
                        );
                return query.ToArray();
            }
        }

        public MealDetail GetMealById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Meals
                        .Single(e => e.MealId == id && e.OwnerId == _userId);
                return
                    new MealDetail
                    {
                        MealId = entity.MealId,
                        MealName = entity.MealName,
                        MealContent = entity.MealContent,
                    };
            }
        }

        public bool UpdateMeal(MealEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Meals
                        .Single(e => e.MealId == model.MealId && e.OwnerId == _userId);

                entity.MealName = model.MealName;
                entity.MealContent = model.MealContent;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMeal(int mealId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Meals
                        .Single(e => e.MealId == mealId && e.OwnerId == _userId);

                ctx.Meals.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
