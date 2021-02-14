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

        public static int ForLessThanOne(int iterations, string propertyName)
        {
            if (iterations < 1) throw new ArgumentOutOfRangeException(nameof(propertyName));

            return iterations;
        }
    }
}
