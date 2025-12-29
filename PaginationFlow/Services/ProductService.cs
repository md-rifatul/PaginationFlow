using PaginationFlow.Pagination;
using PaginationFlow.Repository.IRepository;

namespace PaginationFlow.Services
{
    public class ProductService
    {
        private readonly IRepository<Product> _repository;

        public ProductService(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public PagedResult<Product> GetPagedProducts(int page, int pageSize)
        {
            return _repository.GetPaged(page, pageSize);
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return _repository.GetAll();
        }
    }
}
