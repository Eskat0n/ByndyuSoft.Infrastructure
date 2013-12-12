namespace Codeparts.Frameplate.NHibernate.Conventions.Sources
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using FluentNHibernate;
    using FluentNHibernate.Conventions;
    using FluentNHibernate.Diagnostics;

    public abstract class ConventionsSource : ITypeSource
    {
        private string Name { get; set; }

        protected ConventionsSource(string name)
        {
            Name = name;
        }

        public IEnumerable<Type> GetTypes()
        {
            return GetType().Assembly.GetTypes()
                .Where(x => typeof (IConvention).IsAssignableFrom(x))
                .Where(x => x.Namespace != null && x.Namespace.Contains(Name))
                .ToArray();
        }

        public void LogSource(IDiagnosticLogger logger)
        {
        }

        public string GetIdentifier()
        {
            return GetType().Name;
        }
    }
}