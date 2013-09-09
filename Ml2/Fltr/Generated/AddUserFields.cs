using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// A filter that adds new attributes with user specified type and constant
  /// value. Numeric, nominal, string and date attributes can be created.
  /// Attribute name, and value can be set with environment variables. Date attributes
  /// can also specify a formatting string by which to parse the supplied date
  /// value. Alternatively, a current time stamp can be specified by supplying the
  /// special string "now" as the value for a date
  /// attribute.<br/><br/>Options:<br/><br/>-A &lt;name:type:value&gt; = 	New field specification
  /// (name@type@value).<br/>	 Environment variables may be used for any/all parts of
  /// the<br/>	specification. Type can be one of (numeric, nominal, string or
  /// date).<br/>	The value for date be a specific date string or the special
  /// string<br/>	"now" to indicate the current date-time. A specific date format<br/>	string for
  /// parsing specific date values can be specified by suffixing<br/>	the type
  /// specification - e.g. "myTime@date:MM-dd-yyyy@08-23-2009".This option may be
  /// specified multiple times
  /// </summary>
  public class AddUserFields : BaseFilter<weka.filters.unsupervised.attribute.AddUserFields>
  {
    public AddUserFields(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.AddUserFields()) {
      
    }

    /// <summary>
    /// 
    /// </summary>    
    public AddUserFields Environment (weka.core.Environment env) {
      Impl.setEnvironment(env);
      return this;
    }

        
        
  }
}