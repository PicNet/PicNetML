using System;

namespace Ml2.Tasks.Generator.Clss
{  
  public partial class ClassifierAlgorithm : IMl2CodeGenerator
  {
    public ClassifierAlgorithm(Type impl) {
      Model = new WekaTypeModel(impl);
    }

    public WekaTypeModel Model { get; private set; }
  }
}