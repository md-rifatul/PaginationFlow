using Microsoft.AspNetCore.Mvc;
using PaginationFlow.Services;

namespace PaginationFlow.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public IActionResult Index(int page = 1)
        {
            int pageSize = 10;

            var products = _productService.GetPagedProducts(page, pageSize);

            return View(products);
        }

    }
}
