using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.DbLayer.Models.Entities;

namespace CookBook.DbLayer.Interfaces
{
    internal interface IRecipeRepository : IGenericRepository<Recipe>
    {
    }
}
