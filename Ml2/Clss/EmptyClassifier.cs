using weka.classifiers;

namespace Ml2.Clss {
  public class EmptyClassifier : BaseClassifier<Classifier> {
    public EmptyClassifier(Classifier impl) : base(null, impl) {
      Built = true;
    }    
  }
}