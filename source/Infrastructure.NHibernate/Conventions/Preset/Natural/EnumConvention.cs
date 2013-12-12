namespace Codeparts.Frameplate.NHibernate.Conventions.Preset.Natural
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;
    using JetBrains.Annotations;

    /// <summary>
    /// 
    /// </summary>
    [UsedImplicitly]
    public class EnumConvention : IPropertyConvention
    {
        static EnumConvention()
        {
            EnumType = EnumType.Integer;
        }

        internal static EnumType EnumType { private get; set; }

        public void Apply(IPropertyInstance instance)
        {
            if (instance.Type.IsEnum == false)
                return;

            if (EnumType == EnumType.Integer)
                instance.CustomType<int>();
            else
                instance.CustomType<string>();
        }
    }
}