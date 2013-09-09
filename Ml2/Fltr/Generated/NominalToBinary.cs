using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Converts all nominal attributes into binary numeric attributes. An
  /// attribute with k values is transformed into k binary attributes if the class is
  /// nominal (using the one-attribute-per-value approach). Binary attributes are
  /// left binary, if option '-A' is not given.If the class is numeric, you might
  /// want to use the supervised version of this
  /// filter.<br/><br/>Options:<br/><br/>-N = 	Sets if binary attributes are to be coded as nominal ones.<br/>-A
  /// = 	For each nominal value a new attribute is created, <br/>	not only if
  /// there are more than 2 values.<br/>-R &lt;col1,col2-col4,...&gt; = 	Specifies
  /// list of columns to act on. First and last are <br/>	valid
  /// indexes.<br/>	(default: first-last)<br/>-V = 	Invert matching sense of column indexes.
  /// </summary>
  public class NominalToBinary : BaseFilter<weka.filters.unsupervised.attribute.NominalToBinary>
  {
    public NominalToBinary(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.NominalToBinary()) {
      
    }

    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public NominalToBinary AttributeIndices (string rangeList) {
      Impl.setAttributeIndices(rangeList);
      return this;
    }

    /// <summary>
    /// Whether resulting binary attributes will be nominal.
    /// </summary>    
    public NominalToBinary BinaryAttributesNominal (bool value) {
      Impl.setBinaryAttributesNominal(value);
      return this;
    }

    /// <summary>
    /// Whether all nominal values are turned into new attributes, not only if
    /// there are more than 2.
    /// </summary>    
    public NominalToBinary TransformAllValues (bool value) {
      Impl.setTransformAllValues(value);
      return this;
    }

    /// <summary>
    /// Set attribute selection mode. If false, only selected (numeric)
    /// attributes in the range will be discretized; if true, only non-selected attributes
    /// will be discretized.
    /// </summary>    
    public NominalToBinary InvertSelection (bool invert) {
      Impl.setInvertSelection(invert);
      return this;
    }

        
        
  }
}