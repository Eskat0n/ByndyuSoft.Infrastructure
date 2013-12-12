namespace Codeparts.Frameplate.NHibernate
{
    using ByndyuSoft.Infrastructure.Domain;
    using global::NHibernate;
    using JetBrains.Annotations;

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TCriterion"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    [PublicAPI]
    public abstract class SessionQueryBase<TCriterion, TResult> : global::ByndyuSoft.Infrastructure.Domain.IQuery<TCriterion, TResult>
        where TCriterion : ICriterion
    {
        private readonly ISessionProvider _sessionProvider;

        protected SessionQueryBase(ISessionProvider sessionProvider)
        {
            _sessionProvider = sessionProvider;
        }

        /// <summary>
        /// 
        /// </summary>
        protected virtual ISession Session
        {
            get { return _sessionProvider.CurrentSession; }
        }

        public abstract TResult Ask(TCriterion criterion);
    }
}