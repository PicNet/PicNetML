using System;
using System.Linq;

namespace PicNetML.Tasks.Generator.AttrSel
{
  public partial class Algorithms : ICodeGen
  {
    private readonly Type[] types;
    public Algorithms(Type[] types) { this.types = types; }

    public WekaTypeModel[] AllAgorithms
    {
      get { return types.Select(t => new AttributeSelectionAlgorithm(t).Model).ToArray(); }
    }
  }
}