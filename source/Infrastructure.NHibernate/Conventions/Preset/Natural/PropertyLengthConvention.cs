﻿namespace Codeparts.Frameplate.NHibernate.Conventions.Preset.Natural
{
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Instances;
    using JetBrains.Annotations;

    [UsedImplicitly]
	public class PropertyLengthConvention : IPropertyConvention
	{
		public void Apply(IPropertyInstance instance)
		{
			instance.Length(short.MaxValue);
		}
	}
}