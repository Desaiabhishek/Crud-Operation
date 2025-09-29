using Demo.Interfaces;
using Demo.Modules.Comman;
using MediatR;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace Demo.Command.Product
{
    public class GetAllProduct : IRequest<Response>
    {
        public class GetAllProductHandler : IRequestHandler<GetAllProduct,Response> 
        {
            readonly IDataDbContext _dbContext;
            public  GetAllProductHandler(IDataDbContext context)
            {
                _dbContext = context;
            }

            public async Task<Response> Handle(GetAllProduct request,CancellationToken cancellation)
            {
                Response resp = new();
                JObject ss = new();

                try
                {
                    var productData = _dbContext.Products.ToList();

                    if (productData != null && productData.Count > 0)
                    {
                        ss["Data"] = JToken.FromObject(productData);
                        resp.ResponseFlag = true;
                        resp.ResponseStatus = "Success";
                    }
                    else
                    {
                        resp.ResponseFlag = false;
                        resp.ResponseStatus = "Failed";
                        resp.ResponseMessage = "Product list not found.";
                    }
                }
                catch (Exception ex)
                {
                    resp.ResponseMessage = ex.Message;
                    resp.ResponseFlag = false;
                    resp.ResponseStatus = "Failed";
                }

                resp.ResponseObject = JsonConvert.SerializeObject(ss);
                return resp;
            }
        }


    }
}
