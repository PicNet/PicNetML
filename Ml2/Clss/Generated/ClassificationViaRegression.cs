using System.Collections.Generic;
using System.Linq;
using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Class for doing classification using regression methods. Class is
  /// binarized and one regression model is built for each class value. For more
  /// information, see, for example<br/><br/>E. Frank, Y. Wang, S. Inglis, G. Holmes,
  /// I.H. Witten (1998). Using model trees for classification. Machine Learning.
  /// 32(1):63-76.<br/><br/>Options:<br/><br/>-D = 	If set, classifier is run in
  /// debug mode and<br/>	may output additional info to the console<br/>-W = 	Full
  /// name of base classifier.<br/>	(default:
  /// weka.classifiers.trees.M5P)<br/><br/>Options specific to classifier weka.classifiers.trees.M5P: = <br/>-N =
  /// 	Use unpruned tree/rules<br/>-U = 	Use unsmoothed predictions<br/>-R =
  /// 	Build regression tree/rule rather than a model tree/rule<br/>-M &lt;minimum
  /// number of instances&gt; = 	Set minimum number of instances per
  /// leaf<br/>	(default 4)<br/>-L = 	Save instances at the nodes in<br/>	the tree (for
  /// visualization purposes)
  /// </summary>
  public class ClassificationViaRegression : BaseClassifier<weka.classifiers.meta.ClassificationViaRegression>
  {
    public ClassificationViaRegression(Runtime rt) : base(rt, new weka.classifiers.meta.ClassificationViaRegression()) {
      
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public ClassificationViaRegression Classifier (Ml2.Clss.IBaseClassifier<weka.classifiers.Classifier>newClassifier) {
      Impl.setClassifier(newClassifier.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public ClassificationViaRegression Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}