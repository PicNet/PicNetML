using weka.core;
using weka.attributeSelection;

// ReSharper disable once CheckNamespace
namespace Ml2.AttrSel.Evals
{
  /// <summary>
  /// CorrelationAttributeEval :<br/><br/>Evaluates the worth of an attribute
  /// by measuring the correlation (Pearson's) between it and the
  /// class.<br/><br/>Nominal attributes are considered on a value by value basis by treating
  /// each value as an indicator. An overall correlation for a nominal attribute is
  /// arrived at via a weighted average.<br/><br/><br/>Options:<br/><br/>-D =
  /// 	Output detailed info for nominal attributes
  /// </summary>
  public class CorrelationAttribute : BaseAttributeSelectionEvaluator<weka.attributeSelection.CorrelationAttributeEval>
  {
    public CorrelationAttribute(Runtime rt) : base(rt, new weka.attributeSelection.CorrelationAttributeEval()) {
      
    }
    
    /// <summary>
    /// Output per value correlation for nominal attributes
    /// </summary>    
    public CorrelationAttribute OutputDetailedInfo (bool d) {
      Impl.setOutputDetailedInfo(d);
      return this;
    }

            
        
  }
}