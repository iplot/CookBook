using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CookBook.Models
{
    public class RecipeVM
    {
        public int RecipeId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public int CookTime { get; set; }
        public List<IngredientVM> Ingredients { get; set; }
        public List<StepDescriptionVM> StepDetails { get; set; }
        public IEnumerable<RecipeVersionVM> Versions { get; set; }
    }

    public class RecipeVersionVM
    {
        public int VersionId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}