using RealTimeProject_Batch21.DTO;
using RealTimeProject_Batch21.Models;

namespace RealTimeProject_Batch21.Services
{
    public interface ICartService
    {
        Task<bool> CreateCart(ShoppingCart Cart);
        //IEnumerable<CartViewModel> GetAllCart();
        Task<ShoppingCart> GetCartById(int CartId);
        Task<bool> UpdateCart(ShoppingCart Cart);
        Task<bool> DeleteCart(int CartId);
    }
}
