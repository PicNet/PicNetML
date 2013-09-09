using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// A filter that uses a density-based clusterer to generate cluster
  /// membership values; filtered instances are composed of these values plus the class
  /// attribute (if set in the input data). If a (nominal) class attribute is set,
  /// the clusterer is run separately for each class. The class attribute (if
  /// set) and any user-specified attributes are ignored during the clustering
  /// operation<br/><br/>Options:<br/><br/>-W &lt;clusterer name&gt; = 	Full name of
  /// clusterer to use. eg:<br/>		weka.clusterers.EM<br/>	Additional options
  /// after the '--'.<br/>	(default: weka.clusterers.EM)<br/>-I
  /// &lt;att1,att2-att4,...&gt; = 	The range of attributes the clusterer should ignore.<br/>	(the
  /// class attribute is automatically ignored)
  /// </summary>
  public class ClusterMembership : BaseFilter<weka.filters.unsupervised.attribute.ClusterMembership>
  {
    public ClusterMembership(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.ClusterMembership()) {
      
    }

    /// <summary>
    /// The clusterer that will generate membership values for the instances.
    /// </summary>    
    public ClusterMembership DensityBasedClusterer (weka.clusterers.DensityBasedClusterer newClusterer) {
      Impl.setDensityBasedClusterer(newClusterer);
      return this;
    }

    /// <summary>
    /// The range of attributes to be ignored by the clusterer. eg:
    /// first-3,5,9-last
    /// </summary>    
    public ClusterMembership IgnoredAttributeIndices (string rangeList) {
      Impl.setIgnoredAttributeIndices(rangeList);
      return this;
    }

        
        
  }
}