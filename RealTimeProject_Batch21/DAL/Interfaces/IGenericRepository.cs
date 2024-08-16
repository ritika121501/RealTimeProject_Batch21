namespace RealTimeProject_Batch21.DAL.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        IEnumerable<T> GetAll();
        Task Add(T entity);
        void delete(T entity);
        void update(T entity);
    }
}
