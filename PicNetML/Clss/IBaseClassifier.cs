using weka.classifiers;

namespace PicNetML.Clss {
  public interface IBaseClassifier<out I> : IUntypedBaseClassifier<I> where I : Classifier {
    double ClassifyRow<T>(T o) where T : new();
    double ClassifyRowProba<T>(T o) where T : new();

    PmlEvaluation EvaluateWithCrossValidation(int numfolds = 10, bool quiet = false);
    IUntypedBaseClassifier<I> Build(bool quiet = false);
    IBaseClassifier<I> FlushToFile(string file, bool quiet = false);
  }
}