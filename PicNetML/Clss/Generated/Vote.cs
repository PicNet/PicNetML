using System.Collections.Generic;
using System.Linq;
using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
namespace PicNetML.Clss
{
  /// <summary>
  /// Class for combining classifiers. Different combinations of probability
  /// estimates for classification are available.<br/><br/>For more information
  /// see:<br/><br/>Ludmila I. Kuncheva (2004). Combining Pattern Classifiers:
  /// Methods and Algorithms. John Wiley and Sons, Inc..<br/><br/>J. Kittler, M.
  /// Hatef, Robert P.W. Duin, J. Matas (1998). On combining classifiers. IEEE
  /// Transactions on Pattern Analysis and Machine Intelligence.
  /// 20(3):226-239.<br/><br/>Options:<br/><br/>-S &lt;num&gt; = 	Random number seed.<br/>	(default
  /// 1)<br/>-B &lt;classifier specification&gt; = 	Full class name of classifier to
  /// include, followed<br/>	by scheme options. May be specified multiple
  /// times.<br/>	(default: "weka.classifiers.rules.ZeroR")<br/>-D = 	If set, classifier
  /// is run in debug mode and<br/>	may output additional info to the
  /// console<br/>-P &lt;path to serialized classifier&gt; = 	Full path to serialized
  /// classifier to include.<br/>	May be specified multiple times to
  /// include<br/>	multiple serialized classifiers. Note: it does<br/>	not make sense to use
  /// pre-built classifiers in<br/>	a cross-validation.<br/>-R
  /// &lt;AVG|PROD|MAJ|MIN|MAX|MED&gt; = 	The combination rule to use<br/>	(default: AVG)
  /// </summary>
  public class Vote : BaseClassifier<weka.classifiers.meta.Vote>
  {
    public Vote(Runtime rt) : base(rt, new weka.classifiers.meta.Vote()) {
      Impl.setSeed(Runtime.GlobalRandomSeed);
    }

    /// <summary>
    /// The combination rule used.
    /// </summary>    
    public Vote CombinationRule (ECombinationRule newRule) {
      Impl.setCombinationRule(new weka.core.SelectedTag((int) newRule, weka.classifiers.meta.Vote.TAGS_RULES));
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public Vote Environment (weka.core.Environment env) {
      Impl.setEnvironment(env);
      return this;
    }

    /// <summary>
    /// The base classifiers to be used.
    /// </summary>    
    public Vote Classifiers (IEnumerable<IBaseClassifier<weka.classifiers.Classifier>> classifiers) {
      Impl.setClassifiers(classifiers.Select(v => v.Impl).ToArray());
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public Vote Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
    public enum ECombinationRule {
      Average_of_Probabilities = 1,
      Product_of_Probabilities = 2,
      Majority_Voting = 3,
      Minimum_Probability = 4,
      Maximum_Probability = 5,
      Median = 6
    }

        
  }
}