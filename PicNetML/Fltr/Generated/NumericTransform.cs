using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// Transforms numeric attributes using a given transformation
  /// method.<br/><br/>Options:<br/><br/>-R &lt;index1,index2-index4,...&gt; = 	Specify list of
  /// columns to transform. First and last are<br/>	valid indexes (default
  /// none). Non-numeric columns are <br/>	skipped.<br/>-V = 	Invert matching
  /// sense.<br/>-C &lt;string&gt; = 	Sets the class containing transformation
  /// method.<br/>	(default java.lang.Math)<br/>-M &lt;string&gt; = 	Sets the method.
  /// (default abs)
  /// </summary>
  public class NumericTransform : BaseFilter<weka.filters.unsupervised.attribute.NumericTransform>
  {
    public NumericTransform(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.NumericTransform()) {
      
    }

    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public NumericTransform AttributeIndices (string rangeList) {
      Impl.setAttributeIndices(rangeList);
      return this;
    }

    /// <summary>
    /// Whether to process the inverse of the given attribute ranges.
    /// </summary>    
    public NumericTransform InvertSelection (bool invert) {
      Impl.setInvertSelection(invert);
      return this;
    }

    /// <summary>
    /// Name of the class containing the method used for the transformation.
    /// </summary>    
    public NumericTransform ClassName (string name) {
      Impl.setClassName(name);
      return this;
    }

    /// <summary>
    /// Name of the method used for the transformation.
    /// </summary>    
    public NumericTransform MethodName (string name) {
      Impl.setMethodName(name);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public NumericTransform AttributeIndicesArray (int[] attributes) {
      Impl.setAttributeIndicesArray(attributes);
      return this;
    }

        
        
  }
}