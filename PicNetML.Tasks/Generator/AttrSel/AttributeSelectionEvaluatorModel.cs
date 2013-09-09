using System;

namespace PicNetML.Tasks.Generator.AttrSel
{  
  public partial class AttributeSelectionEvaluator : IPmlCodeGenerator
  {
    public AttributeSelectionEvaluator(Type impl) {
      Model = new WekaTypeModel(impl, "Eval");
    }

    public WekaTypeModel Model { get; private set; }
  }
}