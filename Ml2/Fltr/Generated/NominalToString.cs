using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Converts a nominal attribute (that is, a set number of values) to string
  /// (that is, an unspecified number of values).<br/><br/>Options:<br/><br/>-C
  /// &lt;col&gt; = 	Sets the range of attributes to convert (default last).
  /// </summary>
  public class NominalToString : BaseFilter<weka.filters.unsupervised.attribute.NominalToString>
  {
    public NominalToString(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.NominalToString()) {
      
    }

    /// <summary>
    /// Sets a range attributes to process. Any non-nominal attributes in the
    /// range are left untouched ("first" and "last" are valid values)
    /// </summary>    
    public NominalToString AttributeIndexes (string attIndex) {
      Impl.setAttributeIndexes(attIndex);
      return this;
    }

        
        
  }
}