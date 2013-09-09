using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// Centers all numeric attributes in the given dataset to have zero mean
  /// (apart from the class attribute, if
  /// set).<br/><br/>Options:<br/><br/>-unset-class-temporarily = 	Unsets the class index temporarily before the filter
  /// is<br/>	applied to the data.<br/>	(default: no)
  /// </summary>
  public class Center : BaseFilter<weka.filters.unsupervised.attribute.Center>
  {
    public Center(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.Center()) {
      
    }

    /// <summary>
    /// The class index will be unset temporarily before the filter is applied.
    /// </summary>    
    public Center IgnoreClass (bool newIgnoreClass) {
      Impl.setIgnoreClass(newIgnoreClass);
      return this;
    }

        
        
  }
}