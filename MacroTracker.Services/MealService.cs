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
                    Food = ctx.Foods.OrderBy(x => x.FoodName).Select(e => new FoodComponent
                    {
                        FoodId = e.FoodId,
                        FoodName = e.FoodName,
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
                return ctx.SaveChanges() == 1;
                if (ctx.SaveChanges() == 1)
                {
                    foreach (var item in model.Food)
                    {
                        if (item.Quantity != 0)
                        {
                            var lastIntake = ctx.Intakes.ToList();
                            var foodRelation = new Food
                            {
                                FoodId = lastIntake.Last().IntakeId,
                                FoodName = item.FoodName,
                            };
                    ++savedItems;
                    ctx.Foods.Add(foodRelation);
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
                        .Select(
                            e =>
                                new MealListItem
                                {
                                    MealId = e.MealId,
                                    MealName = e.MealName,
                                    Calories = (int)e.Intake.Select( c => c.Food.Calories * c.FoodQty).Sum()
                                }
                        );;
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
