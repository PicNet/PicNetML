using System;

namespace PicNetML.Tasks.Generator.AttrSel
{
  public partial class AttributeSelectionAlgorithm : IPmlCodeGenerator
  {    
    public AttributeSelectionAlgorithm(Type impl) {
      Model = new WekaTypeModel(impl);
    }

    public WekaTypeModel Model { get; private set; }
  }
}