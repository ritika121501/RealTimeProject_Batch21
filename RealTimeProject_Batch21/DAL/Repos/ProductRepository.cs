using RealTimeProject_Batch21.DAL.Interfaces;
using RealTimeProject_Batch21.Models;

namespace RealTimeProject_Batch21.DAL.Repos
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
