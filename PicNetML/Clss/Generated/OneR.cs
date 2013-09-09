using System.Collections.Generic;
using System.Linq;
using weka.classifiers.rules;

// ReSharper disable once CheckNamespace
namespace PicNetML.Clss
{
  /// <summary>
  /// Class for building and using a 1R classifier; in other words, uses the
  /// minimum-error attribute for prediction, discretizing numeric attributes. For
  /// more information, see:<br/><br/>R.C. Holte (1993). Very simple
  /// classification rules perform well on most commonly used datasets. Machine Learning.
  /// 11:63-91.<br/><br/>Options:<br/><br/>-B &lt;minimum bucket size&gt; = 	The
  /// minimum number of objects in a bucket (default: 6).
  /// </summary>
  public class OneR : BaseClassifier<weka.classifiers.rules.OneR>
  {
    public OneR(Runtime rt) : base(rt, new weka.classifiers.rules.OneR()) {
      
    }

    /// <summary>
    /// The minimum bucket size used for discretizing numeric attributes.
    /// </summary>    
    public OneR MinBucketSize (int v) {
      Impl.setMinBucketSize(v);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public OneR Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}