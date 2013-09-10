using weka.classifiers;

namespace PicNetML.Clss {
  public class DeserialisedClassifier : UntypedBaseClassifier<Classifier> {
    public DeserialisedClassifier(Classifier impl) : base(impl) {
    }

    public override IUntypedBaseClassifier<Classifier> Build(bool quiet = false) { return this; }
  }
}