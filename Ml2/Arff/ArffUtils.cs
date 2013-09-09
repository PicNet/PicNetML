using System;

namespace Ml2.Arff
{
  public static class ArffUtils
  {
    public static Type GetNonNullableType(Type t) {
      if (t == null) throw new ArgumentNullException("t");

      if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof (Nullable<>)) {
        return Nullable.GetUnderlyingType(t);
      }
      return t;
    }
  }
}