using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.DbLayer.Interfaces;

namespace CookBook.DbLayer.Models.Entities
{
    internal class RecipeBase
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int CookTime { get; set; }   //in minutes
        public string Ingredients { get; set; }
        public string StepDetails { get; set; }
    }

    internal class Recipe : RecipeBase, IEntity
    {
        [Key]
        public int Id { get; set; }
        public virtual ICollection<RecipeHistory> History { get; set; }
    }
}
