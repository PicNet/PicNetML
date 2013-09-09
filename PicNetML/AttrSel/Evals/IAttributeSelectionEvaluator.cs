using weka.attributeSelection;

namespace PicNetML.AttrSel.Evals
{
  public interface IAttributeSelectionEvaluator
  {
    ASEvaluation GetImpl();
  }
}