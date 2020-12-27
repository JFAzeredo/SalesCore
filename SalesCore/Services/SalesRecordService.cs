using SalesCore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesCore.Services
{
    public class SalesRecordService
    {
        private readonly SalesCoreContext _context;

        public SalesRecordService(SalesCoreContext context)
        {
            _context = context;
        }

        public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;
            if (minDate.HasValue)
            {
                result = result.Where(obj => obj.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(obj => obj.Date <= maxDate.Value);
            }
            return await result
                           .Include(obj => obj.Seller)
                           .Include(obj => obj.Seller.Department)
                           .OrderByDescending(obj => obj.Date)
                           .ToListAsync();
        }
    }
}
