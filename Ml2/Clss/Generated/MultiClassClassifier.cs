using System.Collections.Generic;
using System.Linq;
using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// A metaclassifier for handling multi-class datasets with 2-class
  /// classifiers. This classifier is also capable of applying error correcting output
  /// codes for increased accuracy.<br/><br/>Options:<br/><br/>-M &lt;num&gt; =
  /// 	Sets the method to use. Valid values are 0 (1-against-all),<br/>	1 (random
  /// codes), 2 (exhaustive code), and 3 (1-against-1). (default 0)<br/><br/>-R
  /// &lt;num&gt; = 	Sets the multiplier when using random codes. (default
  /// 2.0)<br/>-P = 	Use pairwise coupling (only has an effect for 1-against1)<br/>-S
  /// &lt;num&gt; = 	Random number seed.<br/>	(default 1)<br/>-D = 	If set, classifier
  /// is run in debug mode and<br/>	may output additional info to the
  /// console<br/>-W = 	Full name of base classifier.<br/>	(default:
  /// weka.classifiers.functions.Logistic)<br/><br/>Options specific to classifier
  /// weka.classifiers.functions.Logistic: = <br/>-D = 	Turn on debugging output.<br/>-C = 	Use
  /// conjugate gradient descent rather than BFGS updates.<br/>-R &lt;ridge&gt; = 	Set
  /// the ridge in the log-likelihood.<br/>-M &lt;number&gt; = 	Set the maximum
  /// number of iterations (default -1, until convergence).
  /// </summary>
  public class MultiClassClassifier : BaseClassifier<weka.classifiers.meta.MultiClassClassifier>
  {
    public MultiClassClassifier(Runtime rt) : base(rt, new weka.classifiers.meta.MultiClassClassifier()) {
      Impl.setSeed(Runtime.GlobalRandomSeed);
    }

    /// <summary>
    /// Sets the method to use for transforming the multi-class problem into
    /// several 2-class ones.
    /// </summary>    
    public MultiClassClassifier Method (EMethod newMethod) {
      Impl.setMethod(new weka.core.SelectedTag((int) newMethod, weka.classifiers.meta.MultiClassClassifier.TAGS_METHOD));
      return this;
    }

    /// <summary>
    /// Sets the width multiplier when using random codes. The number of codes
    /// generated will be thus number multiplied by the number of classes.
    /// </summary>    
    public MultiClassClassifier RandomWidthFactor (double newRandomWidthFactor) {
      Impl.setRandomWidthFactor(newRandomWidthFactor);
      return this;
    }

    /// <summary>
    /// Use pairwise coupling (only has an effect for 1-against-1).
    /// </summary>    
    public MultiClassClassifier UsePairwiseCoupling (bool p) {
      Impl.setUsePairwiseCoupling(p);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public MultiClassClassifier Classifier (Ml2.Clss.IBaseClassifier<weka.classifiers.Classifier>newClassifier) {
      Impl.setClassifier(newClassifier.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public MultiClassClassifier Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
    public enum EMethod {
      one_against_all = 0,
      Random_correction_code = 1,
      Exhaustive_correction_code = 2,
      one_against_one = 3
    }

        
  }
}