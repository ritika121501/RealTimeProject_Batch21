using RealTimeProject_Batch21.DTO;
using RealTimeProject_Batch21.Models;

namespace RealTimeProject_Batch21.DAL.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<ProductViewModel> GetAllProductsWithCategory();
        Task<Product> GetProductDetailsWithProductImages(int productId);
    }
}
