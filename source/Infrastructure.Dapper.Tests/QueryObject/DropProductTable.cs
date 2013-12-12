namespace Infrastructure.Dapper.Tests.QueryObject
{
    using Codeparts.Frameplate.Dapper;

    public class DropProductTable
    {
        public QueryObject Query()
        {
            return new QueryObject("drop table Product");
        }
    }
}