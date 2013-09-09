using System.Collections.Generic;
using System.Linq;
using weka.classifiers.bayes.net;

// ReSharper disable once CheckNamespace
namespace PicNetML.Clss
{
  /// <summary>
  /// Bayes Network learning using various search algorithms and quality
  /// measures.<br/>Base class for a Bayes Network classifier. Provides datastructures
  /// (network structure, conditional probability distributions, etc.) and
  /// facilities common to Bayes Network learning algorithms like K2 and
  /// B.<br/><br/>For more information
  /// see:<br/><br/>http://www.cs.waikato.ac.nz/~remco/weka.pdf<br/><br/>Options:<br/><br/>-B = 	Generate network (instead of
  /// instances)<br/><br/>-N &lt;integer&gt; = 	Nr of nodes<br/><br/>-A &lt;integer&gt; =
  /// 	Nr of arcs<br/><br/>-M &lt;integer&gt; = 	Nr of instances<br/><br/>-C
  /// &lt;integer&gt; = 	Cardinality of the variables<br/><br/>-S &lt;integer&gt; =
  /// 	Seed for random number generator<br/><br/>-F &lt;file&gt; = 	The BIF file to
  /// obtain the structure from.<br/>
  /// </summary>
  public class BayesNetGenerator : BaseClassifier<weka.classifiers.bayes.net.BayesNetGenerator>
  {
    public BayesNetGenerator(Runtime rt) : base(rt, new weka.classifiers.bayes.net.BayesNetGenerator()) {
      
    }

    /// <summary>
    /// 
    /// </summary>    
    public BayesNetGenerator Distribution (int nTargetNode, double[][] P) {
      Impl.setDistribution(nTargetNode, P);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public BayesNetGenerator Evidence (int iNode, int iValue) {
      Impl.setEvidence(iNode, iValue);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public BayesNetGenerator Data (Runtime instances) {
      Impl.setData(instances.Impl);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public BayesNetGenerator Distribution (string sName, double[][] P) {
      Impl.setDistribution(sName, P);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public BayesNetGenerator NodeName (int nTargetNode, string sName) {
      Impl.setNodeName(nTargetNode, sName);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public BayesNetGenerator Position (int iNode, int nX, int nY) {
      Impl.setPosition(iNode, nX, nY);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public BayesNetGenerator Margin (int iNode, double[] fMarginP) {
      Impl.setMargin(iNode, fMarginP);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public BayesNetGenerator BIFFile (string sBIFFile) {
      Impl.setBIFFile(sBIFFile);
      return this;
    }

    /// <summary>
    /// Select method used for searching network structures.
    /// </summary>    
    public BayesNetGenerator SearchAlgorithm (weka.classifiers.bayes.net.search.SearchAlgorithm newSearchAlgorithm) {
      Impl.setSearchAlgorithm(newSearchAlgorithm);
      return this;
    }

    /// <summary>
    /// Select Estimator algorithm for finding the conditional probability tables
    /// of the Bayes Network.
    /// </summary>    
    public BayesNetGenerator Estimator (weka.classifiers.bayes.net.estimate.BayesNetEstimator newBayesNetEstimator) {
      Impl.setEstimator(newBayesNetEstimator);
      return this;
    }

    /// <summary>
    /// When ADTree (the data structure for increasing speed on counts, not to be
    /// confused with the classifier under the same name) is used learning time
    /// goes down typically. However, because ADTrees are memory intensive, memory
    /// problems may occur. Switching this option off makes the structure learning
    /// algorithms slower, and run with less memory. By default, ADTrees are used.
    /// </summary>    
    public BayesNetGenerator UseADTree (bool bUseADTree) {
      Impl.setUseADTree(bUseADTree);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public BayesNetGenerator Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}