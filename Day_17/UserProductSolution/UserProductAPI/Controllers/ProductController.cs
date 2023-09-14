using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserProductAPI.Interfaces;
using UserProductAPI.Models;
using UserProductAPI.Models.DTOs;

namespace UserProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;



        public ProductController(IProductService service)
        {
            _service = service;
        }



        [Authorize]
        [HttpGet]
        public ActionResult Get()
        {
            var result = _service.GetAllProducts();
            if (result == null)
            {
                return NotFound("No products are there at this moment");
            }
            return Ok(result);
        }





        [HttpPost]
        public ActionResult Post(Product product)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var result = _service.AddANewProduct(product);
                    return Created("", result);
                }
                catch (Exception e)
                {
                    return BadRequest(e.Message);
                }
            }
            return BadRequest(ModelState.Keys);
        }





        [HttpPut("Price")]
        public ActionResult UpdatePrice(ProductPriceDTO priceDTO)
        {
            try
            {



                var result = _service.UpdatePrice(priceDTO);
                if (result == null)
                    return NotFound();
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }



        [HttpDelete]
        public ActionResult Delete(int id)
        {
            try
            {
                var result = _service.DeleteProduct(id);
                return Ok(result);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
