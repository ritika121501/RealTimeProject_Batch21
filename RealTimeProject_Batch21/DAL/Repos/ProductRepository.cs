using Microsoft.EntityFrameworkCore;
using RealTimeProject_Batch21.DAL.Interfaces;
using RealTimeProject_Batch21.DTO;
using RealTimeProject_Batch21.Models;

namespace RealTimeProject_Batch21.DAL.Repos
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _context;
        public ProductRepository(ApplicationDbContext context) : base(context)
        { 
            _context = context;
        }

        //anonymous functions are types of delegates
        //if the new keyword is used , it is known as anonymous function
        //and if a types model is used along with new keyword it is known as Projections
        public IEnumerable<ProductViewModel> GetAllProductsWithCategory()
        {
            var query = _context.Product
                  .Join(
                      _context.Category,
                      p => p.CategoryId,
                      c => c.CategoryId,
                      (p, c) => new ProductViewModel
                      {
                          ProductId=p.ProductId,
                          Title = p.Title,
                          ISBN = p.ISBN,
                          Author = p.Author,
                          Price = p.Price,
                          CategoryName = c.Name
                      });
            return query.ToList();
        }

        //First and firstOrDefault
        public async Task<Product> GetProductDetailsWithProductImages(int productId)
        {
            var query = await _context.Product.Include(x=>x.ProductImages)
                       .FirstOrDefaultAsync(x => x.ProductId == productId);

            return query;
        }

        //This is important not part of real time project but a concept of
        //entity framework
        public async Task<List<Product>> GetAllProductWithFilters(int productId)
        {
            var query = await _context.Product
                .Include(x => x.ProductImages.Where(p => p.ProductImagesId > 4))
                .Include(x=>x.Category)
                .Where(x => x.ProductId == productId)
                .OrderByDescending(x => x.Title)
                .Take(1).ToListAsync();

            return query;
        }
    }
}
