using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// A filter for detecting outliers and extreme values based on interquartile
  /// ranges. The filter skips the class attribute.<br/><br/>Outliers:<br/> Q3 +
  /// OF*IQR < x <= Q3 + EVF*IQR<br/> or<br/> Q1 - EVF*IQR <= x < Q1 -
  /// OF*IQR<br/><br/>Extreme values:<br/> x > Q3 + EVF*IQR<br/> or<br/> x < Q1 -
  /// EVF*IQR<br/><br/>Key:<br/> Q1 = 25% quartile<br/> Q3 = 75% quartile<br/> IQR =
  /// Interquartile Range, difference between Q1 and Q3<br/> OF = Outlier Factor<br/>
  /// EVF = Extreme Value Factor<br/><br/>Options:<br/><br/>-D = 	Turns on
  /// output of debugging information.<br/>-R &lt;col1,col2-col4,...&gt; = 	Specifies
  /// list of columns to base outlier/extreme value detection<br/>	on. If an
  /// instance is considered in at least one of those<br/>	attributes an
  /// outlier/extreme value, it is tagged accordingly.<br/> 'first' and 'last' are valid
  /// indexes.<br/>	(default none)<br/>-O &lt;num&gt; = 	The factor for outlier
  /// detection.<br/>	(default: 3)<br/>-E &lt;num&gt; = 	The factor for extreme values
  /// detection.<br/>	(default: 2*Outlier Factor)<br/>-E-as-O = 	Tags extreme
  /// values also as outliers.<br/>	(default: off)<br/>-P = 	Generates
  /// Outlier/ExtremeValue pair for each numeric attribute in<br/>	the range, not just a
  /// single indicator pair for all the attributes.<br/>	(default: off)<br/>-M =
  /// 	Generates an additional attribute 'Offset' per Outlier/ExtremeValue<br/>	pair
  /// that contains the multiplier that the value is off the median.<br/>	 value
  /// = median + 'multiplier' * IQR<br/>Note: implicitely sets '-P'.	(default:
  /// off)
  /// </summary>
  public class InterquartileRange : BaseFilter<weka.filters.unsupervised.attribute.InterquartileRange>
  {
    public InterquartileRange(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.InterquartileRange()) {
      
    }

    /// <summary>
    /// Specify range of attributes to act on; this is a comma separated list of
    /// attribute indices, with "first" and "last" valid values; specify an
    /// inclusive range with "-", eg: "first-3,5,6-10,last".
    /// </summary>    
    public InterquartileRange AttributeIndices (string value) {
      Impl.setAttributeIndices(value);
      return this;
    }

    /// <summary>
    /// The factor for determining the thresholds for outliers.
    /// </summary>    
    public InterquartileRange OutlierFactor (double value) {
      Impl.setOutlierFactor(value);
      return this;
    }

    /// <summary>
    /// The factor for determining the thresholds for extreme values.
    /// </summary>    
    public InterquartileRange ExtremeValuesFactor (double value) {
      Impl.setExtremeValuesFactor(value);
      return this;
    }

    /// <summary>
    /// Whether to tag extreme values also as outliers.
    /// </summary>    
    public InterquartileRange ExtremeValuesAsOutliers (bool value) {
      Impl.setExtremeValuesAsOutliers(value);
      return this;
    }

    /// <summary>
    /// Generates Outlier/ExtremeValue attribute pair for each numeric attribute,
    /// not just a single pair for all numeric attributes together.
    /// </summary>    
    public InterquartileRange DetectionPerAttribute (bool value) {
      Impl.setDetectionPerAttribute(value);
      return this;
    }

    /// <summary>
    /// Generates an additional attribute 'Offset' that contains the multiplier
    /// the value is off the median: value = median + 'multiplier' * IQR
    /// </summary>    
    public InterquartileRange OutputOffsetMultiplier (bool value) {
      Impl.setOutputOffsetMultiplier(value);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public InterquartileRange AttributeIndicesArray (int[] value) {
      Impl.setAttributeIndicesArray(value);
      return this;
    }

    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public InterquartileRange Debug (bool value) {
      Impl.setDebug(value);
      return this;
    }

        
        
  }
}