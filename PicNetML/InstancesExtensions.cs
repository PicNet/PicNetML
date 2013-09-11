using System.Collections.Generic;
using java.lang;
using weka.core;

namespace PicNetML
{
  public static class AttributeExtensions
  {     
    public static IEnumerable<string> ToEnumerable(this Attribute source)  {
      var num = source.numValues();
      for (int i = 0; i < num; i++) {
        yield return source.value(i);
      }
    }
  }

  public static class InstanceExtensions
  {    
    public static IEnumerable<string> ToStrings(this Instance source) 
    {
      var num = source.numAttributes();
      var arr = new string[num];      
      for (int i = 0; i < num; i++) {
        // Nominal, String, Date
        try { arr[i] = source.stringValue(i); }
        // Numerics
        catch (IllegalArgumentException) { arr[i] = source.value(i).ToString(); }
      }
      return arr;
    }

    public static IEnumerable<PmlAttribute> ToEnumerableAttributes(this Instance source)  {
      var num = source.numAttributes();
      for (int i = 0; i < num; i++) {
        yield return new PmlAttribute(source.attribute(i));
      }
    }
  }

  public static class InstancesExtensions
  {
    public static IEnumerable<string> GetAttrStrings(this Instances source, int attidx) 
    {
      var num = source.numInstances();
      var arr = new string[num];      
      for (int i = 0; i < num; i++) {
        arr[i] = source.instance(i).stringValue(attidx);
      }
      return arr;
    }

    public static IEnumerable<double> GetAttrDoubles(this Instances source, int attidx) 
    {
      var num = source.numInstances();
      var arr = new double[num];      
      for (int i = 0; i < num; i++) {
        arr[i] = source.instance(i).value(attidx);
      }
      return arr;
    }

    public static IEnumerable<PmlAttribute> ToEnumerableAttributes(this Instances source)  {
      var num = source.numAttributes();
      for (int i = 0; i < num; i++) {
        yield return new PmlAttribute(source.attribute(i));
      }
    }


    public static IEnumerable<PmlInstance> ToEnumerable(this Instances source)  {
      var num = source.numInstances();
      for (int i = 0; i < num; i++) {
        yield return new PmlInstance(source.instance(i));
      }
    }
  }
}