using System.Collections.Generic;
using System.Linq;
using weka.classifiers.bayes;

// ReSharper disable once CheckNamespace
namespace PicNetML.Clss
{
  /// <summary>
  /// Class for a Naive Bayes classifier using estimator classes. Numeric
  /// estimator precision values are chosen based on analysis of the training data.
  /// For this reason, the classifier is not an UpdateableClassifier (which in
  /// typical usage are initialized with zero training instances) -- if you need the
  /// UpdateableClassifier functionality, use the NaiveBayesUpdateable
  /// classifier. The NaiveBayesUpdateable classifier will use a default precision of 0.1
  /// for numeric attributes when buildClassifier is called with zero training
  /// instances.<br/><br/>For more information on Naive Bayes classifiers,
  /// see<br/><br/>George H. John, Pat Langley: Estimating Continuous Distributions in
  /// Bayesian Classifiers. In: Eleventh Conference on Uncertainty in Artificial
  /// Intelligence, San Mateo, 338-345, 1995.<br/><br/>Options:<br/><br/>-K = 	Use
  /// kernel density estimator rather than normal<br/>	distribution for numeric
  /// attributes<br/>-D = 	Use supervised discretization to process numeric
  /// attributes<br/><br/>-O = 	Display model in old format (good when there are many
  /// classes)<br/>
  /// </summary>
  public class NaiveBayes : BaseClassifier<weka.classifiers.bayes.NaiveBayes>
  {
    public NaiveBayes(Runtime rt) : base(rt, new weka.classifiers.bayes.NaiveBayes()) {
      
    }

    /// <summary>
    /// Use supervised discretization to convert numeric attributes to nominal
    /// ones.
    /// </summary>    
    public NaiveBayes UseSupervisedDiscretization (bool newblah) {
      Impl.setUseSupervisedDiscretization(newblah);
      return this;
    }

    /// <summary>
    /// Use a kernel estimator for numeric attributes rather than a normal
    /// distribution.
    /// </summary>    
    public NaiveBayes UseKernelEstimator (bool v) {
      Impl.setUseKernelEstimator(v);
      return this;
    }

    /// <summary>
    /// Use old format for model output. The old format is better when there are
    /// many class values. The new format is better when there are fewer classes
    /// and many attributes.
    /// </summary>    
    public NaiveBayes DisplayModelInOldFormat (bool d) {
      Impl.setDisplayModelInOldFormat(d);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public NaiveBayes Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}