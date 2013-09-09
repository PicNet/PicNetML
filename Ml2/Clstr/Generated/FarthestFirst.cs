using weka.core;
using weka.clusterers;

// ReSharper disable once CheckNamespace
namespace Ml2.Clstr
{
  /// <summary>
  /// Cluster data using the FarthestFirst algorithm.<br/><br/>For more
  /// information see:<br/><br/>Hochbaum, Shmoys (1985). A best possible heuristic for
  /// the k-center problem. Mathematics of Operations Research.
  /// 10(2):180-184.<br/><br/>Sanjoy Dasgupta: Performance Guarantees for Hierarchical Clustering.
  /// In: 15th Annual Conference on Computational Learning Theory, 351-363,
  /// 2002.<br/><br/>Notes:<br/>- works as a fast simple approximate clusterer<br/>-
  /// modelled after SimpleKMeans, might be a useful initializer for
  /// it<br/><br/>Options:<br/><br/>-N &lt;num&gt; = 	number of clusters. (default =
  /// 2).<br/>-S &lt;num&gt; = 	Random number seed.<br/>	(default 1)
  /// </summary>
  public class FarthestFirst : BaseClusterer<weka.clusterers.FarthestFirst>
  {    
    public FarthestFirst(Runtime rt) : base(rt, new weka.clusterers.FarthestFirst()) {
      Impl.setSeed(Runtime.GlobalRandomSeed);
    }

    /// <summary>
    /// set number of clusters
    /// </summary>    
    public FarthestFirst NumClusters (int n) {
      Impl.setNumClusters(n);
      return this;
    }

            

        
  }
}