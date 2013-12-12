namespace Codeparts.Frameplate.NHibernate.Conventions
{
    using FluentNHibernate.Conventions.Inspections;

    /// <summary>
    /// 
    /// </summary>
    public interface INaturalPresetConfigurator
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="prefix"></param>
        /// <returns></returns>
        INaturalPresetConfigurator FieldPrefix(CamelCasePrefix prefix);

        INaturalPresetConfigurator EnumType(EnumType enumType);
    }
}