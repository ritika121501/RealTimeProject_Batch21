using RealTimeProject_Batch21.Models;

namespace RealTimeProject_Batch21.Services
{
    public interface IProductService
    {
        Task<bool> CreateProduct(Product product);
        IEnumerable<Product> GetAllProduct();
        Task<Product> GetProductById(int productId);
        Task<bool> UpdateProduct(Product product);
        Task<bool> DeleteProduct(int productId);
    }
}
