using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// Swaps two values of a nominal attribute.<br/><br/>Options:<br/><br/>-C
  /// &lt;col&gt; = 	Sets the attribute index (default last).<br/>-F &lt;value
  /// index&gt; = 	Sets the first value's index (default first).<br/>-S &lt;value
  /// index&gt; = 	Sets the second value's index (default last).
  /// </summary>
  public class SwapValues : BaseFilter<weka.filters.unsupervised.attribute.SwapValues>
  {
    public SwapValues(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.SwapValues()) {
      
    }

    /// <summary>
    /// Sets which attribute to process. This attribute must be nominal ("first"
    /// and "last" are valid values)
    /// </summary>    
    public SwapValues AttributeIndex (string attIndex) {
      Impl.setAttributeIndex(attIndex);
      return this;
    }

    /// <summary>
    /// The index of the first value.("first" and "last" are valid values)
    /// </summary>    
    public SwapValues FirstValueIndex (string firstIndex) {
      Impl.setFirstValueIndex(firstIndex);
      return this;
    }

    /// <summary>
    /// The index of the second value.("first" and "last" are valid values)
    /// </summary>    
    public SwapValues SecondValueIndex (string secondIndex) {
      Impl.setSecondValueIndex(secondIndex);
      return this;
    }

        
        
  }
}