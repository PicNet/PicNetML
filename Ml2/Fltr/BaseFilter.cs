using weka.filters;

namespace Ml2.Fltr
{
  public interface IBaseFilter<out I> where I : Filter {
    I Impl { get; }
    Runtime RunFilter();
  }

  public class BaseFilter<I> : IBaseFilter<I> where I : Filter
  {
    protected readonly Runtime rt;

    public BaseFilter(Runtime rt, I impl)
    {
      this.rt = rt;
      Impl = impl;

      InternalHelpers.SetSeedOnInstance(impl);
    }

    public I Impl { get; private set;}

    public Runtime RunFilter()
    {
      Impl.setInputFormat(rt.Impl);
      return new Runtime(Filter.useFilter(rt.Impl, Impl));
    }    
  }
}