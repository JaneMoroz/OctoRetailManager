using ORMDataManager.Library.Models;
using System.Collections.Generic;

namespace ORMDataManager.Library.DataAccess
{
    public interface IUserData
    {
        List<UserModel> GetUserById(string Id);
    }
}