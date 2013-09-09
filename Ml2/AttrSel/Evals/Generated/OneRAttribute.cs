using weka.core;
using weka.attributeSelection;

// ReSharper disable once CheckNamespace
namespace Ml2.AttrSel.Evals
{
  /// <summary>
  /// OneRAttributeEval :<br/><br/>Evaluates the worth of an attribute by using
  /// the OneR classifier.<br/><br/><br/>Options:<br/><br/>-S &lt;seed&gt; =
  /// 	Random number seed for cross validation<br/>	(default = 1)<br/>-F
  /// &lt;folds&gt; = 	Number of folds for cross validation<br/>	(default = 10)<br/>-D =
  /// 	Use training data for evaluation rather than cross validaton<br/>-B
  /// &lt;minimum bucket size&gt; = 	Minimum number of objects in a bucket<br/>	(passed on
  /// to OneR, default = 6)
  /// </summary>
  public class OneRAttribute : BaseAttributeSelectionEvaluator<weka.attributeSelection.OneRAttributeEval>
  {
    public OneRAttribute(Runtime rt) : base(rt, new weka.attributeSelection.OneRAttributeEval()) {
      Impl.setSeed(Runtime.GlobalRandomSeed);
    }
    
    /// <summary>
    /// Set the number of folds for cross validation.
    /// </summary>    
    public OneRAttribute Folds (int folds) {
      Impl.setFolds(folds);
      return this;
    }

    /// <summary>
    /// The minimum number of objects in a bucket (passed to OneR).
    /// </summary>    
    public OneRAttribute MinimumBucketSize (int minB) {
      Impl.setMinimumBucketSize(minB);
      return this;
    }

    /// <summary>
    /// Use the training data to evaluate attributes rather than cross
    /// validation.
    /// </summary>    
    public OneRAttribute EvalUsingTrainingData (bool e) {
      Impl.setEvalUsingTrainingData(e);
      return this;
    }

            
        
  }
}