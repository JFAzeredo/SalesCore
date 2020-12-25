using SalesCore.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesCore.Services
{
    public class DepartmentService
    {
        readonly SalesCoreContext _context;


        public DepartmentService(SalesCoreContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(d => d.Name).ToList();
        }
    }

}
