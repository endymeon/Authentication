namespace TWG.Authentication.Core.Database
{
    public class DatabaseSetting
    {
        public class Authentication
        {
            public static string ConnectionString
            {
                get
                {
                    //TODO : read from file in specific folder
                    return @"Data Source=localhost\SQLEXPRESS;Initial Catalog=AUTHENTICATION;uid=test;pwd=test1234";
                }
            }

            public class StoredProcedures
            {
                public const string UsersSelectByUserName = "Users_Sel_By_UserName";
                public const string UsersSelectById = "Users_Sel_By_Id";
            }
        }
    }
}