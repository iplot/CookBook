using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.DbLayer.Interfaces;
using CookBook.DbLayer.Models.Entities;

namespace CookBook.DbLayer.DataBase
{
    internal class HistoryRepository : RepositoryBase<RecipeHistory>, IRecipeHistoryRepository
    {
        public HistoryRepository(DbContext context) : base(context)
        {
        }
    }
}
