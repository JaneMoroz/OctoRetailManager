using ORMDesktopUI.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ORMDesktopUI.Library.API
{
    public interface IProductEndPoint
    {
        Task<List<ProductModel>> GetAll();
    }
}