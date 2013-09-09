using System;
using System.Linq;
using java.text;
using weka.associations;
using weka.attributeSelection;
using weka.classifiers;
using weka.classifiers.bayes.net.estimate;
using weka.classifiers.bayes.net.search;
using weka.classifiers.functions.supportVector;
using weka.classifiers.trees.lmt;
using weka.clusterers;
using weka.core;
using weka.core.neighboursearch;
using weka.core.stemmers;
using weka.core.tokenizers;
using weka.filters;

namespace Ml2.Tasks.Generator
{
  public static class TemplatedSetters
  {
    private static readonly Type[] KEEP_WEKA_IMPL = new [] {
      typeof(DistanceFunction), 
      typeof(SimpleDateFormat),
      typeof(weka.core.Environment),
      typeof(DensityBasedClusterer),
      typeof(Kernel),
      typeof(PartitionGenerator),
      typeof(Range),
      typeof(Range[]),
      typeof(Stemmer),
      typeof(Tokenizer),
      typeof(SearchAlgorithm),
      typeof(BayesNetEstimator),
      typeof(RegOptimizer),
      typeof(NearestNeighbourSearch),
      typeof(LogisticBase)
    };

    public static string GetSetterTemplate(SetterModel o) {

      if (o.Method.Name == "setInputFormat") { throw new NotSupportedException("InputFormat not supported as its handled by BaseFilter"); }

      var args = o.Method.GetParameters();
      if (args.Length > 1) return String.Empty;
      var mi = args.Single();
      var pt = mi.ParameterType;
      var name = args[0].Name;      
      if (KEEP_WEKA_IMPL.Contains(pt)) { return GetSetterTemplateImpl(o, name, pt.FullName + " " + mi.Name); }

      if (pt == typeof(CostMatrix)) {
        return GetSetterTemplateImpl(o, "new CostMatrix(Runtime.NumClasses, " + name + ").Impl", "double[,] " + mi.Name);
      }
      if (pt == typeof(Filter)) {
        return GetSetterTemplateImpl(o, name + ".Impl", "Fltr.IBaseFilter<weka.filters.Filter> " + mi.Name);
      }
      if (pt == typeof(Filter[])) {
        return GetSetterTemplateImpl(o, name + ".Select(v => v.Impl).ToArray()", "IEnumerable<Fltr.IBaseFilter<weka.filters.Filter>> " + mi.Name);
      }
      if (pt == typeof(Associator)) {
        return GetSetterTemplateImpl(o, name + ".Impl", "BaseAssociation<AbstractAssociator> " + mi.Name);
      }
      if (pt == typeof(Classifier)) {
        return GetSetterTemplateImpl(o, name + ".Impl", "Ml2.Clss.IBaseClassifier<weka.classifiers.Classifier>" + mi.Name);
      }
      if (pt == typeof(Classifier[])) {
        return GetSetterTemplateImpl(o, name + ".Select(v => v.Impl).ToArray()", "IEnumerable<IBaseClassifier<weka.classifiers.Classifier>> " + mi.Name);
      }
      if (pt == typeof(ASEvaluation)) {
        return GetSetterTemplateImpl(o, name + ".Impl", "AttrSel.Evals.BaseAttributeSelectionEvaluator<weka.attributeSelection.ASEvaluation> " + mi.Name);
      }
      if (pt == typeof(ASSearch)) {
        return GetSetterTemplateImpl(o, name + ".Impl", "AttrSel.Algs.BaseAttributeSelectionAlgorithm<weka.attributeSelection.ASSearch> " + mi.Name);
      }
      if (pt == typeof(Clusterer)) {
        return GetSetterTemplateImpl(o, name + ".Impl", "Clstr.IBaseClusterer<weka.clusterers.Clusterer> " + mi.Name);
      }
      if (pt == typeof(Instances)) {
        return GetSetterTemplateImpl(o, name + ".Impl", "Runtime " + mi.Name);
      }
      if (o.Method.Name == "setAttributeRange")
      {
        const string arg = "System.String.Join(\",\", attributes.Select(a => a + 1))";
        return GetSetterTemplateImpl(o, arg, "params int[] attributes");
      }
      return String.Empty;
    }

    private static string GetSetterTemplateImpl(SetterModel o, string arg, string opttype) {
      var impl = "Impl." + o.Method.Name + "(" + arg + ");";
      var args = new [] {opttype};
      return Utils.GetSetterCode(o.SetterDescription, o.Model.TypeName, o.SetterName, args, impl);
    }
  }
}