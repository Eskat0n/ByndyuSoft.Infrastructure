namespace Codeparts.Frameplate.Web.Extensions
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Web.Mvc;

    public static class EnumExtensions
	{
		public static SelectList ToSelectdList<TEnum>() where TEnum : struct, IConvertible
		{
			return new SelectList(ToKeyValuePairs<TEnum>(), "Key", "Value");
		}

        public static string GetDescription(this Enum member)
        {
            if (member.GetType().IsEnum == false)
                throw new ArgumentOutOfRangeException("member", "member is not enum");

            var fieldInfo = member.GetType().GetField(member.ToString());

            if (fieldInfo == null)
                return null;

            var attributes = fieldInfo.GetCustomAttributes(typeof (DescriptionAttribute), false)
                .Cast<DescriptionAttribute>()
                .ToArray();

            return attributes.Length > 0 
                ? attributes[0].Description
                : member.ToString();
        }

        public static IEnumerable<KeyValuePair<int, string>> ToKeyValuePairs<TEnum>()
            where TEnum : struct, IConvertible
		{
			if (typeof (TEnum).IsEnum == false)
				throw new ArgumentException("TEnum must be an enumerated type");

			var items = Enum.GetValues(typeof (TEnum))
				.Cast<Enum>()
				.Select(x => new KeyValuePair<int, string>(int.Parse(x.ToString("D")), x.GetDescription()))
				.ToList();

			return items;
		}
	}
}