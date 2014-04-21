using System;
using System.Collections.Generic;
using weka.classifiers;

namespace PicNetML.Clss {
  public interface IUntypedBaseClassifier<out I> where I : Classifier {    
    Runtime Runtime { get; }
    bool Built { get; set; }
    I Impl { get; }    
    
    double ClassifyInstance(PmlInstance instance);
    double ClassifyInstanceProba(PmlInstance instance);    
    PmlEvaluation EvaluateWithCrossValidation(Runtime runtime, int numfolds = 10, bool quiet = false);
    List<string> GeneratePredictions<T>(
        Runtime testset,
        Func<double, int, string> outputline, 
        string logfile = null, 
        Func<int, double> exception_value = null,
        bool quiet = false);
  }
}