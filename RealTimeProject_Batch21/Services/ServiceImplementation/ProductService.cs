using RealTimeProject_Batch21.DAL.Interfaces;
using RealTimeProject_Batch21.Models;

namespace RealTimeProject_Batch21.Services.ServiceImplementation
{
    public class ProductService : IProductService
    {
        public IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateProduct(Product product)
        {
            if (product != null)
            {
                await _unitOfWork.ProductRepository.Add(product);
                var result = _unitOfWork.Save();
                if (result > 0)
                {
                    return true;
                }
                else { return false; }
            }
            return false;
        }

        public async Task<bool> DeleteProduct(int productId)
        {
            if (productId > 0)
            {
                var empDetails = await _unitOfWork.ProductRepository.GetById(productId);

                if (empDetails != null)
                {
                    _unitOfWork.ProductRepository.delete(empDetails);
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

        public IEnumerable<Product> GetAllProduct()
        {
            var empDetailsList =  _unitOfWork.ProductRepository.GetAll();
            return empDetailsList;
        }

        public async Task<Product> GetProductById(int productId)
        {
            if (productId > 0)
            {
                var empDetails = await _unitOfWork.ProductRepository.GetById(productId);
                if (empDetails != null)
                {
                    return empDetails;
                }
            }
            return null;
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            if (product != null)
            {
                var pro = await _unitOfWork.ProductRepository.GetById(product.ProductId);
                if (pro != null)
                {
                    pro.Title = product.Title;
                    pro.Description= product.Description;
                    pro.Price = product.Price;
                    pro.Author = product.Author;
                    pro.ISBN = product.ISBN;
                    _unitOfWork.ProductRepository.update(pro);
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
