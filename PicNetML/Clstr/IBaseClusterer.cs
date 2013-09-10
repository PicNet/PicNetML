using weka.clusterers;

namespace PicNetML.Clstr {
  public interface IBaseClusterer<out I> : IUntypedBaseClusterer<I> where I : Clusterer {
    int ClusterRow<T>(T t) where T : new();
    IBaseClusterer<I> Build();  
  }
}