using System.Collections.Generic;
using System.Linq;
using weka.classifiers.trees.lmt;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// No class description found.
  /// </summary>
  public class LogisticBase : BaseClassifier<weka.classifiers.trees.lmt.LogisticBase>
  {
    public LogisticBase(Runtime rt) : base(rt, new weka.classifiers.trees.lmt.LogisticBase()) {
      
    }

    /// <summary>
    /// 
    /// </summary>    
    public LogisticBase MaxIterations (int maxIterations) {
      Impl.setMaxIterations(maxIterations);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public LogisticBase HeuristicStop (int heuristicStop) {
      Impl.setHeuristicStop(heuristicStop);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public LogisticBase WeightTrimBeta (double w) {
      Impl.setWeightTrimBeta(w);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public LogisticBase UseAIC (bool c) {
      Impl.setUseAIC(c);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public LogisticBase Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}