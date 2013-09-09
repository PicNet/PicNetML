using weka.classifiers;

namespace Ml2.Clss
{
  /// <summary>
  /// Delegates classification to an instance of any weka Classifier.
  /// </summary>
  /// <typeparam name="T">The classifier to delegate classification to.</typeparam>
  public class DelegatingClassifier<T> : BaseClassifier<T> where T : Classifier
  {     
    public DelegatingClassifier(Runtime rt, T impl) : base(rt, impl) {}
  }
}