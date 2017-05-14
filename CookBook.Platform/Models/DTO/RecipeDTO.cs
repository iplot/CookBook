using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.DbLayer.Models.DTO
{
    public class RecipeDto
    {
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int CookTime { get; set; }   //in minutes
        public ICollection<IngredientDto> Ingredients { get; set; }
        public ICollection<RecipeStepDetailDto> Details { get; set; }
        public ICollection<VersionDto> Versions { get; set; }
    }

    //Only for get methods
    public class VersionDto
    {
        public int VersionId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
