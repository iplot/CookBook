using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.DbLayer.Models.DTO;
using CookBook.DbLayer.Models.Entities;

namespace CookBook.DbLayer.Utils
{
    internal class DtoEntityRecipeConverter
    {
        internal Recipe DtoToEntity(RecipeDto recipeDto, Recipe recipeEntity)
        {
            //recipeEntity.Id = recipeDto.RecipeId;
            recipeEntity.Title = recipeDto.Title;
            recipeEntity.CookTime = recipeDto.CookTime;
            recipeEntity.CreationDate = recipeDto.CreationDate;
            recipeEntity.Description = recipeDto.Description;
            recipeEntity.Ingredients = IngredientsToSingleString(recipeDto.Ingredients);
            recipeEntity.StepDetails = StepDetailsToSingleString(recipeDto.Details);

            return recipeEntity;
        }

        internal RecipeDto EntityToDto(Recipe recipeEntity)
        {
            RecipeDto recipeDto = EntityToDtoBase(recipeEntity);
            recipeDto.RecipeId = recipeEntity.Id;
            recipeDto.Versions = recipeEntity.History
                .Select(x => new VersionDto {CreationDate = x.CreationDate, VersionId = x.Id})
                .ToList();

            return recipeDto;
        }

        internal RecipeDto EntityToDto(RecipeHistory recipeEntity)
        {
            RecipeDto recipeDto = EntityToDtoBase(recipeEntity);
            recipeDto.RecipeId = recipeEntity.RecipeId;
            recipeDto.Versions = null;

            return recipeDto;
        }

        #region Private Methods
        private RecipeDto EntityToDtoBase(RecipeBase recipeBase)
        {
            RecipeDto recipeDto = new RecipeDto
            {
                Title = recipeBase.Title,
                Description = recipeBase.Description,
                //CookTime = recipeBase.CookTime,
                CreationDate = recipeBase.CreationDate,
                Ingredients = IngredientsFromSingleString(recipeBase.Ingredients),
                Details = StepDetailsFromSingleString(recipeBase.StepDetails)
            };

            return recipeDto;
        }

        private string IngredientsToSingleString(IEnumerable<IngredientDto> ingredients)
        {
            return string.Join("#",
                ingredients.Select(x => string.Format("{0}&{1}&{2}", x.Amount, x.Measurement, x.Name))
            );
        }

        private string StepDetailsToSingleString(IEnumerable<RecipeStepDetailDto> steps)
        {
            return string.Join("#", steps.Select(x => x.Description));
        }

        private IList<IngredientDto> IngredientsFromSingleString(string ingredientsStr)
        {
            List<IngredientDto> ingredients = new List<IngredientDto>();

            foreach (var ingredientStr in ingredientsStr.Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries))
            {
                try
                {
                    string[] ingredientItems = ingredientsStr.Split(new string[] {"&"}, StringSplitOptions.None);
                    ingredients.Add(new IngredientDto
                    {
                        Amount = Double.Parse(ingredientItems[0]),
                        Measurement = ingredientItems[1],
                        Name = ingredientItems[2]
                    });
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(string.Format("Can't parse ingredient from DB string \r\n{0}\r\n{1}", ingredientStr, ex.Message));
                }
            }

            return ingredients;
        }

        private IList<RecipeStepDetailDto> StepDetailsFromSingleString(string detailsStr)
        {
            List<RecipeStepDetailDto> stepDetails = new List<RecipeStepDetailDto>();

            foreach (var detailStr in detailsStr.Split(new string[] { "#" }, StringSplitOptions.RemoveEmptyEntries))
            {
                try
                {
                    stepDetails.Add(new RecipeStepDetailDto
                    {
                        Description = detailsStr
                    });
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(string.Format("Can't parse recipe step detail from DB string\r\n{0}\r\n{1}", detailsStr, ex.Message));
                }
            }

            return stepDetails;
        }
        #endregion
    }
}
