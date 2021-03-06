using System.Collections.Generic;
using System.Linq;
using weka.classifiers.functions;

// ReSharper disable once CheckNamespace
namespace PicNetML.Clss
{
  /// <summary>
  /// Implements stochastic gradient descent for learning various linear models
  /// (binary class SVM, binary class logistic regression, squared loss, Huber
  /// loss and epsilon-insensitive loss linear regression). Globally replaces all
  /// missing values and transforms nominal attributes into binary ones. It also
  /// normalizes all attributes, so the coefficients in the output are based on
  /// the normalized data.<br/>For numeric class attributes, the squared, Huber or
  /// epsilon-insensitve loss function must be used. Epsilon-insensitive and
  /// Huber loss may require a much higher learning
  /// rate.<br/><br/>Options:<br/><br/>-F = 	Set the loss function to minimize.<br/>	0 = hinge loss (SVM), 1 =
  /// log loss (logistic regression),<br/>	2 = squared loss (regression), 3 =
  /// epsilon insensitive loss (regression),<br/>	4 = Huber loss
  /// (regression).<br/>	(default = 0)<br/>-L = 	The learning rate. If normalization is<br/>	turned
  /// off (as it is automatically for streaming data), then the<br/>	default
  /// learning rate will need to be reduced (try 0.0001).<br/>	(default = 0.01).<br/>-R
  /// &lt;double&gt; = 	The lambda regularization constant (default =
  /// 0.0001)<br/>-E &lt;integer&gt; = 	The number of epochs to perform (batch learning
  /// only, default = 500)<br/>-C &lt;double&gt; = 	The epsilon threshold
  /// (epsilon-insenstive and Huber loss only, default = 1e-3)<br/>-N = 	Don't normalize
  /// the data<br/>-M = 	Don't replace missing values
  /// </summary>
  public class SGD : BaseClassifier<weka.classifiers.functions.SGD>
  {
    public SGD(Runtime rt) : base(rt, new weka.classifiers.functions.SGD()) {
      Impl.setSeed(Runtime.GlobalRandomSeed);
    }

    /// <summary>
    /// The loss function to use. Hinge loss (SVM), log loss (logistic
    /// regression) or squared loss (regression).
    /// </summary>    
    public SGD LossFunction (ELossFunction function) {
      Impl.setLossFunction(new weka.core.SelectedTag((int) function, weka.classifiers.functions.SGD.TAGS_SELECTION));
      return this;
    }

    /// <summary>
    /// The regularization constant. (default = 0.0001)
    /// </summary>    
    public SGD Lambda (double lambda) {
      Impl.setLambda(lambda);
      return this;
    }

    /// <summary>
    /// The learning rate. If normalization is turned off (as it is automatically
    /// for streaming data), thenthe default learning rate will need to be reduced
    /// (try 0.0001).
    /// </summary>    
    public SGD LearningRate (double lr) {
      Impl.setLearningRate(lr);
      return this;
    }

    /// <summary>
    /// The number of epochs to perform (batch learning). The total number of
    /// iterations is epochs * num instances.
    /// </summary>    
    public SGD Epochs (int e) {
      Impl.setEpochs(e);
      return this;
    }

    /// <summary>
    /// The epsilon threshold for epsilon insensitive and Huber loss. An error
    /// with absolute value less that this threshold has loss of 0 for epsilon
    /// insensitive loss. For Huber loss this is the boundary between the quadratic and
    /// linear parts of the loss function.
    /// </summary>    
    public SGD Epsilon (double e) {
      Impl.setEpsilon(e);
      return this;
    }

    /// <summary>
    /// Turn normalization off
    /// </summary>    
    public SGD DontNormalize (bool m) {
      Impl.setDontNormalize(m);
      return this;
    }

    /// <summary>
    /// Turn off global replacement of missing values
    /// </summary>    
    public SGD DontReplaceMissing (bool m) {
      Impl.setDontReplaceMissing(m);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public SGD Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
    public enum ELossFunction {
      Hinge_loss_SVM = 0,
      Log_loss_logistic_regression = 1,
      Squared_loss_regression = 2,
      Epsilon_insensitive_loss_SVM_regression = 3,
      Huber_loss_robust_regression = 4
    }

        
  }
}