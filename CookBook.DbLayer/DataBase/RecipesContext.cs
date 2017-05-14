using System.Data.Entity;
using CookBook.DbLayer.Models.Entities;

namespace CookBook.DbLayer.DataBase
{
    internal class RecipesContext : DbContext
    {
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RecipeHistory> RecipesHistory { get; set; }
    }
}
