using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// Filters instances according to the value of an
  /// attribute.<br/><br/>Options:<br/><br/>-C &lt;num&gt; = 	Choose attribute to be used for
  /// selection.<br/>-S &lt;num&gt; = 	Numeric value to be used for selection on
  /// numeric<br/>	attribute.<br/>	Instances with values smaller than given value will<br/>	be
  /// selected. (default 0)<br/>-L &lt;index1,index2-index4,...&gt; = 	Range of
  /// label indices to be used for selection on<br/>	nominal
  /// attribute.<br/>	First and last are valid indexes. (default all values)<br/>-M = 	Missing values
  /// count as a match. This setting is<br/>	independent of the -V
  /// option.<br/>	(default missing values don't match)<br/>-V = 	Invert matching
  /// sense.<br/>-H = 	When selecting on nominal attributes, removes header<br/>	references
  /// to excluded values.<br/>-F = 	Do not apply the filter to instances that
  /// arrive after the first<br/>	(training) batch. The default is to apply the
  /// filter (i.e.<br/>	the filter may not return an instance if it matches the remove
  /// criteria)
  /// </summary>
  public class RemoveWithValues : BaseFilter<weka.filters.unsupervised.instance.RemoveWithValues>
  {
    public RemoveWithValues(Runtime rt) : base(rt, new weka.filters.unsupervised.instance.RemoveWithValues()) {
      
    }

    /// <summary>
    /// Choose attribute to be used for selection (default last).
    /// </summary>    
    public RemoveWithValues AttributeIndex (string attIndex) {
      Impl.setAttributeIndex(attIndex);
      return this;
    }

    /// <summary>
    /// When selecting on nominal attributes, removes header references to
    /// excluded values.
    /// </summary>    
    public RemoveWithValues ModifyHeader (bool newModifyHeader) {
      Impl.setModifyHeader(newModifyHeader);
      return this;
    }

    /// <summary>
    /// Invert matching sense.
    /// </summary>    
    public RemoveWithValues InvertSelection (bool invert) {
      Impl.setInvertSelection(invert);
      return this;
    }

    /// <summary>
    /// 
    /// </summary>    
    public RemoveWithValues NominalIndicesArr (int[] values) {
      Impl.setNominalIndicesArr(values);
      return this;
    }

    /// <summary>
    /// Numeric value to be used for selection on numeric attribute. Instances
    /// with values smaller than given value will be selected.
    /// </summary>    
    public RemoveWithValues SplitPoint (double value) {
      Impl.setSplitPoint(value);
      return this;
    }

    /// <summary>
    /// Range of label indices to be used for selection on nominal attribute.
    /// First and last are valid indexes.
    /// </summary>    
    public RemoveWithValues NominalIndices (string rangeList) {
      Impl.setNominalIndices(rangeList);
      return this;
    }

    /// <summary>
    /// Missing values count as a match. This setting is independent of the
    /// invertSelection option.
    /// </summary>    
    public RemoveWithValues MatchMissingValues (bool newMatchMissingValues) {
      Impl.setMatchMissingValues(newMatchMissingValues);
      return this;
    }

    /// <summary>
    /// Whether to apply the filtering process to instances that are input after
    /// the first (training) batch. The default is false so instances in subsequent
    /// batches can potentially get 'consumed' by the filter.
    /// </summary>    
    public RemoveWithValues DontFilterAfterFirstBatch (bool b) {
      Impl.setDontFilterAfterFirstBatch(b);
      return this;
    }

        
        
  }
}