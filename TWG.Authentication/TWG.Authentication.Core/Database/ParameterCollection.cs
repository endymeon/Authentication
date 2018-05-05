using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;

namespace TWG.Authentication.Core.Database
{
    public class ParameterCollection : List<DbParameter>
    {
        /// <summary>
        /// Default constructor, default withReturnValue to false.
        /// </summary>
        private DbProviderFactory _dbProviderFactory;

        public ParameterCollection()
            : this(false)
        {
            _dbProviderFactory = SqlClientFactory.Instance;
        }

        public ParameterCollection(DbProviderFactory dbProviderFactory)
            : this(false)
        {
            _dbProviderFactory = dbProviderFactory;
        }

        /// <summary>
        /// Overloaded constructor, create Return Value parameter.
        /// </summary>
        /// <param name="withReturnValue">Set true to create Return Value parameter.</param>
        public ParameterCollection(bool withReturnValue)
        {
            if (withReturnValue && _dbProviderFactory == null)
                _dbProviderFactory = SqlClientFactory.Instance;

            if (withReturnValue && _dbProviderFactory == SqlClientFactory.Instance)
            {
                DbParameter p = new SqlParameter();
                p.ParameterName = "@RETURN_VALUE";
                p.DbType = DbType.Int32;
                p.Size = 4;

                p.Direction = ParameterDirection.ReturnValue;
                this.Add(p);
                return;
            }

            if (_dbProviderFactory != null)
                throw new NotImplementedException();
        }

        /// <summary>
        /// Add parameter
        /// </summary>
        /// <param name="parameterName"></param>
        /// <param name="type"></param>
        /// <param name="size"></param>
        /// <param name="direction"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public DbParameter Add(string parameterName, DbType type, int size, ParameterDirection direction, object value)
        {
            var p = _dbProviderFactory.CreateParameter();
            p.ParameterName = parameterName;
            p.Direction = direction;
            p.DbType = type;
            p.Value = value ?? DBNull.Value;
            if (size > 0)
            {
                p.Size = size;
            }
            this.Add(p);
            return p;
        }

        public DbParameter Add(string parameterName, DbType type, int size, object value)
        {
            return Add(parameterName, type, size, ParameterDirection.Input, value);
        }

        public DbParameter Add(string parameterName, DbType type, object value)
        {
            return Add(parameterName, type, 0, ParameterDirection.Input, value);
        }

        public DbParameter Add(string parameterName, object value)
        {
            return AddParameter(parameterName, 0, ParameterDirection.Input, value);
        }

        public DbParameter Add(string parameterName, ParameterDirection direction, object value)
        {
            return AddParameter(parameterName, 0, direction, value);
        }

        private DbParameter AddParameter(string parameterName, Int32 size, ParameterDirection direction, object value)
        {
            var p = _dbProviderFactory.CreateParameter();
            p.ParameterName = parameterName;
            p.Size = size;
            p.Direction = direction;
            p.Value = value == null ? DBNull.Value : value;
            this.Add(p);
            return p;
        }

        public DbParameter AddOutput(string parameterName, DbType type, int size)
        {
            return Add(parameterName, type, size, ParameterDirection.Output, DBNull.Value);
        }

        public ParameterCollection Clone()
        {
            ParameterCollection col = new ParameterCollection();

            foreach (DbParameter p in this)
            {
                col.Add((DbParameter)p.Clone());
            }

            return col;
        }

        public new DbParameter this[int index]
        {
            get { return base[index]; }
        }

        public DbParameter this[string parameterName]
        {
            get { return this.Where(p => p.ParameterName == parameterName).SingleOrDefault(); }
        }

    }
}