using System.Collections.Generic;
using System.Linq;
using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
namespace Ml2.Clss
{
  /// <summary>
  /// Dimensionality of training and test data is reduced by attribute
  /// selection before being passed on to a classifier.<br/><br/>Options:<br/><br/>-E
  /// &lt;attribute evaluator specification&gt; = 	Full class name of attribute
  /// evaluator, followed<br/>	by its options.<br/>	eg:
  /// "weka.attributeSelection.CfsSubsetEval -L"<br/>	(default weka.attributeSelection.CfsSubsetEval)<br/>-S
  /// &lt;search method specification&gt; = 	Full class name of search method,
  /// followed<br/>	by its options.<br/>	eg: "weka.attributeSelection.BestFirst -D
  /// 1"<br/>	(default weka.attributeSelection.BestFirst)<br/>-D = 	If set,
  /// classifier is run in debug mode and<br/>	may output additional info to the
  /// console<br/>-W = 	Full name of base classifier.<br/>	(default:
  /// weka.classifiers.trees.J48)<br/><br/>Options specific to classifier
  /// weka.classifiers.trees.J48: = <br/>-U = 	Use unpruned tree.<br/>-O = 	Do not collapse tree.<br/>-C
  /// &lt;pruning confidence&gt; = 	Set confidence threshold for
  /// pruning.<br/>	(default 0.25)<br/>-M &lt;minimum number of instances&gt; = 	Set minimum
  /// number of instances per leaf.<br/>	(default 2)<br/>-R = 	Use reduced error
  /// pruning.<br/>-N &lt;number of folds&gt; = 	Set number of folds for reduced
  /// error<br/>	pruning. One fold is used as pruning set.<br/>	(default 3)<br/>-B =
  /// 	Use binary splits only.<br/>-S = 	Don't perform subtree raising.<br/>-L =
  /// 	Do not clean up after the tree has been built.<br/>-A = 	Laplace smoothing
  /// for predicted probabilities.<br/>-J = 	Do not use MDL correction for info
  /// gain on numeric attributes.<br/>-Q &lt;seed&gt; = 	Seed for random data
  /// shuffling (default 1).
  /// </summary>
  public class AttributeSelectedClassifier : BaseClassifier<weka.classifiers.meta.AttributeSelectedClassifier>
  {
    public AttributeSelectedClassifier(Runtime rt) : base(rt, new weka.classifiers.meta.AttributeSelectedClassifier()) {
      
    }

    /// <summary>
    /// Set the attribute evaluator to use. This evaluator is used during the
    /// attribute selection phase before the classifier is invoked.
    /// </summary>    
    public AttributeSelectedClassifier Evaluator (AttrSel.Evals.BaseAttributeSelectionEvaluator<weka.attributeSelection.ASEvaluation> evaluator) {
      Impl.setEvaluator(evaluator.Impl);
      return this;
    }

    /// <summary>
    /// Set the search method. This search method is used during the attribute
    /// selection phase before the classifier is invoked.
    /// </summary>    
    public AttributeSelectedClassifier Search (AttrSel.Algs.BaseAttributeSelectionAlgorithm<weka.attributeSelection.ASSearch> search) {
      Impl.setSearch(search.Impl);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public AttributeSelectedClassifier Classifier (Ml2.Clss.IBaseClassifier<weka.classifiers.Classifier>newClassifier) {
      Impl.setClassifier(newClassifier.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public AttributeSelectedClassifier Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}