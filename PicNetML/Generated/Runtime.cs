using System.Collections;
using System.Collections.Generic;
using weka.core;


// ReSharper disable once CheckNamespace
namespace PicNetML
{
  public partial class Runtime 
  {
    public Runtime(Instances impl) { Impl = impl; }

    public Instances Impl { get; private set; }

    public int NumInstances { get { return Impl.numInstances(); } }
    public int NumAttributes { get { return Impl.numAttributes(); } }
    public void SetClassIndex(int classIndex) { Impl.setClassIndex(classIndex); }
    public PmlAttribute Attribute(int index) { return new PmlAttribute(Impl.attribute(index)); }
    public PmlInstance Instance(int index) { return new PmlInstance(Impl.instance(index)); }
    public bool EqualHeaders(Runtime dataset) { return Impl.equalHeaders(dataset.Impl); }
    public string EqualHeadersMsg(Runtime dataset) { return Impl.equalHeadersMsg(dataset.Impl); }
    public int ClassIndex { get { return Impl.classIndex(); } }
    public PmlAttribute Attribute(string name) { return new PmlAttribute(Impl.attribute(name)); }
    public bool Add(PmlInstance instance) { return Impl.add(instance.Impl); }
    public void Compactify() { Impl.compactify(); }
    public void DeleteWithMissingClass() { Impl.deleteWithMissingClass(); }
    public Runtime StringFreeStructure { get { return new Runtime(Impl.stringFreeStructure()); } }
    public void DeleteAttributeAt(int position) { Impl.deleteAttributeAt(position); }
    public PmlAttribute ClassAttribute { get { return new PmlAttribute(Impl.classAttribute()); } }
    public void Randomize() { Impl.randomize(new java.util.Random(GlobalRandomSeed)); }
    public void Stratify(int numFolds) { Impl.stratify(numFolds); }
    public Runtime TrainCV(int numFolds, int numFold) { return new Runtime(Impl.trainCV(numFolds, numFold, new java.util.Random(GlobalRandomSeed))); }
    public double MeanOrMode(PmlAttribute att) { return Impl.meanOrMode(att.Impl); }
    public double[] AttributeToDoubleArray(int index) { return Impl.attributeToDoubleArray(index); }
    public int NumDistinctValues(int attIndex) { return Impl.numDistinctValues(attIndex); }
    public double MeanOrMode(int attIndex) { return Impl.meanOrMode(attIndex); }
    public string RelationName { get { return Impl.relationName(); } }
    public int NumClasses { get { return Impl.numClasses(); } }
    public bool CheckForStringAttributes { get { return Impl.checkForStringAttributes(); } }
    public Runtime ResampleWithWeights(double[] weights) { return new Runtime(Impl.resampleWithWeights(new java.util.Random(GlobalRandomSeed), weights)); }
    public IEnumerable<PmlAttribute> EnumerateAttributes { get { return Impl.ToEnumerableAttributes(); } }
    public void Sort(PmlAttribute att) { Impl.sort(att.Impl); }
    public double SumOfWeights { get { return Impl.sumOfWeights(); } }
    public void InsertAttributeAt(PmlAttribute att, int position) { Impl.insertAttributeAt(att.Impl, position); }
    public void Delete(int index) { Impl.delete(index); }
    public Runtime TestCV(int numFolds, int numFold) { return new Runtime(Impl.testCV(numFolds, numFold)); }
    public double Variance(int attIndex) { return Impl.variance(attIndex); }
    public Runtime ResampleWithWeights() { return new Runtime(Impl.resampleWithWeights(new java.util.Random(GlobalRandomSeed))); }
    public Runtime ResampleWithWeights(bool[] sampled) { return new Runtime(Impl.resampleWithWeights(new java.util.Random(GlobalRandomSeed), sampled)); }
    public PmlInstance LastInstance { get { return new PmlInstance(Impl.lastInstance()); } }
    public int NumDistinctValues(PmlAttribute att) { return Impl.numDistinctValues(att.Impl); }
    public void Sort(int attIndex) { Impl.sort(attIndex); }
    public void Delete() { Impl.delete(); }
    public void SetRelationName(string newName) { Impl.setRelationName(newName); }
    public void Swap(int i, int j) { Impl.swap(i, j); }
    public double KthSmallestValue(int attIndex, int k) { return Impl.kthSmallestValue(attIndex, k); }
    public bool CheckForAttributeType(int attType) { return Impl.checkForAttributeType(attType); }
    public void DeleteAttributeType(int attType) { Impl.deleteAttributeType(attType); }
    public void DeleteWithMissing(int attIndex) { Impl.deleteWithMissing(attIndex); }
    public void RenameAttribute(int att, string name) { Impl.renameAttribute(att, name); }
    public void RenameAttributeValue(int att, int val, string name) { Impl.renameAttributeValue(att, val, name); }
    public Runtime ResampleWithWeights(double[] weights, bool[] sampled) { return new Runtime(Impl.resampleWithWeights(new java.util.Random(GlobalRandomSeed), weights, sampled)); }
    public void RenameAttribute(PmlAttribute att, string name) { Impl.renameAttribute(att.Impl, name); }
    public void RenameAttributeValue(PmlAttribute att, string val, string name) { Impl.renameAttributeValue(att.Impl, val, name); }
    public string ToSummaryString { get { return Impl.toSummaryString(); } }
    public static Runtime MergeRuntime(Runtime first, Runtime second) { return new Runtime(Instances.mergeInstances(first.Impl, second.Impl)); }
    public PmlInstance Remove(int index) { return new PmlInstance(Impl.remove(index)); }
    public void Add(int index, PmlInstance instance) { Impl.add(index, instance.Impl); }
    public PmlInstance Set(int index, PmlInstance instance) { return new PmlInstance(Impl.set(index, instance.Impl)); }
    public PmlInstance Get(int index) { return new PmlInstance(Impl.get(index)); }
    public bool CheckInstance(PmlInstance instance) { return Impl.checkInstance(instance.Impl); }
    public void DeleteStringAttributes() { Impl.deleteStringAttributes(); }
    public void DeleteWithMissing(PmlAttribute att) { Impl.deleteWithMissing(att.Impl); }
    public PmlInstance FirstInstance { get { return new PmlInstance(Impl.firstInstance()); } }
    public double KthSmallestValue(PmlAttribute att, int k) { return Impl.kthSmallestValue(att.Impl, k); }
    public int Size { get { return Impl.size(); } }
    public Runtime Resample() { return new Runtime(Impl.resample(new java.util.Random(GlobalRandomSeed))); }
    public void SetClass(PmlAttribute att) { Impl.setClass(att.Impl); }
    public double Variance(PmlAttribute att) { return Impl.variance(att.Impl); }
    public string GetRevision { get { return Impl.getRevision(); } }
    public void Add(int x0, object x1) { Impl.add(x0, x1); }
    public bool Add(object x0) { return Impl.add(x0); }
    

        
  }
}
