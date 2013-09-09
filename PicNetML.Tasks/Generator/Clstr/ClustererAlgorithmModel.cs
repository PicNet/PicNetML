using System;

namespace PicNetML.Tasks.Generator.Clstr
{  
  public partial class ClustererAlgorithm : IPmlCodeGenerator
  {  
    public ClustererAlgorithm(Type impl) {
      Model = new WekaTypeModel(impl, "Clusterer");
    }

    public WekaTypeModel Model { get; private set; }
  }
}