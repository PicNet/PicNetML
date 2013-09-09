using System.Collections.Generic;
using System.Linq;
using weka.classifiers.meta;

// ReSharper disable once CheckNamespace
namespace PicNetML.Clss
{
  /// <summary>
  /// Class for running an arbitrary classifier on data that has been passed
  /// through an arbitrary filter. Like the classifier, the structure of the filter
  /// is based exclusively on the training data and test instances will be
  /// processed by the filter without changing their
  /// structure.<br/><br/>Options:<br/><br/>-F &lt;filter specification&gt; = 	Full class name of filter to use,
  /// followed<br/>	by filter options.<br/>	eg:
  /// "weka.filters.unsupervised.attribute.Remove -V -R 1,2"<br/>-D = 	If set, classifier is run in debug mode
  /// and<br/>	may output additional info to the console<br/>-W = 	Full name of base
  /// classifier.<br/>	(default: weka.classifiers.trees.J48)<br/><br/>Options
  /// specific to classifier weka.classifiers.trees.J48: = <br/>-U = 	Use unpruned
  /// tree.<br/>-O = 	Do not collapse tree.<br/>-C &lt;pruning confidence&gt; =
  /// 	Set confidence threshold for pruning.<br/>	(default 0.25)<br/>-M &lt;minimum
  /// number of instances&gt; = 	Set minimum number of instances per
  /// leaf.<br/>	(default 2)<br/>-R = 	Use reduced error pruning.<br/>-N &lt;number of
  /// folds&gt; = 	Set number of folds for reduced error<br/>	pruning. One fold is
  /// used as pruning set.<br/>	(default 3)<br/>-B = 	Use binary splits only.<br/>-S
  /// = 	Don't perform subtree raising.<br/>-L = 	Do not clean up after the tree
  /// has been built.<br/>-A = 	Laplace smoothing for predicted
  /// probabilities.<br/>-J = 	Do not use MDL correction for info gain on numeric
  /// attributes.<br/>-Q &lt;seed&gt; = 	Seed for random data shuffling (default 1).
  /// </summary>
  public class FilteredClassifier : BaseClassifier<weka.classifiers.meta.FilteredClassifier>
  {
    public FilteredClassifier(Runtime rt) : base(rt, new weka.classifiers.meta.FilteredClassifier()) {
      
    }

    /// <summary>
    /// The filter to be used.
    /// </summary>    
    public FilteredClassifier Filter (Fltr.IBaseFilter<weka.filters.Filter> filter) {
      Impl.setFilter(filter.Impl);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public FilteredClassifier Classifier (PicNetML.Clss.IBaseClassifier<weka.classifiers.Classifier>newClassifier) {
      Impl.setClassifier(newClassifier.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public FilteredClassifier Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}