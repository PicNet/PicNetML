using weka.core;
using weka.clusterers;

// ReSharper disable once CheckNamespace
namespace PicNetML.Clstr
{
  /// <summary>
  /// Simple EM (expectation maximisation) class.<br/><br/>EM assigns a
  /// probability distribution to each instance which indicates the probability of it
  /// belonging to each of the clusters. EM can decide how many clusters to create
  /// by cross validation, or you may specify apriori how many clusters to
  /// generate.<br/><br/>The cross validation performed to determine the number of
  /// clusters is done in the following steps:<br/>1. the number of clusters is set
  /// to 1<br/>2. the training set is split randomly into 10 folds.<br/>3. EM is
  /// performed 10 times using the 10 folds the usual CV way.<br/>4. the
  /// loglikelihood is averaged over all 10 results.<br/>5. if loglikelihood has increased
  /// the number of clusters is increased by 1 and the program continues at step
  /// 2. <br/><br/>The number of folds is fixed to 10, as long as the number of
  /// instances in the training set is not smaller 10. If this is the case the
  /// number of folds is set equal to the number of
  /// instances.<br/><br/>Options:<br/><br/>-N &lt;num&gt; = 	number of clusters. If omitted or -1 specified,
  /// then <br/>	cross validation is used to select the number of clusters.<br/>-X
  /// &lt;num&gt; = 	Number of folds to use when cross-validating to find the
  /// best number of clusters.<br/>-max &lt;num&gt; = 	Maximum number of clusters to
  /// consider during cross-validation. If omitted or -1 specified, then
  /// <br/>	there is no upper limit on the number of clusters.<br/>-ll-cv &lt;num&gt; =
  /// 	Minimum improvement in cross-validated log likelihood required<br/>	to
  /// consider increasing the number of clusters.<br/>	(default 1e-6)<br/>-I
  /// &lt;num&gt; = 	max iterations.<br/>	(default 100)<br/>-ll-iter &lt;num&gt; =
  /// 	Minimum improvement in log likelihood required<br/>	to perform another
  /// iteration of the E and M steps.<br/>	(default 1e-6)<br/>-V = 	verbose.<br/>-M
  /// &lt;num&gt; = 	minimum allowable standard deviation for normal
  /// density<br/>	computation<br/>	(default 1e-6)<br/>-O = 	Display model in old format (good
  /// when there are many clusters)<br/><br/>-num-slots &lt;num&gt; = 	Number of
  /// execution slots.<br/>	(default 1 - i.e. no parallelism)<br/>-S &lt;num&gt; =
  /// 	Random number seed.<br/>	(default 100)
  /// </summary>
  public class EM : BaseClusterer<weka.clusterers.EM>
  {    
    public EM(Runtime rt) : base(rt, new weka.clusterers.EM()) {
      Impl.setSeed(Runtime.GlobalRandomSeed);
    }

    /// <summary>
    /// If set to true, clusterer may output additional info to the console.
    /// </summary>    
    public EM Debug (bool v) {
      Impl.setDebug(v);
      return this;
    }

    /// <summary>
    /// maximum number of iterations
    /// </summary>    
    public EM MaxIterations (int i) {
      Impl.setMaxIterations(i);
      return this;
    }

    /// <summary>
    /// The number of folds to use when cross-validating to find the best number
    /// of clusters (default = 10)
    /// </summary>    
    public EM NumFolds (int folds) {
      Impl.setNumFolds(folds);
      return this;
    }

    /// <summary>
    /// The minimum improvement in log likelihood required to perform another
    /// iteration of the E and M steps
    /// </summary>    
    public EM MinLogLikelihoodImprovementIterating (double min) {
      Impl.setMinLogLikelihoodImprovementIterating(min);
      return this;
    }

    /// <summary>
    /// The minimum improvement in cross-validated log likelihood required in
    /// order to consider increasing the number of clusters when cross-validiting to
    /// find the best number of clusters
    /// </summary>    
    public EM MinLogLikelihoodImprovementCV (double min) {
      Impl.setMinLogLikelihoodImprovementCV(min);
      return this;
    }

    /// <summary>
    /// set number of clusters. -1 to select number of clusters automatically by
    /// cross validation.
    /// </summary>    
    public EM NumClusters (int n) {
      Impl.setNumClusters(n);
      return this;
    }

    /// <summary>
    /// The maximum number of clusters to consider during cross-validation to
    /// select the best number of clusters
    /// </summary>    
    public EM MaximumNumberOfClusters (int n) {
      Impl.setMaximumNumberOfClusters(n);
      return this;
    }

    /// <summary>
    /// set minimum allowable standard deviation
    /// </summary>    
    public EM MinStdDev (double m) {
      Impl.setMinStdDev(m);
      return this;
    }

    /// <summary>
    /// Use old format for model output. The old format is better when there are
    /// many clusters. The new format is better when there are fewer clusters and
    /// many attributes.
    /// </summary>    
    public EM DisplayModelInOldFormat (bool d) {
      Impl.setDisplayModelInOldFormat(d);
      return this;
    }

    /// <summary>
    /// The number of execution slots (threads) to use. Set equal to the number
    /// of available cpu/cores
    /// </summary>    
    public EM NumExecutionSlots (int slots) {
      Impl.setNumExecutionSlots(slots);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public EM MinStdDevPerAtt (double[] m) {
      Impl.setMinStdDevPerAtt(m);
      return this;
    }

            

        
  }
}