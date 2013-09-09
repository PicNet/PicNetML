using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// A filter that 'cleanses' the numeric data from values that are too small,
  /// too big or very close to a certain value (e.g., 0) and sets these values
  /// to a pre-defined default.<br/><br/>Options:<br/><br/>-D = 	Turns on output
  /// of debugging information.<br/>-min &lt;double&gt; = 	The minimum threshold.
  /// (default -Double.MAX_VALUE)<br/>-min-default &lt;double&gt; = 	The
  /// replacement for values smaller than the minimum threshold.<br/>	(default
  /// -Double.MAX_VALUE)<br/>-max &lt;double&gt; = 	The maximum threshold. (default
  /// Double.MAX_VALUE)<br/>-max-default &lt;double&gt; = 	The replacement for values
  /// larger than the maximum threshold.<br/>	(default
  /// Double.MAX_VALUE)<br/>-closeto &lt;double&gt; = 	The number values are checked for closeness. (default
  /// 0)<br/>-closeto-default &lt;double&gt; = 	The replacement for values that
  /// are close to '-closeto'.<br/>	(default 0)<br/>-closeto-tolerance
  /// &lt;double&gt; = 	The tolerance below which numbers are considered being close to
  /// <br/>	to each other. (default 1E-6)<br/>-decimals &lt;int&gt; = 	The number of
  /// decimals to round to, -1 means no rounding at all.<br/>	(default -1)<br/>-R
  /// &lt;col1,col2,...&gt; = 	The list of columns to cleanse, e.g., first-last
  /// or first-3,5-last.<br/>	(default first-last)<br/>-V = 	Inverts the matching
  /// sense.<br/>-include-class = 	Whether to include the class in the
  /// cleansing.<br/>	The class column will always be skipped, if this flag is
  /// not<br/>	present. (default no)
  /// </summary>
  public class NumericCleaner : BaseFilter<weka.filters.unsupervised.attribute.NumericCleaner>
  {
    public NumericCleaner(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.NumericCleaner()) {
      
    }

    /// <summary>
    /// The minimum threshold below values are replaced by a default.
    /// </summary>    
    public NumericCleaner MinThreshold (double value) {
      Impl.setMinThreshold(value);
      return this;
    }

    /// <summary>
    /// The default value to replace values that are below the minimum threshold.
    /// </summary>    
    public NumericCleaner MinDefault (double value) {
      Impl.setMinDefault(value);
      return this;
    }

    /// <summary>
    /// The maximum threshold above values are replaced by a default.
    /// </summary>    
    public NumericCleaner MaxThreshold (double value) {
      Impl.setMaxThreshold(value);
      return this;
    }

    /// <summary>
    /// The default value to replace values that are above the maximum threshold.
    /// </summary>    
    public NumericCleaner MaxDefault (double value) {
      Impl.setMaxDefault(value);
      return this;
    }

    /// <summary>
    /// The number values are checked for whether they are too close to and get
    /// replaced by a default.
    /// </summary>    
    public NumericCleaner CloseTo (double value) {
      Impl.setCloseTo(value);
      return this;
    }

    /// <summary>
    /// The default value to replace values with that are too close.
    /// </summary>    
    public NumericCleaner CloseToDefault (double value) {
      Impl.setCloseToDefault(value);
      return this;
    }

    /// <summary>
    /// The value below which values are considered close to.
    /// </summary>    
    public NumericCleaner CloseToTolerance (double value) {
      Impl.setCloseToTolerance(value);
      return this;
    }

    /// <summary>
    /// The selection of columns to use in the cleansing processs, first and last
    /// are valid indices.
    /// </summary>    
    public NumericCleaner AttributeIndices (string value) {
      Impl.setAttributeIndices(value);
      return this;
    }

    /// <summary>
    /// If enabled the selection of the columns is inverted.
    /// </summary>    
    public NumericCleaner InvertSelection (bool value) {
      Impl.setInvertSelection(value);
      return this;
    }

    /// <summary>
    /// If disabled, the class attribute will be always left out of the cleaning
    /// process.
    /// </summary>    
    public NumericCleaner IncludeClass (bool value) {
      Impl.setIncludeClass(value);
      return this;
    }

    /// <summary>
    /// The number of decimals to round to, -1 means no rounding at all.
    /// </summary>    
    public NumericCleaner Decimals (int value) {
      Impl.setDecimals(value);
      return this;
    }

    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public NumericCleaner Debug (bool value) {
      Impl.setDebug(value);
      return this;
    }

        
        
  }
}