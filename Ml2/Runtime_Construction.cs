using System;
using System.Collections.Generic;
using System.Linq;
using Ml2.Arff;
using Ml2.Arff.Builder;
using Ml2.RuntimeHelpers;
using weka.core;

namespace Ml2
{
  public partial class Runtime
  {
    public static Runtime LoadFromFile<T>(int classifier, string file, int trainingsize = 0, Func<string, string> preprocessor = null) where T : new() {
      var loader = new RuntimeFileLoader(classifier, file, trainingsize, preprocessor);
      return new Runtime(loader.Load<T>(), typeof(T));
    }

    public static Runtime LoadFromRows<T>(int classifier, IEnumerable<T> lines, int trainingsize = 0) where T : new() {      
      var instances = new InstancesBuilder<T>(lines, classifier, trainingsize).Build();
      instances.setClassIndex(classifier);
      return new Runtime(instances, typeof(T));
    }

    public static Runtime FromInstances(IEnumerable<Ml2Instance> instances) {
      var all = instances.ToArray();
      if (!all.Any()) throw new ArgumentNullException("instances");
      var template = all.First();
      var impl = new Instances("frominstances", template.EnumerateAttributes.ToArrayList(), all.Length);
      Array.ForEach(all, i => impl.add(i.Impl));
      return new Runtime(impl);
    }

    public static IEnumerable<T> LoadRowsFromFile<T>(string file, int trainingsize = 0, Func<string, string> preprocessor = null) where T : new()
    {
      if (String.IsNullOrWhiteSpace(file)) throw new ArgumentNullException("file");
      return new RuntimeFileLoader(0, file, trainingsize, preprocessor).LoadRows<T>();    
    }

    public static IEnumerable<T> LoadRowsFromLines<T>(ICollection<string> lines) where T : new()
    {
      if (!lines.Any()) throw new ArgumentNullException("lines");      
      return new CsvLoader<T>().LoadLines(lines);      
    }    

    public static Runtime CreateWithArgCombinations<T>(int classifier, T[] data, int[] indexes, int degrees) where T : new() {
      return new CombinationRuntimeBuilder<T>(classifier, data, indexes, degrees).CreateRuntime();
    }

    public Runtime Clone() {
      return new Runtime(new Instances(Impl));
    }

    public static Ml2Instance BuildInstance<T>(int classifier, T o) where T : new() {
      if (o == null) throw new ArgumentNullException("o");
      var instances = new InstancesBuilder<T>(new [] {o}, classifier).Build();      
      return new Ml2Instance(instances.instance(0));
      
    }

    internal Ml2Instance BuildInstance<T>(T o) where T : new() {
      if (o == null) throw new ArgumentNullException("o");
      if (InternalDataType == null) throw new ApplicationException("BuildInstance can only be called when InternalDataType has been set.  This is done by using the Runtime.Load methods to create the runtime.");
      if (o.GetType() != InternalDataType) throw new ArgumentException("Expected o to be of type " + InternalDataType.Name + " but was " + o.GetType().Name);
      var instances = new InstancesBuilder<T>(new [] {o}, ClassIndex).Build();      
      return new Ml2Instance(instances.instance(0));
      
    }
  }
}