using System.Collections.Generic;
using System.Linq;
using weka.classifiers.misc;

// ReSharper disable once CheckNamespace
namespace PicNetML.Clss
{
  /// <summary>
  /// Wrapper classifier that addresses incompatible training and test data by
  /// building a mapping between the training data that a classifier has been
  /// built with and the incoming test instances' structure. Model attributes that
  /// are not found in the incoming instances receive missing values, so do
  /// incoming nominal attribute values that the classifier has not seen before. A new
  /// classifier can be trained or an existing one loaded from a
  /// file.<br/><br/>Options:<br/><br/>-I = 	Ignore case when matching attribute names and
  /// nominal values.<br/>-M = 	Suppress the output of the mapping report.<br/>-trim =
  /// 	Trim white space from either end of names before matching.<br/>-L &lt;path
  /// to model to load&gt; = 	Path to a model to load. If set, this
  /// model<br/>	will be used for prediction and any base classifier<br/>	specification will
  /// be ignored. Environment variables<br/>	may be used in the path (e.g.
  /// ${HOME}/myModel.model)<br/>-D = 	If set, classifier is run in debug mode
  /// and<br/>	may output additional info to the console<br/>-W = 	Full name of base
  /// classifier.<br/>	(default: weka.classifiers.rules.ZeroR)<br/><br/>Options
  /// specific to classifier weka.classifiers.rules.ZeroR: = <br/>-D = 	If set,
  /// classifier is run in debug mode and<br/>	may output additional info to the
  /// console
  /// </summary>
  public class InputMappedClassifier : BaseClassifier<weka.classifiers.misc.InputMappedClassifier>
  {
    public InputMappedClassifier(Runtime rt) : base(rt, new weka.classifiers.misc.InputMappedClassifier()) {
      
    }

    /// <summary>
    /// Ignore case when matching attribute names and nomina values.
    /// </summary>    
    public InputMappedClassifier IgnoreCaseForNames (bool ignore) {
      Impl.setIgnoreCaseForNames(ignore);
      return this;
    }

    /// <summary>
    /// Don't output a report of model-to-input mappings.
    /// </summary>    
    public InputMappedClassifier SuppressMappingReport (bool suppress) {
      Impl.setSuppressMappingReport(suppress);
      return this;
    }

    /// <summary>
    /// Trim white space from each end of attribute names and nominal values
    /// before matching.
    /// </summary>    
    public InputMappedClassifier Trim (bool trim) {
      Impl.setTrim(trim);
      return this;
    }

    /// <summary>
    /// Set the path from which to load a model. Loading occurs when the first
    /// test instance is received. Environment variables can be used in the supplied
    /// path.
    /// </summary>    
    public InputMappedClassifier ModelPath (string modelPath) {
      Impl.setModelPath(modelPath);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public InputMappedClassifier Environment (weka.core.Environment env) {
      Impl.setEnvironment(env);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public InputMappedClassifier TestStructure (Runtime testStructure) {
      Impl.setTestStructure(testStructure.Impl);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public InputMappedClassifier ModelHeader (Runtime modelHeader) {
      Impl.setModelHeader(modelHeader.Impl);
      return this;
    }

    /// <summary>
    /// The base classifier to be used.
    /// </summary>    
    public InputMappedClassifier Classifier (PicNetML.Clss.IBaseClassifier<weka.classifiers.Classifier>newClassifier) {
      Impl.setClassifier(newClassifier.Impl);
      return this;
    }

    /// <summary>
    /// If set to true, classifier may output additional info to the console.
    /// </summary>    
    public InputMappedClassifier Debug (bool debug) {
      Impl.setDebug(debug);
      return this;
    }

        
        
  }
}