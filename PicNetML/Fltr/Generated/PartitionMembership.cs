using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// A filter that uses a PartitionGenerator to generate partition membership
  /// values; filtered instances are composed of these values plus the class
  /// attribute (if set in the input data) and rendered as sparse
  /// instances.<br/><br/>Options:<br/><br/>-W &lt;name of partition generator&gt; = 	Full name of
  /// partition generator to use,
  /// e.g.:<br/>		weka.classifiers.trees.J48<br/>	Additional options after the '--'.<br/>	(default: weka.classifiers.trees.J48)
  /// </summary>
  public class PartitionMembership : BaseFilter<weka.filters.supervised.attribute.PartitionMembership>
  {
    public PartitionMembership(Runtime rt) : base(rt, new weka.filters.supervised.attribute.PartitionMembership()) {
      
    }

    /// <summary>
    /// The partition generator that will generate membership values for the
    /// instances.
    /// </summary>    
    public PartitionMembership PartitionGenerator (weka.core.PartitionGenerator newPartitionGenerator) {
      Impl.setPartitionGenerator(newPartitionGenerator);
      return this;
    }

        
        
  }
}