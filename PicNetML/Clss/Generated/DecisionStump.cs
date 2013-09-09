using System.Collections.Generic;
using System.Linq;
using weka.classifiers.trees;

// ReSharper disable once CheckNamespace
namespace PicNetML.Clss
{
  /// <summary>
  /// Class for building and using a decision stump. Usually used in
  /// conjunction with a boosting algorithm. Does regression (based on mean-squared error)
  /// or classification (based on entropy). Missing is treated as a separate
  /// value.<br/><br/>Options:<br/><br/>-D = 	If set, classifier is run in debug mode
  /// and<br/>	may output additional info to the console
  /// </summary>
  public class DecisionStump : BaseClassifier<weka.classifiers.trees.DecisionStump>
  {
    public DecisionStump(Runtime rt) : base(rt, new weka.classifiers.trees.DecisionStump()) {
      
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public DecisionStump Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}