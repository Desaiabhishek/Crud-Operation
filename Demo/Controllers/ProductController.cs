using Demo.Modules;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public static List<Product> _products = new List<Product>();

        [HttpGet]
        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }

        [HttpGet]
        public Product GetProductbyId(int id)
        {
            Product product = _products.Where(x => x.Id == id).FirstOrDefault();

            return product;
        }

        [HttpPost]

        public string UpsertProduct(Product objreq)
        {
            string res = "";
            try
            {
                if (objreq != null)
                {

                    _products.Add(objreq);

                    res = "Product saved.";
                }
                else
                {
                    res = "Bad request.";
                }
            }
            catch (Exception ex)
            {
                res = ex.Message;
            }

            return res;
        }

    }
}
