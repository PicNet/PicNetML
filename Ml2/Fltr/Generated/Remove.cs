using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// A filter that removes a range of attributes from the dataset. Will
  /// re-order the remaining attributes if invert matching sense is turned on and the
  /// attribute column indices are not specified in ascending
  /// order.<br/><br/>Options:<br/><br/>-R &lt;index1,index2-index4,...&gt; = 	Specify list of
  /// columns to delete. First and last are valid<br/>	indexes. (default none)<br/>-V =
  /// 	Invert matching sense (i.e. only keep specified columns)
  /// </summary>
  public class Remove : BaseFilter<weka.filters.unsupervised.attribute.Remove>
  {
    public Remove(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.Remove()) {
      
    }

    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public Remove AttributeIndices (string rangeList) {
      Impl.setAttributeIndices(rangeList);
      return this;
    }

    /// <summary>
    /// Determines whether action is to select or delete. If set to true, only
    /// the specified attributes will be kept; If set to false, specified attributes
    /// will be deleted.
    /// </summary>    
    public Remove InvertSelection (bool invert) {
      Impl.setInvertSelection(invert);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public Remove AttributeIndicesArray (int[] attributes) {
      Impl.setAttributeIndicesArray(attributes);
      return this;
    }

        
        
  }
}