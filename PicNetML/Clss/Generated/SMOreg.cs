using System.Collections.Generic;
using System.Linq;
using weka.classifiers.functions;

// ReSharper disable once CheckNamespace
namespace PicNetML.Clss
{
  /// <summary>
  /// SMOreg implements the support vector machine for regression. The
  /// parameters can be learned using various algorithms. The algorithm is selected by
  /// setting the RegOptimizer. The most popular algorithm (RegSMOImproved) is due
  /// to Shevade, Keerthi et al and this is the default
  /// RegOptimizer.<br/><br/>For more information see:<br/><br/>S.K. Shevade, S.S. Keerthi, C.
  /// Bhattacharyya, K.R.K. Murthy: Improvements to the SMO Algorithm for SVM Regression.
  /// In: IEEE Transactions on Neural Networks, 1999.<br/><br/>A.J. Smola, B.
  /// Schoelkopf (1998). A tutorial on support vector
  /// regression.<br/><br/>Options:<br/><br/>-C &lt;double&gt; = 	The complexity constant C.<br/>	(default
  /// 1)<br/>-N = 	Whether to 0=normalize/1=standardize/2=neither.<br/>	(default
  /// 0=normalize)<br/>-I &lt;classname and parameters&gt; = 	Optimizer class used for
  /// solving quadratic optimization problem<br/>	(default
  /// weka.classifiers.functions.supportVector.RegSMOImproved)<br/>-K &lt;classname and parameters&gt;
  /// = 	The Kernel to use.<br/>	(default:
  /// weka.classifiers.functions.supportVector.PolyKernel)<br/><br/>Options specific to optimizer ('-I')
  /// weka.classifiers.functions.supportVector.RegSMOImproved: = <br/>-T &lt;double&gt; = 	The
  /// tolerance parameter for checking the stopping criterion.<br/>	(default
  /// 0.001)<br/>-V = 	Use variant 1 of the algorithm when true, otherwise use
  /// variant 2.<br/>	(default true)<br/>-P &lt;double&gt; = 	The epsilon for round-off
  /// error.<br/>	(default 1.0e-12)<br/>-L &lt;double&gt; = 	The epsilon
  /// parameter in epsilon-insensitive loss function.<br/>	(default 1.0e-3)<br/>-W
  /// &lt;double&gt; = 	The random number seed.<br/>	(default 1)<br/><br/>Options
  /// specific to kernel ('-K') weka.classifiers.functions.supportVector.PolyKernel:
  /// = <br/>-D = 	Enables debugging output (if available) to be
  /// printed.<br/>	(default: off)<br/>-no-checks = 	Turns off all checks - use with
  /// caution!<br/>	(default: checks on)<br/>-C &lt;num&gt; = 	The size of the cache (a prime
  /// number), 0 for full cache and <br/>	-1 to turn it off.<br/>	(default:
  /// 250007)<br/>-E &lt;num&gt; = 	The Exponent to use.<br/>	(default: 1.0)<br/>-L =
  /// 	Use lower-order terms.<br/>	(default: no)
  /// </summary>
  public class SMOreg : BaseClassifier<weka.classifiers.functions.SMOreg>
  {
    public SMOreg(Runtime rt) : base(rt, new weka.classifiers.functions.SMOreg()) {
      
    }

    /// <summary>
    /// The complexity parameter C.
    /// </summary>    
    public SMOreg C (double v) {
      Impl.setC(v);
      return this;
    }

    /// <summary>
    /// Determines how/if the data will be transformed.
    /// </summary>    
    public SMOreg FilterType (EFilterType newType) {
      Impl.setFilterType(new weka.core.SelectedTag((int) newType, weka.classifiers.functions.SMOreg.TAGS_FILTER));
      return this;
    }

    /// <summary>
    /// The learning algorithm.
    /// </summary>    
    public SMOreg RegOptimizer (weka.classifiers.functions.supportVector.RegOptimizer regOptimizer) {
      Impl.setRegOptimizer(regOptimizer);
      return this;
    }

    /// <summary>
    /// The kernel to use.
    /// </summary>    
    public SMOreg Kernel (weka.classifiers.functions.supportVector.Kernel value) {
      Impl.setKernel(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public SMOreg Debug (bool debug) {
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