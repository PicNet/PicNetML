using System.Collections.Generic;
using System.Linq;
using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
namespace PicNetML.Clss
{
  /// <summary>
  /// Meta classifier that enhances the performance of a regression base
  /// classifier. Each iteration fits a model to the residuals left by the classifier
  /// on the previous iteration. Prediction is accomplished by adding the
  /// predictions of each classifier. Reducing the shrinkage (learning rate) parameter
  /// helps prevent overfitting and has a smoothing effect but increases the
  /// learning time.<br/><br/>For more information see:<br/><br/>J.H. Friedman (1999).
  /// Stochastic Gradient Boosting.<br/><br/>Options:<br/><br/>-S = 	Specify
  /// shrinkage rate. (default = 1.0, ie. no shrinkage)<br/><br/>-I &lt;num&gt; =
  /// 	Number of iterations.<br/>	(default 10)<br/>-D = 	If set, classifier is run
  /// in debug mode and<br/>	may output additional info to the console<br/>-W =
  /// 	Full name of base classifier.<br/>	(default:
  /// weka.classifiers.trees.DecisionStump)<br/><br/>Options specific to classifier
  /// weka.classifiers.trees.DecisionStump: = <br/>-D = 	If set, classifier is run in debug mode and<br/>	may
  /// output additional info to the console
  /// </summary>
  public class AdditiveRegression : BaseClassifier<weka.classifiers.meta.AdditiveRegression>
  {
    public AdditiveRegression(Runtime rt) : base(rt, new weka.classifiers.meta.AdditiveRegression()) {
      
    }

    /// <summary>
    /// Shrinkage rate. Smaller values help prevent overfitting and have a
    /// smoothing effect (but increase learning time). Default = 1.0, ie. no shrinkage.
    /// </summary>    
    public AdditiveRegression Shrinkage (double l) {
      Impl.setShrinkage(l);
      return this;
    }

    /// <summary>
    /// The number of iterations to be performed.
    /// </summary>    
    public AdditiveRegression NumIterations (int numIterations) {
      Impl.setNumIterations(numIterations);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public AdditiveRegression Classifier (PicNetML.Clss.IBaseClassifier<weka.classifiers.Classifier>newClassifier) {
      Impl.setClassifier(newClassifier.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public AdditiveRegression Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}