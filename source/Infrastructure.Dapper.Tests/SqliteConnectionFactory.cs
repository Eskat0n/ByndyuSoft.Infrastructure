namespace Infrastructure.Dapper.Tests
{
    using System.Data;
    using System.Data.SQLite;
    using Codeparts.Frameplate.Dapper;

    public class SqliteConnectionFactory : IConnectionFactory
    {
        public IDbConnection Create(string connectionStringName = null)
        {
            IDbConnection dbConnection = new SQLiteConnection("Data Source=:memory:;pooling = true;");
            dbConnection.Open();
            return dbConnection;
        }
    }
}