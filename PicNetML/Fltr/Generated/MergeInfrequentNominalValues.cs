using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// Merges all values of the specified nominal attribute that are
  /// sufficiently infrequent.<br/><br/>Options:<br/><br/>-D = 	Turns on output of debugging
  /// information.<br/>-N &lt;int&gt; = 	The minimum frequency for a value to
  /// remain (default: 2).<br/><br/>-R &lt;range&gt; = 	Sets list of attributes to
  /// act on (or its inverse). 'first and 'last' are accepted as
  /// well.'<br/>	E.g.: first-5,7,9,20-last<br/>	(default: 1,2)<br/>-V = 	Invert matching sense
  /// (i.e. act on all attributes not specified in list)
  /// </summary>
  public class MergeInfrequentNominalValues : BaseFilter<weka.filters.unsupervised.attribute.MergeInfrequentNominalValues>
  {
    public MergeInfrequentNominalValues(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.MergeInfrequentNominalValues()) {
      
    }

    /// <summary>
    /// The minimum frequency for a value to remain.
    /// </summary>    
    public MergeInfrequentNominalValues MinimumFrequency (int minF) {
      Impl.setMinimumFrequency(minF);
      return this;
    }

    /// <summary>
    /// Specify range of attributes to act on (or its inverse). This is a comma
    /// separated list of attribute indices, with "first" and "last" valid values.
    /// Specify an inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public MergeInfrequentNominalValues AttributeIndices (string rangeList) {
      Impl.setAttributeIndices(rangeList);
      return this;
    }

    /// <summary>
    /// Determines whether selected attributes are to be acted on or all other
    /// attributes are used instead.
    /// </summary>    
    public MergeInfrequentNominalValues InvertSelection (bool invert) {
      Impl.setInvertSelection(invert);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public MergeInfrequentNominalValues AttributeIndicesArray (int[] attributes) {
      Impl.setAttributeIndicesArray(attributes);
      return this;
    }

    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public MergeInfrequentNominalValues Debug (bool value) {
      Impl.setDebug(value);
      return this;
    }

        
        
  }
}