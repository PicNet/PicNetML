using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// Applies several filters successively. In case all supplied filters are
  /// StreamableFilters, it will act as a streamable one,
  /// too.<br/><br/>Options:<br/><br/>-D = 	Turns on output of debugging information.<br/>-F &lt;classname
  /// [options]&gt; = 	A filter to apply (can be specified multiple times).
  /// </summary>
  public class MultiFilter : BaseFilter<weka.filters.MultiFilter>
  {
    public MultiFilter(Runtime rt) : base(rt, new weka.filters.MultiFilter()) {
      
    }

    /// <summary>
    /// The base filters to be used.
    /// </summary>    
    public MultiFilter Filters (IEnumerable<Fltr.IBaseFilter<weka.filters.Filter>> filters) {
      Impl.setFilters(filters.Select(v => v.Impl).ToArray());
      return this;
    }

    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public MultiFilter Debug (bool value) {
      Impl.setDebug(value);
      return this;
    }

        
        
  }
}