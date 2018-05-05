using System;
using System.Data.Common;

namespace TWG.Authentication.Core.Database
{
    public static class DbParameterExt
    {
        public static DbParameter Clone(this DbParameter p)
        {
            ICloneable cloneableParameter = p as ICloneable;
            if (cloneableParameter != null)
            {
                return (DbParameter)cloneableParameter.Clone();
            }
            else
            {
                throw new NotSupportedException(String.Format("Unable to clone parameter {0}", p.ParameterName));
            }
        }
    }
}