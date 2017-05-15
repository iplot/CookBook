using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using CookBook.DbLayer.Interfaces;
using CookBook.DbLayer.Public;
using CookBook.Interfaces;
using CookBook.Models;
using CookBook.Utils;

namespace CookBook.Services
{
    public class RecipeService : IRecipeService
    {
        private IRecipePublicRepository _recipeRepository;

        public RecipeService()
        {
            _recipeRepository = new PublicRecipeRepository(RecipeContextContainer.GetContext());
        }

        public RecipeService(IRecipePublicRepository recipeRepository)
        {
            _recipeRepository = recipeRepository;
        }

        public async Task<IEnumerable<RecipeVM>> GetAllRecipes()
        {
            var recipeDtos = await _recipeRepository.GetAllItems();

            return recipeDtos.Select(x => x.ToVM());
        }

        public async Task<RecipeVM> GetRecipe(int id)
        {
            var recipeDto = await _recipeRepository.GetItemAsync(id);

            return recipeDto.ToVM();
        }

        public async Task<RecipeVM> GetRecipeVersion(int versionId)
        {
            var recipeDto = await _recipeRepository.GetPreviousVersion(versionId);

            return recipeDto.ToVM();
        }
    }
}