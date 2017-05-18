using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CookBook.DbLayer.Models.Entities;

namespace CookBook.DbLayer.DataBase
{
    internal class RecipesContext : DbContext
    {
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RecipeHistory> RecipesHistory { get; set; }

        public override Task<int> SaveChangesAsync()
        {
            var modifiedEntries = ChangeTracker.Entries().Where(x => x.State == EntityState.Modified);

            foreach (var modifiedEntry in modifiedEntries.Where(x => x.Entity.GetType() == typeof(Recipe)))
            {
                RecipeHistory history = CreateHistoryRecord(modifiedEntry.Entity as Recipe, modifiedEntry);
                if (history != null)
                {
                    RecipesHistory.Add(history);
                }
            }

            return base.SaveChangesAsync();
        }

        private RecipeHistory CreateHistoryRecord(Recipe recipe, DbEntityEntry modifiedEntry)
        {
            RecipeHistory history = null;

            try
            {
                history = new RecipeHistory
                {
                    RecipeId = recipe.Id,
                    Title = modifiedEntry.OriginalValues["Title"].ToString(),
                    CookTime = (int)modifiedEntry.OriginalValues["CookTime"],
                    Description = modifiedEntry.OriginalValues["Description"].ToString(),
                    Ingredients = modifiedEntry.OriginalValues["Ingredients"].ToString(),
                    StepDetails = modifiedEntry.OriginalValues["StepDetails"].ToString(),
                    CreationDate = (DateTime)modifiedEntry.OriginalValues["CreationDate"]
                };
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Failed to create history record");
            }

            return history;
        }
    }
}
