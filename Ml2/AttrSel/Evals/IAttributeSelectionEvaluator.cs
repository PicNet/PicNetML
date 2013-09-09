using weka.attributeSelection;

namespace Ml2.AttrSel.Evals
{
  public interface IAttributeSelectionEvaluator
  {
    ASEvaluation GetImpl();
  }
}