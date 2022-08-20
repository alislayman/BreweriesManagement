using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public static class CommonMethods
    {
        public static void ThrowIfNull<T>(this T obj, string objectName) where T : class
        {
            if (obj == null)
                throw new NullReferenceException($"{objectName} cannot be empty");
        }

        public static void ThrowIfNotFound<T>(this T obj, string objectName, object objectID) where T : class
        {
            obj.ThrowIfNotFound($"Invalid {objectName} ID: {objectID}");
        }

        public static void ThrowIfNotFound<T>(this T obj, string message) where T : class
        {
            if (obj == null)
                throw new Exception(message);
        }
    }
}
