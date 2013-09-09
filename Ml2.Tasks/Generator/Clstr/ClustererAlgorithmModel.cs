using System;

namespace Ml2.Tasks.Generator.Clstr
{  
  public partial class ClustererAlgorithm : IMl2CodeGenerator
  {  
    public ClustererAlgorithm(Type impl) {
      Model = new WekaTypeModel(impl, "Clusterer");
    }

    public WekaTypeModel Model { get; private set; }
  }
}