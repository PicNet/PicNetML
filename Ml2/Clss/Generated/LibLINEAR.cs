using System.Collections.Generic;
using System.Linq;
using weka.classifiers.functions;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// A wrapper class for the liblinear tools (the liblinear classes, typically
  /// the jar file, need to be in the classpath to use this
  /// classifier).<br/>Rong-En Fan, Kai-Wei Chang, Cho-Jui Hsieh, Xiang-Rui Wang, Chih-Jen Lin
  /// (2008). LIBLINEAR - A Library for Large Linear Classification. URL
  /// http://www.csie.ntu.edu.tw/~cjlin/liblinear/.<br/><br/>Options:<br/><br/>-S &lt;int&gt; =
  /// 	Set type of solver (default: 1)<br/>		 0 = L2-regularized logistic
  /// regression<br/>		 1 = L2-loss support vector machines (dual)<br/>		 2 = L2-loss
  /// support vector machines (primal)<br/>		 3 = L1-loss support vector machines
  /// (dual)<br/>		 4 = multi-class support vector machines by Crammer and
  /// Singer<br/>-C &lt;double&gt; = 	Set the cost parameter C<br/>	 (default:
  /// 1)<br/>-Z = 	Turn on normalization of input data (default: off)<br/>-N = 	Turn on
  /// nominal to binary conversion.<br/>-M = 	Turn off missing value
  /// replacement.<br/>	WARNING: use only if your data has no missing values.<br/>-P = 	Use
  /// probability estimation (default: off)<br/>currently for L2-regularized
  /// logistic regression only! <br/>-E &lt;double&gt; = 	Set tolerance of termination
  /// criterion (default: 0.01)<br/>-W &lt;double&gt; = 	Set the parameters C of
  /// class i to weight[i]*C<br/>	 (default: 1)<br/>-B &lt;double&gt; = 	Add Bias
  /// term with the given value if >= 0; if < 0, no bias term added (default:
  /// 1)<br/>-D = 	If set, classifier is run in debug mode and<br/>	may output
  /// additional info to the console
  /// </summary>
  public class LibLINEAR : BaseClassifier<weka.classifiers.functions.LibLINEAR>
  {
    public LibLINEAR(Runtime rt) : base(rt, new weka.classifiers.functions.LibLINEAR()) {
      
    }

    /// <summary>
    /// 
    /// </summary>    
    public LibLINEAR SVMType (ESVMType value) {
      Impl.setSVMType(new weka.core.SelectedTag((int) value, weka.classifiers.functions.LibLINEAR.TAGS_SVMTYPE));
      return this;
    }

    /// <summary>
    /// The cost parameter C.
    /// </summary>    
    public LibLINEAR Cost (double value) {
      Impl.setCost(value);
      return this;
    }

    /// <summary>
    /// The tolerance of the termination criterion.
    /// </summary>    
    public LibLINEAR Eps (double value) {
      Impl.setEps(value);
      return this;
    }

    /// <summary>
    /// Whether to normalize the data.
    /// </summary>    
    public LibLINEAR Normalize (bool value) {
      Impl.setNormalize(value);
      return this;
    }

    /// <summary>
    /// Whether to turn on conversion of nominal attributes to binary.
    /// </summary>    
    public LibLINEAR ConvertNominalToBinary (bool b) {
      Impl.setConvertNominalToBinary(b);
      return this;
    }

    /// <summary>
    /// Whether to turn off automatic replacement of missing values. WARNING: set
    /// to true only if the data does not contain missing values.
    /// </summary>    
    public LibLINEAR DoNotReplaceMissingValues (bool b) {
      Impl.setDoNotReplaceMissingValues(b);
      return this;
    }

    /// <summary>
    /// If >= 0, a bias term with that value is added; otherwise (<0) no bias
    /// term is added (default: 1).
    /// </summary>    
    public LibLINEAR Bias (double value) {
      Impl.setBias(value);
      return this;
    }

    /// <summary>
    /// The weights to use for the classes, if empty 1 is used by default.
    /// </summary>    
    public LibLINEAR Weights (string weightsStr) {
      Impl.setWeights(weightsStr);
      return this;
    }

    /// <summary>
    /// Whether to generate probability estimates instead of -1/+1 for
    /// classification problems (currently for L2-regularized logistic regression only!)
    /// </summary>    
    public LibLINEAR ProbabilityEstimates (bool value) {
      Impl.setProbabilityEstimates(value);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public LibLINEAR Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
    public enum ESVMType {
      L2_regularized_logistic_regression = 0,
      L2_loss_support_vector_machines_dual = 1,
      L2_loss_support_vector_machines_primal = 2,
      Lone_loss_support_vector_machines_dual = 3,
      multi_class_support_vector_machines_by_Crammer_and_Singer = 4
    }

        
  }
}