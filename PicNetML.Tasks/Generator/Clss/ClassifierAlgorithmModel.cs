using System;

namespace PicNetML.Tasks.Generator.Clss
{  
  public partial class ClassifierAlgorithm : IPmlCodeGenerator
  {
    public ClassifierAlgorithm(Type impl) {
      Model = new WekaTypeModel(impl);
    }

    public WekaTypeModel Model { get; private set; }
  }
}