using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using weka.core;

namespace PicNetML.Tasks.Generator
{
  public class WekaTypeModel
  {
    private readonly Type impl;
    private readonly string ignoresuffix;

    public WekaTypeModel(Type impl, string ignoresuffix = null) {
      this.impl = impl;
      this.ignoresuffix = ignoresuffix;
    }

    internal Type ImplementationType { get { return impl; } }

    public string TypeName { get { return Utils.GetPmlTypeName(impl, ignoresuffix); } }
    public string GetClassDescription(string separator) { return Utils.GetClassDescription(impl, separator); }
    public string ImplTypeName { get { return impl.FullName; } }
    public string ImplTypeNamespace { get { return impl.Namespace; } }
    public string ConstructorContent { get {
      var seeder = impl.GetMethods(BindingFlags.Instance | BindingFlags.Public).
          SingleOrDefault(mi => mi.Name == "setSeed" || mi.Name == "setRandomSeed");
      if (seeder == null) { return String.Empty; }
      return "Impl." + seeder.Name + "(Runtime.GlobalRandomSeed);";
    } }

    public SetterModel[] Setters
    {
      get
      {
        return impl.GetMethods(BindingFlags.Instance | BindingFlags.Public).
          Where(m => m.Name.StartsWith("set") && m.Name != "setOptions").
          Select(m => new SetterModel(this, m)).
          Where(o => o.IsSupported).
          ToArray();
      }
    } 

    public WekaEnum[] Enumerations {
      get {
        var tagmethods = impl.GetMethods(BindingFlags.Instance | BindingFlags.Public).
          Where(m => m.Name.StartsWith("set") && m.Name != "setOptions").
          Where(m => m.GetParameters().Any(p => p.ParameterType == typeof(SelectedTag))).
          ToArray();
        return tagmethods.Select(GetEnumForMethod).Where(e => e != null).ToArray();
      }
    }

    private WekaEnum GetEnumForMethod(MethodInfo m) {
      try {
        return new WekaEnum {
          Name = Utils.GetEnumNameFromSetter(m.Name),
          Values = GetEnumValuesFromSetter(m)
        };
      } catch (InvalidOperationException) { return null; }
    }

    private KeyValuePair<string, string>[] GetEnumValuesFromSetter(MethodInfo m) {
      var tags = (Tag[]) Utils.GetEnumImplType(m).GetValue(null);
      
      return tags.Select(t => new KeyValuePair<string, string>(
          GetEnumValueName(t.getReadable()), 
          String.Empty + t.getID())).ToArray();
    }

    private string GetEnumValueName(string raw) {      
      return raw.
          Replace(" ", "_").
          Replace(":", "_").
          Replace("/", "_div_").
          Replace("1", "one").
          Replace("(", "").
          Replace(")", "").
          Replace(";", "").
          Replace("-", "_");
    }

    public class WekaEnum {
      public string Name { get; set; }
      public KeyValuePair<string, string>[] Values { get; set; }       
    }
  }
}