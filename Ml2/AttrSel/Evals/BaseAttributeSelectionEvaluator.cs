using weka.attributeSelection;

namespace Ml2.AttrSel.Evals
{
  public interface IBaseAttributeSelectionEvaluator<out I>  where I : ASEvaluation {
    I Impl { get; }
  }

  public class BaseAttributeSelectionEvaluator<I> : IBaseAttributeSelectionEvaluator<I> where I : ASEvaluation {
    protected readonly Runtime rt;
    public I Impl { get; private set; }
    
    public BaseAttributeSelectionEvaluator(Runtime rt, I impl) { 
      this.rt = rt;
      Impl = impl; 

      InternalHelpers.SetSeedOnInstance(impl);
    }    
  }
}