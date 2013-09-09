using System.Collections.Generic;
using System.Linq;
using weka.classifiers.functions;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Implements John Platt's sequential minimal optimization algorithm for
  /// training a support vector classifier.<br/><br/>This implementation globally
  /// replaces all missing values and transforms nominal attributes into binary
  /// ones. It also normalizes all attributes by default. (In that case the
  /// coefficients in the output are based on the normalized data, not the original data
  /// --- this is important for interpreting the
  /// classifier.)<br/><br/>Multi-class problems are solved using pairwise classification (1-vs-1 and if logistic
  /// models are built pairwise coupling according to Hastie and Tibshirani,
  /// 1998).<br/><br/>To obtain proper probability estimates, use the option that
  /// fits logistic regression models to the outputs of the support vector machine.
  /// In the multi-class case the predicted probabilities are coupled using
  /// Hastie and Tibshirani's pairwise coupling method.<br/><br/>Note: for improved
  /// speed normalization should be turned off when operating on
  /// SparseInstances.<br/><br/>For more information on the SMO algorithm, see<br/><br/>J. Platt:
  /// Fast Training of Support Vector Machines using Sequential Minimal
  /// Optimization. In B. Schoelkopf and C. Burges and A. Smola, editors, Advances in
  /// Kernel Methods - Support Vector Learning, 1998.<br/><br/>S.S. Keerthi, S.K.
  /// Shevade, C. Bhattacharyya, K.R.K. Murthy (2001). Improvements to Platt's SMO
  /// Algorithm for SVM Classifier Design. Neural Computation.
  /// 13(3):637-649.<br/><br/>Trevor Hastie, Robert Tibshirani: Classification by Pairwise Coupling.
  /// In: Advances in Neural Information Processing Systems,
  /// 1998.<br/><br/>Options:<br/><br/>-D = 	If set, classifier is run in debug mode and<br/>	may
  /// output additional info to the console<br/>-no-checks = 	Turns off all checks
  /// - use with caution!<br/>	Turning them off assumes that data is purely
  /// numeric, doesn't<br/>	contain any missing values, and has a nominal class.
  /// Turning them<br/>	off also means that no header information will be stored if
  /// the<br/>	machine is linear. Finally, it also assumes that no instance
  /// has<br/>	a weight equal to 0.<br/>	(default: checks on)<br/>-C &lt;double&gt; =
  /// 	The complexity constant C. (default 1)<br/>-N = 	Whether to
  /// 0=normalize/1=standardize/2=neither. (default 0=normalize)<br/>-L &lt;double&gt; = 	The
  /// tolerance parameter. (default 1.0e-3)<br/>-P &lt;double&gt; = 	The epsilon for
  /// round-off error. (default 1.0e-12)<br/>-M = 	Fit logistic models to SVM
  /// outputs. <br/>-V &lt;double&gt; = 	The number of folds for the
  /// internal<br/>	cross-validation. (default -1, use training data)<br/>-W &lt;double&gt; =
  /// 	The random number seed. (default 1)<br/>-K &lt;classname and parameters&gt;
  /// = 	The Kernel to use.<br/>	(default:
  /// weka.classifiers.functions.supportVector.PolyKernel)<br/><br/>Options specific to kernel
  /// weka.classifiers.functions.supportVector.PolyKernel: = <br/>-D = 	Enables debugging output (if
  /// available) to be printed.<br/>	(default: off)<br/>-no-checks = 	Turns off all
  /// checks - use with caution!<br/>	(default: checks on)<br/>-C &lt;num&gt; =
  /// 	The size of the cache (a prime number), 0 for full cache and <br/>	-1 to
  /// turn it off.<br/>	(default: 250007)<br/>-E &lt;num&gt; = 	The Exponent to
  /// use.<br/>	(default: 1.0)<br/>-L = 	Use lower-order terms.<br/>	(default: no)
  /// </summary>
  public class SMO : BaseClassifier<weka.classifiers.functions.SMO>
  {
    public SMO(Runtime rt) : base(rt, new weka.classifiers.functions.SMO()) {
      Impl.setRandomSeed(Runtime.GlobalRandomSeed);
    }

    /// <summary>
    /// Turns time-consuming checks off - use with caution.
    /// </summary>    
    public SMO ChecksTurnedOff (bool value) {
      Impl.setChecksTurnedOff(value);
      return this;
    }

    /// <summary>
    /// The complexity parameter C.
    /// </summary>    
    public SMO C (double v) {
      Impl.setC(v);
      return this;
    }

    /// <summary>
    /// The tolerance parameter (shouldn't be changed).
    /// </summary>    
    public SMO ToleranceParameter (double v) {
      Impl.setToleranceParameter(v);
      return this;
    }

    /// <summary>
    /// The epsilon for round-off error (shouldn't be changed).
    /// </summary>    
    public SMO Epsilon (double v) {
      Impl.setEpsilon(v);
      return this;
    }

    /// <summary>
    /// Determines how/if the data will be transformed.
    /// </summary>    
    public SMO FilterType (EFilterType newType) {
      Impl.setFilterType(new weka.core.SelectedTag((int) newType, weka.classifiers.functions.SMO.TAGS_FILTER));
      return this;
    }

    /// <summary>
    /// Whether to fit logistic models to the outputs (for proper probability
    /// estimates).
    /// </summary>    
    public SMO BuildLogisticModels (bool newbuildLogisticModels) {
      Impl.setBuildLogisticModels(newbuildLogisticModels);
      return this;
    }

    /// <summary>
    /// The number of folds for cross-validation used to generate training data
    /// for logistic models (-1 means use training data).
    /// </summary>    
    public SMO NumFolds (int newnumFolds) {
      Impl.setNumFolds(newnumFolds);
      return this;
    }

    /// <summary>
    /// The kernel to use.
    /// </summary>    
    public SMO Kernel (weka.classifiers.functions.supportVector.Kernel value) {
      Impl.setKernel(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public SMO Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
    public enum EFilterType {
      Normalize_training_data = 0,
      Standardize_training_data = 1,
      No_normalization_div_standardization = 2
    }

        
  }
}