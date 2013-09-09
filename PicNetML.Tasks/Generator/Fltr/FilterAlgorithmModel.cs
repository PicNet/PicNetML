using System;

namespace PicNetML.Tasks.Generator.Fltr
{  
  public partial class FilterAlgorithm : IPmlCodeGenerator
  {
    public FilterAlgorithm(Type impl) { Model = new WekaTypeModel(impl); }

    public WekaTypeModel Model { get; private set; }
  }
}