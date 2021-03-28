using ORMDesktopUI.Library.Models;
using System.Threading.Tasks;

namespace ORMDesktopUI.Library.API
{
    public interface ISaleEndpoint
    {
        Task PostSale(SaleModel sale);
    }
}