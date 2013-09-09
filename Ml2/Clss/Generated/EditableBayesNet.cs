using System.Collections.Generic;
using System.Linq;
using weka.classifiers.bayes.net;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Bayes Network learning using various search algorithms and quality
  /// measures.<br/>Base class for a Bayes Network classifier. Provides datastructures
  /// (network structure, conditional probability distributions, etc.) and
  /// facilities common to Bayes Network learning algorithms like K2 and
  /// B.<br/><br/>For more information
  /// see:<br/><br/>http://www.cs.waikato.ac.nz/~remco/weka.pdf<br/><br/>Options:<br/><br/>-D = 	Do not use ADTree data
  /// structure<br/><br/>-B &lt;BIF file&gt; = 	BIF file to compare with<br/><br/>-Q
  /// weka.classifiers.bayes.net.search.SearchAlgorithm = 	Search algorithm<br/><br/>-E
  /// weka.classifiers.bayes.net.estimate.SimpleEstimator = 	Estimator algorithm<br/>
  /// </summary>
  public class EditableBayesNet : BaseClassifier<weka.classifiers.bayes.net.EditableBayesNet>
  {
    public EditableBayesNet(Runtime rt) : base(rt, new weka.classifiers.bayes.net.EditableBayesNet()) {
      
    }

    /// <summary>
    /// 
    /// </summary>    
    public EditableBayesNet Distribution (int nTargetNode, double[][] P) {
      Impl.setDistribution(nTargetNode, P);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public EditableBayesNet Evidence (int iNode, int iValue) {
      Impl.setEvidence(iNode, iValue);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public EditableBayesNet Data (Runtime instances) {
      Impl.setData(instances.Impl);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public EditableBayesNet Distribution (string sName, double[][] P) {
      Impl.setDistribution(sName, P);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public EditableBayesNet NodeName (int nTargetNode, string sName) {
      Impl.setNodeName(nTargetNode, sName);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public EditableBayesNet Position (int iNode, int nX, int nY) {
      Impl.setPosition(iNode, nX, nY);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public EditableBayesNet Margin (int iNode, double[] fMarginP) {
      Impl.setMargin(iNode, fMarginP);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public EditableBayesNet BIFFile (string sBIFFile) {
      Impl.setBIFFile(sBIFFile);
      return this;
    }

    /// <summary>
    /// Select method used for searching network structures.
    /// </summary>    
    public EditableBayesNet SearchAlgorithm (weka.classifiers.bayes.net.search.SearchAlgorithm newSearchAlgorithm) {
      Impl.setSearchAlgorithm(newSearchAlgorithm);
      return this;
    }

    /// <summary>
    /// Select Estimator algorithm for finding the conditional probability tables
    /// of the Bayes Network.
    /// </summary>    
    public EditableBayesNet Estimator (weka.classifiers.bayes.net.estimate.BayesNetEstimator newBayesNetEstimator) {
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
    public EditableBayesNet UseADTree (bool bUseADTree) {
      Impl.setUseADTree(bUseADTree);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public EditableBayesNet Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}