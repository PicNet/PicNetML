using System;
using System.Collections.Generic;
using System.Linq;
using Ml2.Clss;
using Ml2.RuntimeHelpers;
using weka.classifiers;

namespace Ml2
{
  public partial class Runtime 
  {                  
    public Ml2Evaluation EvaluateWithCrossValidation(IBaseClassifier<Classifier> classifier, int numfolds = 10, bool quiet = false)
    {
      return new ClassifierEvaluator(this, classifier).
        EvaluateWithCrossValidateion(numfolds, quiet);
    }

    public List<string> GeneratePredictions(
        Func<double, int, string> outputline,
        IBaseClassifier<Classifier> classifier,
        string logfile = null, 
        Func<int, double> exception_value = null,
        bool quiet = false) {
      
      if (classifier.Runtime == this) 
        throw new ArgumentException("It appears that the training set is being used to generate predictions.  The Runtime used to train the classifier(s) should the different than the Runtime used when calling GeneratePredictions.");

      return new PredictionsGenerator(this).GeneratePredictionsImpl(
          outputline, classifier, logfile, exception_value, quiet);
    }

    public void EvaluateClassifier(
        IBaseClassifier<Classifier> classifier, 
        Runtime testing,
        bool crossFoldsEvaluate = true,
        bool runPredictions = true,      
        string saveModelToDiskFile = null,
        string loadModelfromDiskFile = null,
        int numFolds = 10) {
      Console.WriteLine("EvaluateClassifier");

      var start = DateTime.Now;      

      if (classifier != null) {
        classifier.Build();
      }

      if (!String.IsNullOrWhiteSpace(loadModelfromDiskFile)) {
        throw new NotSupportedException("loadModelfromDiskFile not supported " + 
            "as BaseClassifier.Read returns a Classifier not a IBaseClassifier as it should");
        // clas = BaseClassifier.Read(loadModelfromDiskFile);
        // Console.WriteLine("Loading Model From Disk Took: {0}", DateTime.Now.Subtract(start));
      }
      else if (!String.IsNullOrWhiteSpace(saveModelToDiskFile)) { classifier.FlushToFile(saveModelToDiskFile); }
      if (crossFoldsEvaluate) classifier.Runtime.EvaluateWithCrossValidation(classifier, numFolds); 
      if (runPredictions) testing.GeneratePredictions(null, classifier);
      
      Console.WriteLine("\n\nEvaluation Took: {0}", DateTime.Now.Subtract(start));
    }

    public double[] GetClassifications(IBaseClassifier<Classifier> classifier) { 
      return this.Select(classifier.Classify).ToArray();
    }
  }
}