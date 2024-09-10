using MvcDotnetGigs.Models;

namespace MvcDotnetGigs.Data.Services
{
    public class ListingsService : IListingsService
    {
        private readonly ApplicationDbContext _context;

        public ListingsService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task Add(Listing listing)
        {
            _context.Listings.Add(listing);
            await _context.SaveChangesAsync();
        }

        public IQueryable<Listing> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<Listing> GetById(int? id)
        {
            throw new NotImplementedException();
        }

        public Task SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
