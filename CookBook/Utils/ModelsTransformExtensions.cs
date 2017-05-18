using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using CookBook.DbLayer.Models.DTO;
using CookBook.Models;

namespace CookBook.Utils
{
    public static class ModelsTransformExtensions
    {
#region Recipe
        public static RecipeVM ToVM(this RecipeDto dto)
        {
            RecipeVM recipeVm = new RecipeVM
            {
                RecipeId = dto.RecipeId,
                Title = dto.Title.DecodeSpecialCharacters(),
                Description = dto.Description.DecodeSpecialCharacters(),
                CookTime = dto.CookTime,
                CreationTime = dto.CreationDate,
                Ingredients = dto.Ingredients.Select(x => x.ToVM()).ToList(),
                StepDetails = dto.Details.Select(x => x.ToVM()).ToList(),
                Versions = dto.Versions != null ? dto.Versions.Select(x => x.ToVM()).ToList() : null
            };

            return recipeVm;
        }

        public static RecipeDto ToDto(this RecipeVM vm)
        {
            RecipeDto dto = new RecipeDto
            {
                RecipeId = vm.RecipeId,
                Description = vm.Description.CleanFromHTML().EncodeSpecialCharacters(),
                CreationDate = DateTime.UtcNow,
                Title = vm.Title.CleanFromHTML().EncodeSpecialCharacters(),
                CookTime = vm.CookTime,
                Versions = null,
                Details = vm.StepDetails.Select(x => x.ToDto()).ToList(),
                Ingredients = vm.Ingredients.Select(x => x.ToDto()).ToList()
            };

            return dto;
        }
#endregion

#region Ingredient
        public static IngredientVM ToVM(this IngredientDto dto)
        {
            IngredientVM ingredientVm = new IngredientVM
            {
                Name = dto.Name.DecodeSpecialCharacters(),
                Amount = dto.Amount,
                Measurements =dto.Measurement.DecodeSpecialCharacters()
            };

            return ingredientVm;
        }

        public static IngredientDto ToDto(this IngredientVM vm)
        {
            IngredientDto dto = new IngredientDto
            {
                Name = vm.Name.CleanFromHTML().EncodeSpecialCharacters(),
                Measurement = vm.Measurements.CleanFromHTML().EncodeSpecialCharacters(),
                Amount = vm.Amount
            };

            return dto;
        }
#endregion

#region StepDetails
        public static StepDescriptionVM ToVM(this RecipeStepDetailDto dto)
        {
            StepDescriptionVM stepDescriptionVm = new StepDescriptionVM
            {
                Description = dto.Description.DecodeSpecialCharacters()
            };

            return stepDescriptionVm;
        }

        public static RecipeStepDetailDto ToDto(this StepDescriptionVM vm)
        {
            RecipeStepDetailDto dto = new RecipeStepDetailDto
            {
                Description = vm.Description.CleanFromHTML().EncodeSpecialCharacters()
            };

            return dto;
        }
#endregion

        public static RecipeVersionVM ToVM(this VersionDto dto)
        {
            RecipeVersionVM versionVm = new RecipeVersionVM
            {
                CreationDate = dto.CreationDate,
                VersionId = dto.VersionId
            };

            return versionVm;
        }
    }
}