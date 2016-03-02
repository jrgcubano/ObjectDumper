using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace System
{
    public static class ObjectExtensions
    {
        public static bool IsNull(this object obj)
        {
            return Object.ReferenceEquals(obj, null);
        }

        public static bool IsNotNull(this object obj)
        {
            return !IsNull(obj);
        }

        public static IEnumerable<PropertyInfo> GetRedeableProperties(this object source)
        {
            return source.GetType()
                         .GetProperties()
                         .Where(p => p.CanRead);
        }
    }
}
