using System.Collections;
using System.Collections.Generic;
using weka.core;


// ReSharper disable once CheckNamespace
namespace PicNetML
{
  public partial class PmlInstance  : IEnumerable<PmlAttribute>
  {
  
    /// <summary>
    /// This is used to create a new Runtime with a specified set of Instances.
    /// </summary>
    public PmlInstance(Instance impl) { Impl = impl; }

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
    public PmlAttribute Attribute(int i) { return new PmlAttribute(Impl.attribute(i)); }
    public double ClassValue { get { return Impl.classValue(); } }
    public bool ClassIsMissing { get { return Impl.classIsMissing(); } }
    public Runtime Dataset { get { return new Runtime(Impl.dataset()); } }
    public int ClassIndex { get { return Impl.classIndex(); } }
    public PmlAttribute AttributeSparse(int i) { return new PmlAttribute(Impl.attributeSparse(i)); }
    public PmlAttribute ClassAttribute { get { return new PmlAttribute(Impl.classAttribute()); } }
    public int NumClasses { get { return Impl.numClasses(); } }
    public void SetDataset(Runtime i) { Impl.setDataset(i.Impl); }
    public void SetClassMissing() { Impl.setClassMissing(); }
    public bool IsMissing(PmlAttribute a) { return Impl.isMissing(a.Impl); }
    public double Value(PmlAttribute a) { return Impl.value(a.Impl); }
    public IEnumerable<PmlAttribute> EnumerateAttributes { get { return Impl.ToEnumerableAttributes(); } }
    public string StringValue(int i) { return Impl.stringValue(i); }
    public void SetValue(int i, double d) { Impl.setValue(i, d); }
    public string ToString(int i) { return Impl.toString(i); }
    public void SetClassValue(double d) { Impl.setClassValue(d); }
    public void DeleteAttributeAt(int i) { Impl.deleteAttributeAt(i); }
    public bool EqualHeaders(PmlInstance i) { return Impl.equalHeaders(i.Impl); }
    public string EqualHeadersMsg(PmlInstance i) { return Impl.equalHeadersMsg(i.Impl); }
    public bool HasMissingValue { get { return Impl.hasMissingValue(); } }
    public void InsertAttributeAt(int i) { Impl.insertAttributeAt(i); }
    public void ReplaceMissingValues(double[] darr) { Impl.replaceMissingValues(darr); }
    public void SetClassValue(string str) { Impl.setClassValue(str); }
    public void SetMissing(PmlAttribute a) { Impl.setMissing(a.Impl); }
    public void SetValueSparse(int i, double d) { Impl.setValueSparse(i, d); }
    public void SetValue(int i, string str) { Impl.setValue(i, str); }
    public void SetValue(PmlAttribute a, double d) { Impl.setValue(a.Impl, d); }
    public void SetValue(PmlAttribute a, string str) { Impl.setValue(a.Impl, str); }
    public Runtime RelationalValue(int i) { return new Runtime(Impl.relationalValue(i)); }
    public Runtime RelationalValue(PmlAttribute a) { return new Runtime(Impl.relationalValue(a.Impl)); }
    public string StringValue(PmlAttribute a) { return Impl.stringValue(a.Impl); }
    public double[] ToDoubleArray { get { return Impl.toDoubleArray(); } }
    public string ToStringNoWeight(int i) { return Impl.toStringNoWeight(i); }
    public string ToStringNoWeight() { return Impl.toStringNoWeight(); }
    public string ToStringMaxDecimalDigits(int i) { return Impl.toStringMaxDecimalDigits(i); }
    public string ToString(int i1, int i2) { return Impl.toString(i1, i2); }
    public string ToString(PmlAttribute a, int i) { return Impl.toString(a.Impl, i); }
    public string ToString(PmlAttribute a) { return Impl.toString(a.Impl); }
    

    public IEnumerator<PmlAttribute> GetEnumerator() { return EnumerateAttributes.GetEnumerator(); }
    IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }    
  }
}
