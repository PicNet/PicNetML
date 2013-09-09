using System;
using System.Linq;

namespace Ml2.Tasks.Generator.Asstn
{
  public partial class Associations : ICodeGen
  {
    private readonly Type[] types;
    public Associations(Type[] types) { this.types = types; }

    public WekaTypeModel[] AllAssociations { 
      get { 
        return types.Select(t => new AssociationAlgorithm(t).Model).ToArray(); 
      } 
    }
  }
}