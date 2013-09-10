using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using PicNetML.Clss;
using weka.classifiers;

namespace PicNetML.RuntimeHelpers
{
  internal class PredictionsGenerator {
    private readonly Runtime rt;

    internal PredictionsGenerator(Runtime rt) { this.rt = rt; }

    internal List<string> GeneratePredictionsImpl(
          Func<double, int, string> outputline, 
          IBaseClassifier<Classifier> classifier, 
          string logfile = null, 
          Func<int, double> exception_value = null,
          bool quiet = false) {

      var outlines = new List<string>();
      var failures = 0;
      var results = new Dictionary<double, int>();
      for (int i = 0; i < rt.NumInstances; i++) {        
        double classification;
        try {
          classification = classifier.ClassifyInstance(rt[i]);          
        } catch (Exception) {
          if (exception_value == null) throw;
          classification = exception_value(i);
          failures++;
        } 
        if (!results.ContainsKey(classification)) results[classification] = 1;
        else results[classification]++;
        
        if (outputline != null) { outlines.Add(outputline(classification, i)); }
      }      
      if (failures > 0) Console.WriteLine("GeneratePredictions had " + failures + " failures.");
      
      if (!quiet) Console.WriteLine("Predictions:\n\t" + String.Join("\n\t", results.
              Select(kvp => kvp.Key + ": " + kvp.Value + " - " + 
                (kvp.Value * 100.0 / rt.NumInstances).ToString("N5"))));
      
      if (String.IsNullOrEmpty(logfile)) {
        logfile = String.Format("{0}_predictions_{1}.csv", 
            classifier.GetType().Name, 
            DateTime.Now.ToString("yyyyMMdd_HHmmss"));        
      }
      if (outlines.Count > 0) { File.WriteAllLines(logfile, outlines); }

      return outlines;
    }
  }
}