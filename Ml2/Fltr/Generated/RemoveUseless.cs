using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// This filter removes attributes that do not vary at all or that vary too
  /// much. All constant attributes are deleted automatically, along with any that
  /// exceed the maximum percentage of variance parameter. The maximum variance
  /// test is only applied to nominal attributes.<br/><br/>Options:<br/><br/>-M
  /// &lt;max variance %&gt; = 	Maximum variance percentage allowed (default 99)
  /// </summary>
  public class RemoveUseless : BaseFilter<weka.filters.unsupervised.attribute.RemoveUseless>
  {
    public RemoveUseless(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.RemoveUseless()) {
      
    }

    /// <summary>
    /// Set the threshold for the highest variance allowed before a nominal
    /// attribute will be deleted.Specifically, if (number_of_distinct_values /
    /// total_number_of_values * 100) is greater than this value then the attribute will be
    /// removed.
    /// </summary>    
    public RemoveUseless MaximumVariancePercentageAllowed (double maxVariance) {
      Impl.setMaximumVariancePercentageAllowed(maxVariance);
      return this;
    }

        
        
  }
}