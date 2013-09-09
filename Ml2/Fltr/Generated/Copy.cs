using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// An instance filter that copies a range of attributes in the dataset. This
  /// is used in conjunction with other filters that overwrite attribute values
  /// during the course of their operation -- this filter allows the original
  /// attributes to be kept as well as the new
  /// attributes.<br/><br/>Options:<br/><br/>-R &lt;index1,index2-index4,...&gt; = 	Specify list of columns to copy.
  /// First and last are valid<br/>	indexes. (default none)<br/>-V = 	Invert
  /// matching sense (i.e. copy all non-specified columns)
  /// </summary>
  public class Copy : BaseFilter<weka.filters.unsupervised.attribute.Copy>
  {
    public Copy(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.Copy()) {
      
    }

    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public Copy AttributeIndices (string rangeList) {
      Impl.setAttributeIndices(rangeList);
      return this;
    }

    /// <summary>
    /// Sets copy selected vs unselected action. If set to false, only the
    /// specified attributes will be copied; If set to true, non-specified attributes
    /// will be copied.
    /// </summary>    
    public Copy InvertSelection (bool invert) {
      Impl.setInvertSelection(invert);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public Copy AttributeIndicesArray (int[] attributes) {
      Impl.setAttributeIndicesArray(attributes);
      return this;
    }

        
        
  }
}