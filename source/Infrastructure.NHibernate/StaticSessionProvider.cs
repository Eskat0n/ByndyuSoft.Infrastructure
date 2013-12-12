namespace Codeparts.Frameplate.NHibernate
{
    using System;
    using global::NHibernate;
    using JetBrains.Annotations;

    /// <summary>
    /// 
    /// </summary>
    [PublicAPI]
    public class StaticSessionProvider : ISessionProvider
    {
        private readonly object _lockObject = new object();
        private readonly ISession _session;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="session"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public StaticSessionProvider([NotNull] ISession session)
        {
            if (session == null)
                throw new ArgumentNullException("session");

            _session = session;
        }

        #region ISessionProvider Members

        public ISession CurrentSession
        {
            get
            {
                lock (_lockObject)
                {
                    return _session;
                }
            }
        }

        #endregion
    }
}