using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ArrayList = java.util.ArrayList;
using Attribute = weka.core.Attribute;

namespace PicNetML.Arff.Builder
{
  public class AttributesBuilder<T> where T : new()
  {
    internal const string ISO_8601_DATE_FORMAT = "yyyy-MM-dd'T'HH:mm:ss";    
    private readonly ArrayList binary = new ArrayList {"0", "1"};

    private readonly T[] data;
    private readonly T template;
    private readonly PropertyInfo[] properties;

    private List<Attribute> atts;
    private List<Attribute> binarizedatts;
    private List<Attribute> hasclassatts;    

    public AttributesBuilder(T[] data) { 
      this.data = data; 
      template = data[0];
      var type = typeof(T) == typeof(object) ? template.GetType() : typeof(T);
      properties = template is IExtendableObj<object> ? 
          Helpers.GetProps(((IExtendableObj<object>)template).BaseObject.GetType()) : 
          Helpers.GetProps(type);
    }

    public List<PmlAttribute> BuildAttributes()
    {      
      atts = new List<Attribute>();
      binarizedatts = new List<Attribute>();
      hasclassatts = new List<Attribute>();
      
      foreach (var prop in properties) {
        var name = prop.Name;        
        var atttypes = EvaluateAttributeTypes(prop);
        var patts = BuildAttributesOfTypes(atttypes, prop, name);
        if (!InternalHelpers.IsAtt<IgnoreFeatureAttribute>(prop)) { atts.AddRange(patts); }
      }
      
      if (template is ExtendableObjBase) {
        var ext = template as ExtendableObjBase;
        Array.ForEach(ext.Properties.ToArray(), p => 
          {
            if (p.Type == EAttributeType.Nominal) {
              var vals = data.
                  Select(r => (r as ExtendableObjBase).GetValue(p.Name)).
                  Distinct().
                  ToArrayList();
              atts.Add(new Attribute(p.Name, vals));
            } else {
              atts.AddRange(BuildAttributesOfTypes(new [] { p.Type }, null, p.Name));
            }
          });
      }

      return atts.
          Concat(hasclassatts).
          Concat(binarizedatts).
          Select(a => new PmlAttribute(a)).
          ToList();
    }

    private IEnumerable<Attribute> BuildAttributesOfTypes(IEnumerable<EAttributeType> atttypes, PropertyInfo prop, string name) {
      return atttypes.Select(t => BuildAttributeOfTypeImpl(t, prop, name)).ToArray();       
    }

    private Attribute BuildAttributeOfTypeImpl(EAttributeType atttype, PropertyInfo prop, string name) {
      Attribute att;
      if (atttype == EAttributeType.Nominal) {
        att = GetNominalAttribute(prop);
      } else if (atttype == EAttributeType.Numeric) {
        att = new Attribute(name);
      } else if (atttype == EAttributeType.Binary) {
        att = new Attribute(name, binary);
      } else if (atttype == EAttributeType.String) {
        att = new Attribute(name, (ArrayList) null);
      } else if (atttype == EAttributeType.Date) {
        att = new Attribute(name, ISO_8601_DATE_FORMAT); // ISO-8601 Format
      } else {
        throw new NotSupportedException(atttype + " is not a supported attribute atttype.");
      }
      return att;
    }

    private Attribute GetNominalAttribute(PropertyInfo prop) {
      var attributevals = GetAttributePossibleValues(prop);         
      var name = prop.Name;
      if (InternalHelpers.IsAtt<AppendHasClassifierAttribute>(prop)) hasclassatts.Add(new Attribute(name + "_hasclass", binary));
      if (InternalHelpers.IsAtt<BinarizeAttribute>(prop)) binarizedatts.AddRange(attributevals.Select(v => new Attribute(name + "_" + v, binary))); 
      return new Attribute(name, attributevals.ToArrayList());
    }

    private string[] GetAttributePossibleValues(PropertyInfo prop) {
      var type = ArffUtils.GetNonNullableType(prop.PropertyType);
      var att = InternalHelpers.ToAtt<NominalAttribute>(prop);
      if (att != null && !String.IsNullOrWhiteSpace(att.CommaSeparatedValues)) return att.CommaSeparatedValues.Split(',');
      if (type.IsEnum) return Enum.GetNames(type);
      
      var attvals = data.Select(row => InternalHelpers.ToStringSafe(Helpers.GetValue(row, prop.Name))).ToArray();
      return att is GroupedNominalAttribute ? 
          GetGroupedAttributePossibleValues(prop, att, attvals) :
          attvals.Distinct().ToArray();
    }

    private string[] GetGroupedAttributePossibleValues(PropertyInfo prop, NominalAttribute att, string[] attvals) {
      var togroup = GetAttributeValuesToGroup(att, attvals);

      Array.ForEach(data, row => {
        var val = InternalHelpers.ToStringSafe(Helpers.GetValue(row, prop.Name));
        var idx = Array.BinarySearch(togroup, val);
        while (idx >= 0) {
          Helpers.SetValue(row, prop.Name, "Others");
          idx = idx == togroup.Length ? -1 : Array.BinarySearch(togroup, idx + 1, togroup.Length - (idx + 1), val);
        }
      });
      return attvals.Concat(new[] { "Others" }).Distinct().Except(togroup).ToArray();
    }

    private static string[] GetAttributeValuesToGroup(NominalAttribute att, string[] atts) {
      if (att is NominalGroupWhenLessThanAttribute) {
        var min = ((NominalGroupWhenLessThanAttribute) att).Min;
        return atts.GroupBy(a => a).
            Where(g => g.Count() < min).
            Select(g => g.Key).
            OrderBy(a => a).
            ToArray();
      } 
      if (att is NominalGroupMaxBinsAttribute) {
        var max = ((NominalGroupMaxBinsAttribute) att).Max;
        return atts.GroupBy(a => a).
            OrderByDescending(g => g.Count()).
            Skip(max).
            Select(g => g.Key).
            OrderBy(a => a).ToArray();
      } 
      throw new NotSupportedException("Type: " + att.GetType().Name + " does not support grouping");
    }

    private static IEnumerable<EAttributeType> EvaluateAttributeTypes(PropertyInfo pi)
    {
      if(pi == null) throw new ArgumentNullException("pi");

      var t = ArffUtils.GetNonNullableType(pi.PropertyType);      

      if (t.IsEnum || InternalHelpers.IsAtt<NominalAttribute>(pi)) { return new [] { EAttributeType.Nominal }; }      
      if (t == typeof(string)) { return new [] { EAttributeType.String }; }
      if (t == typeof(DateTime)) { return new [] { EAttributeType.Date }; }
      if (t == typeof(bool)) { return new [] { EAttributeType.Binary }; }
      if (typeof(IEnumerable).IsAssignableFrom(t) && 
            InternalHelpers.IsAtt<FlattenAttribute>(pi)) {
        // TODO: Only numerics supported at the moment.  Should recurse into something
        // similar to this function to get the actual type of the attribute.
        return Enumerable.Range(0, InternalHelpers.ToAtt<FlattenAttribute>(pi).IntoHowMany).
          Select(i => EAttributeType.Numeric).
          ToArray();
      }
      var tc = Type.GetTypeCode(t);
      if (tc >= TypeCode.SByte && tc <= TypeCode.Decimal) { return new [] { EAttributeType.Numeric }; }
      throw new NotSupportedException(t.Name + " is not a supported attribute atttype.");
    }

  }
}