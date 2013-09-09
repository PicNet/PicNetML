using System.Collections.Generic;
using System.Linq;
using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Combines several classifiers using the stacking method. Can do
  /// classification or regression.<br/><br/>For more information, see<br/><br/>David H.
  /// Wolpert (1992). Stacked generalization. Neural Networks.
  /// 5:241-259.<br/><br/>Options:<br/><br/>-M &lt;scheme specification&gt; = 	Full name of meta
  /// classifier, followed by options.<br/>	(default:
  /// "weka.classifiers.rules.Zero")<br/>-X &lt;number of folds&gt; = 	Sets the number of cross-validation
  /// folds.<br/>-S &lt;num&gt; = 	Random number seed.<br/>	(default 1)<br/>-num-slots
  /// &lt;num&gt; = 	Number of execution slots.<br/>	(default 1 - i.e. no
  /// parallelism)<br/>-B &lt;classifier specification&gt; = 	Full class name of
  /// classifier to include, followed<br/>	by scheme options. May be specified multiple
  /// times.<br/>	(default: "weka.classifiers.rules.ZeroR")<br/>-D = 	If set,
  /// classifier is run in debug mode and<br/>	may output additional info to the
  /// console
  /// </summary>
  public class Stacking : BaseClassifier<weka.classifiers.meta.Stacking>
  {
    public Stacking(Runtime rt) : base(rt, new weka.classifiers.meta.Stacking()) {
      Impl.setSeed(Runtime.GlobalRandomSeed);
    }

    /// <summary>
    /// The number of folds used for cross-validation.
    /// </summary>    
    public Stacking NumFolds (int numFolds) {
      Impl.setNumFolds(numFolds);
      return this;
    }

    /// <summary>
    /// The meta classifiers to be used.
    /// </summary>    
    public Stacking MetaClassifier (Ml2.Clss.IBaseClassifier<weka.classifiers.Classifier>classifier) {
      Impl.setMetaClassifier(classifier.Impl);
      return this;
    }

    /// <summary>
    /// The number of execution slots (threads) to use for constructing the
    /// ensemble.
    /// </summary>    
    public Stacking NumExecutionSlots (int numSlots) {
      Impl.setNumExecutionSlots(numSlots);
      return this;
    }

    /// <summary>
    /// The base classifiers to be used.
    /// </summary>    
    public Stacking Classifiers (IEnumerable<IBaseClassifier<weka.classifiers.Classifier>> classifiers) {
      Impl.setClassifiers(classifiers.Select(v => v.Impl).ToArray());
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public Stacking Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}