using RealTimeProject_Batch21.DTO;
using RealTimeProject_Batch21.Models;

namespace RealTimeProject_Batch21.Services
{
    public interface IProductImagesService
    {
        Task<bool> CreateProductImages(ProductImages productImages);
        Task<bool> UpdateProductImages(ProductImages productImages);
        Task<bool> DeleteProductImages(int productImageId);
    }
}
