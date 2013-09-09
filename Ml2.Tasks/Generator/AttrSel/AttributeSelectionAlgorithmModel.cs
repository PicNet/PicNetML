using System;

namespace Ml2.Tasks.Generator.AttrSel
{
  public partial class AttributeSelectionAlgorithm : IMl2CodeGenerator
  {    
    public AttributeSelectionAlgorithm(Type impl) {
      Model = new WekaTypeModel(impl);
    }

    public WekaTypeModel Model { get; private set; }
  }
}