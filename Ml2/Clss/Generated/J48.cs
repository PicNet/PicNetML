using System.Collections.Generic;
using System.Linq;
using weka.classifiers.trees;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for generating a pruned or unpruned C4.5 decision tree. For more
  /// information, see<br/><br/>Ross Quinlan (1993). C4.5: Programs for Machine
  /// Learning. Morgan Kaufmann Publishers, San Mateo,
  /// CA.<br/><br/>Options:<br/><br/>-U = 	Use unpruned tree.<br/>-O = 	Do not collapse tree.<br/>-C
  /// &lt;pruning confidence&gt; = 	Set confidence threshold for pruning.<br/>	(default
  /// 0.25)<br/>-M &lt;minimum number of instances&gt; = 	Set minimum number of
  /// instances per leaf.<br/>	(default 2)<br/>-R = 	Use reduced error
  /// pruning.<br/>-N &lt;number of folds&gt; = 	Set number of folds for reduced
  /// error<br/>	pruning. One fold is used as pruning set.<br/>	(default 3)<br/>-B = 	Use
  /// binary splits only.<br/>-S = 	Don't perform subtree raising.<br/>-L = 	Do not
  /// clean up after the tree has been built.<br/>-A = 	Laplace smoothing for
  /// predicted probabilities.<br/>-J = 	Do not use MDL correction for info gain on
  /// numeric attributes.<br/>-Q &lt;seed&gt; = 	Seed for random data shuffling
  /// (default 1).
  /// </summary>
  public class J48 : BaseClassifier<weka.classifiers.trees.J48>
  {
    public J48(Runtime rt) : base(rt, new weka.classifiers.trees.J48()) {
      Impl.setSeed(Runtime.GlobalRandomSeed);
    }

    /// <summary>
    /// Whether counts at leaves are smoothed based on Laplace.
    /// </summary>    
    public J48 UseLaplace (bool newuseLaplace) {
      Impl.setUseLaplace(newuseLaplace);
      return this;
    }

    /// <summary>
    /// Whether MDL correction is used when finding splits on numeric attributes.
    /// </summary>    
    public J48 UseMDLcorrection (bool newuseMDLcorrection) {
      Impl.setUseMDLcorrection(newuseMDLcorrection);
      return this;
    }

    /// <summary>
    /// Whether pruning is performed.
    /// </summary>    
    public J48 Unpruned (bool v) {
      Impl.setUnpruned(v);
      return this;
    }

    /// <summary>
    /// Whether parts are removed that do not reduce training error.
    /// </summary>    
    public J48 CollapseTree (bool v) {
      Impl.setCollapseTree(v);
      return this;
    }

    /// <summary>
    /// The confidence factor used for pruning (smaller values incur more
    /// pruning).
    /// </summary>    
    public J48 ConfidenceFactor (float v) {
      Impl.setConfidenceFactor(v);
      return this;
    }

    /// <summary>
    /// The minimum number of instances per leaf.
    /// </summary>    
    public J48 MinNumObj (int v) {
      Impl.setMinNumObj(v);
      return this;
    }

    /// <summary>
    /// Whether reduced-error pruning is used instead of C.4.5 pruning.
    /// </summary>    
    public J48 ReducedErrorPruning (bool v) {
      Impl.setReducedErrorPruning(v);
      return this;
    }

    /// <summary>
    /// Determines the amount of data used for reduced-error pruning. One fold is
    /// used for pruning, the rest for growing the tree.
    /// </summary>    
    public J48 NumFolds (int v) {
      Impl.setNumFolds(v);
      return this;
    }

    /// <summary>
    /// Whether to use binary splits on nominal attributes when building the
    /// trees.
    /// </summary>    
    public J48 BinarySplits (bool v) {
      Impl.setBinarySplits(v);
      return this;
    }

    /// <summary>
    /// Whether to consider the subtree raising operation when pruning.
    /// </summary>    
    public J48 SubtreeRaising (bool v) {
      Impl.setSubtreeRaising(v);
      return this;
    }

    /// <summary>
    /// Whether to save the training data for visualization.
    /// </summary>    
    public J48 SaveInstanceData (bool v) {
      Impl.setSaveInstanceData(v);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public J48 Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}