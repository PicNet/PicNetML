using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// Merges values of all nominal attributes among the specified attributes,
  /// excluding the class attribute, using the CHAID method, but without
  /// considering to re-split merged subsets. It implements Steps 1 and 2 described by
  /// Kass (1980), see<br/><br/>Gordon V. Kass (1980). An Exploratory Technique for
  /// Investigating Large Quantities of Categorical Data. Applied Statistics.
  /// 29(2):119-127.<br/><br/>Once attribute values have been merged, a chi-squared
  /// test using the Bonferroni correction is applied to check if the resulting
  /// attribute is a valid predictor, based on the Bonferroni multiplier in
  /// Equation 3.2 in Kass (1980). If an attribute does not pass this test, all
  /// remaining values (if any) are merged. Nevertheless, useless predictors can slip
  /// through without being fully merged, e.g. identifier attributes.<br/><br/>The
  /// code applies the Yates correction when the chi-squared statistic is
  /// computed.<br/><br/>Note that the algorithm is quadratic in the number of attribute
  /// values for an attribute.<br/><br/>Options:<br/><br/>-D = 	Turns on output
  /// of debugging information.<br/>-L &lt;double&gt; = 	The significance level
  /// (default: 0.05).<br/><br/>-R &lt;range&gt; = 	Sets list of attributes to act
  /// on (or its inverse). 'first and 'last' are accepted as well.'<br/>	E.g.:
  /// first-5,7,9,20-last<br/>	(default: first-last)<br/>-V = 	Invert matching
  /// sense (i.e. act on all attributes not specified in list)<br/>-O = 	Use short
  /// identifiers for merged subsets.
  /// </summary>
  public class MergeNominalValues : BaseFilter<weka.filters.supervised.attribute.MergeNominalValues>
  {
    public MergeNominalValues(Runtime rt) : base(rt, new weka.filters.supervised.attribute.MergeNominalValues()) {
      
    }

    /// <summary>
    /// The significance level for the chi-squared test used to decide when to
    /// stop merging.
    /// </summary>    
    public MergeNominalValues SignificanceLevel (double sF) {
      Impl.setSignificanceLevel(sF);
      return this;
    }

    /// <summary>
    /// Specify range of attributes to act on (or its inverse). This is a comma
    /// separated list of attribute indices, with "first" and "last" valid values.
    /// Specify an inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public MergeNominalValues AttributeIndices (string rangeList) {
      Impl.setAttributeIndices(rangeList);
      return this;
    }

    /// <summary>
    /// Determines whether selected attributes are to be acted on or all other
    /// attributes are used instead.
    /// </summary>    
    public MergeNominalValues InvertSelection (bool invert) {
      Impl.setInvertSelection(invert);
      return this;
    }

    /// <summary>
    /// Whether to use short identifiers for the merged values.
    /// </summary>    
    public MergeNominalValues UseShortIdentifiers (bool b) {
      Impl.setUseShortIdentifiers(b);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public MergeNominalValues AttributeIndicesArray (int[] attributes) {
      Impl.setAttributeIndicesArray(attributes);
      return this;
    }

    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public MergeNominalValues Debug (bool value) {
      Impl.setDebug(value);
      return this;
    }

        
        
  }
}