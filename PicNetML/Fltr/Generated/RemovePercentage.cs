using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// A filter that removes a given percentage of a
  /// dataset.<br/><br/>Options:<br/><br/>-P &lt;percentage&gt; = 	Specifies percentage of instances to
  /// select. (default 50)<br/><br/>-V = 	Specifies if inverse of selection is to be
  /// output.<br/>
  /// </summary>
  public class RemovePercentage : BaseFilter<weka.filters.unsupervised.instance.RemovePercentage>
  {
    public RemovePercentage(Runtime rt) : base(rt, new weka.filters.unsupervised.instance.RemovePercentage()) {
      
    }

    /// <summary>
    /// The percentage of the data to select.
    /// </summary>    
    public RemovePercentage Percentage (double percent) {
      Impl.setPercentage(percent);
      return this;
    }

    /// <summary>
    /// Whether to invert the selection.
    /// </summary>    
    public RemovePercentage InvertSelection (bool inverse) {
      Impl.setInvertSelection(inverse);
      return this;
    }

        
        
  }
}