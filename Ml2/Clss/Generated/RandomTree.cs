using System.Collections.Generic;
using System.Linq;
using weka.classifiers.trees;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for constructing a tree that considers K randomly chosen attributes
  /// at each node. Performs no pruning. Also has an option to allow estimation
  /// of class probabilities based on a hold-out set
  /// (backfitting).<br/><br/>Options:<br/><br/>-K &lt;number of attributes&gt; = 	Number of attributes to
  /// randomly investigate<br/>	(<0 = int(log_2(#attributes)+1)).<br/>-M
  /// &lt;minimum number of instances&gt; = 	Set minimum number of instances per
  /// leaf.<br/>-S &lt;num&gt; = 	Seed for random number generator.<br/>	(default
  /// 1)<br/>-depth &lt;num&gt; = 	The maximum depth of the tree, 0 for
  /// unlimited.<br/>	(default 0)<br/>-N &lt;num&gt; = 	Number of folds for backfitting (default 0,
  /// no backfitting).<br/>-U = 	Allow unclassified instances.<br/>-D = 	If set,
  /// classifier is run in debug mode and<br/>	may output additional info to the
  /// console
  /// </summary>
  public class RandomTree : BaseClassifier<weka.classifiers.trees.RandomTree>
  {
    public RandomTree(Runtime rt) : base(rt, new weka.classifiers.trees.RandomTree()) {
      Impl.setSeed(Runtime.GlobalRandomSeed);
    }

    /// <summary>
    /// 
    /// </summary>    
    public RandomTree KValue (int k) {
      Impl.setKValue(k);
      return this;
    }

    /// <summary>
    /// The maximum depth of the tree, 0 for unlimited.
    /// </summary>    
    public RandomTree MaxDepth (int value) {
      Impl.setMaxDepth(value);
      return this;
    }

    /// <summary>
    /// Whether to allow unclassified instances.
    /// </summary>    
    public RandomTree AllowUnclassifiedInstances (bool newAllowUnclassifiedInstances) {
      Impl.setAllowUnclassifiedInstances(newAllowUnclassifiedInstances);
      return this;
    }

    /// <summary>
    /// The minimum total weight of the instances in a leaf.
    /// </summary>    
    public RandomTree MinNum (double newMinNum) {
      Impl.setMinNum(newMinNum);
      return this;
    }

    /// <summary>
    /// Determines the amount of data used for backfitting. One fold is used for
    /// backfitting, the rest for growing the tree. (Default: 0, no backfitting)
    /// </summary>    
    public RandomTree NumFolds (int newNumFolds) {
      Impl.setNumFolds(newNumFolds);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public RandomTree Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}