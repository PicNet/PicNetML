using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// Renames the values of nominal attributes.<br/><br/>Options:<br/><br/>-R =
  /// 	Attributes to act on. Can be either a range<br/>	string (e.g. 1,2,6-10)
  /// OR a comma-separated list of named attributes<br/>	(default none)<br/>-V =
  /// 	Invert matching sense (i.e. act on all attributes other than those
  /// specified)<br/>-N = 	Nominal labels and their replacement values.<br/>	E.g.
  /// red:blue, black:white, fred:bob<br/>-I = 	Ignore case when matching nominal values
  /// </summary>
  public class RenameNominalValues : BaseFilter<weka.filters.unsupervised.attribute.RenameNominalValues>
  {
    public RenameNominalValues(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.RenameNominalValues()) {
      
    }

    /// <summary>
    /// The attributes (index range string or explicit comma-separated attribute
    /// names) to work on
    /// </summary>    
    public RenameNominalValues SelectedAttributes (string atts) {
      Impl.setSelectedAttributes(atts);
      return this;
    }

    /// <summary>
    /// A comma separated list of values to replace and their replacements. E.g.
    /// red:green, blue:purple, fred:bob
    /// </summary>    
    public RenameNominalValues ValueReplacements (string v) {
      Impl.setValueReplacements(v);
      return this;
    }

    /// <summary>
    /// Determines whether to apply the operation to the specified. attributes,
    /// or all attributes but the specified ones. If set to true, all attributes but
    /// the speficied ones will be affected.
    /// </summary>    
    public RenameNominalValues InvertSelection (bool invert) {
      Impl.setInvertSelection(invert);
      return this;
    }

    /// <summary>
    /// Whether to ignore case when matching nominal values
    /// </summary>    
    public RenameNominalValues IgnoreCase (bool ignore) {
      Impl.setIgnoreCase(ignore);
      return this;
    }

        
        
  }
}