using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.DbLayer.Interfaces;
using CookBook.DbLayer.Models.Entities;

namespace CookBook.DbLayer.DataBase
{
    internal class RecipeRepository : RepositoryBase<Recipe>, IRecipeRepository
    {
        public RecipeRepository(DbContext context) : base(context)
        {
        }
    }
}
