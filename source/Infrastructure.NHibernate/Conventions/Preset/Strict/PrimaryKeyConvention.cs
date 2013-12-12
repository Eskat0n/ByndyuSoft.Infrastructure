namespace Codeparts.Frameplate.NHibernate.Conventions.Preset.Strict
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;

    public class PrimaryKeyConvention : IIdConvention
	{
		public void Apply(IIdentityInstance instance)
		{
			var sequenceName = NameConventions.GetSequenceName(instance.EntityType);
			var columnName = NameConventions.GetPrimaryKeyColumnName(instance.EntityType);

			instance.Column(columnName);
			instance.GeneratedBy.Native(paramBuilder => paramBuilder.AddParam("sequence", sequenceName));
		}
	}
}