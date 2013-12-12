namespace Codeparts.Frameplate.NHibernate.Conventions.Preset.Natural
{
    using System;
    using FluentNHibernate;
    using FluentNHibernate.Conventions;
    using JetBrains.Annotations;

    /// <summary>
    /// 
    /// </summary>
    [UsedImplicitly]
    public class ForeignKeyColumnNameConvention : ForeignKeyConvention
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="member"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        protected override string GetKeyName(Member member, Type type)
        {
            return string.Format("{0}Id", member == null ? type.Name : member.Name);
        }
    }
}