using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Resamples a dataset by applying the Synthetic Minority Oversampling
  /// TEchnique (SMOTE). The original dataset must fit entirely in memory. The amount
  /// of SMOTE and number of nearest neighbors may be specified. For more
  /// information, see <br/><br/>Nitesh V. Chawla et. al. (2002). Synthetic Minority
  /// Over-sampling Technique. Journal of Artificial Intelligence Research.
  /// 16:321-357.<br/><br/>Options:<br/><br/>-S &lt;num&gt; = 	Specifies the random
  /// number seed<br/>	(default 1)<br/>-P &lt;percentage&gt; = 	Specifies percentage
  /// of SMOTE instances to create.<br/>	(default 100.0)<br/><br/>-K
  /// &lt;nearest-neighbors&gt; = 	Specifies the number of nearest neighbors to
  /// use.<br/>	(default 5)<br/><br/>-C &lt;value-index&gt; = 	Specifies the index of the
  /// nominal class value to SMOTE<br/>	(default 0: auto-detect non-empty minority
  /// class))<br/>
  /// </summary>
  public class SMOTE : BaseFilter<weka.filters.supervised.instance.SMOTE>
  {
    public SMOTE(Runtime rt) : base(rt, new weka.filters.supervised.instance.SMOTE()) {
      Impl.setRandomSeed(Runtime.GlobalRandomSeed);
    }

    /// <summary>
    /// The percentage of SMOTE instances to create.
    /// </summary>    
    public SMOTE Percentage (double value) {
      Impl.setPercentage(value);
      return this;
    }

    /// <summary>
    /// The number of nearest neighbors to use.
    /// </summary>    
    public SMOTE NearestNeighbors (int value) {
      Impl.setNearestNeighbors(value);
      return this;
    }

    /// <summary>
    /// The index of the class value to which SMOTE should be applied. Use a
    /// value of 0 to auto-detect the non-empty minority class.
    /// </summary>    
    public SMOTE ClassValue (string value) {
      Impl.setClassValue(value);
      return this;
    }

        
        
  }
}