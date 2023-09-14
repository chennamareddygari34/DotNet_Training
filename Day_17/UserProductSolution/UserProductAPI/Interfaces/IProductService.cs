using UserProductAPI.Models;
using UserProductAPI.Models.DTOs;



namespace UserProductAPI.Interfaces
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product AddANewProduct(Product product);
        Product UpdatePrice(ProductPriceDTO product);
        Product DeleteProduct(int Id);
    }
}