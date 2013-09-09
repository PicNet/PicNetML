using weka.core;
using weka.attributeSelection;

// ReSharper disable once CheckNamespace
namespace PicNetML.AttrSel.Evals
{
  /// <summary>
  /// SymmetricalUncertAttributeEval :<br/><br/>Evaluates the worth of an
  /// attribute by measuring the symmetrical uncertainty with respect to the class.
  /// <br/><br/> SymmU(Class, Attribute) = 2 * (H(Class) - H(Class | Attribute)) /
  /// H(Class) + H(Attribute).<br/><br/><br/>Options:<br/><br/>-M = 	treat
  /// missing values as a seperate value.
  /// </summary>
  public class SymmetricalUncertAttribute : BaseAttributeSelectionEvaluator<weka.attributeSelection.SymmetricalUncertAttributeEval>
  {
    public SymmetricalUncertAttribute(Runtime rt) : base(rt, new weka.attributeSelection.SymmetricalUncertAttributeEval()) {
      
    }
    
    /// <summary>
    /// Distribute counts for missing values. Counts are distributed across other
    /// values in proportion to their frequency. Otherwise, missing is treated as
    /// a separate value.
    /// </summary>    
    public SymmetricalUncertAttribute MissingMerge (bool b) {
      Impl.setMissingMerge(b);
      return this;
    }

            
        
  }
}