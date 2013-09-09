using weka.core;
using weka.attributeSelection;

// ReSharper disable once CheckNamespace
namespace Ml2.AttrSel.Evals
{
  /// <summary>
  /// InfoGainAttributeEval :<br/><br/>Evaluates the worth of an attribute by
  /// measuring the information gain with respect to the
  /// class.<br/><br/>InfoGain(Class,Attribute) = H(Class) - H(Class |
  /// Attribute).<br/><br/><br/>Options:<br/><br/>-M = 	treat missing values as a seperate value.<br/>-B = 	just
  /// binarize numeric attributes instead <br/>	of properly discretizing them.
  /// </summary>
  public class InfoGainAttribute : BaseAttributeSelectionEvaluator<weka.attributeSelection.InfoGainAttributeEval>
  {
    public InfoGainAttribute(Runtime rt) : base(rt, new weka.attributeSelection.InfoGainAttributeEval()) {
      
    }
    
    /// <summary>
    /// Distribute counts for missing values. Counts are distributed across other
    /// values in proportion to their frequency. Otherwise, missing is treated as
    /// a separate value.
    /// </summary>    
    public InfoGainAttribute MissingMerge (bool b) {
      Impl.setMissingMerge(b);
      return this;
    }

    /// <summary>
    /// Just binarize numeric attributes instead of properly discretizing them.
    /// </summary>    
    public InfoGainAttribute BinarizeNumericAttributes (bool b) {
      Impl.setBinarizeNumericAttributes(b);
      return this;
    }

            
        
  }
}