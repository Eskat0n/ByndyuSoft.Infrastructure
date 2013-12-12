namespace Codeparts.Frameplate.NHibernate.Conventions.Sources
{
    using FluentNHibernate.Conventions.Inspections;
    using Preset.Natural;

    internal class NaturalConventionsSource : ConventionsSource, INaturalPresetConfigurator
    {
        public NaturalConventionsSource()
            : base("Natural")
        {
        }

        public INaturalPresetConfigurator FieldPrefix(CamelCasePrefix prefix)
        {
            PluralRelationsConvention.FieldPrefix = prefix;
            return this;
        }

        public INaturalPresetConfigurator EnumType(EnumType enumType)
        {
            EnumConvention.EnumType = enumType;
            return this;
        }
    }
}