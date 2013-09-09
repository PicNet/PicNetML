using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PicNetML.Tasks.Generator.Core
{
  public partial class CoreClass : ICodeGen
  {    
    private readonly IDictionary<string, bool> added_templates = new Dictionary<string, bool>(); 
    public string ClassName { get; private set;}   
    public Type ImplType { get; private set;}   

    public string ImplClassName { get;set;}    
    public string AdditionalMethods { get;set;}    
    public string Extends { get; set;}
    public string AdditionalUsings { get; set;}    

    public CoreClass(string className, Type implType) {
      ClassName = className;
      ImplType = implType;
      ImplClassName = ImplType.Name;
      
      AdditionalMethods = String.Empty;
      AdditionalUsings = String.Empty;
      Extends = String.Empty;
    }

    public string[] Methods { get {
      var valids = ImplType.GetMethods().
          Where(IsValidMethod).
          ToArray();
      return valids.
          Select(m => ToCsMethod(m, valids)).
          Where(m => m != null).
          ToArray();
    }}

    private string ToCsMethod(MethodInfo mi, MethodInfo[] all) {
      if (added_templates.ContainsKey(mi.Name)) return null;
      var template = TemplateMethods(mi.Name);      
      if (!String.IsNullOrWhiteSpace(template)) {
        added_templates.Add(mi.Name, true);
        return template;
      }

      var rettype = GetCsReturnType(mi.ReturnType);
      var name = GetCsMethodName(mi.Name);
      var args = GetCsArgs(mi);
      var retstring = GetReturnString(mi, args == null ? String.Empty : args.Item2);
      return args == null && rettype != "void" && all.Count(a => a.Name == mi.Name) == 1 ? 
        String.Format("public {0} {1} {{ get {{ {2}; }} }}", rettype, name, retstring):
        mi.IsStatic ? 
          String.Format("public static {0} {1}({2}) {{ return {3}.{4}({5}); }}", 
          rettype, 
          name,
          args == null ? String.Empty : args.Item1,
		      ImplClassName,
          mi.Name,
          args == null ? String.Empty : args.Item2) : 
        String.Format("public {0} {1}({2}) {{ {3}; }}", 
          rettype, 
          name,
          args == null ? String.Empty : args.Item1,
          retstring);
    }

    private string GetReturnString(MethodInfo mi, string argnames) { 
      var rettype = GetCsReturnType(mi.ReturnType);
      var retstr = rettype == "void" ? String.Empty : "return ";
      var impl = String.Format("Impl.{0}({1})", mi.Name, argnames);
      var wrapper = GetCsWrapperForReturn(mi);
      impl = wrapper == null ? impl : "new " + wrapper + "(" + impl + ")";
      return retstr + impl;
    }

    private string GetCsWrapperForReturn(MethodInfo mi) { 
      switch (mi.ReturnType.Name) {
        case "Instance": return "PmlInstance";
        case "Instances": return "Runtime";
        case "Attribute": return "PmlAttribute";
        default: return null;
      }
    }

    private string GetCsReturnType(Type t) {
      return GetCsSafeType(t);
    }

    private string GetCsMethodName(string old) {
      return Char.ToUpper(old.ToCharArray(0, 1)[0]) + old.Substring(1);
    }

    private string GetCsSafeType(Type t) {
      switch (t.Name) {
        case "Instance": return "PmlInstance";
        case "Instances": return "Runtime";
        case "Attribute": return "PmlAttribute";
        case "Enumeration": return "Enumeration";
		    case "Classifier": return "IBaseClassifier<Classifier>";
        // TODO
        case "Random": return "Random";
        case "Reader": return "Reader";
        default: return Utils.GetCsSafeType(t);
      }
    }

    private Tuple<string, string> GetCsArgs(MethodInfo mi) {
      var args = mi.GetParameters();
      if (!args.Any()) return null;
      var full = String.Join(", ", args.
	  		Where(pi => !IgnoreCsParam(pi)).
			Select(p => GetCsSafeType(p.ParameterType) + " " + GetSafeCsArgName(p.Name)));
      var names = String.Join(", ", args.Select(GetJavaType));
      return Tuple.Create(full, names);
    }

    private bool IgnoreCsParam(ParameterInfo pi) {
      return pi.ParameterType.Name == "Random";
    }

    private string GetSafeCsArgName(string orig) {
      if (orig == "string") { return "str"; }
      if (orig == "params") { return "args"; }
      return orig;
    }

    private string GetJavaType(ParameterInfo pi) {
      if (pi.ParameterType.Name == "Instance") { return pi.Name + ".Impl"; }
      if (pi.ParameterType.Name == "Classifier") { return pi.Name + ".Impl"; }
      if (pi.ParameterType.Name == "Attribute") { return pi.Name + ".Impl"; }
      if (pi.ParameterType.Name == "Instances") { return pi.Name + ".Impl"; }
	    if (pi.Name == "string") { return "str"; }
      if (pi.ParameterType.Name == "Random") { return "new java.util.Random(GlobalRandomSeed)"; }
      return pi.Name;
    }

    private bool IsValidMethod(MethodInfo mi) {
      var name = mi.Name;
      if (name == "trainCV" && mi.GetParameters().Length == 2) return false;
      if (name == "toString" && mi.GetParameters().Length == 0) return false;
      if (name == "equals" && mi.GetParameters().Length == 1) return false;
	  if (name == "crossValidateModel" || name == "setMetricsToDisplay"||
          name == "dontDisplayMetrics" || name == "wekaStaticWrapper" ||
          name == "evaluationForSingleInstance" || name == "mergeInstance" ||
          name.IndexOfAny(new [] {'<', '_'}) >= 0) return false;
		  
      try { GetCsReturnType(mi.ReturnType); } catch { return false; }
      return mi.DeclaringType.Namespace.StartsWith("weka") &&         
        name != "main" && name != "mergeInstance" && 
        name != "enumerateInstances" && name != "readInstance" &&
        name != "getRandomNumberGenerator" && name != "test";
    }

    private string TemplateMethods(string name) {
      switch (name) {
        case "mergeInstance": 
          return "public Runtime MergeRuntime(Runtime rt) { return new Runtime(Impl.mergeInstance(rt.Instances)); }";
        case "mergeInstances": 
          return "public static Runtime MergeRuntime(Runtime first, Runtime second) { return new Runtime(Instances.mergeInstances(first.Impl, second.Impl)); }";
        case "enumerateAttributes": 
          return "public IEnumerable<PmlAttribute> EnumerateAttributes { get { return Impl.ToEnumerableAttributes(); } }";
	    case "enumerateValues": 
          return "public IEnumerable<string> EnumerateValues { get { return Impl.ToEnumerable(); } }";
        case "instance" :
          return "public PmlInstance Instance(int index) { return new PmlInstance(Impl.instance(index)); }";
        case "remove" :
          return "public PmlInstance Remove(int index) { return new PmlInstance(Impl.remove(index)); }";
        case "set" :
          return "public PmlInstance Set(int index, PmlInstance instance) { return new PmlInstance(Impl.set(index, instance.Impl)); }";
        case "get" :
          return "public PmlInstance Get(int index) { return new PmlInstance(Impl.get(index)); }";
        case "lastInstance" :
          return "public PmlInstance LastInstance { get { return new PmlInstance(Impl.lastInstance()); } }";
        case "firstInstance" :
          return "public PmlInstance FirstInstance { get { return new PmlInstance(Impl.firstInstance()); } }";
        default: return null;
      }
    }
  }
}
