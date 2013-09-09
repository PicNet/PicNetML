using System;
using System.Linq;
using System.Reflection;

namespace PicNetML
{
  internal static class InternalHelpers
  {
    internal static void SetSeedOnInstance(object o) {
      o.GetType().GetMethods().
          Where(m => m.Name == "setSeed" || m.Name == "setRandomSeed").
          ToList().ForEach(m => m.Invoke(o, new object[] { Runtime.GlobalRandomSeed }));
    }

    internal static bool IsAtt<T>(PropertyInfo pi) where T : Attribute {
      return Attribute.IsDefined(pi, typeof(T));
    }

    internal static T ToAtt<T>(PropertyInfo pi) where T : Attribute {
      return (T) Attribute.GetCustomAttribute(pi, typeof(T));
    }

    public static string ToStringSafe(object o) { 
      return o == null ? String.Empty : o is string ? (string) o : o.ToString();
    }    
  }
}