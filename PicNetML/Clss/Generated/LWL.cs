using System.Collections.Generic;
using System.Linq;
using weka.classifiers.lazy;

// ReSharper disable once CheckNamespace
namespace PicNetML.Clss
{
  /// <summary>
  /// Locally weighted learning. Uses an instance-based algorithm to assign
  /// instance weights which are then used by a specified
  /// WeightedInstancesHandler.<br/>Can do classification (e.g. using naive Bayes) or regression (e.g.
  /// using linear regression).<br/><br/>For more info, see<br/><br/>Eibe Frank, Mark
  /// Hall, Bernhard Pfahringer: Locally Weighted Naive Bayes. In: 19th
  /// Conference in Uncertainty in Artificial Intelligence, 249-256, 2003.<br/><br/>C.
  /// Atkeson, A. Moore, S. Schaal (1996). Locally weighted learning. AI
  /// Review..<br/><br/>Options:<br/><br/>-A = 	The nearest neighbour search algorithm to
  /// use (default: weka.core.neighboursearch.LinearNNSearch).<br/><br/>-K
  /// &lt;number of neighbours&gt; = 	Set the number of neighbours used to set the
  /// kernel bandwidth.<br/>	(default all)<br/>-U &lt;number of weighting method&gt; =
  /// 	Set the weighting kernel shape to use. 0=Linear,
  /// 1=Epanechnikov,<br/>	2=Tricube, 3=Inverse, 4=Gaussian.<br/>	(default 0 = Linear)<br/>-D = 	If set,
  /// classifier is run in debug mode and<br/>	may output additional info to the
  /// console<br/>-W = 	Full name of base classifier.<br/>	(default:
  /// weka.classifiers.trees.DecisionStump)<br/><br/>Options specific to classifier
  /// weka.classifiers.trees.DecisionStump: = <br/>-D = 	If set, classifier is run in
  /// debug mode and<br/>	may output additional info to the console
  /// </summary>
  public class LWL : BaseClassifier<weka.classifiers.lazy.LWL>
  {
    public LWL(Runtime rt) : base(rt, new weka.classifiers.lazy.LWL()) {
      
    }

    /// <summary>
    /// 
    /// </summary>    
    public LWL KNN (int knn) {
      Impl.setKNN(knn);
      return this;
    }

    /// <summary>
    /// Determines weighting function. [0 = Linear, 1 = Epnechnikov,2 = Tricube,
    /// 3 = Inverse, 4 = Gaussian and 5 = Constant. (default 0 = Linear)].
    /// </summary>    
    public LWL WeightingKernel (int kernel) {
      Impl.setWeightingKernel(kernel);
      return this;
    }

    /// <summary>
    /// The nearest neighbour search algorithm to use (Default: LinearNN).
    /// </summary>    
    public LWL NearestNeighbourSearchAlgorithm (weka.core.neighboursearch.NearestNeighbourSearch nearestNeighbourSearchAlgorithm) {
      Impl.setNearestNeighbourSearchAlgorithm(nearestNeighbourSearchAlgorithm);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public LWL Classifier (PicNetML.Clss.IBaseClassifier<weka.classifiers.Classifier>newClassifier) {
      Impl.setClassifier(newClassifier.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public LWL Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}