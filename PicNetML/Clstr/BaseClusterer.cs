using System;
using weka.clusterers;

namespace PicNetML.Clstr
{
  public abstract class BaseClusterer<I> : UntypedBaseClusterer<I>, IBaseClusterer<I> where I : Clusterer{
    protected readonly Runtime rt;

    protected BaseClusterer(Runtime rt, I impl) : base(impl) { 
      if (rt == null) throw new ArgumentNullException("rt");
      this.rt = rt; 
    }

    public int ClusterRow<T>(T t) where T : new() {
      if (rt == null) throw new ApplicationException("Cannot use ClusterInstance(T) if loading a model from a file.  Use Classify/ClassifyProba(Runtime.BuildInstance<Type>(classidx, row) instead.");
      return ClusterInstance(rt.BuildInstance(t));
    }

    public IBaseClusterer<I> Build()
    {
      Impl.buildClusterer(rt.Impl);
      return this;
    }    
  }
}