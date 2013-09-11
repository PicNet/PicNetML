using System;
using System.Collections.Generic;
using java.lang;
using PicNetML.Arff;
using PicNetML.Arff.Builder;
using weka.core;
using weka.core.converters;

namespace PicNetML.RuntimeHelpers
{
  internal class RuntimeFileLoader {
    private readonly string file;
    private readonly Func<string, string> preprocessor;

    public RuntimeFileLoader(string file, Func<string, string> preprocessor) {
      if (System.String.IsNullOrWhiteSpace(file)) { throw new ArgumentNullException("file"); }

      this.file = file;
      this.preprocessor = preprocessor;
    }

    internal Instances Load<T>(int classidx) where T : new () {      
      var instances = file.EndsWith(".arff") ? 
          LoadRuntimFromArffFile(classidx) :
          file.EndsWith(".xrff") || file.EndsWith(".xrff.gz") ? 
            LoadRuntimFromXrffFile(classidx) :
            LoadRuntimeFromNonArffFile<T>(classidx);
      
      if (instances.numInstances() <= 0) { throw new IllegalStateException("Could not load any instances from the file provided"); }
      return instances;
    }

    private Instances LoadRuntimFromXrffFile(int classidx) { return LoadRuntimFromInternalFile(new XRFFLoader(), classidx); }
    private Instances LoadRuntimFromArffFile(int classidx) { return LoadRuntimFromInternalFile(new ArffLoader(), classidx); }
    private Instances LoadRuntimFromInternalFile(AbstractFileLoader loader, int classidx) { 
      if (preprocessor != null) throw new ApplicationException ("RuntimeFileLoader.preprocessor can only be used when loading non arff/xrff files.");
      loader.setFile(new java.io.File(file));

      var instances = loader.getDataSet();
      instances.setClassIndex(classidx);
      return instances;
    }

    private Instances LoadRuntimeFromNonArffFile<T>(int classidx) where T : new () {
      var rows = LoadRows<T>();
      var instances = new InstancesBuilder<T>(rows, classidx).Build();
      instances.setClassIndex(classidx);
      return instances;        
    }

    internal IEnumerable<T> LoadRows<T>() where T : new()
    {
      return new CsvLoader<T>().Load(file, preprocessor);
    }
  }
}