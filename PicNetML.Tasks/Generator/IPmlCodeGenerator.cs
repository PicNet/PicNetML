namespace PicNetML.Tasks.Generator
{
  internal interface IPmlCodeGenerator : ICodeGen
  {
    WekaTypeModel Model { get; }
  }
}