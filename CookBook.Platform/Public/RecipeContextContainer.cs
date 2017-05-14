using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CookBook.DbLayer.DataBase;

namespace CookBook.DbLayer.Public
{
    public static class RecipeContextContainer
    {
        private static RecipesContext _context = null;
        private static object _mutex = new object();

        public static DbContext GetContext()
        {
            if (_context == null)
            {
                lock (_mutex)
                {
                    if (_context == null)
                    {
                        _context = new RecipesContext();
                    }
                }
            }

            return _context;
        }

        public static void DisposeContext()
        {
            if (_context != null)
            {
                _context.Dispose();    
            }
        }
    }
}
