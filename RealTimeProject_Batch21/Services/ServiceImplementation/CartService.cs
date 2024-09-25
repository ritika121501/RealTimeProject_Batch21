using Microsoft.EntityFrameworkCore.Query;
using RealTimeProject_Batch21.DAL.Interfaces;
using RealTimeProject_Batch21.DTO;
using RealTimeProject_Batch21.Models;



//Why dbContext is regostered as scoped but not singleton or Transient
//1) DbContext is not thread safe. it's a nature entity framework
//2)if we register as a  singleton. the same instance would nbe shared accross
//multiple request, we will concurrency issue.

//If it scoped, pne db request is not interfering with another db request. 
//Unit of work will not work as expected with singleton and changes of related entities are not saved will lead to
//inconsistent data

namespace RealTimeProject_Batch21.Services.ServiceImplementation
{
    public class CartService : ICartService
    {
        public IUnitOfWork _unitOfWork;
        public CartService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateCart(ShoppingCart Cart)
        {
            if (Cart != null)
            {
                await _unitOfWork.CartRepository.Add(Cart);
                var result = _unitOfWork.Save();
                if (result > 0)
                {
                    return true;
                }
                else { return false; }
            }
            return false;
        }

        public async Task<bool> DeleteCart(int CartId)
        {
            if (CartId > 0)
            {
               var prodDetails = await _unitOfWork.CartRepository.GetById(CartId);

                if (prodDetails != null)
                {
                    _unitOfWork.CartRepository.delete(prodDetails);
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

        //public IEnumerable<CartViewModel> GetAllCart()
        //{
        //    var empDetailsList =  _unitOfWork.CartRepository.GetAllCartsWithCategory();
        //    return empDetailsList;
        //}

        public async Task<ShoppingCart> GetCartById(int CartId)
        {
            if (CartId > 0)
            {
                var empDetails = await _unitOfWork.CartRepository.GetById(CartId);
                if (empDetails != null)
                {
                    return empDetails;
                }
            }
            return null;
        }

        public async Task<bool> UpdateCart(ShoppingCart Cart)
        {
            if (Cart != null)
            {
                var pro = await _unitOfWork.CartRepository.GetById(Cart.ShoppingCartId);
                if (pro != null)
                {
                    pro.Product= Cart.Product;
                    pro.Price = Cart.Price;
                    pro.Count = Cart.Count;
                    pro.ProductId = Cart.ProductId;
                    _unitOfWork.CartRepository.update(pro);
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
