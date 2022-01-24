using MacroTracker.Data;
using MacroTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Services
{
    public class MealIntakeService
    {
        private readonly Guid _userId;

        public MealIntakeService(Guid userId)
        {
            _userId = userId;
        }

        public MealIntakeCreate CreateGet()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var starterModel = new MealIntakeCreate()
                {

                };
                return starterModel;
            }
        }

        public bool MealIntakeCreate(MealIntakeCreate model)
        {
            var entity =
                new MealIntake()
                {
                    OwnerId = _userId,
                    MealId = model.MealId,
                    MealQty = (int)model.MealQty,
                    MealPlanId = model.MealPlanId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.MealIntakes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<MealIntakeListItem> GetMealIntakes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .MealIntakes
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new MealIntakeListItem
                                {
                                    MealIntakeId = e.MealIntakeId,
                                    MealId = e.MealId,
                                    MealQty = e.MealQty,
                                    MealPlanId = e.MealPlanId,
                                    Meal = e.Meal.MealName,
                                }
                        );
                return query.ToArray();
            }
        }

        public MealIntakeDetail GetMealIntakeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MealIntakes
                        .Single(e => e.MealIntakeId == id && e.OwnerId == _userId);
                return
                    new MealIntakeDetail
                    {
                        MealIntakeId = entity.MealIntakeId,
                        MealPlanId = entity.MealPlanId,
                        DateTime = entity.Meal.DateTime,
                        MealQty = entity.MealQty,
                        Meal = new MealListItem
                        {
                            MealId = entity.MealId,
                            MealName = entity.Meal.MealName,
                            Calories = entity.MealPlan.Calories,
                            Proteins = entity.MealPlan.Proteins,
                            Fats = entity.MealPlan.Fats,
                            Carbs = entity.MealPlan.Carbs,
                        }
                    };
            }
        }

        public bool UpdateMealIntake(MealIntakeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MealIntakes
                        .Single(e => e.MealIntakeId == model.MealIntakeId && e.OwnerId == _userId);

                entity.MealIntakeId = model.MealIntakeId;
                entity.MealPlanId = model.MealPlanId;
                entity.MealQty = model.MealIntakeQty;
                entity.MealId = model.MealId;
                
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteMealIntake(int mealintakeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .MealIntakes
                        .Single(e => e.MealIntakeId == mealintakeId && e.OwnerId == _userId);

                ctx.MealIntakes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}

