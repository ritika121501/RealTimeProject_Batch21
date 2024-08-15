using RealTimeProject_Batch21.Models;

namespace RealTimeProject_Batch21.Services
{
    public interface IProductService
    {
        Task<bool> CreateProduct(Product employee);
        Task<IEnumerable<Product>> GetAllProduct();
        Task<Product> GetProductById(int employeeId);
        Task<bool> UpdateProduct(Product employee);
        Task<bool> DeleteProduct(int employeeId);
    }
}
