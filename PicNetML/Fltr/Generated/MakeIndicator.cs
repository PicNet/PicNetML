using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// A filter that creates a new dataset with a boolean attribute replacing a
  /// nominal attribute. In the new dataset, a value of 1 is assigned to an
  /// instance that exhibits a particular range of attribute values, a 0 to an
  /// instance that doesn't. The boolean attribute is coded as numeric by
  /// default.<br/><br/>Options:<br/><br/>-C &lt;col&gt; = 	Sets the attribute index.<br/>-V
  /// &lt;index1,index2-index4,...&gt; = 	Specify the list of values to indicate.
  /// First and last are<br/>	valid indexes (default last)<br/>-N &lt;index&gt; =
  /// 	Set if new boolean attribute nominal.
  /// </summary>
  public class MakeIndicator : BaseFilter<weka.filters.unsupervised.attribute.MakeIndicator>
  {
    public MakeIndicator(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.MakeIndicator()) {
      
    }

    /// <summary>
    /// Sets which attribute should be replaced by the indicator. This attribute
    /// must be nominal.
    /// </summary>    
    public MakeIndicator AttributeIndex (string attIndex) {
      Impl.setAttributeIndex(attIndex);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public MakeIndicator ValueIndex (int index) {
      Impl.setValueIndex(index);
      return this;
    }

    /// <summary>
    /// Determines whether the output indicator attribute is numeric. If this is
    /// set to false, the output attribute will be nominal.
    /// </summary>    
    public MakeIndicator Numeric (bool value) {
      Impl.setNumeric(value);
      return this;
    }

    /// <summary>
    /// Specify range of nominal values to act on. This is a comma separated list
    /// of attribute indices (numbered from 1), with "first" and "last" valid
    /// values. Specify an inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public MakeIndicator ValueIndices (string range) {
      Impl.setValueIndices(range);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public MakeIndicator ValueIndicesArray (int[] indices) {
      Impl.setValueIndicesArray(indices);
      return this;
    }

        
        
  }
}