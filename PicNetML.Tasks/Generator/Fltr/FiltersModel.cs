using System;
using System.Linq;

namespace PicNetML.Tasks.Generator.Fltr
{
  public partial class Filters : ICodeGen
  {
    private readonly Type[] types;    
    public Filters(Type[] types) { this.types = types; } 

    public string TypeName {get;set; }

    public WekaTypeModel[] AllFilters { 
      get { 
        return types.Select(t => new FilterAlgorithm(t).Model).ToArray(); 
      } 
    }    
  }
}