using weka.core;

namespace PicNetML.Arff.Builder
{
  internal interface IInstancesBuilder<T> where T : new()
  {
    Instances Build();
  }
}