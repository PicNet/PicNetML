using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ml2.Tasks.Generator.Asstn;
using Ml2.Tasks.Generator.AttrSel;
using Ml2.Tasks.Generator.Clss;
using Ml2.Tasks.Generator.Clstr;
using Ml2.Tasks.Generator.Core;
using Ml2.Tasks.Generator.Fltr;
using NUnit.Framework;
using weka.associations;
using weka.attributeSelection;
using weka.classifiers;
using weka.clusterers;
using weka.core;
using weka.filters;
using Attribute = weka.core.Attribute;

namespace Ml2.Tasks.Generator
{
  [TestFixture, Ignore("Run Manually")] public class CodeGenerator
  {    

    [Test] public void GenerateAll() {
      GenerateCoreClassWrappers();
      GenerateAttributeSelectionEvaluators();
      GenerateAttributeSelectionAlgorithms();
      GenerateClusterers();
      GenerateAllFilters();
      GenerateAllClassifiers();
      GenerateAllAssociations();
    }

    [Test] public void GenerateCoreClassWrappers() {
      var dir = PrepDir("Generated");

      RunT4TemplateImpl(new CoreClass("Runtime", typeof(Instances)) {
      }, dir + @"\Runtime");

      RunT4TemplateImpl(new CoreClass("Ml2Instance", typeof(Instance)) {
        Extends = "IEnumerable<Ml2Attribute>",
        AdditionalMethods = "public IEnumerator<Ml2Attribute> GetEnumerator() { return EnumerateAttributes.GetEnumerator(); }\n    IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }"
      }, dir + @"\Ml2Instance");

      RunT4TemplateImpl(new CoreClass("Ml2Attribute", typeof(Attribute)) {
        Extends = "IEnumerable<string>",
        AdditionalMethods = "public IEnumerator<string> GetEnumerator() { return EnumerateValues.GetEnumerator(); }\n    IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }"
      }, dir + @"\Ml2Attribute");

      RunT4TemplateImpl(new CoreClass("Ml2Evaluation", typeof(Evaluation)) {
        AdditionalUsings = "using Ml2.Clss;\nusing weka.classifiers;"
      }, dir + @"\Ml2Evaluation");
    }

    [Test] public void GenerateAttributeSelectionEvaluators()
    {
      var dir = PrepDir(@"AttrSel\Evals\Generated");

      var types = GetBaseClassesOf(typeof (ASEvaluation)).
          ToArray();
      Array.ForEach(types, t => 
            RunT4Template(typeof(AttributeSelectionEvaluator), t, dir));
      RunT4TemplateImpl(new Evaluators(types), dir + @"\Evaluators");
    }

    [Test] public void GenerateAttributeSelectionAlgorithms()
    {
      var dir = PrepDir(@"AttrSel\Algs\Generated");

      var types = GetBaseClassesOf(typeof (ASSearch));
      Array.ForEach(types, t => 
            RunT4Template(typeof(AttributeSelectionAlgorithm), t, dir));

      RunT4TemplateImpl(new Algorithms(types), dir + @"\Algorithms");
    }

    [Test] public void GenerateClusterers()
    {
      var dir = PrepDir(@"Clstr\Generated");

      var types = GetBaseClassesOf(typeof (AbstractClusterer));
      Array.ForEach(types, t => 
             RunT4Template(typeof(ClustererAlgorithm), t, dir));

      RunT4TemplateImpl(new Clusterers(types), dir + @"\Clusterers");
    }

    [Test] public void GenerateAllFilters()
    {      
      var dir = PrepDir(@"Fltr\Generated");

      var types = GetBaseClassesOf(typeof (Filter));
      var namespaces = types.
          Select(t => t.Namespace).
          Distinct().
          ToList();
      namespaces.ForEach(ns => GenerateCodeForNamespace(types, typeof(Filters), ns, "Fltr"));      
      Array.ForEach(types, t => RunT4Template(typeof(FilterAlgorithm), t, dir));
    }

    [Test] public void GenerateAllClassifiers()
    {
      var dir = PrepDir(@"Clss\Generated");

      var types = GetBaseClassesOf(typeof (Classifier));
      var namespaces = types.
          Select(t => t.Namespace).
          Distinct().
          ToList();
      namespaces.ForEach(ns => GenerateCodeForNamespace(types, typeof(Classifiers), ns, "Clss"));      
      Array.ForEach(types, t => RunT4Template(typeof(ClassifierAlgorithm), t, dir));
    }

    [Test] public void GenerateAllAssociations()
    {
      var dir = PrepDir(@"Asstn\Generated");

      var types = GetBaseClassesOf(typeof (AbstractAssociator));
      Array.ForEach(types, t => 
             RunT4Template(typeof(AssociationAlgorithm), t, dir));

      RunT4TemplateImpl(new Associations(types), dir + @"\Associations");
    }

    private static string PrepDir(string dir)
    {      
      if (Directory.Exists(dir)) Directory.Delete(dir, true);
      Directory.CreateDirectory(dir);
      return dir;
    }

    private void GenerateCodeForNamespace(IEnumerable<Type> alltypes, Type generator, string ns, string targetdir)
    {
      var types = alltypes.
        Where(t => t.Namespace == ns).
        ToArray();
      ns = ns.Replace("weka.", String.Empty);
      var tokens = ns.Split('.');
      var typename = String.Join(String.Empty, tokens.Select(w => Char.ToUpper(w[0]) + w.Substring(1)));
      if (tokens.Length == 1) typename += "General";
      Console.WriteLine("Generating for type: " + typename);
      var codegen = (ICodeGen) Activator.CreateInstance(generator, new object[] { types });
      generator.GetProperty("TypeName").SetValue(codegen, typename);
      RunT4TemplateImpl(codegen, targetdir + @"\Generated\" + typename);
    }

    private static Type[] GetBaseClassesOf(Type ancestor)
    {
      
      return AppDomain.CurrentDomain.GetAssemblies().SelectMany(a => {
          var name = a.GetName().Name;
        if (name.StartsWith("System.") || name.StartsWith("JetBrains.") || 
          name.StartsWith("nunit.") || name.StartsWith("IKVM.")) { return new Type[0]; }
          return a.GetTypes().Where(t => !t.IsAbstract && 
              t.DeclaringType == null &&  // No nested classes
              ancestor.IsAssignableFrom(t) && Utils.IsSupportedType(t));
      }).
        ToArray();
    }

    private void RunT4Template(Type template, Type t, string dir)
    {
      var eval = (IMl2CodeGenerator) Activator.CreateInstance(template, t);
      Console.WriteLine("Generating Type:  " + t.Name);
      RunT4TemplateImpl(eval, dir + "\\" + eval.Model.TypeName);
    }

    private static void RunT4TemplateImpl(ICodeGen eval, string file)
    {
      var output = @"..\..\..\Ml2\" + file + ".cs";
      if (File.Exists(output)) File.Delete(output);      
      var generated = eval.TransformText();
      File.WriteAllText(output, generated);
    }
  }
}