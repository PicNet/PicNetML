using System;
using System.Collections.Generic;
using System.IO;
using PicNetML.RuntimeHelpers;
using weka.classifiers;
using weka.core;

namespace PicNetML.Clss
{
  public abstract class UntypedBaseClassifier<I> : IUntypedBaseClassifier<I> where I : Classifier
  {
    public Runtime Runtime { get; protected set; }
    public bool Built { get; set; }
    public I Impl { get; private set; }

    protected UntypedBaseClassifier(I impl)
    {
      Impl = impl;
      
      InternalHelpers.SetSeedOnInstance(impl);
    }    

    public double ClassifyInstance(PmlInstance instance)
    {
      Build();
      return Impl.classifyInstance(instance.Impl);
    }

    public abstract IUntypedBaseClassifier<I> Build(bool quiet = false);

    public double ClassifyInstanceProba(PmlInstance instance) {
      Build();
      var confidences = Impl.distributionForInstance(instance.Impl);
      if (confidences.Length != 2) throw new NotSupportedException("ClassifyProba only supports binary classifiers");

      return confidences[0] > confidences[1] ? 
        1 - confidences[0] : 
        confidences[1];
    }

    public List<string> GeneratePredictions<T>(
        Runtime testset,
        Func<double, int, string> outputline, 
        string logfile = null, 
        Func<int, double> exception_value = null,
        bool quiet = false) {
      return new PredictionsGenerator(testset).GeneratePredictionsImpl(
          outputline, (IBaseClassifier<Classifier>) this, logfile, exception_value, quiet);
    }       

    public PmlEvaluation EvaluateWithCrossValidation(Runtime runtime, int numfolds = 10, bool quiet = false)
    {
      Build(quiet);
      return new ClassifierEvaluator(runtime, (IBaseClassifier<Classifier>) this).
        EvaluateWithCrossValidateion(numfolds, quiet);
    }

    public PmlEvaluation Evaluate(Runtime test, bool quiet = false)
    {
      Build(quiet);
      return new ClassifierEvaluator(test, (IBaseClassifier<Classifier>) this).
        Evaluate(quiet);
    }   
  }

  public static class BaseClassifier {
    public static IUntypedBaseClassifier<Classifier> Read(string file) {
      var classifier = new weka.classifiers.misc.SerializedClassifier();
      classifier.setModelFile(new java.io.File(file));
      return new DeserialisedClassifier(classifier);
    }

    public static void FlushToFile(IUntypedBaseClassifier<Classifier> classifier, string file, bool quiet = false) {
      FlushToFile(classifier.Impl, file, quiet);
    }

    public static void FlushToFile(Classifier classifier, string file, bool quiet = false) {
      var start = DateTime.Now;
      if (File.Exists(file)) File.Delete(file);
      if (!quiet) Console.WriteLine("Saving model to disk: " + file);

      try {
        Debug.saveToFile(file, classifier);
        if (!quiet) Console.WriteLine("Saving model to disk took: {0}ms", DateTime.Now.Subtract(start));
      } catch (Exception e) {
        Console.WriteLine("Could not save model to disk: {0}", e.Message);
      }
      
    }
  }
}