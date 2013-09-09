using System.Collections.Generic;
using System.Linq;
using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
namespace PicNetML.Clss
{
  /// <summary>
  /// This method constructs a decision tree based classifier that maintains
  /// highest accuracy on training data and improves on generalization accuracy as
  /// it grows in complexity. The classifier consists of multiple trees
  /// constructed systematically by pseudorandomly selecting subsets of components of the
  /// feature vector, that is, trees constructed in randomly chosen
  /// subspaces.<br/><br/>For more information, see<br/><br/>Tin Kam Ho (1998). The Random
  /// Subspace Method for Constructing Decision Forests. IEEE Transactions on
  /// Pattern Analysis and Machine Intelligence. 20(8):832-844. URL
  /// http://citeseer.ist.psu.edu/ho98random.html.<br/><br/>Options:<br/><br/>-P = 	Size of each
  /// subspace:<br/>		< 1: percentage of the number of attributes<br/>		>=1:
  /// absolute number of attributes<br/><br/>-S &lt;num&gt; = 	Random number
  /// seed.<br/>	(default 1)<br/>-num-slots &lt;num&gt; = 	Number of execution
  /// slots.<br/>	(default 1 - i.e. no parallelism)<br/>-I &lt;num&gt; = 	Number of
  /// iterations.<br/>	(default 10)<br/>-D = 	If set, classifier is run in debug mode
  /// and<br/>	may output additional info to the console<br/>-W = 	Full name of base
  /// classifier.<br/>	(default: weka.classifiers.trees.REPTree)<br/><br/>Options
  /// specific to classifier weka.classifiers.trees.REPTree: = <br/>-M
  /// &lt;minimum number of instances&gt; = 	Set minimum number of instances per leaf
  /// (default 2).<br/>-V &lt;minimum variance for split&gt; = 	Set minimum numeric
  /// class variance proportion<br/>	of train variance for split (default
  /// 1e-3).<br/>-N &lt;number of folds&gt; = 	Number of folds for reduced error pruning
  /// (default 3).<br/>-S &lt;seed&gt; = 	Seed for random data shuffling (default
  /// 1).<br/>-P = 	No pruning.<br/>-L = 	Maximum tree depth (default -1, no
  /// maximum)<br/>-I = 	Initial class value count (default 0)<br/>-R = 	Spread
  /// initial count over all class values (i.e. don't use 1 per value)
  /// </summary>
  public class RandomSubSpace : BaseClassifier<weka.classifiers.meta.RandomSubSpace>
  {
    public RandomSubSpace(Runtime rt) : base(rt, new weka.classifiers.meta.RandomSubSpace()) {
      Impl.setSeed(Runtime.GlobalRandomSeed);
    }

    /// <summary>
    /// Size of each subSpace: if less than 1 as a percentage of the number of
    /// attributes, otherwise the absolute number of attributes.
    /// </summary>    
    public RandomSubSpace SubSpaceSize (double value) {
      Impl.setSubSpaceSize(value);
      return this;
    }

    /// <summary>
    /// The number of execution slots (threads) to use for constructing the
    /// ensemble.
    /// </summary>    
    public RandomSubSpace NumExecutionSlots (int numSlots) {
      Impl.setNumExecutionSlots(numSlots);
      return this;
    }

    /// <summary>
    /// The number of iterations to be performed.
    /// </summary>    
    public RandomSubSpace NumIterations (int numIterations) {
      Impl.setNumIterations(numIterations);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public RandomSubSpace Classifier (PicNetML.Clss.IBaseClassifier<weka.classifiers.Classifier>newClassifier) {
      Impl.setClassifier(newClassifier.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public RandomSubSpace Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}