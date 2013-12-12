namespace Codeparts.Frameplate.NHibernate
{
    using System.Linq;
    using ByndyuSoft.Infrastructure.Domain;
    using JetBrains.Annotations;

    /// <summary>
    /// </summary>
    /// <typeparam name="TEntity"> </typeparam>
    /// <typeparam name="TCriterion"> </typeparam>
    /// <typeparam name="TResult"> </typeparam>
    [PublicAPI]
    public abstract class LinqQueryBase<TEntity, TCriterion, TResult> : IQuery<TCriterion, TResult>
        where TCriterion : ICriterion
        where TEntity : class, IEntity, new()
    {
        public ILinqProvider LinqProvider { get; set; }

        /// <summary>
        /// </summary>
        [PublicAPI]
        protected IQueryable<TEntity> Query
        {
            get { return LinqProvider.Query<TEntity>(); }
        }

        #region IQuery<TCriterion,TResult> Members

        public abstract TResult Ask(TCriterion criterion);

        #endregion
    }
}