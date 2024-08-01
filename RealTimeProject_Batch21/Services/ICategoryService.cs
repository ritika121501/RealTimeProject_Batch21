using RealTimeProject_Batch21.Models;

namespace RealTimeProject_Batch21.Services
{
    public interface ICategoryService
    {
        Task<bool> CreateCategory(Category employee);
        Task<IEnumerable<Category>> GetAllCategory();
        Task<Category> GetCategoryById(int employeeId);
        Task<bool> UpdateCategory(Category employee);
        Task<bool> DeleteCategory(int employeeId);
    }
}
