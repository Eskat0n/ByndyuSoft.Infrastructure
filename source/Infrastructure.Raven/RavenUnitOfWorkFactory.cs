namespace ByndyuSoft.Infrastructure.Raven.DB
{
    using System.Data;
    using Codeparts.Frameplate.Domain;
    using JetBrains.Annotations;

    [PublicAPI]
    public class RavenUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IRavenSessionFactory _sessionFactory;

        public RavenUnitOfWorkFactory(IRavenSessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public IUnitOfWork Create(IsolationLevel isolationLevel)
        {
            return Create();
        }

        public IUnitOfWork Create()
        {
            return new RavenUnitOfWork(_sessionFactory.OpenSession());
        }
    }
}