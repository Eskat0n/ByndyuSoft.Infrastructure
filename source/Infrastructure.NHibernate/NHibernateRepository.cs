namespace Codeparts.Frameplate.NHibernate
{
    using Domain;
    using JetBrains.Annotations;

    /// <summary>
    ///   ����������� ����������� ��� NHibernate
    /// </summary>
    /// <typeparam name="TEntity"> </typeparam>
    [UsedImplicitly]
    public sealed class NHibernateRepository<TEntity> : NHibernateRepositoryBase<TEntity>
        where TEntity : class, IEntity
    {
        /// <summary>
        ///   �����������
        /// </summary>
        /// <param name="sessionProvider"> </param>
        public NHibernateRepository(ISessionProvider sessionProvider)
            : base(sessionProvider)
        {
        }
    }
}