using RealTimeProject_Batch21.DAL.Interfaces;
using RealTimeProject_Batch21.Models;

namespace RealTimeProject_Batch21.DAL.Repos
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context)
        { }
    }
}
