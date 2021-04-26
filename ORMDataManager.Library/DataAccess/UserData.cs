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
    public class UserData : IUserData
    {
        private readonly ISqlDataAccess _sql;

        public UserData()
        {

        }
        public UserData(ISqlDataAccess sql)
        {
            _sql = sql;
        }
        public List<UserModel> GetUserById(string Id)
        {

            var output = _sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", new { Id }, "ORMData");

            return output;
        }
    }
}
