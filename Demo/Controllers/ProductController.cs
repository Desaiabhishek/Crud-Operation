using Demo.Command.Product;
using Demo.Modules;
using Demo.Modules.Comman;
using MediatR;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ISender _mediator;

        public ProductController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<Response> GetAllProducts()
        {
            return await _mediator.Send(new GetAllProduct { }).ConfigureAwait(true);
        }

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
