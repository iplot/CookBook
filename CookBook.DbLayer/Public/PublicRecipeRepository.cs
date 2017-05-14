using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using CookBook.DbLayer.DataBase;
using CookBook.DbLayer.Interfaces;
using CookBook.DbLayer.Models.DTO;
using CookBook.DbLayer.Models.Entities;
using CookBook.DbLayer.Utils;

namespace CookBook.DbLayer.Public
{
    public class PublicRecipeRepository : IRecipePublicRepository
    {
        private IRecipeRepository _recipeRepository;
        private IRecipeHistoryRepository _historyRepository;

        private DtoEntityRecipeConverter _converter;

        public PublicRecipeRepository(DbContext context)
        {
            _recipeRepository = new RecipeRepository(context);
            _historyRepository = new HistoryRepository(context);

            _converter = new DtoEntityRecipeConverter();
        }

        public async Task<List<RecipeDto>> GetAllItems()
        {
            Func<Recipe, object> includeHistory = x => x.History;
            var recipes = await _recipeRepository
                .GetEntities(null, x => x.History)
                .ToListAsync();

            return recipes
                .Select(x => _converter.EntityToDto(x))
                .ToList();
        }

        public RecipeDto GetItem(int id)
        {
            Recipe recipe = _recipeRepository.GetEntity(id);
            recipe.History = _historyRepository.GetEntities(x => x.RecipeId == id)
                .ToList();

            return _converter.EntityToDto(recipe);
        }

        public async Task<RecipeDto> GetItemAsync(int id)
        {
            Recipe recipe = await _recipeRepository.GetEntityAsync(id);
            recipe.History = await _historyRepository.GetEntities(x => x.RecipeId == id)
                .ToListAsync();

            return _converter.EntityToDto(recipe);
        }

        public void AddItem(RecipeDto entity)
        {
            Recipe recipe = GetEntityToAdd(entity);

            _recipeRepository.AddEntityToContext(recipe);
        }

        public async Task<int> PushItem(RecipeDto entity)
        {
            Recipe recipe = GetEntityToAdd(entity);

            return await _recipeRepository.AddEntityAndSubmit(recipe);
        }

        public async Task<RecipeDto> GetPreviousVersion(int versionId)
        {
            var recipeHistoryVersion = await _historyRepository.GetEntityAsync(versionId);

            return _converter.EntityToDto(recipeHistoryVersion);
        }

        #region Private Methods
        private Recipe GetEntityToAdd(RecipeDto dto)
        {
            Recipe recipe = dto.RecipeId == 0 ? new Recipe() : _recipeRepository.GetEntity(dto.RecipeId);
            recipe = _converter.DtoToEntity(dto, recipe);

            return recipe;
        }
        #endregion
    }
}
