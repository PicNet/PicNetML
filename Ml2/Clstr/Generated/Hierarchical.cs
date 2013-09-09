using weka.core;
using weka.clusterers;

// ReSharper disable once CheckNamespace
namespace Ml2.Clstr
{
  /// <summary>
  /// Hierarchical clustering class.<br/>Implements a number of classic
  /// agglomorative (i.e. bottom up) hierarchical clustering methodsbased on
  /// .<br/><br/>Options:<br/><br/>-D = 	If set, classifier is run in debug mode
  /// and<br/>	may output additional info to the console<br/>-B = 	If set, distance is
  /// interpreted as branch length<br/>	otherwise it is node height.<br/>-N &lt;Nr Of
  /// Clusters&gt; = 	number of clusters<br/>-P = 	Flag to indicate the cluster
  /// should be printed in Newick format.<br/>-L
  /// [SINGLE|COMPLETE|AVERAGE|MEAN|CENTROID|WARD|ADJCOMLPETE|NEIGHBOR_JOINING] = Link type (Single, Complete,
  /// Average, Mean, Centroid, Ward, Adjusted complete, Neighbor joining)<br/>-A
  /// &lt;classname and options&gt; = 	Distance function to use.<br/>	(default:
  /// weka.core.EuclideanDistance)
  /// </summary>
  public class Hierarchical : BaseClusterer<weka.clusterers.HierarchicalClusterer>
  {    
    public Hierarchical(Runtime rt) : base(rt, new weka.clusterers.HierarchicalClusterer()) {
      
    }

    /// <summary>
    /// Sets the number of clusters. If a single hierarchy is desired, set this
    /// to 1.
    /// </summary>    
    public Hierarchical NumClusters (int nClusters) {
      Impl.setNumClusters(nClusters);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public Hierarchical Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

    /// <summary>
    /// If set to false, the distance between clusters is interpreted as the
    /// height of the node linking the clusters. This is appropriate for example for
    /// single link clustering. However, for neighbor joining, the distance is better
    /// interpreted as branch length. Set this flag to get the latter
    /// interpretation.
    /// </summary>    
    public Hierarchical DistanceIsBranchLength (bool bDistanceIsHeight) {
      Impl.setDistanceIsBranchLength(bDistanceIsHeight);
      return this;
    }

    /// <summary>
    /// Sets the method used to measure the distance between two clusters.
    /// SINGLE: find single link distance aka minimum link, which is the closest distance
    /// between any item in cluster1 and any item in cluster2 COMPLETE: find
    /// complete link distance aka maximum link, which is the largest distance between
    /// any item in cluster1 and any item in cluster2 ADJCOMLPETE: as COMPLETE, but
    /// with adjustment, which is the largest within cluster distance AVERAGE:
    /// finds average distance between the elements of the two clusters MEAN:
    /// calculates the mean distance of a merged cluster (akak Group-average agglomerative
    /// clustering) CENTROID: finds the distance of the centroids of the clusters
    /// WARD: finds the distance of the change in caused by merging the cluster. The
    /// information of a cluster is calculated as the error sum of squares of the
    /// centroids of the cluster and its members. NEIGHBOR_JOINING use neighbor
    /// joining algorithm.
    /// </summary>    
    public Hierarchical LinkType (ELinkType newLinkType) {
      Impl.setLinkType(new weka.core.SelectedTag((int) newLinkType, weka.clusterers.HierarchicalClusterer.TAGS_LINK_TYPE));
      return this;
    }

    /// <summary>
    /// Sets the distance function, which measures the distance between two
    /// individual. instances (or possibly the distance between an instance and the
    /// centroid of a clusterdepending on the Link type).
    /// </summary>    
    public Hierarchical DistanceFunction (weka.core.DistanceFunction distanceFunction) {
      Impl.setDistanceFunction(distanceFunction);
      return this;
    }

    /// <summary>
    /// Flag to indicate whether the cluster should be print in Newick format.
    /// This can be useful for display in other programs. However, for large datasets
    /// a lot of text may be produced, which may not be a nuisance when the Newick
    /// format is not required
    /// </summary>    
    public Hierarchical PrintNewick (bool bPrintNewick) {
      Impl.setPrintNewick(bPrintNewick);
      return this;
    }

            

    public enum ELinkType {
      SINGLE = 0,
      COMPLETE = 1,
      AVERAGE = 2,
      MEAN = 3,
      CENTROID = 4,
      WARD = 5,
      ADJCOMLPETE = 6,
      NEIGHBOR_JOINING = 7
    }

        
  }
}