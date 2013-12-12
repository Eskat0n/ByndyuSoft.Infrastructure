namespace Codeparts.Frameplate.NHibernate
{
    using global::NHibernate.Cfg;

    /// <summary>
    ///     Bootstrapper for NHibernate
    /// </summary>
    public interface INHibernateInitializer
    {
        /// <summary>
        ///     Builds and returns NHibernate configuration
        /// </summary>
        /// <returns>NHibernate configuration object</returns>
        Configuration CreateConfiguration();
    }
}