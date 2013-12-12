namespace ByndyuSoft.Infrastructure.Dapper
{
    using System.Data;
    using Codeparts.Frameplate.Domain;

    public abstract class DapperQueryBase<TCriterion, TResult> : IQuery<TCriterion, TResult>
        where TCriterion : ICriterion
    {
        private IDbConnection _connection;

        public IConnectionFactory ConnectionFactory { get; set; }

        protected IDbConnection Connection
        {
            get
            {
                if (_connection != null)
                    return _connection;

                return _connection = ConnectionFactory.Create();
            }
        }

        public abstract TResult Ask(TCriterion criterion);
    }
}