using Microsoft.Extensions.Configuration;
using ORMDataManager.Library.Internal.DataAccess;
using ORMDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMDataManager.Library.DataAccess
{
    public class ProductData : IProductData
    {
        private readonly ISqlDataAccess _sql;

        public ProductData(ISqlDataAccess sql)
        {
            _sql = sql;
        }
        public List<ProductModel> GetProducts()
        {
            var output = _sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetAll", new { }, "ORMData");

            return output;
        }

        public ProductModel GetProductById(int productId)
        {
            var output = _sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetById", new { Id = productId }, "ORMData").FirstOrDefault();

            return output;
        }
    }
}
