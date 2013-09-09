using System.Collections;
using System.Collections.Generic;
using weka.core;


// ReSharper disable once CheckNamespace
namespace Ml2
{
  public partial class Ml2Instance  : IEnumerable<Ml2Attribute>
  {
  
    /// <summary>
    /// This is used to create a new Runtime with a specified set of Instances.
    /// </summary>
    public Ml2Instance(Instance impl) { Impl = impl; }

    public Instance Impl { get; private set; }

    public int NumValues { get { return Impl.numValues(); } }
    public int Index(int i) { return Impl.index(i); }
    public bool IsMissingSparse(int i) { return Impl.isMissingSparse(i); }
    public double ValueSparse(int i) { return Impl.valueSparse(i); }
    public int NumAttributes { get { return Impl.numAttributes(); } }
    public bool IsMissing(int i) { return Impl.isMissing(i); }
    public double Value(int i) { return Impl.value(i); }
    public double Weight { get { return Impl.weight(); } }
    public void SetMissing(int i) { Impl.setMissing(i); }
    public void SetWeight(double d) { Impl.setWeight(d); }
    public Ml2Attribute Attribute(int i) { return new Ml2Attribute(Impl.attribute(i)); }
    public double ClassValue { get { return Impl.classValue(); } }
    public bool ClassIsMissing { get { return Impl.classIsMissing(); } }
    public Runtime Dataset { get { return new Runtime(Impl.dataset()); } }
    public int ClassIndex { get { return Impl.classIndex(); } }
    public Ml2Attribute AttributeSparse(int i) { return new Ml2Attribute(Impl.attributeSparse(i)); }
    public Ml2Attribute ClassAttribute { get { return new Ml2Attribute(Impl.classAttribute()); } }
    public int NumClasses { get { return Impl.numClasses(); } }
    public void SetDataset(Runtime i) { Impl.setDataset(i.Impl); }
    public void SetClassMissing() { Impl.setClassMissing(); }
    public bool IsMissing(Ml2Attribute a) { return Impl.isMissing(a.Impl); }
    public double Value(Ml2Attribute a) { return Impl.value(a.Impl); }
    public IEnumerable<Ml2Attribute> EnumerateAttributes { get { return Impl.ToEnumerableAttributes(); } }
    public string StringValue(int i) { return Impl.stringValue(i); }
    public void SetValue(int i, double d) { Impl.setValue(i, d); }
    public string ToString(int i) { return Impl.toString(i); }
    public void SetClassValue(double d) { Impl.setClassValue(d); }
    public void DeleteAttributeAt(int i) { Impl.deleteAttributeAt(i); }
    public bool EqualHeaders(Ml2Instance i) { return Impl.equalHeaders(i.Impl); }
    public string EqualHeadersMsg(Ml2Instance i) { return Impl.equalHeadersMsg(i.Impl); }
    public bool HasMissingValue { get { return Impl.hasMissingValue(); } }
    public void InsertAttributeAt(int i) { Impl.insertAttributeAt(i); }
    public void ReplaceMissingValues(double[] darr) { Impl.replaceMissingValues(darr); }
    public void SetClassValue(string str) { Impl.setClassValue(str); }
    public void SetMissing(Ml2Attribute a) { Impl.setMissing(a.Impl); }
    public void SetValueSparse(int i, double d) { Impl.setValueSparse(i, d); }
    public void SetValue(int i, string str) { Impl.setValue(i, str); }
    public void SetValue(Ml2Attribute a, double d) { Impl.setValue(a.Impl, d); }
    public void SetValue(Ml2Attribute a, string str) { Impl.setValue(a.Impl, str); }
    public Runtime RelationalValue(int i) { return new Runtime(Impl.relationalValue(i)); }
    public Runtime RelationalValue(Ml2Attribute a) { return new Runtime(Impl.relationalValue(a.Impl)); }
    public string StringValue(Ml2Attribute a) { return Impl.stringValue(a.Impl); }
    public double[] ToDoubleArray { get { return Impl.toDoubleArray(); } }
    public string ToStringNoWeight(int i) { return Impl.toStringNoWeight(i); }
    public string ToStringNoWeight() { return Impl.toStringNoWeight(); }
    public string ToStringMaxDecimalDigits(int i) { return Impl.toStringMaxDecimalDigits(i); }
    public string ToString(int i1, int i2) { return Impl.toString(i1, i2); }
    public string ToString(Ml2Attribute a, int i) { return Impl.toString(a.Impl, i); }
    public string ToString(Ml2Attribute a) { return Impl.toString(a.Impl); }
    

    public IEnumerator<Ml2Attribute> GetEnumerator() { return EnumerateAttributes.GetEnumerator(); }
    IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }    
  }
}
