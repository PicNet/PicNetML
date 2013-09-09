using weka.core;
using weka.attributeSelection;

// ReSharper disable once CheckNamespace
namespace Ml2.AttrSel.Evals
{
  /// <summary>
  /// GainRatioAttributeEval :<br/><br/>Evaluates the worth of an attribute by
  /// measuring the gain ratio with respect to the class.<br/><br/>GainR(Class,
  /// Attribute) = (H(Class) - H(Class | Attribute)) /
  /// H(Attribute).<br/><br/><br/>Options:<br/><br/>-M = 	treat missing values as a seperate value.
  /// </summary>
  public class GainRatioAttribute : BaseAttributeSelectionEvaluator<weka.attributeSelection.GainRatioAttributeEval>
  {
    public GainRatioAttribute(Runtime rt) : base(rt, new weka.attributeSelection.GainRatioAttributeEval()) {
      
    }
    
    /// <summary>
    /// Distribute counts for missing values. Counts are distributed across other
    /// values in proportion to their frequency. Otherwise, missing is treated as
    /// a separate value.
    /// </summary>    
    public GainRatioAttribute MissingMerge (bool b) {
      Impl.setMissingMerge(b);
      return this;
    }

            
        
  }
}