namespace Codeparts.Frameplate.NHibernate.Conventions.Preset.Natural
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Inspections;
    using FluentNHibernate.Conventions.Instances;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class PluralRelationsConvention : IHasManyConvention, IHasManyToManyConvention
    {
        static PluralRelationsConvention()
        {
            FieldPrefix = CamelCasePrefix.Underscore;
        }

        internal static CamelCasePrefix FieldPrefix { private get; set; }

        public void Apply(IOneToManyCollectionInstance instance)
        {
            instance.Access.ReadOnlyPropertyThroughCamelCaseField(FieldPrefix);
            instance.Cascade.AllDeleteOrphan();            
            if (instance.OtherSide == null)
                instance.Not.Inverse();
            else
                instance.Inverse();
            instance.BatchSize(500);
            instance.AsSet();
            instance.Not.KeyNullable();
            instance.LazyLoad();
        }

        public void Apply(IManyToManyCollectionInstance instance)
        {
            instance.Access.ReadOnlyPropertyThroughCamelCaseField(FieldPrefix);
            instance.Cascade.SaveUpdate();
            instance.BatchSize(500);
            instance.AsSet();
            instance.LazyLoad();
        }
    }
}