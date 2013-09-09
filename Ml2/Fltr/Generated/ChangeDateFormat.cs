using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Changes the date format used by a date attribute. This is most useful for
  /// converting to a format with less precision, for example, from an absolute
  /// date to day of year, etc. This changes the format string, and changes the
  /// date values to those that would be parsed by the new
  /// format.<br/><br/>Options:<br/><br/>-C &lt;col&gt; = 	Sets the attribute index (default
  /// last).<br/>-F &lt;value index&gt; = 	Sets the output date format string (default
  /// corresponds to ISO-8601).
  /// </summary>
  public class ChangeDateFormat : BaseFilter<weka.filters.unsupervised.attribute.ChangeDateFormat>
  {
    public ChangeDateFormat(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.ChangeDateFormat()) {
      
    }

    /// <summary>
    /// Sets which attribute to process. This attribute must be of type date
    /// ("first" and "last" are valid values)
    /// </summary>    
    public ChangeDateFormat AttributeIndex (string attIndex) {
      Impl.setAttributeIndex(attIndex);
      return this;
    }

    /// <summary>
    /// The date format to change to. This should be a format understood by
    /// Java's SimpleDateFormat class.
    /// </summary>    
    public ChangeDateFormat DateFormat (string dateFormat) {
      Impl.setDateFormat(dateFormat);
      return this;
    }

    /// <summary>
    /// The date format to change to. This should be a format understood by
    /// Java's SimpleDateFormat class.
    /// </summary>    
    public ChangeDateFormat DateFormat (java.text.SimpleDateFormat dateFormat) {
      Impl.setDateFormat(dateFormat);
      return this;
    }

        
        
  }
}