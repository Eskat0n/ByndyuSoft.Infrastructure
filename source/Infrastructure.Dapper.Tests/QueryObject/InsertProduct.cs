﻿namespace Infrastructure.Dapper.Tests.QueryObject
{
    using Codeparts.Frameplate.Dapper;
    using Dto;

    public class InsertProduct
    {
        public QueryObject Query(ProductDto product)
        {
            return new QueryObject(@"insert into Product(Name) values (@Name);
                                     SELECT last_insert_rowid();", new {product.Name});
        }
    }
}