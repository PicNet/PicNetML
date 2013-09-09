using System.Collections.Generic;
using System.Linq;
using weka.classifiers.trees;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Fast decision tree learner. Builds a decision/regression tree using
  /// information gain/variance and prunes it using reduced-error pruning (with
  /// backfitting). Only sorts values for numeric attributes once. Missing values are
  /// dealt with by splitting the corresponding instances into pieces (i.e. as in
  /// C4.5).<br/><br/>Options:<br/><br/>-M &lt;minimum number of instances&gt; =
  /// 	Set minimum number of instances per leaf (default 2).<br/>-V &lt;minimum
  /// variance for split&gt; = 	Set minimum numeric class variance
  /// proportion<br/>	of train variance for split (default 1e-3).<br/>-N &lt;number of folds&gt;
  /// = 	Number of folds for reduced error pruning (default 3).<br/>-S
  /// &lt;seed&gt; = 	Seed for random data shuffling (default 1).<br/>-P = 	No
  /// pruning.<br/>-L = 	Maximum tree depth (default -1, no maximum)<br/>-I = 	Initial class
  /// value count (default 0)<br/>-R = 	Spread initial count over all class
  /// values (i.e. don't use 1 per value)
  /// </summary>
  public class REPTree : BaseClassifier<weka.classifiers.trees.REPTree>
  {
    public REPTree(Runtime rt) : base(rt, new weka.classifiers.trees.REPTree()) {
      Impl.setSeed(Runtime.GlobalRandomSeed);
    }

    /// <summary>
    /// Whether pruning is performed.
    /// </summary>    
    public REPTree NoPruning (bool newNoPruning) {
      Impl.setNoPruning(newNoPruning);
      return this;
    }

    /// <summary>
    /// The minimum total weight of the instances in a leaf.
    /// </summary>    
    public REPTree MinNum (double newMinNum) {
      Impl.setMinNum(newMinNum);
      return this;
    }

    /// <summary>
    /// The minimum proportion of the variance on all the data that needs to be
    /// present at a node in order for splitting to be performed in regression
    /// trees.
    /// </summary>    
    public REPTree MinVarianceProp (double newMinVarianceProp) {
      Impl.setMinVarianceProp(newMinVarianceProp);
      return this;
    }

    /// <summary>
    /// Determines the amount of data used for pruning. One fold is used for
    /// pruning, the rest for growing the rules.
    /// </summary>    
    public REPTree NumFolds (int newNumFolds) {
      Impl.setNumFolds(newNumFolds);
      return this;
    }

    /// <summary>
    /// The maximum tree depth (-1 for no restriction).
    /// </summary>    
    public REPTree MaxDepth (int newMaxDepth) {
      Impl.setMaxDepth(newMaxDepth);
      return this;
    }

    /// <summary>
    /// Initial class value count.
    /// </summary>    
    public REPTree InitialCount (double newInitialCount) {
      Impl.setInitialCount(newInitialCount);
      return this;
    }

    /// <summary>
    /// Spread initial count across all values instead of using the count per
    /// value.
    /// </summary>    
    public REPTree SpreadInitialCount (bool newSpreadInitialCount) {
      Impl.setSpreadInitialCount(newSpreadInitialCount);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public REPTree Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}