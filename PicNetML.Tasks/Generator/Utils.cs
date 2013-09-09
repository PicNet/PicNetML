using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using java.util;
using weka.core;

namespace PicNetML.Tasks.Generator
{
  internal static class Utils
  {
    public static string GetPmlTypeName(Type t, string suffix)
    {
      if (String.IsNullOrWhiteSpace(suffix)) return t.Name;
      var idx = t.Name.IndexOf(suffix);
      return idx < 0 ? t.Name : t.Name.Substring(0, idx);
    }

    public static bool IsSupportedType(Type t)
    {
      if (t.GetConstructor(new Type[0]) == null)
      {
        Console.WriteLine("Type [" + t.FullName + "] does not have a default constructor.");
        return false;
      }
      return t.Name != "DummySubsetEvaluator";
    }

    public static string GetClassDescription(Type t, string separator)
    {
      var impl = Activator.CreateInstance(t);
      var mi = t.GetMethod("globalInfo", BindingFlags.Instance | BindingFlags.Public);
      if (mi == null)
      {
        Console.WriteLine("Type [" + t.FullName + "] does not have a valid globalInfo method.");
        return "No class description found.";
      }
      var desc = (string) mi.Invoke(impl, null);      
      desc += GetOptionsDescriptions(impl);
      desc = desc.Replace("\n", "<br/>");
      return String.Join("\n" + separator, SplitIntoChunks(desc, 75));
    }

    private static string GetOptionsDescriptions(object impl) {
      var mi = impl.GetType().GetMethod("listOptions");
      if (mi == null) return String.Empty;
      var options = (Enumeration) mi.Invoke(impl, null);
      var descs = new List<string>();
      Option o;
      while (options.hasMoreElements()) { 
        o = (Option) options.nextElement();
        var desc = o.synopsis().Replace("<", "&lt;").Replace(">", "&gt;") + 
            " = " + o.description();
        descs.Add(desc); 
      }      
      return "\n\nOptions:\n\n" + String.Join("\n", descs);
    }

    public static string[] SplitIntoChunks(string str, int chunksize)
    {
      int charCount = 0;
      return str.Split(new[] {' ', '\n'}, StringSplitOptions.RemoveEmptyEntries)
        .GroupBy(w => (charCount += w.Length + 1) / chunksize)
        .Select(g => string.Join(" ", g)).
        ToArray();
    }

    public static string GetEnumNameFromSetter(string name) {      
      return "E" + name.Substring(3);
    }

    public static PropertyInfo GetEnumImplType(MethodInfo m) {
      var statics = m.DeclaringType.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.GetField);
      var alltaggs = statics.Where(f => f.PropertyType == typeof(Tag[])).ToArray();
      return alltaggs.Single();
    }

    public static string GetSetterCode(string summary, string modeltype, string settername, string[] args, string impl) {
      return String.Format(@"/// <summary>
    /// {0}
    /// </summary>    
    public {1} {2} ({3}) {{
      {4}
      return this;
    }}", summary, modeltype, settername, String.Join(", ", args), impl);
    }

    public static string GetCsSafeType(Type type) {
      switch (type.Name)
        {
          case "Void": return "void";
          case "Object": return "object";
          case "Object[]": return "object[]";
          case "Boolean": return "bool";
          case "Boolean[]": return "bool[]";
          case "String": return "string";
          case "String[]": return "string[]";
          case "Int32": return "int";
          case "Int32[]": return "int[]";
          case "Int64": return "long";
          case "Int64[]": return "long[]";
          case "Double": return "double";
          case "Double[]": return "double[]";
          case "Double[][]": return "double[][]";
          case "Single": return "float";
          case "Single[]": return "float[]";          
          default: throw new NotSupportedException("Type: " + type.Name + " not supported.");
        }
    }
  }
}