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

        public bool CreateIntake(IntakeCreate model)
        {
            var entity =
                new Intake()
                {
                    OwnerId = _userId,
                    IntakeName = model.IntakeName,
                };

            using (var ctx = new ApplicationDbContext())
            {
                //int savedItems = 0;
                ctx.Intakes.Add(entity);
                return ctx.SaveChanges() == 1;
                //if (ctx.SaveChanges() == 1)
                /*{
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
                }*/
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
                                    IntakeName = e.IntakeName,
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
                        IntakeName = entity.IntakeName,
                        FoodDetail = entity.FoodDetail,
                        FoodQty = entity.FoodQty
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

                entity.IntakeName = model.IntakeName;
                entity.FoodDetail = model.FoodDetail;
                entity.FoodQty = model.FoodQty;
               
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
