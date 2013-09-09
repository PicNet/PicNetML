using System;
using System.Linq;

namespace Ml2.Tasks.Generator.Clss
{
  public partial class Classifiers : ICodeGen
  {
    private readonly Type[] types;
    public Classifiers(Type[] types) { this.types = types; }

    public string TypeName { get; set; }

    public WekaTypeModel[] AllClassifiers { 
      get { 
        return types.Select(t => new ClassifierAlgorithm(t).Model).ToArray(); 
      } 
    }
  }
}