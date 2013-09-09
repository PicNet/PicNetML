using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// An instance filter that changes a percentage of a given attributes
  /// values. The attribute must be nominal. Missing value can be treated as value
  /// itself.<br/><br/>Options:<br/><br/>-C &lt;col&gt; = 	Index of the attribute to
  /// be changed <br/>	(default last attribute)<br/>-M = 	Treat missing values as
  /// an extra value <br/><br/>-P &lt;num&gt; = 	Specify the percentage of noise
  /// introduced <br/>	to the data (default 10)<br/>-S &lt;num&gt; = 	Specify
  /// the random number seed (default 1)
  /// </summary>
  public class AddNoise : BaseFilter<weka.filters.unsupervised.attribute.AddNoise>
  {
    public AddNoise(Runtime rt) : base(rt, new weka.filters.unsupervised.attribute.AddNoise()) {
      Impl.setRandomSeed(Runtime.GlobalRandomSeed);
    }

    /// <summary>
    /// Index of the attribute that is to changed.
    /// </summary>    
    public AddNoise AttributeIndex (string attIndex) {
      Impl.setAttributeIndex(attIndex);
      return this;
    }

    /// <summary>
    /// Flag to set if missing values are used.
    /// </summary>    
    public AddNoise UseMissing (bool newUseMissing) {
      Impl.setUseMissing(newUseMissing);
      return this;
    }

    /// <summary>
    /// Percentage of introduced noise to data.
    /// </summary>    
    public AddNoise Percent (int newPercent) {
      Impl.setPercent(newPercent);
      return this;
    }

        
        
  }
}