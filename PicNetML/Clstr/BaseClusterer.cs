using weka.clusterers;

namespace PicNetML.Clstr
{
  public interface IBaseClusterer<out I> where I : Clusterer {
    I Impl { get; }
    IBaseClusterer<I> Build();
  }

  public abstract class BaseClusterer<I> : IBaseClusterer<I> where I : Clusterer
  {
    protected readonly Runtime rt;
    public I Impl { get; private set; }

    protected BaseClusterer(Runtime rt, I impl) { 
      this.rt = rt; 
      Impl = impl;

      InternalHelpers.SetSeedOnInstance(impl);
    }

    public IBaseClusterer<I> Build()
    {
      Impl.buildClusterer(rt.Impl);
      return this;
    }
  }
}