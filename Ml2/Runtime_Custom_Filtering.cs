using System;
using System.Linq;
using Ml2.RuntimeHelpers;
using weka.core;

namespace Ml2
{
  public partial class Runtime
  {    
    public Runtime KeepAttributes(params object[] attributes) {
      var exp = attributes.Length;
      if (!attributes.Contains(ClassAttribute.Name)) exp++;
      new AttributesRemover(this).KeepAttributes(attributes);
      var actual = NumAttributes;
      if (exp != actual) { throw new ApplicationException("Attributes not removed, expected: " + exp + " actual: " + actual); }
      return this;
    }

    public Runtime RemoveAttributes(params object[] attributes) {
      var exp = NumAttributes - attributes.Length;
      new AttributesRemover(this).RemoveAttributes(attributes);
      var actual = NumAttributes;
      if (exp != actual) { throw new ApplicationException("Attributes not removed, expected: " + exp + " actual: " + actual); }
      return this;            
    }

    public Runtime[] Partition(params int[] points) {
      if (points == null || points.Length == 0) throw new ArgumentNullException("points");

      var ends = points.Concat(new [] {NumInstances}).ToArray();
      var atts = EnumerateAttributes.Select(a => a.Impl).ToArrayList();
      var start = 0;
      var cumm = 0;
      var partitioned = ends.
          Select(end => {
            var name = String.Format("partition-{0}-{1}", start, end);
            var instance = new Instances(name, atts, end - start);        
            instance.setClassIndex(ClassIndex);
            for (int i = start; i < end; i++) { cumm++; instance.add(Instance(i).Impl); }
            start = end;
            return new Runtime(instance);
          }).
          ToArray();
      if (cumm != NumInstances) throw new ApplicationException("Partition did not work as expected.  Expected " + NumInstances + " instances to be copied, actually got: " + cumm);
      return partitioned;
    }

    public Runtime AddNominalAttribute(string name, string[] values) {
      if (values.Length != NumInstances) throw new ArgumentException("Values should be " + NumInstances + " in length.");

      var labels = values.Distinct().ToArray();
      var att = new weka.core.Attribute(name, labels.ToArrayList());
      
      var attidx = NumAttributes;
      InsertAttributeAt(new Ml2Attribute(att), attidx);
      for (int j = 0; j < values.Length; j++) { this[j].SetValue(attidx, values[j]); }

      return this;
    }

    public Runtime AddNumericAttribute(string name, double[] values) {
      if (values.Length != NumInstances) throw new ArgumentException("Values should be " + NumInstances + " in length.");

      var att = new weka.core.Attribute(name);
      
      var attidx = NumAttributes;
      InsertAttributeAt(new Ml2Attribute(att), attidx);
      for (int j = 0; j < values.Length; j++) { this[j].SetValue(attidx, values[j]); }

      return this;
    }
  }
}