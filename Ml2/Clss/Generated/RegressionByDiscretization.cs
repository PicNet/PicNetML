using System.Collections.Generic;
using System.Linq;
using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// A regression scheme that employs any classifier on a copy of the data
  /// that has the class attribute discretized. The predicted value is the expected
  /// value of the mean class value for each discretized interval (based on the
  /// predicted probabilities for each interval). This class now also supports
  /// conditional density estimation by building a univariate density estimator from
  /// the target values in the training data, weighted by the class
  /// probabilities. <br/><br/>For more information on this process, see<br/><br/>Eibe Frank,
  /// Remco R. Bouckaert: Conditional Density Estimation with Class Probability
  /// Estimators. In: First Asian Conference on Machine Learning, Berlin, 65-81,
  /// 2009.<br/><br/>Options:<br/><br/>-B &lt;int&gt; = 	Number of bins for
  /// equal-width discretization<br/>	(default 10).<br/><br/>-E = 	Whether to delete
  /// empty bins after discretization<br/>	(default false).<br/><br/>-A = 	Whether
  /// to minimize absolute error, rather than squared error.<br/>	(default
  /// false).<br/><br/>-F = 	Use equal-frequency instead of equal-width
  /// discretization.<br/>-K = 	What type of density estimator to use:
  /// 0=histogram/1=kernel/2=normal (default: 0).<br/>-D = 	If set, classifier is run in debug mode
  /// and<br/>	may output additional info to the console<br/>-W = 	Full name of base
  /// classifier.<br/>	(default: weka.classifiers.trees.J48)<br/><br/>Options
  /// specific to classifier weka.classifiers.trees.J48: = <br/>-U = 	Use unpruned
  /// tree.<br/>-O = 	Do not collapse tree.<br/>-C &lt;pruning confidence&gt; =
  /// 	Set confidence threshold for pruning.<br/>	(default 0.25)<br/>-M &lt;minimum
  /// number of instances&gt; = 	Set minimum number of instances per
  /// leaf.<br/>	(default 2)<br/>-R = 	Use reduced error pruning.<br/>-N &lt;number of
  /// folds&gt; = 	Set number of folds for reduced error<br/>	pruning. One fold is used
  /// as pruning set.<br/>	(default 3)<br/>-B = 	Use binary splits only.<br/>-S
  /// = 	Don't perform subtree raising.<br/>-L = 	Do not clean up after the tree
  /// has been built.<br/>-A = 	Laplace smoothing for predicted
  /// probabilities.<br/>-J = 	Do not use MDL correction for info gain on numeric
  /// attributes.<br/>-Q &lt;seed&gt; = 	Seed for random data shuffling (default 1).
  /// </summary>
  public class RegressionByDiscretization : BaseClassifier<weka.classifiers.meta.RegressionByDiscretization>
  {
    public RegressionByDiscretization(Runtime rt) : base(rt, new weka.classifiers.meta.RegressionByDiscretization()) {
      
    }

    /// <summary>
    /// Number of bins for discretization.
    /// </summary>    
    public RegressionByDiscretization NumBins (int numBins) {
      Impl.setNumBins(numBins);
      return this;
    }

    /// <summary>
    /// Whether to delete empty bins after discretization.
    /// </summary>    
    public RegressionByDiscretization DeleteEmptyBins (bool b) {
      Impl.setDeleteEmptyBins(b);
      return this;
    }

    /// <summary>
    /// If set to true, equal-frequency binning will be used instead of
    /// equal-width binning.
    /// </summary>    
    public RegressionByDiscretization UseEqualFrequency (bool newUseEqualFrequency) {
      Impl.setUseEqualFrequency(newUseEqualFrequency);
      return this;
    }

    /// <summary>
    /// Whether to minimize absolute error.
    /// </summary>    
    public RegressionByDiscretization MinimizeAbsoluteError (bool b) {
      Impl.setMinimizeAbsoluteError(b);
      return this;
    }

    /// <summary>
    /// The density estimator to use.
    /// </summary>    
    public RegressionByDiscretization EstimatorType (EEstimatorType newEstimator) {
      Impl.setEstimatorType(new weka.core.SelectedTag((int) newEstimator, weka.classifiers.meta.RegressionByDiscretization.TAGS_ESTIMATOR));
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public RegressionByDiscretization Classifier (Ml2.Clss.IBaseClassifier<weka.classifiers.Classifier>newClassifier) {
      Impl.setClassifier(newClassifier.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public RegressionByDiscretization Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
    public enum EEstimatorType {
      Histogram_density_estimator = 0,
      Kernel_density_estimator = 1,
      Normal_density_estimator = 2
    }

        
  }
}