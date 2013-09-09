using System;
using System.Collections.Generic;
using System.IO;
using Ml2.RuntimeHelpers;
using weka.classifiers;
using weka.core;

namespace Ml2.Clss
{
  public interface IBaseClassifier<out I> where I : Classifier {
    Runtime Runtime { get; }
    I Impl { get; }
    bool Built { get; set; }

    double Classify<T>(T o) where T : new();
    double ClassifyProba<T>(T o) where T : new();
    double Classify(Ml2Instance instance);
    double ClassifyProba(Ml2Instance instance);
    IBaseClassifier<I> Build(bool quiet = false);
    IBaseClassifier<I> FlushToFile(string file, bool quiet = false);
    Ml2Evaluation EvaluateWithCrossValidation(int numfolds = 10, bool quiet = false);
    List<string> GeneratePredictions<T>(
        Runtime testset,
        Func<double, int, string> outputline, 
        string logfile = null, 
        Func<int, double> exception_value = null,
        bool quiet = false);
  }

  public class BaseClassifier<I> : IBaseClassifier<I> where I : Classifier
  {    
    public Runtime Runtime { get; private set; }
    public I Impl { get; private set; }
    public bool Built { get; set; }

    public BaseClassifier(Runtime rt, I impl)
    {
      Runtime = rt;
      Impl = impl;
      
      InternalHelpers.SetSeedOnInstance(impl);
    }

    public double Classify<T>(T o) where T : new() {
      if (Runtime == null) throw new ApplicationException("Cannot use Classify/ClassifyProba(T) if loading a model from a file.  Use Classify/ClassifyProba(Runtime.BuildInstance<Type>(classidx, row) instead.");
      return Classify(Runtime.BuildInstance(o));
    }

    public double ClassifyProba<T>(T o) where T : new() {
      if (Runtime == null) throw new ApplicationException("Cannot use Classify/ClassifyProba(T) if loading a model from a file.  Use Classify/ClassifyProba(Runtime.BuildInstance<Type>(classidx, row) instead.");
      return ClassifyProba(Runtime.BuildInstance(o));
    }

    public double Classify(Ml2Instance instance)
    {
      Build();
      return Impl.classifyInstance(instance.Impl);
    }

    public double ClassifyProba(Ml2Instance instance) {
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
    
    public IBaseClassifier<I> FlushToFile(string file, bool quiet = false) {
      Build();
      BaseClassifier.FlushToFile(Impl, file, quiet);      
      return this;
    }    

    public Ml2Evaluation EvaluateWithCrossValidation(int numfolds = 10, bool quiet = false)
    {
      Build(quiet);
      return new ClassifierEvaluator(Runtime, (IBaseClassifier<Classifier>) this).
        EvaluateWithCrossValidateion(numfolds, quiet);
    }

    public Ml2Evaluation Evaluate(Runtime test, bool quiet = false)
    {
      Build(quiet);
      return new ClassifierEvaluator(test, (IBaseClassifier<Classifier>) this).
        Evaluate(quiet);
    }

    public IBaseClassifier<I> Build(bool quiet = false)
    {
      if (Built) return this;
      Built = true;
      var start = DateTime.Now;
      Impl.buildClassifier(Runtime.Impl);
      var took = DateTime.Now.Subtract(start);
      
      if (!quiet) Console.WriteLine("Building Classifier Took {0}ms", took);
      
      return this;
    }
  }

  public static class BaseClassifier {
    public static IBaseClassifier<Classifier> Read(string file) {
      var classifier = new weka.classifiers.misc.SerializedClassifier();
      classifier.setModelFile(new java.io.File(file));
      return new EmptyClassifier(classifier);
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