// ReSharper disable once CheckNamespace
namespace PicNetML.Clss
{
  public class ClassifiersMisc
  {
    private readonly Runtime rt;    
    public ClassifiersMisc(Runtime rt) { this.rt = rt; }   

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
    public InputMappedClassifier InputMappedClassifier { get {
      return new InputMappedClassifier(rt); 
    } }

    /// <summary>
    /// A wrapper around a serialized classifier model. This classifier loads a
    /// serialized models and uses it to make predictions.<br/><br/>Warning: since
    /// the serialized model doesn't get changed, cross-validation cannot bet used
    /// with this classifier.<br/><br/>Options:<br/><br/>-D = 	If set, classifier is
    /// run in debug mode and<br/>	may output additional info to the
    /// console<br/>-model &lt;filename&gt; = 	The file containing the serialized
    /// model.<br/>	(required)
    /// </summary>
    public SerializedClassifier SerializedClassifier { get {
      return new SerializedClassifier(rt); 
    } }

    
  }
}