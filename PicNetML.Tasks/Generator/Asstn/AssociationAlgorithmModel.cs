using System;

namespace PicNetML.Tasks.Generator.Asstn
{  
  public partial class AssociationAlgorithm : IPmlCodeGenerator
  {
    public AssociationAlgorithm(Type impl) {
      Model = new WekaTypeModel(impl);
    }

    public WekaTypeModel Model { get; private set; }
  }
}