using System.Collections.Generic;
using System.Linq;
using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
namespace PicNetML.Clss
{
  /// <summary>
  /// A metaclassifier for handling multi-class datasets with 2-class
  /// classifiers. This classifier is also capable of applying error correcting output
  /// codes for increased accuracy. The base classifier must be an updateable
  /// classifier<br/><br/>Options:<br/><br/>-M &lt;num&gt; = 	Sets the method to use.
  /// Valid values are 0 (1-against-all),<br/>	1 (random codes), 2 (exhaustive
  /// code), and 3 (1-against-1). (default 0)<br/><br/>-R &lt;num&gt; = 	Sets the
  /// multiplier when using random codes. (default 2.0)<br/>-P = 	Use pairwise
  /// coupling (only has an effect for 1-against1)<br/>-S &lt;num&gt; = 	Random
  /// number seed.<br/>	(default 1)<br/>-D = 	If set, classifier is run in debug mode
  /// and<br/>	may output additional info to the console<br/>-W = 	Full name of
  /// base classifier.<br/>	(default:
  /// weka.classifiers.functions.Logistic)<br/><br/>Options specific to classifier weka.classifiers.functions.SGD: = <br/>-F
  /// = 	Set the loss function to minimize. 0 = hinge loss (SVM), 1 = log loss
  /// (logistic regression),<br/>	2 = squared loss (regression).<br/>	(default =
  /// 0)<br/>-L = 	The learning rate. If normalization is<br/>	turned off (as it is
  /// automatically for streaming data), then the<br/>	default learning rate
  /// will need to be reduced (try 0.0001).<br/>	(default = 0.01).<br/>-R
  /// &lt;double&gt; = 	The lambda regularization constant (default = 0.0001)<br/>-E
  /// &lt;integer&gt; = 	The number of epochs to perform (batch learning only, default
  /// = 500)<br/>-N = 	Don't normalize the data<br/>-M = 	Don't replace missing
  /// values
  /// </summary>
  public class MultiClassClassifierUpdateable : BaseClassifier<weka.classifiers.meta.MultiClassClassifierUpdateable>
  {
    public MultiClassClassifierUpdateable(Runtime rt) : base(rt, new weka.classifiers.meta.MultiClassClassifierUpdateable()) {
      Impl.setSeed(Runtime.GlobalRandomSeed);
    }

    /// <summary>
    /// Sets the method to use for transforming the multi-class problem into
    /// several 2-class ones.
    /// </summary>    
    public MultiClassClassifierUpdateable Method (EMethod newMethod) {
      Impl.setMethod(new weka.core.SelectedTag((int) newMethod, weka.classifiers.meta.MultiClassClassifierUpdateable.TAGS_METHOD));
      return this;
    }

    /// <summary>
    /// Sets the width multiplier when using random codes. The number of codes
    /// generated will be thus number multiplied by the number of classes.
    /// </summary>    
    public MultiClassClassifierUpdateable RandomWidthFactor (double newRandomWidthFactor) {
      Impl.setRandomWidthFactor(newRandomWidthFactor);
      return this;
    }

    /// <summary>
    /// Use pairwise coupling (only has an effect for 1-against-1).
    /// </summary>    
    public MultiClassClassifierUpdateable UsePairwiseCoupling (bool p) {
      Impl.setUsePairwiseCoupling(p);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public MultiClassClassifierUpdateable Classifier (PicNetML.Clss.IBaseClassifier<weka.classifiers.Classifier>newClassifier) {
      Impl.setClassifier(newClassifier.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public MultiClassClassifierUpdateable Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
    public enum EMethod {
      one_against_all = 0,
      Random_correction_code = 1,
      Exhaustive_correction_code = 2,
      one_against_one = 3
    }

        
  }
}