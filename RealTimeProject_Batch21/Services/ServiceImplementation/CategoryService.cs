using RealTimeProject_Batch21.DAL.Interfaces;
using RealTimeProject_Batch21.Models;

namespace RealTimeProject_Batch21.Services.ServiceImplementation
{
    public class CategoryService : ICategoryService
    {
        public IUnitOfWork _unitOfWork;
        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> CreateCategory(Category category)
        {
            if (category != null)
            {
                await _unitOfWork.CategoryRepository.Add(category);
                var result = _unitOfWork.Save();
                if (result > 0)
                {
                    return true;
                }
                else { return false; }
            }
            return false;
        }

        public async Task<bool> DeleteCategory(int categoryId)
        {
            if (categoryId > 0)
            {
                var empDetails = await _unitOfWork.CategoryRepository.GetById(categoryId);

                if (empDetails != null)
                {
                    _unitOfWork.CategoryRepository.delete(empDetails);
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

        public  IEnumerable<Category> GetAllCategory()
        {
            var empDetailsList =  _unitOfWork.CategoryRepository.GetAll();
            return empDetailsList;
        }

        public async Task<Category> GetCategoryById(int categoryId)
        {
            if (categoryId > 0)
            {
                var empDetails = await _unitOfWork.CategoryRepository.GetById(categoryId);
                if (empDetails != null)
                {
                    return empDetails;
                }
            }
            return null;
        }

        public async Task<bool> UpdateCategory(Category category)
        {
            if (category != null)
            {
                var cat = await _unitOfWork.CategoryRepository.GetById(category.CategoryId);
                if (cat != null)
                {
                    cat.Name = category.Name;
                    cat.Description= category.Description;
                    _unitOfWork.CategoryRepository.update(cat);
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
