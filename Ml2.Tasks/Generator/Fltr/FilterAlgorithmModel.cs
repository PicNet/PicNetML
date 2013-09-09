using System;

namespace Ml2.Tasks.Generator.Fltr
{  
  public partial class FilterAlgorithm : IMl2CodeGenerator
  {
    public FilterAlgorithm(Type impl) { Model = new WekaTypeModel(impl); }

    public WekaTypeModel Model { get; private set; }
  }
}