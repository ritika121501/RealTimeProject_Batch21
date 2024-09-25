using Microsoft.EntityFrameworkCore;
using RealTimeProject_Batch21.DAL.Interfaces;
using RealTimeProject_Batch21.DTO;
using RealTimeProject_Batch21.Models;

namespace RealTimeProject_Batch21.DAL.Repos
{
    public class CartRepository : GenericRepository<ShoppingCart>, ICartRepository
    {
        private readonly ApplicationDbContext _context;
        public CartRepository(ApplicationDbContext context) : base(context)
        { 
            _context = context;
        }
    }
}
