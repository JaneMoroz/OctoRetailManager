using ORMDataManager.Library.Models;
using System.Collections.Generic;

namespace ORMDataManager.Library.DataAccess
{
    public interface IProductData
    {
        ProductModel GetProductById(int productId);
        List<ProductModel> GetProducts();
    }
}