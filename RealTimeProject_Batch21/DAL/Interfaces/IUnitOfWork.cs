namespace RealTimeProject_Batch21.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        ICategoryRespository CategoryRepository { get; }
        int Save();
    }
}
