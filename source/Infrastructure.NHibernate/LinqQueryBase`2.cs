namespace Codeparts.Frameplate.NHibernate
{
    using System.Linq;
    using ByndyuSoft.Infrastructure.Domain;
    using JetBrains.Annotations;

    /// <summary>
    /// </summary>
    /// <typeparam name="TCriterion"> </typeparam>
    /// <typeparam name="TResult"> </typeparam>
    [PublicAPI]
    public abstract class LinqQueryBase<TCriterion, TResult> : IQuery<TCriterion, TResult>
        where TCriterion : ICriterion
    {
        public ILinqProvider LinqProvider { get; set; }

        #region IQuery<TCriterion,TResult> Members

        /// <summary>
        /// 
        /// </summary>
        /// <param name="criterion"></param>
        /// <returns></returns>
        public abstract TResult Ask(TCriterion criterion);

        #endregion

        /// <summary>
        /// </summary>
        [PublicAPI]
        protected virtual IQueryable<TEntity> Query<TEntity>()
            where TEntity : class, IEntity, new()
        {
            return LinqProvider.Query<TEntity>();
        }
    }
}