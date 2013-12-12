namespace Infrastructure.Dapper.Tests.QueryObject
{
    using Codeparts.Frameplate.Dapper;

    public class DeleteProduct
    {
        public QueryObject All()
        {
            return new QueryObject("delete from Product");
        }
    }
}