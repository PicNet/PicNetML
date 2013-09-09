using System;
using System.IO;
using Ml2.Clss;
using weka.classifiers;

namespace Ml2.RuntimeHelpers
{
  public class ClassifierEvaluator
  {
    private readonly Runtime runtime;
    private readonly IBaseClassifier<Classifier> classifier;

    public ClassifierEvaluator(Runtime runtime, IBaseClassifier<Classifier> classifier)
    {
      this.runtime = runtime;
      this.classifier = classifier;
    }

    public Ml2Evaluation EvaluateWithCrossValidateion(int numfolds = 10, bool quiet = false)
    {
      return EvaluateImpl(e => e.Impl.crossValidateModel(classifier.Impl, runtime.Impl, numfolds, new java.util.Random(Runtime.GlobalRandomSeed)), quiet);
    }

    public Ml2Evaluation Evaluate(bool quiet = false) {
      return EvaluateImpl(e => e.Impl.evaluateModel(classifier.Impl, runtime.Impl), quiet);
    }

    private Ml2Evaluation EvaluateImpl(Action<Ml2Evaluation> eval, bool quiet) {      
      var start = DateTime.Now;
      var evaluation = new Ml2Evaluation(new Evaluation(runtime.Impl));
      eval(evaluation);
      var description = FlushResultsToFile(DateTime.Now.Subtract(start), evaluation);
      if (!quiet) {
        Console.WriteLine("\n" + description);
      }
      return evaluation;
    }

    private string FlushResultsToFile(TimeSpan took, Ml2Evaluation eval)
    {
      var date = DateTime.Now;
      var filename = date.ToString("yyyyMMddTHHmmss.") + classifier.GetType().Name.ToLower() + ".eval";
      if (File.Exists(filename)) File.Delete(filename);
      
      var m = classifier.Impl.GetType().GetMethod("toString");      
      var classdesc = m == null ? null : (string) m.Invoke(classifier.Impl, new object[0]);
      
      var contents = "Evaluation Took " + took + "ms\n\n";
      if (!String.IsNullOrWhiteSpace(classdesc)) 
        contents +=  "Classifier:\n==========\n\n" + classdesc + "\n\n";
      contents += eval.ToSummaryString("Summary:\n=======\n\n", true);
      try { contents += eval.ToClassDetailsString("\n\nClass Details:\n=============\n\n"); } catch {}
      try { contents += eval.ToMatrixString("\n\nConfusion Matrix:\n================\n\n"); } catch {}
          
      File.WriteAllText(filename, contents);
      return contents;
    }
  }
}