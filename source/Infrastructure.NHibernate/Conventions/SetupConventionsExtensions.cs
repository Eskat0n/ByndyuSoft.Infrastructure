namespace Codeparts.Frameplate.NHibernate.Conventions
{
    using System;
    using FluentNHibernate.Automapping;
    using FluentNHibernate.Cfg;
    using JetBrains.Annotations;
    using Sources;

    /// <summary>
    /// 
    /// </summary>
    public static class SetupConventionsExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="setupConventionFinder"></param>
        /// <returns></returns>
        public static AutoPersistenceModel NaturalPreset(this SetupConventionFinder<AutoPersistenceModel> setupConventionFinder)
        {
            return NaturalPreset(setupConventionFinder, cfg => { });
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="setupConventionFinder"></param>
        /// <param name="configurator"></param>
        /// <returns></returns>
        public static AutoPersistenceModel NaturalPreset(this SetupConventionFinder<AutoPersistenceModel> setupConventionFinder,
                                                         [NotNull] Action<INaturalPresetConfigurator> configurator)
        {
            var source = new NaturalConventionsSource();
            configurator(source);
            return setupConventionFinder.AddSource(source);
        }
    }
}