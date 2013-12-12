namespace ByndyuSoft.Infrastructure.Dapper
{
    using System.Configuration;
    using System.Data;
    using System.Data.Common;
    using System.Data.SqlClient;
    using StackExchange.Profiling;
    using StackExchange.Profiling.Data;

    /// <summary>
    ///     Create <see cref="IDbConnection" /> with <see cref="MiniProfiler" />
    /// </summary>
    public class ConnectionFactory : IConnectionFactory
    {
        public IDbConnection Create(string connectionStringName = null)
        {
            var connectionString = ConfigurationManager.ConnectionStrings[connectionStringName ?? "Main"];

            var sqlConnection = new SqlConnection(connectionString.ConnectionString);
            var dbConnection = MiniProfiler.Current == null
                ? (DbConnection) sqlConnection
                : new ProfiledDbConnection(sqlConnection, MiniProfiler.Current);

            dbConnection.Open();

            return dbConnection;
        }
    }
}