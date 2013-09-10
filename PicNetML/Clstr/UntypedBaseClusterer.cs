using weka.clusterers;

namespace PicNetML.Clstr {
  public abstract class UntypedBaseClusterer<I> : IUntypedBaseClusterer<I> where I : Clusterer
  {    
    public I Impl { get; private set; }

    protected UntypedBaseClusterer(I impl) { 
      Impl = impl;

      InternalHelpers.SetSeedOnInstance(impl);
    }

    

    public int ClusterInstance(PmlInstance instance) {
      return Impl.clusterInstance(instance.Impl);
    }
  }
}