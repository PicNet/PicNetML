using System.Collections.Generic;
using System.Linq;
using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
namespace PicNetML.Clss
{
  /// <summary>
  /// Class for bagging a classifier to reduce variance. Can do classification
  /// and regression depending on the base learner. <br/><br/>For more
  /// information, see<br/><br/>Leo Breiman (1996). Bagging predictors. Machine Learning.
  /// 24(2):123-140.<br/><br/>Options:<br/><br/>-P = 	Size of each bag, as a
  /// percentage of the<br/>	training set size. (default 100)<br/>-O = 	Calculate the
  /// out of bag error.<br/>-S &lt;num&gt; = 	Random number seed.<br/>	(default
  /// 1)<br/>-num-slots &lt;num&gt; = 	Number of execution slots.<br/>	(default 1
  /// - i.e. no parallelism)<br/>-I &lt;num&gt; = 	Number of
  /// iterations.<br/>	(default 10)<br/>-D = 	If set, classifier is run in debug mode and<br/>	may
  /// output additional info to the console<br/>-W = 	Full name of base
  /// classifier.<br/>	(default: weka.classifiers.trees.REPTree)<br/><br/>Options specific
  /// to classifier weka.classifiers.trees.REPTree: = <br/>-M &lt;minimum number
  /// of instances&gt; = 	Set minimum number of instances per leaf (default
  /// 2).<br/>-V &lt;minimum variance for split&gt; = 	Set minimum numeric class
  /// variance proportion<br/>	of train variance for split (default 1e-3).<br/>-N
  /// &lt;number of folds&gt; = 	Number of folds for reduced error pruning (default
  /// 3).<br/>-S &lt;seed&gt; = 	Seed for random data shuffling (default 1).<br/>-P
  /// = 	No pruning.<br/>-L = 	Maximum tree depth (default -1, no
  /// maximum)<br/>-I = 	Initial class value count (default 0)<br/>-R = 	Spread initial count
  /// over all class values (i.e. don't use 1 per value)
  /// </summary>
  public class Bagging : BaseClassifier<weka.classifiers.meta.Bagging>
  {
    public Bagging(Runtime rt) : base(rt, new weka.classifiers.meta.Bagging()) {
      Impl.setSeed(Runtime.GlobalRandomSeed);
    }

    /// <summary>
    /// Size of each bag, as a percentage of the training set size.
    /// </summary>    
    public Bagging BagSizePercent (int newBagSizePercent) {
      Impl.setBagSizePercent(newBagSizePercent);
      return this;
    }

    /// <summary>
    /// Whether the out-of-bag error is calculated.
    /// </summary>    
    public Bagging CalcOutOfBag (bool calcOutOfBag) {
      Impl.setCalcOutOfBag(calcOutOfBag);
      return this;
    }

    /// <summary>
    /// The number of execution slots (threads) to use for constructing the
    /// ensemble.
    /// </summary>    
    public Bagging NumExecutionSlots (int numSlots) {
      Impl.setNumExecutionSlots(numSlots);
      return this;
    }

    /// <summary>
    /// The number of iterations to be performed.
    /// </summary>    
    public Bagging NumIterations (int numIterations) {
      Impl.setNumIterations(numIterations);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public Bagging Classifier (PicNetML.Clss.IBaseClassifier<weka.classifiers.Classifier>newClassifier) {
      Impl.setClassifier(newClassifier.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public Bagging Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}