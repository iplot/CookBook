using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.DbLayer.Interfaces;

namespace CookBook.DbLayer.Models.Entities
{
    internal class RecipeHistory : RecipeBase, IEntity
    {
        [Key]
        public int Id { get; set; }
        
        public int RecipeId { get; set; }
        [ForeignKey("RecipeId")]
        public virtual Recipe Recipe { get; set; }
    }
}
