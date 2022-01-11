using MacroTracker.Data;
using MacroTracker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacroTracker.Services
{
    public class FoodService
    {
        private readonly Guid _userId;

        public FoodService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateFood(FoodCreate model)
        {
            var entity =
                new Food()
                {
                    OwnerId = _userId,
                    FoodName = model.FoodName,
                    Content = model.Content,
                    Calories = model.Calories,
                    Proteins = model.Proteins,
                    Fats = model.Fats,
                    Carbs = model.Carbs
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Foods.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<FoodListItem> GetFoods()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Foods
                        .Where(e => e.OwnerId == _userId)
                        .Select(
                            e =>
                                new FoodListItem
                                {
                                    FoodId = e.FoodId,
                                    FoodName = e.FoodName,
                                }
                        );
                return query.ToArray();
            }
        }

        public FoodDetail GetFoodById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Foods
                        .Single(e => e.FoodId == id && e.OwnerId == _userId);
                return
                    new FoodDetail
                    {
                        FoodId = entity.FoodId,
                        FoodName = entity.FoodName,
                        Content = entity.Content,
                        Calories = entity.Calories,
                        Proteins = entity.Proteins,
                        Fats = entity.Fats,
                        Carbs = entity.Carbs
                    };
            }
        }

        public bool UpdateFood(FoodEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Foods
                        .Single(e => e.FoodId == model.FoodId && e.OwnerId == _userId);

                entity.FoodName = model.FoodName;
                entity.Content = model.Content;
                entity.Calories = model.Calories;
                entity.Proteins = model.Proteins;
                entity.Fats = model.Fats;
                entity.Carbs = model.Carbs;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteFood(int foodId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Foods
                        .Single(e => e.FoodId == foodId && e.OwnerId == _userId);

                ctx.Foods.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
