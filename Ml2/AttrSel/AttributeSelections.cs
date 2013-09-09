using Ml2.AttrSel.Algs;
using Ml2.AttrSel.Evals;

namespace Ml2.AttrSel
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