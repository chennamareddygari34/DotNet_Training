using SupplierAndProductManagementApp.Models;
using SupplierAndProductManagementApp.Models.DTOs;

namespace SupplierAndProductManagementApp.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAllProducts();

        Product AddANewProduct(Product product);
        Product UpdatePrice(ProductPriceDTO product);

        Product ToggleProductStatus(int id);
    }
}
