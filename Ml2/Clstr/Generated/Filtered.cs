using weka.core;
using weka.clusterers;

// ReSharper disable once CheckNamespace
namespace Ml2.Clstr
{
  /// <summary>
  /// Class for running an arbitrary clusterer on data that has been passed
  /// through an arbitrary filter. Like the clusterer, the structure of the filter
  /// is based exclusively on the training data and test instances will be
  /// processed by the filter without changing their
  /// structure.<br/><br/>Options:<br/><br/>-F &lt;filter specification&gt; = 	Full class name of filter to use,
  /// followed<br/>	by filter options.<br/>	eg:
  /// "weka.filters.unsupervised.attribute.Remove -V -R 1,2"<br/>(default: weka.filters.AllFilter)<br/>-W = 	Full
  /// name of base clusterer.<br/>	(default:
  /// weka.clusterers.SimpleKMeans)<br/><br/>Options specific to clusterer weka.clusterers.SimpleKMeans: = <br/>-N
  /// &lt;num&gt; = 	number of clusters.<br/>	(default 2).<br/>-P = 	Initialize using
  /// the k-means++ method.<br/><br/>-V = 	Display std. deviations for
  /// centroids.<br/><br/>-M = 	Replace missing values with mean/mode.<br/><br/>-A
  /// &lt;classname and options&gt; = 	Distance function to use.<br/>	(default:
  /// weka.core.EuclideanDistance)<br/>-I &lt;num&gt; = 	Maximum number of
  /// iterations.<br/><br/>-O = 	Preserve order of instances.<br/><br/>-fast = 	Enables faster
  /// distance calculations, using cut-off values.<br/>	Disables the
  /// calculation/output of squared errors/distances.<br/><br/>-num-slots &lt;num&gt; =
  /// 	Number of execution slots.<br/>	(default 1 - i.e. no parallelism)<br/>-S
  /// &lt;num&gt; = 	Random number seed.<br/>	(default 10)
  /// </summary>
  public class Filtered : BaseClusterer<weka.clusterers.FilteredClusterer>
  {    
    public Filtered(Runtime rt) : base(rt, new weka.clusterers.FilteredClusterer()) {
      
    }

    /// <summary>
    /// The filter to be used.
    /// </summary>    
    public Filtered Filter (Fltr.IBaseFilter<weka.filters.Filter> filter) {
      Impl.setFilter(filter.Impl);
      return this;
    }

    /// <summary>
    /// The base clusterer to be used.
    /// </summary>    
    public Filtered Clusterer (Clstr.IBaseClusterer<weka.clusterers.Clusterer> value) {
      Impl.setClusterer(value.Impl);
      return this;
    }

            

        
  }
}