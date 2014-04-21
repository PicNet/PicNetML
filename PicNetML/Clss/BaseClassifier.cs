using System;
using PicNetML.RuntimeHelpers;
using weka.classifiers;

namespace PicNetML.Clss {
  public class BaseClassifier<I> : UntypedBaseClassifier<I>, IBaseClassifier<I> where I : Classifier {
    
    public BaseClassifier(Runtime rt, I impl) : base(impl) {
      if (rt == null) throw new ArgumentNullException("rt");
      Runtime = rt;
    }

    public double ClassifyRow<T>(T o) where T : new() {
      return ClassifyInstance(Runtime.BuildInstance(o));
    }

    public double ClassifyRowProba<T>(T o) where T : new() {
      return ClassifyInstanceProba(Runtime.BuildInstance(o));
    }

    public IBaseClassifier<I> FlushToFile(string file, bool quiet = false) {
      Build();
      BaseClassifier.FlushToFile(Impl, file, quiet);      
      return this;
    }    

    public override IUntypedBaseClassifier<I> Build(bool quiet = false)
    {
      if (Built) return this;
      Built = true;
      var start = DateTime.Now;
      Impl.buildClassifier(Runtime.Impl);
      var took = DateTime.Now.Subtract(start);
      
      if (!quiet) Console.WriteLine("Building Classifier Took {0}ms", took);
      
      return this;
    }

    public PmlEvaluation EvaluateWithCrossValidation(int numfolds = 10, bool quiet = false)
    {
      Build(quiet);
      return new ClassifierEvaluator(Runtime, (IBaseClassifier<Classifier>) this).
        EvaluateWithCrossValidateion(numfolds, quiet);
    }
  }
}