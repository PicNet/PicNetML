using System.Collections.Generic;
using System.Linq;
using weka.classifiers.trees;

// ReSharper disable once CheckNamespace
namespace PicNetML.Clss
{
  /// <summary>
  /// Class for constructing a forest of random trees.<br/><br/>For more
  /// information see: <br/><br/>Leo Breiman (2001). Random Forests. Machine Learning.
  /// 45(1):5-32.<br/><br/>Options:<br/><br/>-I &lt;number of trees&gt; = 	Number
  /// of trees to build.<br/>-K &lt;number of features&gt; = 	Number of features
  /// to consider (<1=int(logM+1)).<br/>-S = 	Seed for random number
  /// generator.<br/>	(default 1)<br/>-depth &lt;num&gt; = 	The maximum depth of the trees,
  /// 0 for unlimited.<br/>	(default 0)<br/>-print = 	Print the individual trees
  /// in the output<br/>-num-slots &lt;num&gt; = 	Number of execution
  /// slots.<br/>	(default 1 - i.e. no parallelism)<br/>-D = 	If set, classifier is run in
  /// debug mode and<br/>	may output additional info to the console
  /// </summary>
  public class RandomForest : BaseClassifier<weka.classifiers.trees.RandomForest>
  {
    public RandomForest(Runtime rt) : base(rt, new weka.classifiers.trees.RandomForest()) {
      Impl.setSeed(Runtime.GlobalRandomSeed);
    }

    /// <summary>
    /// The maximum depth of the trees, 0 for unlimited.
    /// </summary>    
    public RandomForest MaxDepth (int value) {
      Impl.setMaxDepth(value);
      return this;
    }

    /// <summary>
    /// Print the individual trees in the output
    /// </summary>    
    public RandomForest PrintTrees (bool print) {
      Impl.setPrintTrees(print);
      return this;
    }

    /// <summary>
    /// The number of execution slots (threads) to use for constructing the
    /// ensemble.
    /// </summary>    
    public RandomForest NumExecutionSlots (int numSlots) {
      Impl.setNumExecutionSlots(numSlots);
      return this;
    }

    /// <summary>
    /// The number of trees to be generated.
    /// </summary>    
    public RandomForest NumTrees (int newNumTrees) {
      Impl.setNumTrees(newNumTrees);
      return this;
    }

    /// <summary>
    /// The number of attributes to be used in random selection (see RandomTree).
    /// </summary>    
    public RandomForest NumFeatures (int newNumFeatures) {
      Impl.setNumFeatures(newNumFeatures);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public RandomForest Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}