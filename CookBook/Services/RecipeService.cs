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
        private IUnitOfWork _unitOfWork;

        public RecipeService()
        {
            _recipeRepository = new PublicRecipeRepository(RecipeContextContainer.GetContext());
            _unitOfWork = new UnitOfWork(RecipeContextContainer.GetContext());
        }

        public RecipeService(IRecipePublicRepository recipeRepository, IUnitOfWork unitOfWork)
        {
            _recipeRepository = recipeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<RecipeVM>> GetAllRecipes()
        {
            var recipeDtos = await _recipeRepository.GetAllItems();

            return recipeDtos.OrderByDescending(x => x.CreationDate).Select(x => x.ToVM());
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

        public async Task<RecipeVM> SaveRecipe(RecipeVM recipeVm)
        {
            var recipeDto = recipeVm.ToDto();

            _recipeRepository.AddItem(recipeDto);
            await _unitOfWork.SubmitChanges();

            return recipeDto.ToVM();
        }
    }
}