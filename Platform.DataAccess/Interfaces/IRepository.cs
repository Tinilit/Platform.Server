namespace Platform.DataAccess.Interfaces
{
    public interface IRepository<T>
    {
        // Basic DB Operations
        void Add(T entity);
        void Delete(T entity);
    }
}
