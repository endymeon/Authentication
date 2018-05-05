using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using TWG.Authentication.Core.Database;
using TWG.Authentication.Core.Enums;
using TWG.Authentication.Core.Models;
using TWG.Authentication.Core.Providers.Interfaces;

namespace TWG.Authentication.Core.Providers
{
    internal class UserProvider : IUserProvider
    {
        public User Get(string userName)
        {
            var param = new ParameterCollection();
            param.Add("@UserName", DbType.AnsiString, userName);

            var result = SqlAccessor.ExecuteQuery(DatabaseSetting.Authentication.ConnectionString, DatabaseSetting.Authentication.StoredProcedures.UsersSelectByUserName,
                param);

            return (result != null && result.Rows.Count > 0) ? ToUser(result.Rows[0]) : null;
        }

        public User GetById(int userId)
        {
            var param = new ParameterCollection();
            param.Add("@Id", DbType.Int32, userId);

            var result = SqlAccessor.ExecuteQuery(DatabaseSetting.Authentication.ConnectionString, DatabaseSetting.Authentication.StoredProcedures.UsersSelectByUserName,
                param);

            return (result != null && result.Rows.Count > 0) ? ToUser(result.Rows[0]) : null;
        }

        internal LoginInfo GetLoginInfo(int userId)
        {
            var param = new ParameterCollection();
            param.Add("@Id", DbType.Int32, userId);

            var result = SqlAccessor.ExecuteQuery(DatabaseSetting.Authentication.ConnectionString, DatabaseSetting.Authentication.StoredProcedures.UsersSelectByUserName,
                param);

            return (result != null && result.Rows.Count > 0) ? ToLoginInfo(result.Rows[0]) : null;
        }

        private User ToUser(DataRow dr)
        {
            return new User()
            {
                Id = Conversion.DBNullToInt32(dr["Id"]),
                UserName = Conversion.DBNullToString(dr["UserName"]),
                Status = (Status)Conversion.DBNullToInt16(dr["Status"]),
                CreatedDateTime = Conversion.DBNullToDateTime(dr["CreatedDateTime"]),
                CreatedBy = Conversion.DBNullToString(dr["CreatedBy"]),
                ModifiedDateTime = Conversion.DBNullToDateTime(dr["ModifiedDateTime"]),
                ModifiedBy = Conversion.DBNullToString(dr["ModifiedBy"]),
            };
        }
        private LoginInfo ToLoginInfo(DataRow dr)
        {
            return new LoginInfo()
            {
                Id = Conversion.DBNullToInt32(dr["Id"]),
                Salt = Conversion.DBNullToString(dr["Salt"]),
                Password = Conversion.DBNullToString(dr["Password"]),
                Status = (Status)Conversion.DBNullToInt16(dr["Status"]),
            };
        }
    }
}