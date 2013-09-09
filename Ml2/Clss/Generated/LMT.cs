using System.Collections.Generic;
using System.Linq;
using weka.classifiers.trees;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Classifier for building 'logistic model trees', which are classification
  /// trees with logistic regression functions at the leaves. The algorithm can
  /// deal with binary and multi-class target variables, numeric and nominal
  /// attributes and missing values.<br/><br/>For more information see:
  /// <br/><br/>Niels Landwehr, Mark Hall, Eibe Frank (2005). Logistic Model Trees. Machine
  /// Learning. 95(1-2):161-205.<br/><br/>Marc Sumner, Eibe Frank, Mark Hall:
  /// Speeding up Logistic Model Tree Induction. In: 9th European Conference on
  /// Principles and Practice of Knowledge Discovery in Databases, 675-683,
  /// 2005.<br/><br/>Options:<br/><br/>-B = 	Binary splits (convert nominal attributes to
  /// binary ones)<br/>-R = 	Split on residuals instead of class values<br/>-C =
  /// 	Use cross-validation for boosting at all nodes (i.e., disable
  /// heuristic)<br/>-P = 	Use error on probabilities instead of misclassification error for
  /// stopping criterion of LogitBoost.<br/>-I &lt;numIterations&gt; = 	Set fixed
  /// number of iterations for LogitBoost (instead of using
  /// cross-validation)<br/>-M &lt;numInstances&gt; = 	Set minimum number of instances at which a node
  /// can be split (default 15)<br/>-W &lt;beta&gt; = 	Set beta for weight
  /// trimming for LogitBoost. Set to 0 (default) for no weight trimming.<br/>-A = 	The
  /// AIC is used to choose the best iteration.
  /// </summary>
  public class LMT : BaseClassifier<weka.classifiers.trees.LMT>
  {
    public LMT(Runtime rt) : base(rt, new weka.classifiers.trees.LMT()) {
      
    }

    /// <summary>
    /// Convert all nominal attributes to binary ones before building the tree.
    /// This means that all splits in the final tree will be binary.
    /// </summary>    
    public LMT ConvertNominal (bool c) {
      Impl.setConvertNominal(c);
      return this;
    }

    /// <summary>
    /// Set splitting criterion based on the residuals of LogitBoost. There are
    /// two possible splitting criteria for LMT: the default is to use the C4.5
    /// splitting criterion that uses information gain on the class variable. The other
    /// splitting criterion tries to improve the purity in the residuals produces
    /// when fitting the logistic regression functions. The choice of the splitting
    /// criterion does not usually affect classification accuracy much, but can
    /// produce different trees.
    /// </summary>    
    public LMT SplitOnResiduals (bool c) {
      Impl.setSplitOnResiduals(c);
      return this;
    }

    /// <summary>
    /// Use heuristic that avoids cross-validating the number of Logit-Boost
    /// iterations at every node. When fitting the logistic regression functions at a
    /// node, LMT has to determine the number of LogitBoost iterations to run.
    /// Originally, this number was cross-validated at every node in the tree. To save
    /// time, this heuristic cross-validates the number only once and then uses that
    /// number at every node in the tree. Usually this does not decrease accuracy
    /// but improves runtime considerably.
    /// </summary>    
    public LMT FastRegression (bool c) {
      Impl.setFastRegression(c);
      return this;
    }

    /// <summary>
    /// Minimize error on probabilities instead of misclassification error when
    /// cross-validating the number of LogitBoost iterations. When set, the number
    /// of LogitBoost iterations is chosen that minimizes the root mean squared
    /// error instead of the misclassification error.
    /// </summary>    
    public LMT ErrorOnProbabilities (bool c) {
      Impl.setErrorOnProbabilities(c);
      return this;
    }

    /// <summary>
    /// Set a fixed number of iterations for LogitBoost. If >= 0, this sets a
    /// fixed number of LogitBoost iterations that is used everywhere in the tree. If
    /// < 0, the number is cross-validated.
    /// </summary>    
    public LMT NumBoostingIterations (int c) {
      Impl.setNumBoostingIterations(c);
      return this;
    }

    /// <summary>
    /// Set the minimum number of instances at which a node is considered for
    /// splitting. The default value is 15.
    /// </summary>    
    public LMT MinNumInstances (int c) {
      Impl.setMinNumInstances(c);
      return this;
    }

    /// <summary>
    /// Set the beta value used for weight trimming in LogitBoost. Only instances
    /// carrying (1 - beta)% of the weight from previous iteration are used in the
    /// next iteration. Set to 0 for no weight trimming. The default value is 0.
    /// </summary>    
    public LMT WeightTrimBeta (double n) {
      Impl.setWeightTrimBeta(n);
      return this;
    }

    /// <summary>
    /// The AIC is used to determine when to stop LogitBoost iterations. The
    /// default is not to use AIC.
    /// </summary>    
    public LMT UseAIC (bool c) {
      Impl.setUseAIC(c);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public LMT Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}