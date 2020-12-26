using SalesCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using SalesCore.Services.Exceptions;
using System.Linq;
using System.Threading.Tasks;

namespace SalesCore.Services
{
    public class SellerService
    {
        private readonly SalesCoreContext _context;

        public SellerService(SalesCoreContext context)
        {
            _context = context;
        }

        public async Task<List<Seller>> FindAllAsync() =>
            await _context.Seller.ToListAsync();

        public async Task InsertAsync(Seller seller)
        {
            _context.Add(seller);
            await _context.SaveChangesAsync();
        }

        public async Task<Seller> FindByIdAsync(int id) =>
            await _context.Seller.Include(seller => seller.Department)
            .FirstOrDefaultAsync(seller => seller.Id == id);

        public async Task RemoveAsync(int id)
        {
            try
            {
                var seller = await _context.Seller.FindAsync(id);
                _context.Seller.Remove(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                throw new IntegrityException("Can't delete a seller that's have valid Sales in our records.");
            }
        }

        public async Task UpdateAsync(Seller seller)
        {
            bool hasAny = await _context.Seller.AnyAsync(sellerInDb => sellerInDb.Id == seller.Id);
            if (!hasAny)
            {
                throw new NotFoundException("Id not found");
            }
            try
            {
                _context.Update(seller);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }

        }
    }
}
