namespace Codeparts.Frameplate.NHibernate.Conventions.Sources
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentNHibernate;
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Conventions.Inspections;
    using FluentNHibernate.Diagnostics;
    using Preset.Natural;

    internal class NaturalConventionsSource : ITypeSource, INaturalPresetConfigurator
    {
        public IEnumerable<Type> GetTypes()
        {
            return GetType().Assembly.GetTypes()
                .Where(x => typeof (IConvention).IsAssignableFrom(x))
                .Where(x => x.Namespace != null && x.Namespace.Contains("Natural"))
                .ToArray();
        }

        public void LogSource(IDiagnosticLogger logger)
        {
        }

        public string GetIdentifier()
        {
            return GetType().Name;
        }

        public INaturalPresetConfigurator FieldPrefix(CamelCasePrefix prefix)
        {
            PluralRelationsConvention.FieldPrefix = prefix;
            return this;
        }

        public INaturalPresetConfigurator EnumType(EnumType enumType)
        {
            throw new NotImplementedException();
        }
    }
}