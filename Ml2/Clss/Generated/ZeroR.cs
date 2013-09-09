using System.Collections.Generic;
using System.Linq;
using weka.classifiers.rules;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for building and using a 0-R classifier. Predicts the mean (for a
  /// numeric class) or the mode (for a nominal
  /// class).<br/><br/>Options:<br/><br/>-D = 	If set, classifier is run in debug mode and<br/>	may output
  /// additional info to the console
  /// </summary>
  public class ZeroR : BaseClassifier<weka.classifiers.rules.ZeroR>
  {
    public ZeroR(Runtime rt) : base(rt, new weka.classifiers.rules.ZeroR()) {
      
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public ZeroR Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}