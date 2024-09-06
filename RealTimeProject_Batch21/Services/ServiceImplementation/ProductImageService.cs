using RealTimeProject_Batch21.DAL.Interfaces;
using RealTimeProject_Batch21.DTO;
using RealTimeProject_Batch21.Models;

namespace RealTimeProject_Batch21.Services.ServiceImplementation
{
    public class ProductImageService : IProductImagesService
    {
        public IUnitOfWork _unitOfWork;
        public ProductImageService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateProductImages(ProductImages productImages)
        {
            if (productImages != null)
            {
                await _unitOfWork.ProductImageRepository.Add(productImages);
                var result = _unitOfWork.Save();
                if (result > 0)
                {
                    return true;
                }
                else { return false; }
            }
            return false;
        }

        public async Task<bool> DeleteProductImages(int productImageId)
        {
            if (productImageId > 0)
            {
                var empDetails = await _unitOfWork.ProductImageRepository.GetById(productImageId);

                if (empDetails != null)
                {
                    _unitOfWork.ProductImageRepository.delete(empDetails);
                    var result = _unitOfWork.Save();
                    if (result > 0)
                    {
                        return true;
                    }
                    else { return false; }
                }
            }
            return false;
        }

        public async Task<bool> UpdateProductImages(ProductImages productImages)
        {
            if (productImages != null)
            {
                var pro = await _unitOfWork.ProductImageRepository.GetById(productImages.ProductId);
                if (pro != null)
                {
                    //pro.Title = product.Title;
                    //pro.Description= product.Description;
                    //pro.Price = product.Price;
                    //pro.Author = product.Author;
                    //pro.ISBN = product.ISBN;
                    _unitOfWork.ProductImageRepository.update(pro);
                    var result = _unitOfWork.Save();
                    if (result > 0)
                    { return true; }
                    else { return false; }

                }
            }
            return false;
        }
    }
}
