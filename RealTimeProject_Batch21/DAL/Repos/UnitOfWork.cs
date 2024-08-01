using RealTimeProject_Batch21.DAL.Interfaces;

namespace RealTimeProject_Batch21.DAL.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public ICategoryRespository CategoryRepository { get; }

        public UnitOfWork(ApplicationDbContext context, ICategoryRespository categoryRepository)
        {
            _context = context;
            CategoryRepository = categoryRepository;
        }
        public int Save()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
