using weka.core;

namespace Ml2.Arff.Builder
{
  internal interface IInstancesBuilder<T> where T : new()
  {
    Instances Build();
  }
}