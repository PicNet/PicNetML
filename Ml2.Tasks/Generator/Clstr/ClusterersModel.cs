using System;
using System.Linq;

namespace Ml2.Tasks.Generator.Clstr
{
  public partial class Clusterers : ICodeGen
  {
    private readonly Type[] types;
    public Clusterers(Type[] types) { this.types = types; } 

    public WekaTypeModel[] AllClusterers { 
      get { 
        return types.Select(t => new ClustererAlgorithm(t).Model).ToArray(); 
      } 
    }
  }
}