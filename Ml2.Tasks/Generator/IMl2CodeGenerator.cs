namespace Ml2.Tasks.Generator
{
  internal interface IMl2CodeGenerator : ICodeGen
  {
    WekaTypeModel Model { get; }
  }
}