using weka.core;
using weka.clusterers;

// ReSharper disable once CheckNamespace
namespace PicNetML.Clstr
{
  /// <summary>
  /// Class for wrapping a Clusterer to make it return a distribution and
  /// density. Fits normal distributions and discrete distributions within each
  /// cluster produced by the wrapped clusterer. Supports the
  /// NumberOfClustersRequestable interface only if the wrapped Clusterer
  /// does.<br/><br/>Options:<br/><br/>-M &lt;num&gt; = 	minimum allowable standard deviation for normal density
  /// computation <br/>	(default 1e-6)<br/>-W &lt;clusterer name&gt; = 	Clusterer
  /// to wrap.<br/>	(default weka.clusterers.SimpleKMeans)<br/><br/>Options
  /// specific to clusterer weka.clusterers.SimpleKMeans: = <br/>-N &lt;num&gt; =
  /// 	number of clusters.<br/>	(default 2).<br/>-P = 	Initialize using the
  /// k-means++ method.<br/><br/>-V = 	Display std. deviations for centroids.<br/><br/>-M
  /// = 	Don't replace missing values with mean/mode.<br/><br/>-A &lt;classname
  /// and options&gt; = 	Distance function to use.<br/>	(default:
  /// weka.core.EuclideanDistance)<br/>-I &lt;num&gt; = 	Maximum number of
  /// iterations.<br/><br/>-O = 	Preserve order of instances.<br/><br/>-fast = 	Enables faster
  /// distance calculations, using cut-off values.<br/>	Disables the calculation/output
  /// of squared errors/distances.<br/><br/>-num-slots &lt;num&gt; = 	Number of
  /// execution slots.<br/>	(default 1 - i.e. no parallelism)<br/>-S &lt;num&gt; =
  /// 	Random number seed.<br/>	(default 10)
  /// </summary>
  public class MakeDensityBased : BaseClusterer<weka.clusterers.MakeDensityBasedClusterer>
  {    
    public MakeDensityBased(Runtime rt) : base(rt, new weka.clusterers.MakeDensityBasedClusterer()) {
      
    }

    /// <summary>
    /// the clusterer to wrap
    /// </summary>    
    public MakeDensityBased Clusterer (Clstr.IBaseClusterer<weka.clusterers.Clusterer> toWrap) {
      Impl.setClusterer(toWrap.Impl);
      return this;
    }

    /// <summary>
    /// set minimum allowable standard deviation
    /// </summary>    
    public MakeDensityBased MinStdDev (double m) {
      Impl.setMinStdDev(m);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public MakeDensityBased NumClusters (int n) {
      Impl.setNumClusters(n);
      return this;
    }

            

        
  }
}