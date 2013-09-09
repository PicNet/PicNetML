using System;
using System.Collections.Generic;
using System.Linq;
using weka.core;

namespace PicNetML.Arff.Builder
{
  internal class InstancesBuilder<T> : IInstancesBuilder<T> where T : new()
  {
    private readonly T[] data;
    private readonly int classindex;        
    private readonly int trainingsize;
    private readonly string[] properties;
    private readonly string[] tohasclass;    
    private readonly string[] tobinarize;
    private readonly Dictionary<string, double> expected_has_classes;
    private readonly Type type;
    private readonly AttributesBuilder<T> attsbuilder;

    private List<PmlAttribute> attributes;
    private IDictionary<string, int> attributes_indexes_cache;
    private double[] resuable_rowvals = null;
    private IDictionary<string, Dictionary<object, bool>> cached_has_class;    

    public InstancesBuilder(IEnumerable<T> data, int classindex, int trainingsize = 0) {
      this.data = data.ToArray(); 
      if (this.data.Any(row => row is string)) 
        throw new ArgumentException("data are strings, perhaps you intended to call Runtime.LoadFromFiles<>");
      this.classindex = classindex;
      this.trainingsize = trainingsize;

      T template = this.data[0];
      type = typeof(T) == typeof(object) ? template.GetType() : typeof(T);      
      attsbuilder = new AttributesBuilder<T>(this.data);
      
      var pis = template is IExtendableObj<object> ? 
          Helpers.GetProps(((IExtendableObj<object>)template).BaseObject.GetType()) : 
          Helpers.GetProps(type);
      properties = pis.
          Where(pi => !InternalHelpers.IsAtt<IgnoreFeatureAttribute>(pi)).
          Select(pi => pi.Name).
          ToArray();
      var tohasclasspis = pis.Where(InternalHelpers.IsAtt<AppendHasClassifierAttribute>).ToArray();
      tohasclass = tohasclasspis.Select(pi => pi.Name).ToArray();
      tobinarize = pis.Where(InternalHelpers.IsAtt<BinarizeAttribute>).Select(pi => pi.Name).ToArray();            
      expected_has_classes = tohasclasspis.ToDictionary(
          pi => pi.Name, 
          pi => InternalHelpers.ToAtt<AppendHasClassifierAttribute>(pi).Classifier);
    }

    public Instances Build()
    {                  
      attributes = attsbuilder.BuildAttributes();
      CacheAttributeIndexes(attributes);
      
      var attimpls = attributes.Select(a => a.Impl).ToArrayList();
      var instances = new Instances(type.Name, attimpls, data.Length);      
      instances.setClassIndex(classindex);      
      BuildInstances(instances);

      return instances;
    }

    private void CacheAttributeIndexes(List<PmlAttribute> atts) {
      attributes_indexes_cache = new Dictionary<string, int>();
      for (int i = 0; i < atts.Count; i++) { attributes_indexes_cache.Add(atts[i].Name, i); }
    }

    private void BuildInstances(Instances instances) {                 
      CacheHasClassValues();
      Array.ForEach(data, r => instances.add(CreateInstanceForRow(r).Impl));      
    }

    private void CacheHasClassValues() {
      cached_has_class = tohasclass.ToDictionary(n => n, pi => new Dictionary<object, bool>());
      var max = trainingsize > 0 ? trainingsize : data.Length;
      for (int i = 0; i < max; i++) {
        var row = data[i]; 
        foreach (var name in tohasclass) {
          if (expected_has_classes[name] == 
              Helpers.GetValue<double>(row, properties[classindex])) {
            var cache = cached_has_class[name];
            var val = Helpers.GetValue(row, name);
            if (!cache.ContainsKey(val)) cache[val] = true;
          }
        }
      }
    }

    private PmlInstance CreateInstanceForRow(T row)
    { 
      var extendable = row is ExtendableObjBase ? 
          (row as ExtendableObjBase).GetExtendedPropertiesValues() : new object [0];
      var indexes = Enumerable.
          Range(0, properties.Length + extendable.Count + tohasclass.Length).
          ToList();      

      if (resuable_rowvals == null) {        
        resuable_rowvals = new double[properties.Length + extendable.Count + tohasclass.Length + tobinarize.Length];      
      }
      
      for (int i = 0; i < properties.Length; i++) {
        resuable_rowvals[i] = GetValue(attributes[i], Helpers.GetValue(row, properties[i]));
      }

      for (int i = 0; i < extendable.Count; i++) {
        resuable_rowvals[properties.Length + i] = 
          GetValue(attributes[properties.Length + i], extendable.ElementAt(i));
      }        

      for (int i = 0; i < tohasclass.Length; i++) {
        var val = Helpers.GetValue(row, tohasclass[i]);                
        resuable_rowvals[properties.Length + extendable.Count + i] = cached_has_class[tohasclass[i]].ContainsKey(val) ? 1.0 : 0.0;
      }

      for (int i = 0; i < tobinarize.Length; i++) {        
        resuable_rowvals[properties.Length + extendable.Count + tohasclass.Length + i] = 1.0;        
        var name = tobinarize[i] + "_" + 
            InternalHelpers.ToStringSafe(Helpers.GetValue(row, tobinarize[i]));
        try { indexes.Add(attributes_indexes_cache[name]); } 
        catch (KeyNotFoundException) {
          Console.WriteLine("Could not find '" + name + "' in the attributes_indexes_cache.");
          throw;
        }
      }
      var impl = new SparseInstance(1.0, resuable_rowvals, indexes.ToArray(), attributes.Count);
      return new PmlInstance(impl);
    }

    private double GetValue(PmlAttribute att, object v)
    {
      if (v == null || (v is string && String.IsNullOrWhiteSpace((string)v))) return Utils.missingValue();

      if (att.IsDate) return att.ParseDate(v is DateTime ? ((DateTime)v).ToString(AttributesBuilder<object>.ISO_8601_DATE_FORMAT) : (string) v);
      if (att.IsNumeric) return (double) Convert.ChangeType(v, typeof(double));
      if (att.IsNominal) return att.IndexOfValue(v is bool ? ((bool) v ? "1" : "0") : v.ToString());
      if (att.IsString) return att.AddStringValue((string) v);      
      throw new NotSupportedException(att.Type + " is not a supported attribute atttype.");
    }
  }
}