using sqlapp.Models;

namespace sqlapp.Pages.Services
{
    public interface IProductService
    {
        List<Product> GetProducts();
    }
}