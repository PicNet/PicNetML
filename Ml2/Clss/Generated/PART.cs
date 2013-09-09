using System.Collections.Generic;
using System.Linq;
using weka.classifiers.rules;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for generating a PART decision list. Uses separate-and-conquer.
  /// Builds a partial C4.5 decision tree in each iteration and makes the "best"
  /// leaf into a rule.<br/><br/>For more information, see:<br/><br/>Eibe Frank, Ian
  /// H. Witten: Generating Accurate Rule Sets Without Global Optimization. In:
  /// Fifteenth International Conference on Machine Learning, 144-151,
  /// 1998.<br/><br/>Options:<br/><br/>-C &lt;pruning confidence&gt; = 	Set confidence
  /// threshold for pruning.<br/>	(default 0.25)<br/>-M &lt;minimum number of
  /// objects&gt; = 	Set minimum number of objects per leaf.<br/>	(default 2)<br/>-R =
  /// 	Use reduced error pruning.<br/>-N &lt;number of folds&gt; = 	Set number of
  /// folds for reduced error<br/>	pruning. One fold is used as pruning
  /// set.<br/>	(default 3)<br/>-B = 	Use binary splits only.<br/>-U = 	Generate unpruned
  /// decision list.<br/>-J = 	Do not use MDL correction for info gain on numeric
  /// attributes.<br/>-Q &lt;seed&gt; = 	Seed for random data shuffling (default
  /// 1).
  /// </summary>
  public class PART : BaseClassifier<weka.classifiers.rules.PART>
  {
    public PART(Runtime rt) : base(rt, new weka.classifiers.rules.PART()) {
      Impl.setSeed(Runtime.GlobalRandomSeed);
    }

    /// <summary>
    /// The confidence factor used for pruning (smaller values incur more
    /// pruning).
    /// </summary>    
    public PART ConfidenceFactor (float v) {
      Impl.setConfidenceFactor(v);
      return this;
    }

    /// <summary>
    /// The minimum number of instances per rule.
    /// </summary>    
    public PART MinNumObj (int v) {
      Impl.setMinNumObj(v);
      return this;
    }

    /// <summary>
    /// Whether reduced-error pruning is used instead of C.4.5 pruning.
    /// </summary>    
    public PART ReducedErrorPruning (bool v) {
      Impl.setReducedErrorPruning(v);
      return this;
    }

    /// <summary>
    /// Whether pruning is performed.
    /// </summary>    
    public PART Unpruned (bool newunpruned) {
      Impl.setUnpruned(newunpruned);
      return this;
    }

    /// <summary>
    /// Whether MDL correction is used when finding splits on numeric attributes.
    /// </summary>    
    public PART UseMDLcorrection (bool newuseMDLcorrection) {
      Impl.setUseMDLcorrection(newuseMDLcorrection);
      return this;
    }

    /// <summary>
    /// Determines the amount of data used for reduced-error pruning. One fold is
    /// used for pruning, the rest for growing the rules.
    /// </summary>    
    public PART NumFolds (int v) {
      Impl.setNumFolds(v);
      return this;
    }

    /// <summary>
    /// Whether to use binary splits on nominal attributes when building the
    /// partial trees.
    /// </summary>    
    public PART BinarySplits (bool v) {
      Impl.setBinarySplits(v);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public PART Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}