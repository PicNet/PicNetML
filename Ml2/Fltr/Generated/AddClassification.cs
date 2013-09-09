using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// A filter for adding the classification, the class distribution and an
  /// error flag to a dataset with a classifier. The classifier is either trained on
  /// the data itself or provided as serialized
  /// model.<br/><br/>Options:<br/><br/>-D = 	Turns on output of debugging information.<br/>-W &lt;classifier
  /// specification&gt; = 	Full class name of classifier to use, followed<br/>	by
  /// scheme options. eg:<br/>		"weka.classifiers.bayes.NaiveBayes
  /// -D"<br/>	(default: weka.classifiers.rules.ZeroR)<br/>-serialized &lt;file&gt; = 	Instead of
  /// training a classifier on the data, one can also provide<br/>	a serialized
  /// model and use that for tagging the data.<br/>-classification = 	Adds an
  /// attribute with the actual classification.<br/>	(default:
  /// off)<br/>-remove-old-class = 	Removes the old class attribute.<br/>	(default:
  /// off)<br/>-distribution = 	Adds attributes with the distribution for all classes <br/>	(for
  /// numeric classes this will be identical to the attribute <br/>	output with
  /// '-classification').<br/>	(default: off)<br/>-error = 	Adds an attribute
  /// indicating whether the classifier output <br/>	a wrong classification (for
  /// numeric classes this is the numeric <br/>	difference).<br/>	(default: off)
  /// </summary>
  public class AddClassification : BaseFilter<weka.filters.supervised.attribute.AddClassification>
  {
    public AddClassification(Runtime rt) : base(rt, new weka.filters.supervised.attribute.AddClassification()) {
      
    }

    /// <summary>
    /// Whether to add an attribute with the actual classification.
    /// </summary>    
    public AddClassification OutputClassification (bool value) {
      Impl.setOutputClassification(value);
      return this;
    }

    /// <summary>
    /// Whether to remove the old class attribute.
    /// </summary>    
    public AddClassification RemoveOldClass (bool value) {
      Impl.setRemoveOldClass(value);
      return this;
    }

    /// <summary>
    /// Whether to add attributes with the distribution for all classes (for
    /// numeric classes this will be identical to the attribute output with
    /// 'outputClassification').
    /// </summary>    
    public AddClassification OutputDistribution (bool value) {
      Impl.setOutputDistribution(value);
      return this;
    }

    /// <summary>
    /// Whether to add an attribute indicating whether the classifier output a
    /// wrong classification (for numeric classes this is the numeric difference).
    /// </summary>    
    public AddClassification OutputErrorFlag (bool value) {
      Impl.setOutputErrorFlag(value);
      return this;
    }

    /// <summary>
    /// The classifier to use for classification.
    /// </summary>    
    public AddClassification Classifier (Ml2.Clss.IBaseClassifier<weka.classifiers.Classifier>value) {
      Impl.setClassifier(value.Impl);
      return this;
    }

    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public AddClassification Debug (bool value) {
      Impl.setDebug(value);
      return this;
    }

        
        
  }
}