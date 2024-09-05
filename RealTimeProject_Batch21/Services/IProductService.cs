using RealTimeProject_Batch21.DTO;
using RealTimeProject_Batch21.Models;

namespace RealTimeProject_Batch21.Services
{
    public interface IProductService
    {
        Task<bool> CreateProduct(Product product);
        IEnumerable<ProductViewModel> GetAllProduct();
        Task<Product> GetProductById(int productId);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int productId);
    }
}
