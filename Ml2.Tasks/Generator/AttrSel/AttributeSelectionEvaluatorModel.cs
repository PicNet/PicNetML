using System;

namespace Ml2.Tasks.Generator.AttrSel
{  
  public partial class AttributeSelectionEvaluator : IMl2CodeGenerator
  {
    public AttributeSelectionEvaluator(Type impl) {
      Model = new WekaTypeModel(impl, "Eval");
    }

    public WekaTypeModel Model { get; private set; }
  }
}