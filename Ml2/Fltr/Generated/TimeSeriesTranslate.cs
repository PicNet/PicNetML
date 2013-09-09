using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// An instance filter that assumes instances form time-series data and
  /// replaces attribute values in the current instance with the equivalent attribute
  /// values of some previous (or future) instance. For instances where the
  /// desired value is unknown either the instance may be dropped, or missing values
  /// used. Skips the class attribute if it is set.<br/><br/>Options:<br/><br/>-R
  /// &lt;index1,index2-index4,...&gt; = 	Specify list of columns to translate in
  /// time. First and<br/>	last are valid indexes. (default none)<br/>-V =
  /// 	Invert matching sense (i.e. calculate for all non-specified columns)<br/>-I
  /// &lt;num&gt; = 	The number of instances forward to translate
  /// values<br/>	between. A negative number indicates taking values from<br/>	a past instance.
  /// (default -1)<br/>-M = 	For instances at the beginning or end of the dataset
  /// where<br/>	the translated values are not known, remove those
  /// instances<br/>	(default is to use missing values).
  /// </summary>
  public class TimeSeriesTranslate : BaseFilter<weka.filters.unsupervised.attribute.TimeSeriesTranslate>
  {
    public TimeSeriesTranslate(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.TimeSeriesTranslate()) {
      
    }

    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last".
    /// </summary>    
    public TimeSeriesTranslate AttributeIndices (string rangeList) {
      Impl.setAttributeIndices(rangeList);
      return this;
    }

    /// <summary>
    /// Invert matching sense. ie calculate for all non-specified columns.
    /// </summary>    
    public TimeSeriesTranslate InvertSelection (bool invert) {
      Impl.setInvertSelection(invert);
      return this;
    }

    /// <summary>
    /// For instances at the beginning or end of the dataset where the translated
    /// values are not known, use missing values (default is to remove those
    /// instances)
    /// </summary>    
    public TimeSeriesTranslate FillWithMissing (bool newFillWithMissing) {
      Impl.setFillWithMissing(newFillWithMissing);
      return this;
    }

    /// <summary>
    /// The number of instances forward/backward to merge values between. A
    /// negative number indicates taking values from a past instance.
    /// </summary>    
    public TimeSeriesTranslate InstanceRange (int newInstanceRange) {
      Impl.setInstanceRange(newInstanceRange);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public TimeSeriesTranslate AttributeIndicesArray (int[] attributes) {
      Impl.setAttributeIndicesArray(attributes);
      return this;
    }

        
        
  }
}