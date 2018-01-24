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
            if (clientType.IsInterface)
            {
                return clientType.GetMethods();
            }
            else
            {
                return clientType.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly)
                    .Where(m => !m.IsSpecialName && !m.IsVirtual);
            }

        }

        public static PropertyInfo[] GetPublicProperties(Type type)
        {
            return type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
        }

        public static FieldInfo[] GetPublicFields(Type type)
        {
            return type.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.DeclaredOnly);
        }
    }
}
