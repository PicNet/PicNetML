using System.Collections.Generic;
using System.Linq;
using weka.classifiers.functions;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Learns a simple linear regression model. Picks the attribute that results
  /// in the lowest squared error. Missing values are not allowed. Can only deal
  /// with numeric attributes.<br/><br/>Options:<br/><br/>-D = 	If set,
  /// classifier is run in debug mode and<br/>	may output additional info to the console
  /// </summary>
  public class SimpleLinearRegression : BaseClassifier<weka.classifiers.functions.SimpleLinearRegression>
  {
    public SimpleLinearRegression(Runtime rt) : base(rt, new weka.classifiers.functions.SimpleLinearRegression()) {
      
    }

    /// <summary>
    /// 
    /// </summary>    
    public SimpleLinearRegression SuppressErrorMessage (bool s) {
      Impl.setSuppressErrorMessage(s);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public SimpleLinearRegression Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}