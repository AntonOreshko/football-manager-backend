using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Utility.Helpers;

namespace Utility
{
    public static class StringExtensions
    {
        public static T ParseEnum<T>(this string value)
        {
            return (T)Enum.Parse(typeof(T), value, true);
        }
    }

    public static class EnumExtensions
    {
        public static Dictionary<TEnum, string> ToDictionary<TEnum>(this Type type)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return Enum.GetValues(type)
                .OfType<TEnum>()
                .ToDictionary(value => value, value => value.ToString(CultureInfo.InvariantCulture));
        }

        public static List<TEnum> ToList<TEnum>(this Type type)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            return Enum.GetValues(type)
                .OfType<TEnum>()
                .ToList();
        }

        public static TEnum GetRandom<TEnum>(this Type type)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var list = ToList<TEnum>(type);

            var creator = new RandomShuffleListCreator<TEnum>(list);

            return creator.Get();
        }
    }
}
