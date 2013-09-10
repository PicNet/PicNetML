using System.Collections;
using System.Collections.Generic;
using weka.core;


// ReSharper disable once CheckNamespace
namespace PicNetML
{
  public partial class PmlAttribute  : IEnumerable<string>
  {
  
    /// <summary>
    /// This is used to create a new Runtime with a specified set of Instances.
    /// </summary>
    public PmlAttribute(Attribute impl) { Impl = impl; }

    public Attribute Impl { get; private set; }

    public bool IsNumeric { get { return Impl.isNumeric(); } }
    public int NumValues { get { return Impl.numValues(); } }
    public string Name { get { return Impl.name(); } }
    public string Value(int valIndex) { return Impl.value(valIndex); }
    public bool IsNominal { get { return Impl.isNominal(); } }
    public int Index { get { return Impl.index(); } }
    public object Copy() { return Impl.copy(); }
    public int Type { get { return Impl.type(); } }
    public int IndexOfValue(string value) { return Impl.indexOfValue(value); }
    public double Weight { get { return Impl.weight(); } }
    public bool IsString { get { return Impl.isString(); } }
    public string EqualsMsg(object other) { return Impl.equalsMsg(other); }
    public static string TypeToString(int type) { return Attribute.typeToString(type); }
    public int AddStringValue(string value) { return Impl.addStringValue(value); }
    public IEnumerable<string> EnumerateValues { get { return Impl.ToEnumerable(); } }
    public bool IsRelationValued { get { return Impl.isRelationValued(); } }
    public Runtime Relation(int valIndex) { return new Runtime(Impl.relation(valIndex)); }
    public string FormatDate(double date) { return Impl.formatDate(date); }
    public static string TypeToString(PmlAttribute att) { return Attribute.typeToString(att.Impl); }
    public static string TypeToStringShort(int type) { return Attribute.typeToStringShort(type); }
    public bool IsDate { get { return Impl.isDate(); } }
    public double ParseDate(string str) { return Impl.parseDate(str); }
    public static string TypeToStringShort(PmlAttribute att) { return Attribute.typeToStringShort(att.Impl); }
    public string GetDateFormat { get { return Impl.getDateFormat(); } }
    public Runtime Relation() { return new Runtime(Impl.relation()); }
    public void SetStringValue(string value) { Impl.setStringValue(value); }
    public int AddStringValue(PmlAttribute src, int index) { return Impl.addStringValue(src.Impl, index); }
    public int AddRelation(Runtime value) { return Impl.addRelation(value.Impl); }
    public PmlAttribute Copy(string newName) { return new PmlAttribute(Impl.copy(newName)); }
    public int Ordering { get { return Impl.ordering(); } }
    public bool IsRegular { get { return Impl.isRegular(); } }
    public bool IsAveragable { get { return Impl.isAveragable(); } }
    public bool HasZeropoint { get { return Impl.hasZeropoint(); } }
    public void SetWeight(double value) { Impl.setWeight(value); }
    public double GetLowerNumericBound { get { return Impl.getLowerNumericBound(); } }
    public bool LowerNumericBoundIsOpen { get { return Impl.lowerNumericBoundIsOpen(); } }
    public double GetUpperNumericBound { get { return Impl.getUpperNumericBound(); } }
    public bool UpperNumericBoundIsOpen { get { return Impl.upperNumericBoundIsOpen(); } }
    public bool IsInRange(double value) { return Impl.isInRange(value); }
    public string GetRevision { get { return Impl.getRevision(); } }
    

    public IEnumerator<string> GetEnumerator() { return EnumerateValues.GetEnumerator(); }
    IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }    
  }
}
