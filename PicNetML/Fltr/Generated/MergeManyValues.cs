using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// Merges many values of a nominal attribute into one
  /// value.<br/><br/>Options:<br/><br/>-C &lt;col&gt; = 	Sets the attribute index<br/>	(default:
  /// last)<br/>-L &lt;label&gt; = 	Sets the label of the newly merged
  /// classes<br/>	(default: 'merged')<br/>-R &lt;range&gt; = 	Sets the merge range. 'first and
  /// 'last' are accepted as well.'<br/>	E.g.: first-5,7,9,20-last<br/>	(default:
  /// 1,2)
  /// </summary>
  public class MergeManyValues : BaseFilter<weka.filters.unsupervised.attribute.MergeManyValues>
  {
    public MergeManyValues(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.MergeManyValues()) {
      
    }

    /// <summary>
    /// Sets which attribute to process. This attribute must be nominal ("first"
    /// and "last" are valid values)
    /// </summary>    
    public MergeManyValues AttributeIndex (string attIndex) {
      Impl.setAttributeIndex(attIndex);
      return this;
    }

    /// <summary>
    /// The new label for the merged values.
    /// </summary>    
    public MergeManyValues Label (string alabel) {
      Impl.setLabel(alabel);
      return this;
    }

    /// <summary>
    /// The range of values to merge.
    /// </summary>    
    public MergeManyValues MergeValueRange (string range) {
      Impl.setMergeValueRange(range);
      return this;
    }

        
        
  }
}