using RealTimeProject_Batch21.DTO;
using RealTimeProject_Batch21.Models;

namespace RealTimeProject_Batch21.DAL.Interfaces
{
    public interface IOrderHeaderRepository : IGenericRepository<OrderHeader>
    {
        //interface - interfaces does not support access modifiers
        //interfaces can't method implemetation
        //C# 8 and above

        //OrderHeader Get(int userId);
    }
}
