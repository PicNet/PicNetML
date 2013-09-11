using System;
using System.Collections.Generic;
using System.Linq;
using PicNetML.Arff;
using PicNetML.Arff.Builder;
using PicNetML.RuntimeHelpers;

namespace PicNetML
{
  public partial class Runtime
  {
    public static Runtime LoadFromFile<T>(string classifier, string file, Func<string, string> preprocessor = null) where T : new() {      
      return LoadFromFile<T>(GetClassIdx<T>(classifier), file, preprocessor);
    }

    public static Runtime LoadFromRows<T>(string classifier, IEnumerable<T> lines, int trainingsize = 0) where T : new() {      
      return LoadFromRows<T>(GetClassIdx<T>(classifier), lines, trainingsize);
    }

    public static Runtime CreateWithArgCombinations<T>(string classifier, T[] data, int[] indexes, int degrees) where T : new() {
      return CreateWithArgCombinations<T>(GetClassIdx<T>(classifier), data, indexes, degrees);
    }
    
    public static PmlInstance BuildInstance<T>(string classifier, T o) where T : new() {
      return BuildInstance<T>(GetClassIdx<T>(classifier), o);      
    }

    private static int GetClassIdx<T>(string classifier) {
      var unignored = Helpers.GetProps(typeof(T)).
          Where(p => !InternalHelpers.IsAtt<IgnoreFeatureAttribute>(p)).
          Select(p => p.Name).
          ToArray();

      var idx = Array.IndexOf(unignored, classifier);
      if (idx < 0) throw new ArgumentException("classifier: " + classifier + " could not be found");
      return idx;
    }

    public static Runtime LoadFromFile<T>(int classidx, string file, Func<string, string> preprocessor = null) where T : new() {
      if (classidx < 0) throw new ArgumentOutOfRangeException("classidx: " + classidx + " is not valid");
      var loader = new RuntimeFileLoader(file,  preprocessor);
      return new Runtime(loader.Load<T>(classidx));
    }

    public static Runtime LoadFromRows<T>(int classidx, IEnumerable<T> lines, int trainingsize = 0) where T : new() {      
      if (classidx < 0) throw new ArgumentOutOfRangeException("classidx: " + classidx + " is not valid");
      var instances = new InstancesBuilder<T>(lines, classidx, trainingsize).Build();
      instances.setClassIndex(classidx);
      return new Runtime(instances);
    }

    public static Runtime CreateWithArgCombinations<T>(int classidx, T[] data, int[] indexes, int degrees) where T : new() {
      if (classidx < 0) throw new ArgumentOutOfRangeException("classidx: " + classidx + " is not valid");
      return new CombinationRuntimeBuilder<T>(classidx, data, indexes, degrees).CreateRuntime();
    }
    
    public static PmlInstance BuildInstance<T>(int classidx, T o) where T : new() {
      if (classidx < 0) throw new ArgumentOutOfRangeException("classidx: " + classidx + " is not valid");
      if (o == null) throw new ArgumentNullException("o");
      var instances = new InstancesBuilder<T>(new [] {o}, classidx).Build();      
      return new PmlInstance(instances.instance(0));
      
    }

    public static IEnumerable<T> LoadRowsFromFile<T>(string file, Func<string, string> preprocessor = null) where T : new()
    {
      if (String.IsNullOrWhiteSpace(file)) throw new ArgumentNullException("file");
      return new RuntimeFileLoader(file, preprocessor).LoadRows<T>();    
    }

    public static IEnumerable<T> LoadRowsFromLines<T>(ICollection<string> lines) where T : new()
    {
      if (!lines.Any()) throw new ArgumentNullException("lines");      
      return new CsvLoader<T>().LoadLines(lines);      
    }        

    internal PmlInstance BuildInstance<T>(T o) where T : new() {
      if (o == null) throw new ArgumentNullException("o");
      var instances = new InstancesBuilder<T>(new [] {o}, ClassIndex).Build();      
      return new PmlInstance(instances.instance(0));
      
    }
  }
}