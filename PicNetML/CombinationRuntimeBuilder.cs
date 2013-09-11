using System;
using System.Collections.Generic;
using System.Linq;
using PicNetML.Arff;

namespace PicNetML
{
  // TODO: Implement fully or remove.
  internal class CombinationRuntimeBuilder<T> where T : new()
  {
    private readonly int classidx;
    private readonly T[] data;
    private readonly string[][] props;
    private readonly int degrees;

    public CombinationRuntimeBuilder(int classidx, T[] data, int[] indexes, int degrees) {
      if (degrees != 3) throw new ArgumentException("Only 3 degrees currently supported.", "degrees");      
      this.classidx = classidx;
      this.data = data;      
      this.degrees = degrees;

      var startprops = Helpers.GetProps(typeof(T)).
        Where((p, i) => {
          if (indexes.Contains(i)) {
            if (!InternalHelpers.IsAtt<NominalAttribute>(p)) {
              throw new NotSupportedException("Only [Nominal] attributes (or descendant attributes) can be combined");
            }
            return true;
          }
          return false;
        }).
        Select(p => p.Name).
        ToArray();
      props = GetAdditionalProperties(startprops).ToArray();
      Console.WriteLine("Additional Properties to Add: " + props.Length);
    }

    public Runtime CreateRuntime() {             
      var extended = data.Select(r => {
        var ext = ExtendableObj.Create(r); 
        Array.ForEach(props, p => {
          var name  = String.Join("+", p);
          var val = String.Join("+", p.Select(pn => Helpers.GetValue<string>(r, pn)));
          ext.AddNominal(name, val);            
        });
        return ext;
      }).ToArray();
      Console.WriteLine("Created Extended array");
      return Runtime.LoadFromRows(classidx, extended);
    }

    private ICollection<string[]> GetAdditionalProperties(string[] startprops) {
      var additional = new List<string[]>();
      Array.ForEach(startprops, p1 => Array.ForEach(startprops, p2 => {
        additional.Add(new [] {p1, p2});
        Array.ForEach(startprops, p3 => additional.Add(new [] {p1, p2, p3}));
      }));
      return additional;
    }
  }
}