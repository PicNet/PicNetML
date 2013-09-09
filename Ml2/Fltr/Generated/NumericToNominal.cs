using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// A filter for turning numeric attributes into nominal ones. Unlike
  /// discretization, it just takes all numeric values and adds them to the list of
  /// nominal values of that attribute. Useful after CSV imports, to enforce certain
  /// attributes to become nominal, e.g., the class attribute, containing values
  /// from 1 to 5.<br/><br/>Options:<br/><br/>-R &lt;col1,col2-col4,...&gt; =
  /// 	Specifies list of columns to Discretize. First and last are valid
  /// indexes.<br/>	(default: first-last)<br/>-V = 	Invert matching sense of column indexes.
  /// </summary>
  public class NumericToNominal : BaseFilter<weka.filters.unsupervised.attribute.NumericToNominal>
  {
    public NumericToNominal(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.NumericToNominal()) {
      
    }

    /// <summary>
    /// Set attribute selection mode. If false, only selected (numeric)
    /// attributes in the range will be 'nominalized'; if true, only non-selected attributes
    /// will be 'nominalized'.
    /// </summary>    
    public NumericToNominal InvertSelection (bool value) {
      Impl.setInvertSelection(value);
      return this;
    }

    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public NumericToNominal AttributeIndices (string value) {
      Impl.setAttributeIndices(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public NumericToNominal AttributeIndicesArray (int[] value) {
      Impl.setAttributeIndicesArray(value);
      return this;
    }

    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public NumericToNominal Debug (bool value) {
      Impl.setDebug(value);
      return this;
    }

        
        
  }
}