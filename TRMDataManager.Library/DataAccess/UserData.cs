using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TRMDataManager.Library.Internal.DataAccess;
using TRMDataManager.Library.Internal.Models;

namespace TRMDataManager.Library.DataAccess
{
    public class UserData
    {
        public List<UserModel> GetUserById(string Id)
        {
            SqlDataAccess sql = new SqlDataAccess();
            var parameters = new { Id = Id };

            var output = sql.LoadData<UserModel, dynamic>("dbo.spUserLookUp",
                                                          parameters,
                                                          "TRMData");
            return output;
        }
    }
}
