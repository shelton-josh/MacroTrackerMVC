using MacroTracker.Data;
using MacroTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Services
{
    public class IntakeService
    {
        private readonly Guid _userId;

        public IntakeService(Guid userId)
        {
            _userId = userId;
        }

        public IntakeCreate CreateGet()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var starterModel = new IntakeCreate()
                {
                    
                };
            return starterModel;
            }
        }

        public bool CreateIntake(IntakeCreate model)
        {
            var entity =
                new Intake()
                {
                    OwnerId = _userId,
                    MealId = model.MealId,
                    FoodQty = model.FoodQty,
                    FoodId = model.FoodId,
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Intakes.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<IntakeListItem> GetIntakes()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Intakes
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new IntakeListItem
                                {
                                    IntakeId = e.IntakeId,
                                    MealId = e.MealId,
                                    FoodQty = e.FoodQty,
                                    FoodId = e.FoodId,
                                    Food = e.Food.FoodName
                                }
                        );
                return query.ToArray();
            }
        }

        public IntakeDetail GetIntakeById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Intakes
                        .Single(e => e.IntakeId == id && e.OwnerId == _userId);
                return
                    new IntakeDetail
                    {
                        IntakeId = entity.IntakeId,
                        MealId = entity.MealId,
                        DateTime = entity.Meal.DateTime,
                        FoodQty = entity.FoodQty,
                        Food = new FoodListItem
                        {
                            FoodId = entity.FoodId,
                            FoodName = entity.Food.FoodName,
                            Calories = entity.Food.Calories,
                            Proteins = entity.Food.Proteins,
                            Fats = entity.Food.Fats,
                            Carbs = entity.Food.Carbs,
                        }
                    };
            }
        }

        public bool UpdateIntake(IntakeEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Intakes
                        .Single(e => e.IntakeId == model.IntakeId && e.OwnerId == _userId);

                entity.IntakeId = model.IntakeId;
                entity.MealId = model.MealId;
                entity.FoodQty = model.FoodQty;
                entity.FoodId = model.FoodId;
               
                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteIntake(int intakeId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Intakes
                        .Single(e => e.IntakeId == intakeId && e.OwnerId == _userId);

                ctx.Intakes.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
