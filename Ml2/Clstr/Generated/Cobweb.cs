using weka.core;
using weka.clusterers;

// ReSharper disable once CheckNamespace
namespace Ml2.Clstr
{
  /// <summary>
  /// Class implementing the Cobweb and Classit clustering
  /// algorithms.<br/><br/>Note: the application of node operators (merging, splitting etc.) in terms
  /// of ordering and priority differs (and is somewhat ambiguous) between the
  /// original Cobweb and Classit papers. This algorithm always compares the best
  /// host, adding a new leaf, merging the two best hosts, and splitting the best
  /// host when considering where to place a new instance.<br/><br/>For more
  /// information see:<br/><br/>D. Fisher (1987). Knowledge acquisition via
  /// incremental conceptual clustering. Machine Learning. 2(2):139-172.<br/><br/>J. H.
  /// Gennari, P. Langley, D. Fisher (1990). Models of incremental concept
  /// formation. Artificial Intelligence. 40:11-61.<br/><br/>Options:<br/><br/>-A
  /// &lt;acuity&gt; = 	Acuity.<br/>	(default=1.0)<br/>-C &lt;cutoff&gt; =
  /// 	Cutoff.<br/>	(default=0.002)<br/>-S &lt;num&gt; = 	Random number seed.<br/>	(default
  /// 42)
  /// </summary>
  public class Cobweb : BaseClusterer<weka.clusterers.Cobweb>
  {    
    public Cobweb(Runtime rt) : base(rt, new weka.clusterers.Cobweb()) {
      Impl.setSeed(Runtime.GlobalRandomSeed);
    }

    /// <summary>
    /// set the minimum standard deviation for numeric attributes
    /// </summary>    
    public Cobweb Acuity (double a) {
      Impl.setAcuity(a);
      return this;
    }

    /// <summary>
    /// set the category utility threshold by which to prune nodes
    /// </summary>    
    public Cobweb Cutoff (double c) {
      Impl.setCutoff(c);
      return this;
    }

    /// <summary>
    /// save instance information for visualization purposes
    /// </summary>    
    public Cobweb SaveInstanceData (bool newsaveInstances) {
      Impl.setSaveInstanceData(newsaveInstances);
      return this;
    }

            

        
  }
}