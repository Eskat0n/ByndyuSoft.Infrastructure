﻿namespace Codeparts.Frameplate.NHibernate.Conventions.Preset.Strict
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;

    /// <summary>
	/// Соглашение по-умолчанию для сущностей.
	/// </summary>
	public class EntityMapConvention : IClassConvention, IJoinedSubclassConvention
	{
		#region IClassConvention Members

		public void Apply(IClassInstance instance)
		{
			string tableName = NameConventions.GetTableName(instance.EntityType);

			instance.Table(tableName);
			instance.BatchSize(25);
		}

		#endregion

		#region IJoinedSubclassConvention Members

		public void Apply(IJoinedSubclassInstance instance)
		{
			string tableName = NameConventions.GetTableName(instance.EntityType);

			instance.Table(tableName);
			instance.BatchSize(25);
		}

		#endregion
	}
}