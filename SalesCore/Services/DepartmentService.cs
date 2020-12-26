using SalesCore.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesCore.Services
{
    public class DepartmentService
    {
        readonly SalesCoreContext _context;


        public DepartmentService(SalesCoreContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync() =>
            await _context.Department.OrderBy(d => d.Name).ToListAsync();
    }

}
