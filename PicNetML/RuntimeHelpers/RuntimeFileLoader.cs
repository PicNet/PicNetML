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
    private readonly int classifier;
    private readonly string file;
    private readonly int trainingsize;
    private readonly Func<string, string> preprocessor;

    public RuntimeFileLoader(int classifier, string file, int trainingsize, Func<string, string> preprocessor) {
      if (System.String.IsNullOrWhiteSpace(file)) { throw new ArgumentNullException("file"); }

      this.classifier = classifier;
      this.file = file;
      this.trainingsize = trainingsize;
      this.preprocessor = preprocessor;
    }

    internal Instances Load<T>() where T : new () {      
      var instances = file.EndsWith(".arff") ? 
          LoadRuntimFromArffFile() :
          file.EndsWith(".xrff") || file.EndsWith(".xrff.gz") ? 
            LoadRuntimFromXrffFile() :
            LoadRuntimeFromNonArffFile<T>();
      
      if (instances.numInstances() <= 0) { throw new IllegalStateException("Could not load any instances from the file provided"); }
      return instances;
    }

    private Instances LoadRuntimFromXrffFile() { return LoadRuntimFromInternalFile(new XRFFLoader()); }
    private Instances LoadRuntimFromArffFile() { return LoadRuntimFromInternalFile(new ArffLoader()); }
    private Instances LoadRuntimFromInternalFile(AbstractFileLoader loader) { 
      loader.setFile(new java.io.File(file));

      var instances = loader.getDataSet();
      instances.setClassIndex(classifier);
      return instances;
    }

    private Instances LoadRuntimeFromNonArffFile<T>() where T : new () {
      var rows = LoadRows<T>();
      var instances = new InstancesBuilder<T>(rows, classifier, trainingsize).Build();
      instances.setClassIndex(classifier);
      return instances;        
    }

    internal IEnumerable<T> LoadRows<T>() where T : new()
    {
      return new CsvLoader<T>().Load(file, preprocessor);
    }
  }
}