using System;
using weka.clusterers;

namespace PicNetML.Clstr
{
  public interface IBaseClusterer<out I> where I : Clusterer {
    I Impl { get; }
    IBaseClusterer<I> Build();
    int ClusterInstance<T>(T t) where T : new();
    int ClusterInstance(PmlInstance instance);
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

    public int ClusterInstance<T>(T t) where T : new() {
      if (rt == null) throw new ApplicationException("Cannot use ClusterInstance(T) if loading a model from a file.  Use Classify/ClassifyProba(Runtime.BuildInstance<Type>(classidx, row) instead.");
      return ClusterInstance(rt.BuildInstance(t));
    }

    public int ClusterInstance(PmlInstance instance) {
      return Impl.clusterInstance(instance.Impl);
    }
  }
}