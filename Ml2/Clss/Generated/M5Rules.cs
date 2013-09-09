using System.Collections.Generic;
using System.Linq;
using weka.classifiers.rules;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Generates a decision list for regression problems using
  /// separate-and-conquer. In each iteration it builds a model tree using M5 and makes the "best"
  /// leaf into a rule.<br/><br/>For more information see:<br/><br/>Geoffrey
  /// Holmes, Mark Hall, Eibe Frank: Generating Rule Sets from Model Trees. In:
  /// Twelfth Australian Joint Conference on Artificial Intelligence, 1-12,
  /// 1999.<br/><br/>Ross J. Quinlan: Learning with Continuous Classes. In: 5th Australian
  /// Joint Conference on Artificial Intelligence, Singapore, 343-348,
  /// 1992.<br/><br/>Y. Wang, I. H. Witten: Induction of model trees for predicting
  /// continuous classes. In: Poster papers of the 9th European Conference on Machine
  /// Learning, 1997.<br/><br/>Options:<br/><br/>-N = 	Use unpruned
  /// tree/rules<br/>-U = 	Use unsmoothed predictions<br/>-R = 	Build regression tree/rule
  /// rather than a model tree/rule<br/>-M &lt;minimum number of instances&gt; = 	Set
  /// minimum number of instances per leaf<br/>	(default 4)
  /// </summary>
  public class M5Rules : BaseClassifier<weka.classifiers.rules.M5Rules>
  {
    public M5Rules(Runtime rt) : base(rt, new weka.classifiers.rules.M5Rules()) {
      
    }

    /// <summary>
    /// Whether unpruned tree/rules are to be generated.
    /// </summary>    
    public M5Rules Unpruned (bool unpruned) {
      Impl.setUnpruned(unpruned);
      return this;
    }

    /// <summary>
    /// Whether to use unsmoothed predictions.
    /// </summary>    
    public M5Rules UseUnsmoothed (bool s) {
      Impl.setUseUnsmoothed(s);
      return this;
    }

    /// <summary>
    /// Whether to generate a regression tree/rule instead of a model tree/rule.
    /// </summary>    
    public M5Rules BuildRegressionTree (bool newregressionTree) {
      Impl.setBuildRegressionTree(newregressionTree);
      return this;
    }

    /// <summary>
    /// The minimum number of instances to allow at a leaf node.
    /// </summary>    
    public M5Rules MinNumInstances (double minNum) {
      Impl.setMinNumInstances(minNum);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public M5Rules Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}