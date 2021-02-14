using System;

namespace SV.Builder.Core.Common
{
    public static class Guard
    {
        public static T ForNull<T>(T obj, string propertyName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(propertyName);
            }

            return obj;
        }

        public static string ForNullOrEmpty(string value, string propertyName)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException(propertyName);
            }

            return value;
        }

        public static int ForLessThanOne(int val, string propertyName)
        {
            if (val < 1) throw new ArgumentOutOfRangeException(nameof(propertyName));

            return val;
        }

        public static int ForLessThanZero(int val, string propertyName)
        {
            if (val < 0) throw new ArgumentOutOfRangeException(nameof(propertyName));

            return val;
        }

        public static decimal ForLessThanZero(decimal val, string propertyName)
        {
            if (val < 0) throw new ArgumentOutOfRangeException(nameof(propertyName));

            return val;
        }
    }
}
