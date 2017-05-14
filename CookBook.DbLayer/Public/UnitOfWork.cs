using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookBook.DbLayer.Public
{
    public class UnitOfWork
    {
        private DbContext _context;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public async Task SubmitChanges()
        {
            if (_context != null)
            {
                await _context.SaveChangesAsync();
            }
        } 
    }
}
