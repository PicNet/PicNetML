using System.Collections.Generic;
using weka.core;

namespace Ml2
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
        arr[i] = source.stringValue(i);
      }
      return arr;
    }

    public static IEnumerable<Ml2Attribute> ToEnumerableAttributes(this Instance source)  {
      var num = source.numAttributes();
      for (int i = 0; i < num; i++) {
        yield return new Ml2Attribute(source.attribute(i));
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

    public static IEnumerable<Ml2Attribute> ToEnumerableAttributes(this Instances source)  {
      var num = source.numAttributes();
      for (int i = 0; i < num; i++) {
        yield return new Ml2Attribute(source.attribute(i));
      }
    }


    public static IEnumerable<Ml2Instance> ToEnumerable(this Instances source)  {
      var num = source.numInstances();
      for (int i = 0; i < num; i++) {
        yield return new Ml2Instance(source.instance(i));
      }
    }
  }
}