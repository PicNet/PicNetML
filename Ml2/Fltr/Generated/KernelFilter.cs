using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Converts the given set of predictor variables into a kernel matrix. The
  /// class value remains unchangedm, as long as the preprocessing filter doesn't
  /// change it.<br/>By default, the data is preprocessed with the Center filter,
  /// but the user can choose any filter (NB: one must be careful that the
  /// filter does not alter the class attribute unintentionally). With
  /// weka.filters.AllFilter the preprocessing gets disabled.<br/><br/>For more information
  /// regarding preprocessing the data, see:<br/><br/>K.P. Bennett, M.J. Embrechts:
  /// An Optimization Perspective on Kernel Partial Least Squares Regression. In:
  /// Advances in Learning Theory: Methods, Models and Applications, 227-249,
  /// 2003.<br/><br/>Options:<br/><br/>-D = 	Turns on output of debugging
  /// information.<br/>-no-checks = 	Turns off all checks - use with caution!<br/>	Turning
  /// them off assumes that data is purely numeric, doesn't<br/>	contain any
  /// missing values, and has a nominal class. Turning them<br/>	off also means that
  /// no header information will be stored if the<br/>	machine is linear.
  /// Finally, it also assumes that no instance has<br/>	a weight equal to
  /// 0.<br/>	(default: checks on)<br/>-F &lt;filename&gt; = 	The file to initialize the
  /// filter with (optional).<br/>-C &lt;num&gt; = 	The class index for the file to
  /// initialize with,<br/>	First and last are valid (optional, default:
  /// last).<br/>-K &lt;classname and parameters&gt; = 	The Kernel to use.<br/>	(default:
  /// weka.classifiers.functions.supportVector.PolyKernel)<br/>-kernel-factor =
  /// 	Defines a factor for the kernel.<br/>		- RBFKernel: a factor for
  /// gamma<br/>			Standardize: 1/(2*N)<br/>			Normalize..: 6/N<br/>	Available parameters
  /// are:<br/>		N for # of instances, A for # of attributes<br/>	(default:
  /// 1)<br/>-P &lt;classname and parameters&gt; = 	The Filter used for preprocessing
  /// (use weka.filters.AllFilter<br/>	to disable preprocessing).<br/>	(default:
  /// weka.filters.unsupervised.attribute.Center)<br/><br/>Options specific to
  /// kernel weka.classifiers.functions.supportVector.PolyKernel: = <br/>-D =
  /// 	Enables debugging output (if available) to be printed.<br/>	(default:
  /// off)<br/>-no-checks = 	Turns off all checks - use with caution!<br/>	(default: checks
  /// on)<br/>-C &lt;num&gt; = 	The size of the cache (a prime number), 0 for
  /// full cache and <br/>	-1 to turn it off.<br/>	(default: 250007)<br/>-E
  /// &lt;num&gt; = 	The Exponent to use.<br/>	(default: 1.0)<br/>-L = 	Use lower-order
  /// terms.<br/>	(default: no)<br/><br/>Options specific to preprocessing filter
  /// weka.filters.unsupervised.attribute.Center: = <br/>-unset-class-temporarily
  /// = 	Unsets the class index temporarily before the filter is<br/>	applied to
  /// the data.<br/>	(default: no)
  /// </summary>
  public class KernelFilter : BaseFilter<weka.filters.unsupervised.attribute.KernelFilter>
  {
    public KernelFilter(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.KernelFilter()) {
      
    }

    /// <summary>
    /// Turns time-consuming checks off - use with caution.
    /// </summary>    
    public KernelFilter ChecksTurnedOff (bool value) {
      Impl.setChecksTurnedOff(value);
      return this;
    }

    /// <summary>
    /// The class index of the dataset to initialize the filter with (first and
    /// last are valid).
    /// </summary>    
    public KernelFilter InitFileClassIndex (string value) {
      Impl.setInitFileClassIndex(value);
      return this;
    }

    /// <summary>
    /// The kernel to use.
    /// </summary>    
    public KernelFilter Kernel (weka.classifiers.functions.supportVector.Kernel value) {
      Impl.setKernel(value);
      return this;
    }

    /// <summary>
    /// The factor for the kernel, with A = # of attributes and N = # of
    /// instances.
    /// </summary>    
    public KernelFilter KernelFactorExpression (string value) {
      Impl.setKernelFactorExpression(value);
      return this;
    }

    /// <summary>
    /// Sets the filter to use for preprocessing (use the AllFilter for no
    /// preprocessing).
    /// </summary>    
    public KernelFilter Preprocessing (Fltr.IBaseFilter<weka.filters.Filter> value) {
      Impl.setPreprocessing(value.Impl);
      return this;
    }

    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public KernelFilter Debug (bool value) {
      Impl.setDebug(value);
      return this;
    }

        
        
  }
}