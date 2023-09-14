using UserProductAPI.Interfaces;
using UserProductAPI.Models;
using UserProductAPI.Models.DTOs;



namespace UserProductAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<int, Product> _repository;



        public ProductService(IRepository<int, Product> repository)
        {
            _repository = repository;
        }
        public Product AddANewProduct(Product product)
        {
            return _repository.Add(product);
        }



        public Product DeleteProduct(int Id)
        {
            return _repository.Delete(Id);
        }



        public List<Product> GetAllProducts()
        {
            return _repository.GetAll();
        }



        public Product UpdatePrice(ProductPriceDTO product)
        {
            var myproduct = _repository.Get(product.Id);
            if (myproduct != null)
            {
                myproduct.Price = (float)product.Price;
                return _repository.Update(myproduct);
            }
            return null;
        }
    }
}