using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
namespace TWG.Authentication.Core.Database
{
    internal sealed class SqlAccessor
    {
        public static DataTable ExecuteQuery(string connectionString, string storedProc, ParameterCollection paramCollection)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                using (var adapter = new SqlDataAdapter(storedProc, connection))
                {
                    adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                    adapter.SelectCommand.CommandTimeout = 180;

                    foreach (var dbParameter in paramCollection)
                    {
                        adapter.SelectCommand.Parameters.Add(dbParameter);
                    }

                    var ds = new DataSet();
                    connection.Open();
                    adapter.Fill(ds);

                    return ds.Tables.Count > 0 ? ds.Tables[0] : null;
                }
            }
        }
    }
}