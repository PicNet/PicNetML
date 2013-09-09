using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// An instance filter that passes all instances through unmodified.
  /// Primarily for testing purposes.
  /// </summary>
  public class AllFilter : BaseFilter<weka.filters.AllFilter>
  {
    public AllFilter(Runtime rt) : base(rt, new weka.filters.AllFilter()) {
      
    }

        
        
  }
}