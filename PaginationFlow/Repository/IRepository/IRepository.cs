using PaginationFlow.Pagination;

namespace PaginationFlow.Repository.IRepository
{
    public interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();

        PagedResult<T> GetPaged(int pageNumber, int pageSize);

        T? GetById(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}
