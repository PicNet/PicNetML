using weka.classifiers;

namespace PicNetML.Clss {
  public class EmptyClassifier : BaseClassifier<Classifier> {
    public EmptyClassifier(Classifier impl) : base(null, impl) {
      Built = true;
    }    
  }
}