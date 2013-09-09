using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// Produces a random subsample of a dataset. The original dataset must fit
  /// entirely in memory. This filter allows you to specify the maximum "spread"
  /// between the rarest and most common class. For example, you may specify that
  /// there be at most a 2:1 difference in class frequencies. When used in batch
  /// mode, subsequent batches are NOT resampled.<br/><br/>Options:<br/><br/>-S
  /// &lt;num&gt; = 	Specify the random number seed (default 1)<br/>-M &lt;num&gt;
  /// = 	The maximum class distribution spread.<br/>	0 = no maximum spread, 1 =
  /// uniform distribution, 10 = allow at most<br/>	a 10:1 ratio between the
  /// classes (default 0)<br/>-W = 	Adjust weights so that total weight per class is
  /// maintained.<br/>	Individual instance weighting is not preserved. (default
  /// no<br/>	weights adjustment<br/>-X &lt;num&gt; = 	The maximum count for any
  /// class value (default 0 = unlimited).<br/>
  /// </summary>
  public class SpreadSubsample : BaseFilter<weka.filters.supervised.instance.SpreadSubsample>
  {
    public SpreadSubsample(Runtime rt) : base(rt, new weka.filters.supervised.instance.SpreadSubsample()) {
      Impl.setRandomSeed(Runtime.GlobalRandomSeed);
    }

    /// <summary>
    /// The maximum class distribution spread. (0 = no maximum spread, 1 =
    /// uniform distribution, 10 = allow at most a 10:1 ratio between the classes).
    /// </summary>    
    public SpreadSubsample DistributionSpread (double spread) {
      Impl.setDistributionSpread(spread);
      return this;
    }

    /// <summary>
    /// The maximum count for any class value (0 = unlimited).
    /// </summary>    
    public SpreadSubsample MaxCount (double maxcount) {
      Impl.setMaxCount(maxcount);
      return this;
    }

    /// <summary>
    /// Wether instance weights will be adjusted to maintain total weight per
    /// class.
    /// </summary>    
    public SpreadSubsample AdjustWeights (bool newAdjustWeights) {
      Impl.setAdjustWeights(newAdjustWeights);
      return this;
    }

        
        
  }
}