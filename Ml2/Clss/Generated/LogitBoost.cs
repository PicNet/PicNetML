using System.Collections.Generic;
using System.Linq;
using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for performing additive logistic regression. <br/>This class
  /// performs classification using a regression scheme as the base learner, and can
  /// handle multi-class problems. For more information, see<br/><br/>J. Friedman,
  /// T. Hastie, R. Tibshirani (1998). Additive Logistic Regression: a
  /// Statistical View of Boosting. Stanford University.<br/><br/>Can do efficient internal
  /// cross-validation to determine appropriate number of
  /// iterations.<br/><br/>Options:<br/><br/>-Q = 	Use resampling instead of reweighting for
  /// boosting.<br/>-P &lt;percent&gt; = 	Percentage of weight mass to base training
  /// on.<br/>	(default 100, reduce to around 90 speed up)<br/>-F &lt;num&gt; = 	Number
  /// of folds for internal cross-validation.<br/>	(default 0 -- no
  /// cross-validation)<br/>-R &lt;num&gt; = 	Number of runs for internal
  /// cross-validation.<br/>	(default 1)<br/>-L &lt;num&gt; = 	Threshold on the improvement of the
  /// likelihood.<br/>	(default -Double.MAX_VALUE)<br/>-H &lt;num&gt; = 	Shrinkage
  /// parameter.<br/>	(default 1)<br/>-S &lt;num&gt; = 	Random number
  /// seed.<br/>	(default 1)<br/>-I &lt;num&gt; = 	Number of iterations.<br/>	(default
  /// 10)<br/>-D = 	If set, classifier is run in debug mode and<br/>	may output
  /// additional info to the console<br/>-W = 	Full name of base
  /// classifier.<br/>	(default: weka.classifiers.trees.DecisionStump)<br/><br/>Options specific to
  /// classifier weka.classifiers.trees.DecisionStump: = <br/>-D = 	If set,
  /// classifier is run in debug mode and<br/>	may output additional info to the console
  /// </summary>
  public class LogitBoost : BaseClassifier<weka.classifiers.meta.LogitBoost>
  {
    public LogitBoost(Runtime rt) : base(rt, new weka.classifiers.meta.LogitBoost()) {
      Impl.setSeed(Runtime.GlobalRandomSeed);
    }

    /// <summary>
    /// Number of folds for internal cross-validation (default 0 means no
    /// cross-validation is performed).
    /// </summary>    
    public LogitBoost NumFolds (int newNumFolds) {
      Impl.setNumFolds(newNumFolds);
      return this;
    }

    /// <summary>
    /// Number of runs for internal cross-validation.
    /// </summary>    
    public LogitBoost NumRuns (int newNumRuns) {
      Impl.setNumRuns(newNumRuns);
      return this;
    }

    /// <summary>
    /// Weight threshold for weight pruning (reduce to 90 for speeding up
    /// learning process).
    /// </summary>    
    public LogitBoost WeightThreshold (int threshold) {
      Impl.setWeightThreshold(threshold);
      return this;
    }

    /// <summary>
    /// Threshold on improvement in likelihood.
    /// </summary>    
    public LogitBoost LikelihoodThreshold (double newPrecision) {
      Impl.setLikelihoodThreshold(newPrecision);
      return this;
    }

    /// <summary>
    /// Shrinkage parameter (use small value like 0.1 to reduce overfitting).
    /// </summary>    
    public LogitBoost Shrinkage (double newShrinkage) {
      Impl.setShrinkage(newShrinkage);
      return this;
    }

    /// <summary>
    /// Whether resampling is used instead of reweighting.
    /// </summary>    
    public LogitBoost UseResampling (bool r) {
      Impl.setUseResampling(r);
      return this;
    }

    /// <summary>
    /// The number of iterations to be performed.
    /// </summary>    
    public LogitBoost NumIterations (int numIterations) {
      Impl.setNumIterations(numIterations);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public LogitBoost Classifier (Ml2.Clss.IBaseClassifier<weka.classifiers.Classifier>newClassifier) {
      Impl.setClassifier(newClassifier.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public LogitBoost Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}