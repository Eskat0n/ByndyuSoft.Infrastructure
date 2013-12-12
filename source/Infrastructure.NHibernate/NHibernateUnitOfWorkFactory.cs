namespace Codeparts.Frameplate.NHibernate
{
    using System.Data;
    using Domain;
    using global::NHibernate;
    using JetBrains.Annotations;

    ///<summary>
    ///</summary>
    [PublicAPI]
    public class NHibernateUnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly ISessionFactory _sessionSessionFactory;

        ///<summary>
        ///  ctor
        ///</summary>
        ///<param name="sessionFactory"> </param>
        public NHibernateUnitOfWorkFactory(ISessionFactory sessionFactory)
        {
            _sessionSessionFactory = sessionFactory;
        }

        #region IUnitOfWorkFactory Members

        public IUnitOfWork Create(IsolationLevel isolationLevel)
        {
            return new NHibernateUnitOfWork(_sessionSessionFactory.OpenSession(), isolationLevel);
        }

        public IUnitOfWork Create()
        {
            return Create(IsolationLevel.ReadCommitted);
        }

        #endregion
    }
}