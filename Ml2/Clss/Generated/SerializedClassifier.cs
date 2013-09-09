using System.Collections.Generic;
using System.Linq;
using weka.classifiers.misc;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// A wrapper around a serialized classifier model. This classifier loads a
  /// serialized models and uses it to make predictions.<br/><br/>Warning: since
  /// the serialized model doesn't get changed, cross-validation cannot bet used
  /// with this classifier.<br/><br/>Options:<br/><br/>-D = 	If set, classifier is
  /// run in debug mode and<br/>	may output additional info to the
  /// console<br/>-model &lt;filename&gt; = 	The file containing the serialized
  /// model.<br/>	(required)
  /// </summary>
  public class SerializedClassifier : BaseClassifier<weka.classifiers.misc.SerializedClassifier>
  {
    public SerializedClassifier(Runtime rt) : base(rt, new weka.classifiers.misc.SerializedClassifier()) {
      
    }

    /// <summary>
    /// 
    /// </summary>    
    public SerializedClassifier Model (Ml2.Clss.IBaseClassifier<weka.classifiers.Classifier>value) {
      Impl.setModel(value.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public SerializedClassifier Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}