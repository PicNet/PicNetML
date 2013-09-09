using System.Collections.Generic;
using System.Linq;
using weka.classifiers.functions;

// ReSharper disable once CheckNamespace
namespace PicNetML.Clss
{
  /// <summary>
  /// Classifier for building linear logistic regression models. LogitBoost
  /// with simple regression functions as base learners is used for fitting the
  /// logistic models. The optimal number of LogitBoost iterations to perform is
  /// cross-validated, which leads to automatic attribute selection. For more
  /// information see:<br/>Niels Landwehr, Mark Hall, Eibe Frank (2005). Logistic Model
  /// Trees.<br/><br/>Marc Sumner, Eibe Frank, Mark Hall: Speeding up Logistic
  /// Model Tree Induction. In: 9th European Conference on Principles and Practice
  /// of Knowledge Discovery in Databases, 675-683,
  /// 2005.<br/><br/>Options:<br/><br/>-I &lt;iterations&gt; = 	Set fixed number of iterations for
  /// LogitBoost<br/>-S = 	Use stopping criterion on training set (instead
  /// of<br/>	cross-validation)<br/>-P = 	Use error on probabilities (rmse) instead
  /// of<br/>	misclassification error for stopping criterion<br/>-M &lt;iterations&gt; = 	Set
  /// maximum number of boosting iterations<br/>-H &lt;iterations&gt; = 	Set
  /// parameter for heuristic for early stopping of<br/>	LogitBoost.<br/>	If enabled,
  /// the minimum is selected greedily, stopping<br/>	if the current minimum has
  /// not changed for iter iterations.<br/>	By default, heuristic is enabled with
  /// value 50. Set to<br/>	zero to disable heuristic.<br/>-W &lt;beta&gt; =
  /// 	Set beta for weight trimming for LogitBoost. Set to 0 for no weight
  /// trimming.<br/><br/>-A = 	The AIC is used to choose the best iteration (instead of CV
  /// or training error).<br/>
  /// </summary>
  public class SimpleLogistic : BaseClassifier<weka.classifiers.functions.SimpleLogistic>
  {
    public SimpleLogistic(Runtime rt) : base(rt, new weka.classifiers.functions.SimpleLogistic()) {
      
    }

    /// <summary>
    /// Set fixed number of iterations for LogitBoost. If >= 0, this sets the
    /// number of LogitBoost iterations to perform. If < 0, the number is
    /// cross-validated or a stopping criterion on the training set is used (depending on the
    /// value of useCrossValidation).
    /// </summary>    
    public SimpleLogistic NumBoostingIterations (int n) {
      Impl.setNumBoostingIterations(n);
      return this;
    }

    /// <summary>
    /// Sets whether the number of LogitBoost iterations is to be cross-validated
    /// or the stopping criterion on the training set should be used. If not set
    /// (and no fixed number of iterations was given), the number of LogitBoost
    /// iterations is used that minimizes the error on the training set
    /// (misclassification error or error on probabilities depending on errorOnProbabilities).
    /// </summary>    
    public SimpleLogistic UseCrossValidation (bool l) {
      Impl.setUseCrossValidation(l);
      return this;
    }

    /// <summary>
    /// Use error on the probabilties as error measure when determining the best
    /// number of LogitBoost iterations. If set, the number of LogitBoost
    /// iterations is chosen that minimizes the root mean squared error (either on the
    /// training set or in the cross-validation, depending on useCrossValidation).
    /// </summary>    
    public SimpleLogistic ErrorOnProbabilities (bool l) {
      Impl.setErrorOnProbabilities(l);
      return this;
    }

    /// <summary>
    /// Sets the maximum number of iterations for LogitBoost. Default value is
    /// 500, for very small/large datasets a lower/higher value might be preferable.
    /// </summary>    
    public SimpleLogistic MaxBoostingIterations (int n) {
      Impl.setMaxBoostingIterations(n);
      return this;
    }

    /// <summary>
    /// If heuristicStop > 0, the heuristic for greedy stopping while
    /// cross-validating the number of LogitBoost iterations is enabled. This means LogitBoost
    /// is stopped if no new error minimum has been reached in the last
    /// heuristicStop iterations. It is recommended to use this heuristic, it gives a large
    /// speed-up especially on small datasets. The default value is 50.
    /// </summary>    
    public SimpleLogistic HeuristicStop (int n) {
      Impl.setHeuristicStop(n);
      return this;
    }

    /// <summary>
    /// Set the beta value used for weight trimming in LogitBoost. Only instances
    /// carrying (1 - beta)% of the weight from previous iteration are used in the
    /// next iteration. Set to 0 for no weight trimming. The default value is 0.
    /// </summary>    
    public SimpleLogistic WeightTrimBeta (double n) {
      Impl.setWeightTrimBeta(n);
      return this;
    }

    /// <summary>
    /// The AIC is used to determine when to stop LogitBoost iterations (instead
    /// of cross-validation or training error).
    /// </summary>    
    public SimpleLogistic UseAIC (bool c) {
      Impl.setUseAIC(c);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public SimpleLogistic Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}