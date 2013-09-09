using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// Determines which values (frequent or infrequent ones) of an (nominal)
  /// attribute are retained and filters the instances accordingly. In case of
  /// values with the same frequency, they are kept in the way they appear in the
  /// original instances object. E.g. if you have the values "1,2,3,4" with the
  /// frequencies "10,5,5,3" and you chose to keep the 2 most common values, the
  /// values "1,2" would be returned, since the value "2" comes before "3", even
  /// though they have the same frequency.<br/><br/>Options:<br/><br/>-C &lt;num&gt; =
  /// 	Choose attribute to be used for selection.<br/>-N &lt;num&gt; = 	Number
  /// of values to retain for the sepcified attribute, <br/>	i.e. the ones with
  /// the most instances (default 2).<br/>-L = 	Instead of values with the most
  /// instances the ones with the <br/>	least are retained.<br/><br/>-H = 	When
  /// selecting on nominal attributes, removes header<br/>	references to excluded
  /// values.<br/>-V = 	Invert matching sense.
  /// </summary>
  public class RemoveFrequentValues : BaseFilter<weka.filters.unsupervised.instance.RemoveFrequentValues>
  {
    public RemoveFrequentValues(Runtime rt) : base(rt, new weka.filters.unsupervised.instance.RemoveFrequentValues()) {
      
    }

    /// <summary>
    /// Choose attribute to be used for selection (default last).
    /// </summary>    
    public RemoveFrequentValues AttributeIndex (string attIndex) {
      Impl.setAttributeIndex(attIndex);
      return this;
    }

    /// <summary>
    /// The number of values to retain.
    /// </summary>    
    public RemoveFrequentValues NumValues (int numValues) {
      Impl.setNumValues(numValues);
      return this;
    }

    /// <summary>
    /// Retains values with least instance instead of most.
    /// </summary>    
    public RemoveFrequentValues UseLeastValues (bool leastValues) {
      Impl.setUseLeastValues(leastValues);
      return this;
    }

    /// <summary>
    /// When selecting on nominal attributes, removes header references to
    /// excluded values.
    /// </summary>    
    public RemoveFrequentValues ModifyHeader (bool newModifyHeader) {
      Impl.setModifyHeader(newModifyHeader);
      return this;
    }

    /// <summary>
    /// Invert matching sense.
    /// </summary>    
    public RemoveFrequentValues InvertSelection (bool invert) {
      Impl.setInvertSelection(invert);
      return this;
    }

        
        
  }
}