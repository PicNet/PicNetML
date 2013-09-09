using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// Replaces all missing values for nominal, string, numeric and date
  /// attributes in the dataset with user-supplied constant
  /// values.<br/><br/>Options:<br/><br/>-A &lt;index1,index2-index4,... | att-name1,att-name2,...&gt; =
  /// 	Specify list of attributes to replace missing values for <br/>	(as weka range
  /// list of indices or a comma separated list of attribute
  /// names).<br/>	(default: consider all attributes)<br/>-N = 	Specify the replacement constant for
  /// nominal/string attributes<br/>-R = 	Specify the replacement constant for
  /// numeric attributes<br/>	(default: 0)<br/>-D = 	Specify the replacement
  /// constant for date attributes<br/>-F = 	Specify the date format for parsing the
  /// replacement date constant<br/>	(default:
  /// yyyy-MM-dd'T'HH:mm:ss)<br/>-unset-class-temporarily = 	Unsets the class index temporarily before the filter
  /// is<br/>	applied to the data.<br/>	(default: no)
  /// </summary>
  public class ReplaceMissingWithUserConstant : BaseFilter<weka.filters.unsupervised.attribute.ReplaceMissingWithUserConstant>
  {
    public ReplaceMissingWithUserConstant(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.ReplaceMissingWithUserConstant()) {
      
    }

    /// <summary>
    /// Specify range of attributes to act on. This is a comma separated list of
    /// attribute indices, with "first" and "last" valid values. Specify an
    /// inclusive range with "-". E.g: "first-3,5,6-10,last". Can alternatively specify a
    /// comma separated list of attribute names. Note that you can't mix indices
    /// and attribute names in the same list
    /// </summary>    
    public ReplaceMissingWithUserConstant Attributes (string range) {
      Impl.setAttributes(range);
      return this;
    }

    /// <summary>
    /// The constant to replace missing values in nominal/string attributes with
    /// </summary>    
    public ReplaceMissingWithUserConstant NominalStringReplacementValue (string nominalStringConstant) {
      Impl.setNominalStringReplacementValue(nominalStringConstant);
      return this;
    }

    /// <summary>
    /// The constant to replace missing values in numeric attributes with
    /// </summary>    
    public ReplaceMissingWithUserConstant NumericReplacementValue (string numericConstant) {
      Impl.setNumericReplacementValue(numericConstant);
      return this;
    }

    /// <summary>
    /// The constant to replace missing values in date attributes with
    /// </summary>    
    public ReplaceMissingWithUserConstant DateReplacementValue (string dateConstant) {
      Impl.setDateReplacementValue(dateConstant);
      return this;
    }

    /// <summary>
    /// The formatting string to use for parsing the date replacement value
    /// </summary>    
    public ReplaceMissingWithUserConstant DateFormat (string dateFormat) {
      Impl.setDateFormat(dateFormat);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public ReplaceMissingWithUserConstant Environment (weka.core.Environment env) {
      Impl.setEnvironment(env);
      return this;
    }

    /// <summary>
    /// The class index will be unset temporarily before the filter is applied.
    /// </summary>    
    public ReplaceMissingWithUserConstant IgnoreClass (bool newIgnoreClass) {
      Impl.setIgnoreClass(newIgnoreClass);
      return this;
    }

        
        
  }
}