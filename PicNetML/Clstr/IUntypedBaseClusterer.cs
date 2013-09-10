using weka.clusterers;

namespace PicNetML.Clstr {
  public interface IUntypedBaseClusterer<out I> where I : Clusterer {
    I Impl { get; }      
    int ClusterInstance(PmlInstance instance);
  }
}