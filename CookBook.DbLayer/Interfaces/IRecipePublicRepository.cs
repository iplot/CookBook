using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.DbLayer.Models.DTO;

namespace CookBook.DbLayer.Interfaces
{
    public interface IRecipePublicRepository
    {
        Task<List<RecipeDto>> GetAllItems();
        RecipeDto GetItem(int id);
        Task<RecipeDto> GetItemAsync(int id);
        void AddItem(RecipeDto recipe);
        Task<int> PushItem(RecipeDto recipe);
        Task<RecipeDto> GetPreviousVersion(int versionId);
    }
}
