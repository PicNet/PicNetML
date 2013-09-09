using System.Collections.Generic;
using System.Linq;
using weka.classifiers.functions;

// ReSharper disable once CheckNamespace
namespace PicNetML.Clss
{
  /// <summary>
  /// Implements Gaussian processes for regression without
  /// hyperparameter-tuning. To make choosing an appropriate noise level easier, this implementation
  /// applies normalization/standardization to the target attribute as well as
  /// the other attributes (if normalization/standardizaton is turned on). Missing
  /// values are replaced by the global mean/mode. Nominal attributes are
  /// converted to binary ones. Note that kernel caching is turned off if the kernel
  /// used implements CachedKernel.<br/><br/>Options:<br/><br/>-D = 	If set,
  /// classifier is run in debug mode and<br/>	may output additional info to the
  /// console<br/>-L &lt;double&gt; = 	Level of Gaussian Noise wrt transformed target.
  /// (default 1)<br/>-N = 	Whether to 0=normalize/1=standardize/2=neither.
  /// (default 0=normalize)<br/>-K &lt;classname and parameters&gt; = 	The Kernel to
  /// use.<br/>	(default:
  /// weka.classifiers.functions.supportVector.PolyKernel)<br/><br/>Options specific to kernel
  /// weka.classifiers.functions.supportVector.PolyKernel: = <br/>-D = 	Enables debugging output (if available) to be
  /// printed.<br/>	(default: off)<br/>-no-checks = 	Turns off all checks - use with
  /// caution!<br/>	(default: checks on)<br/>-C &lt;num&gt; = 	The size of the
  /// cache (a prime number), 0 for full cache and <br/>	-1 to turn it
  /// off.<br/>	(default: 250007)<br/>-E &lt;num&gt; = 	The Exponent to use.<br/>	(default:
  /// 1.0)<br/>-L = 	Use lower-order terms.<br/>	(default: no)
  /// </summary>
  public class GaussianProcesses : BaseClassifier<weka.classifiers.functions.GaussianProcesses>
  {
    public GaussianProcesses(Runtime rt) : base(rt, new weka.classifiers.functions.GaussianProcesses()) {
      
    }

    /// <summary>
    /// The level of Gaussian Noise (added to the diagonal of the Covariance
    /// Matrix), after the target has been normalized/standardized/left unchanged).
    /// </summary>    
    public GaussianProcesses Noise (double v) {
      Impl.setNoise(v);
      return this;
    }

    /// <summary>
    /// Determines how/if the data will be transformed.
    /// </summary>    
    public GaussianProcesses FilterType (EFilterType newType) {
      Impl.setFilterType(new weka.core.SelectedTag((int) newType, weka.classifiers.functions.GaussianProcesses.TAGS_FILTER));
      return this;
    }

    /// <summary>
    /// The kernel to use.
    /// </summary>    
    public GaussianProcesses Kernel (weka.classifiers.functions.supportVector.Kernel value) {
      Impl.setKernel(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public GaussianProcesses Debug (bool debug) {
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