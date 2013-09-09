using System;

namespace Ml2.Tasks.Generator.Asstn
{  
  public partial class AssociationAlgorithm : IMl2CodeGenerator
  {
    public AssociationAlgorithm(Type impl) {
      Model = new WekaTypeModel(impl);
    }

    public WekaTypeModel Model { get; private set; }
  }
}