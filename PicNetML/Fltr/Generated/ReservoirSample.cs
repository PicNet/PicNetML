using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// Produces a random subsample of a dataset using the reservoir sampling
  /// Algorithm "R" by Vitter. The original data set does not have to fit into main
  /// memory, but the reservoir does. <br/><br/>Options:<br/><br/>-S &lt;num&gt;
  /// = 	Specify the random number seed (default 1)<br/>-Z &lt;num&gt; = 	The
  /// size of the output dataset - number of instances<br/>	(default 100)
  /// </summary>
  public class ReservoirSample : BaseFilter<weka.filters.unsupervised.instance.ReservoirSample>
  {
    public ReservoirSample(Runtime rt) : base(rt, new weka.filters.unsupervised.instance.ReservoirSample()) {
      Impl.setRandomSeed(Runtime.GlobalRandomSeed);
    }

    /// <summary>
    /// Size of the subsample (reservoir). i.e. the number of instances.
    /// </summary>    
    public ReservoirSample SampleSize (int newSampleSize) {
      Impl.setSampleSize(newSampleSize);
      return this;
    }

        
        
  }
}