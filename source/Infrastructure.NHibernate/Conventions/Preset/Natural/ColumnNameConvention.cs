namespace Codeparts.Frameplate.NHibernate.Conventions.Preset.Natural
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;
    using JetBrains.Annotations;

    /// <summary>
    /// 
    /// </summary>
    [UsedImplicitly]
    public class ColumnNameConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            instance.Column(instance.Name);
        }
    }
}