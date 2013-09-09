using PicNetML.AttrSel.Algs;
using PicNetML.AttrSel.Evals;

namespace PicNetML.AttrSel
{
  public class AttributeSelections
  {
    public AttributeSelections(Runtime rt)
    {
      Algorithms = new Algorithms(rt);
      Evaluators = new Evaluators(rt);
    }

    public Algorithms Algorithms { get; private set; }
    public Evaluators Evaluators { get; private set; }
  }
}