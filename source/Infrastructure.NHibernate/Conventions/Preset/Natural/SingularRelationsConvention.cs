namespace Codeparts.Frameplate.NHibernate.Conventions.Preset.Natural
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;
    using JetBrains.Annotations;

    [UsedImplicitly]
    public class SingularRelationsConvention : IReferenceConvention, IHasOneConvention
    {
        public void Apply(IManyToOneInstance instance)
        {
            instance.LazyLoad();
            instance.NotFound.Ignore();
        }

        public void Apply(IOneToOneInstance instance)
        {
            instance.LazyLoad();
        }
    }
}