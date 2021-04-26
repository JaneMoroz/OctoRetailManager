using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using ORMDataManager.Library.DataAccess;
using ORMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ORMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Cashier")]
    public class ProductController : ControllerBase
    {
        private readonly IProductData _productData;

        public ProductController(IProductData productData)
        {
            _productData = productData;
        }

        [HttpGet]
        public List<ProductModel> Get()
        {
            return _productData.GetProducts();
        }
    }
}
