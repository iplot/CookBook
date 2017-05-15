using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.Models;

namespace CookBook.Interfaces
{
    public interface IRecipeService
    {
        Task<IEnumerable<RecipeVM>> GetAllRecipes();
        Task<RecipeVM> GetRecipe(int id);
        Task<RecipeVM> GetRecipeVersion(int versionId);
    }
}
