using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace StubGenerator.Common
{
    public class Reflector
    {
        public static IEnumerable<MethodInfo> GetPublicMethods(Type clientType)
        {
            if (clientType == null)
            {
                throw new InvalidOperationException($"NetSuite Client type was not specified.");
            }
            else if (!clientType.IsClass)
            {
                throw new InvalidOperationException($"Provided NetSuite Client type is not a Class.");
            }

            return clientType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                .Where(m => !m.IsSpecialName && !m.IsVirtual);
        }

        public static IEnumerable<PropertyInfo> GetPublicProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
        }

        public static IEnumerable<FieldInfo> GetPublicFields(Type type)
        {
            return type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
        }
    }
}
