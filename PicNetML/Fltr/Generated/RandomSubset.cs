using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// Chooses a random subset of attributes, either an absolute number or a
  /// percentage. The class is always included in the output (as the last
  /// attribute).<br/><br/>Options:<br/><br/>-D = 	Turns on output of debugging
  /// information.<br/>-N &lt;double&gt; = 	The number of attributes to randomly
  /// select.<br/>	If < 1 then percentage, >= 1 absolute number.<br/>	(default: 0.5)<br/>-S
  /// &lt;int&gt; = 	The seed value.<br/>	(default: 1)
  /// </summary>
  public class RandomSubset : BaseFilter<weka.filters.unsupervised.attribute.RandomSubset>
  {
    public RandomSubset(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.RandomSubset()) {
      Impl.setSeed(Runtime.GlobalRandomSeed);
    }

    /// <summary>
    /// The number of attributes to choose: < 1 percentage, >= 1 absolute number.
    /// </summary>    
    public RandomSubset NumAttributes (double value) {
      Impl.setNumAttributes(value);
      return this;
    }

    /// <summary>
    /// Turns on output of debugging information.
    /// </summary>    
    public RandomSubset Debug (bool value) {
      Impl.setDebug(value);
      return this;
    }

        
        
  }
}