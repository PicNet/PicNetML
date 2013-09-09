using System;
using System.Linq;

namespace Ml2.Tasks.Generator.AttrSel
{
  public partial class Evaluators : ICodeGen
  {
    private readonly Type[] types;
    public Evaluators(Type[] types) { this.types = types; }

    public WekaTypeModel[] AllEvaluators { 
      get { 
        return types.Select(t => new AttributeSelectionEvaluator(t).Model).ToArray(); } }
  }
}