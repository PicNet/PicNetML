using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// Merges two values of a nominal attribute into one
  /// value.<br/><br/>Options:<br/><br/>-C &lt;col&gt; = 	Sets the attribute index (default
  /// last).<br/>-F &lt;value index&gt; = 	Sets the first value's index (default
  /// first).<br/>-S &lt;value index&gt; = 	Sets the second value's index (default last).
  /// </summary>
  public class MergeTwoValues : BaseFilter<weka.filters.unsupervised.attribute.MergeTwoValues>
  {
    public MergeTwoValues(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.MergeTwoValues()) {
      
    }

    /// <summary>
    /// Sets which attribute to process. This attribute must be nominal ("first"
    /// and "last" are valid values)
    /// </summary>    
    public MergeTwoValues AttributeIndex (string attIndex) {
      Impl.setAttributeIndex(attIndex);
      return this;
    }

    /// <summary>
    /// Sets the first value to be merged. ("first" and "last" are valid values)
    /// </summary>    
    public MergeTwoValues FirstValueIndex (string firstIndex) {
      Impl.setFirstValueIndex(firstIndex);
      return this;
    }

    /// <summary>
    /// Sets the second value to be merged. ("first" and "last" are valid values)
    /// </summary>    
    public MergeTwoValues SecondValueIndex (string secondIndex) {
      Impl.setSecondValueIndex(secondIndex);
      return this;
    }

        
        
  }
}