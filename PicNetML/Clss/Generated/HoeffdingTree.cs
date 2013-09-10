using System.Collections.Generic;
using System.Linq;
using weka.classifiers.trees;

// ReSharper disable once CheckNamespace
namespace PicNetML.Clss
{
  /// <summary>
  /// A Hoeffding tree (VFDT) is an incremental, anytime decision tree
  /// induction algorithm that is capable of learning from massive data streams, assuming
  /// that the distribution generating examples does not change over time.
  /// Hoeffding trees exploit the fact that a small sample can often be enough to
  /// choose an optimal splitting attribute. This idea is supported mathematically by
  /// the Hoeffding bound, which quantifies the number of observations (in our
  /// case, examples) needed to estimate some statistics within a prescribed
  /// precision (in our case, the goodness of an attribute).<br/><br/>A theoretically
  /// appealing feature of Hoeffding Trees not shared by otherincremental
  /// decision tree learners is that it has sound guarantees of performance. Using the
  /// Hoeffding bound one can show that its output is asymptotically nearly
  /// identical to that of a non-incremental learner using infinitely many examples.
  /// For more information see: <br/><br/>Geoff Hulten, Laurie Spencer, Pedro
  /// Domingos: Mining time-changing data streams. In: ACM SIGKDD Intl. Conf. on
  /// Knowledge Discovery and Data Mining, 97-106, 2001.<br/><br/>Options:<br/><br/>-L
  /// = 	The leaf prediction strategy to use. 0 = majority class, 1 = naive
  /// Bayes, 2 = naive Bayes adaptive.<br/>	(default = 2)<br/>-S = 	The splitting
  /// criterion to use. 0 = Gini, 1 = Info gain<br/>	(default = 1)<br/>-E = 	The
  /// allowable error in a split decision - values closer to zero will take longer
  /// to decide<br/>	(default = 1e-7)<br/>-H = 	Threshold below which a split will
  /// be forced to break ties<br/>	(default = 0.05)<br/>-M = 	Minimum fraction
  /// of weight required down at least two branches for info gain
  /// splitting<br/>	(default = 0.01)<br/>-G = 	Grace period - the number of instances a leaf
  /// should observe between split attempts<br/>	(default = 200)<br/>-N = 	The
  /// number of instances (weight) a leaf should observe before allowing naive Bayes
  /// to make predictions (NB or NB adaptive only)<br/>	(default = 0)<br/>-P =
  /// 	Print leaf models when using naive Bayes at the leaves.
  /// </summary>
  public class HoeffdingTree : BaseClassifier<weka.classifiers.trees.HoeffdingTree>
  {
    public HoeffdingTree(Runtime rt) : base(rt, new weka.classifiers.trees.HoeffdingTree()) {
      
    }

    /// <summary>
    /// The allowable error in a split decision. Values closer to zero will take
    /// longer to decide.
    /// </summary>    
    public HoeffdingTree SplitConfidence (double sc) {
      Impl.setSplitConfidence(sc);
      return this;
    }

    /// <summary>
    /// Theshold below which a split will be forced to break ties.
    /// </summary>    
    public HoeffdingTree HoeffdingTieThreshold (double ht) {
      Impl.setHoeffdingTieThreshold(ht);
      return this;
    }

    /// <summary>
    /// Minimum fraction of weight required down at least two branches for info
    /// gain splitting.
    /// </summary>    
    public HoeffdingTree MinimumFractionOfWeightInfoGain (double m) {
      Impl.setMinimumFractionOfWeightInfoGain(m);
      return this;
    }

    /// <summary>
    /// Number of instances (or total weight of instances) a leaf should observe
    /// between split attempts.
    /// </summary>    
    public HoeffdingTree GracePeriod (double grace) {
      Impl.setGracePeriod(grace);
      return this;
    }

    /// <summary>
    /// The number of instances (weight) a leaf should observe before allowing
    /// naive Bayes (adaptive) to make predictions
    /// </summary>    
    public HoeffdingTree NaiveBayesPredictionThreshold (double n) {
      Impl.setNaiveBayesPredictionThreshold(n);
      return this;
    }

    /// <summary>
    /// Print leaf models (naive bayes leaves only)
    /// </summary>    
    public HoeffdingTree PrintLeafModels (bool p) {
      Impl.setPrintLeafModels(p);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public HoeffdingTree Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}