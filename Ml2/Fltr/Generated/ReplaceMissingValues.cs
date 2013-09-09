using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Replaces all missing values for nominal and numeric attributes in a
  /// dataset with the modes and means from the training
  /// data.<br/><br/>Options:<br/><br/>-unset-class-temporarily = 	Unsets the class index temporarily before
  /// the filter is<br/>	applied to the data.<br/>	(default: no)
  /// </summary>
  public class ReplaceMissingValues : BaseFilter<weka.filters.unsupervised.attribute.ReplaceMissingValues>
  {
    public ReplaceMissingValues(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.ReplaceMissingValues()) {
      
    }

    /// <summary>
    /// The class index will be unset temporarily before the filter is applied.
    /// </summary>    
    public ReplaceMissingValues IgnoreClass (bool newIgnoreClass) {
      Impl.setIgnoreClass(newIgnoreClass);
      return this;
    }

        
        
  }
}