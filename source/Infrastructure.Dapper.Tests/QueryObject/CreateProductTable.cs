﻿namespace Infrastructure.Dapper.Tests.QueryObject
{
    using Codeparts.Frameplate.Dapper;

    public class CreateProductTable
    {
        public QueryObject Query()
        {
            return new QueryObject(@"CREATE TABLE Product (
                                    Product_Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    Name varchar(255) NOT NULL)");
        }
    }
}