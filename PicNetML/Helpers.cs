using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;
using PicNetML.Arff;

namespace PicNetML
{
  public static class Helpers
  {
    public static decimal[] Range(decimal from, decimal end, decimal step) {
      if (step > 0) {
        if (end <= from) throw new ArgumentOutOfRangeException(String.Format("Invalid from: {0}, end: {1}, step: {2}", from, end, step));
      } else {
        if (end >= from) throw new ArgumentOutOfRangeException(String.Format("Invalid from: {0}, end: {1}, step: {2}", from, end, step));
      }
      var list = new List<decimal>();
      for (var i = from; step > 0 ? i <= end : i >= end; i += step) {
        list.Add(i);        
      }
      return list.ToArray();
    }

    public static T Serialise<T>(T o, string file) {
      using (var stream = File.Open(file, FileMode.Create)) {
        new BinaryFormatter().Serialize(stream, o);
      }
      return o;
    }

    public static T Deserialise<T>(string file) {
      using (FileStream stream = File.Open(file, FileMode.Open)) {
        return (T) new BinaryFormatter().Deserialize(stream);
      }
    }

    public static T GetValue<T>(object o, string prop) { return (T) GetValue(o, prop); }

    public static T GetOrSetSerialised<T>(string file, Func<T> loader) {
      if (File.Exists(file)) return Deserialise<T>(file);
      var val = loader();
      return Serialise(val, file);
    }

    public static object GetValue(object o, string prop) {
      if (o is IExtendableObj<object>) o = ((IExtendableObj<object>)o).BaseObject;
      return o is IGetValue ? 
          ((IGetValue) o).GetValue(prop) : 
          o.GetType().GetProperty(prop).GetValue(o);
    }

    public static void SetValue(object target, string prop, object value) {
      if (target is IExtendableObj<object>) target = ((IExtendableObj<object>)target).BaseObject;
      target.GetType().GetProperty(prop).SetValue(target, value);
    }

    public static IEnumerable<T> RowsWherePropIsValue<T>(IEnumerable<T> data, string prop, object value) {
      return value == null ? 
        data.Where(d => GetValue<object>(d, prop) == null) : 
        data.Where(d => value.Equals(GetValue<object>(d, prop)));
    }

    private static readonly IDictionary<Type, PropertyInfo[]> memoized_props = new Dictionary<Type, PropertyInfo[]>();

    public static PropertyInfo[] GetProps(Type t)
    {
      if (typeof(IExtendableObj<object>).IsAssignableFrom(t)) {
        return GetProps(t.GenericTypeArguments[0]);
      }
      return memoized_props.ContainsKey(t) ? 
          memoized_props[t] : 
          (memoized_props[t] = t.GetProperties().OrderBy(p => p.MetadataToken).ToArray());
    }

    public static T Clone<T>(T o) where T : new() {
      if (o is ICloneable) return (T) ((ICloneable)o).Clone();

      var props = GetProps(o.GetType());
      var o2 = new T();
      foreach (var p in props) { SetValue(o2, p.Name, GetValue(o, p.Name)); }
      return o2;
    }
  }
}