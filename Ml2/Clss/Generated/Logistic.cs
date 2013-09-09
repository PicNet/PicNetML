using System.Collections.Generic;
using System.Linq;
using weka.classifiers.functions;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for building and using a multinomial logistic regression model with
  /// a ridge estimator.<br/><br/>There are some modifications, however,
  /// compared to the paper of leCessie and van Houwelingen(1992): <br/><br/>If there
  /// are k classes for n instances with m attributes, the parameter matrix B to be
  /// calculated will be an m*(k-1) matrix.<br/><br/>The probability for class j
  /// with the exception of the last class is<br/><br/>Pj(Xi) =
  /// exp(XiBj)/((sum[j=1..(k-1)]exp(Xi*Bj))+1) <br/><br/>The last class has
  /// probability<br/><br/>1-(sum[j=1..(k-1)]Pj(Xi)) <br/>	=
  /// 1/((sum[j=1..(k-1)]exp(Xi*Bj))+1)<br/><br/>The (negative) multinomial log-likelihood is thus: <br/><br/>L =
  /// -sum[i=1..n]{<br/>	sum[j=1..(k-1)](Yij * ln(Pj(Xi)))<br/>	+(1 -
  /// (sum[j=1..(k-1)]Yij)) <br/>	* ln(1 - sum[j=1..(k-1)]Pj(Xi))<br/>	} + ridge *
  /// (B^2)<br/><br/>In order to find the matrix B for which L is minimised, a Quasi-Newton
  /// Method is used to search for the optimized values of the m*(k-1) variables. Note
  /// that before we use the optimization procedure, we 'squeeze' the matrix B
  /// into a m*(k-1) vector. For details of the optimization procedure, please
  /// check weka.core.Optimization class.<br/><br/>Although original Logistic
  /// Regression does not deal with instance weights, we modify the algorithm a little
  /// bit to handle the instance weights.<br/><br/>For more information
  /// see:<br/><br/>le Cessie, S., van Houwelingen, J.C. (1992). Ridge Estimators in
  /// Logistic Regression. Applied Statistics. 41(1):191-201.<br/><br/>Note: Missing
  /// values are replaced using a ReplaceMissingValuesFilter, and nominal
  /// attributes are transformed into numeric attributes using a
  /// NominalToBinaryFilter.<br/><br/>Options:<br/><br/>-D = 	Turn on debugging output.<br/>-C = 	Use
  /// conjugate gradient descent rather than BFGS updates.<br/>-R &lt;ridge&gt; =
  /// 	Set the ridge in the log-likelihood.<br/>-M &lt;number&gt; = 	Set the
  /// maximum number of iterations (default -1, until convergence).
  /// </summary>
  public class Logistic : BaseClassifier<weka.classifiers.functions.Logistic>
  {
    public Logistic(Runtime rt) : base(rt, new weka.classifiers.functions.Logistic()) {
      
    }

    /// <summary>
    /// Output debug information to the console.
    /// </summary>    
    public Logistic Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

    /// <summary>
    /// Use conjugate gradient descent rather than BFGS updates; faster for
    /// problems with many parameters.
    /// </summary>    
    public Logistic UseConjugateGradientDescent (bool useConjugateGradientDescent) {
      Impl.setUseConjugateGradientDescent(useConjugateGradientDescent);
      return this;
    }

    /// <summary>
    /// Set the Ridge value in the log-likelihood.
    /// </summary>    
    public Logistic Ridge (double ridge) {
      Impl.setRidge(ridge);
      return this;
    }

    /// <summary>
    /// Maximum number of iterations to perform.
    /// </summary>    
    public Logistic MaxIts (int newMaxIts) {
      Impl.setMaxIts(newMaxIts);
      return this;
    }

        
        
  }
}