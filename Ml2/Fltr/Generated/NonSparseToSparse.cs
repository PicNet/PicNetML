using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace Ml2.Fltr
{
  /// <summary>
  /// An instance filter that converts all incoming instances into sparse
  /// format.<br/><br/>Options:<br/><br/>-M = 	Treat missing values as zero.<br/>-F =
  /// 	Add a dummy first value for nominal attributes.
  /// </summary>
  public class NonSparseToSparse : BaseFilter<weka.filters.unsupervised.instance.NonSparseToSparse>
  {
    public NonSparseToSparse(Runtime rt) : base(rt, new weka.filters.unsupervised.instance.NonSparseToSparse()) {
      
    }

    /// <summary>
    /// Treat missing values in the same way as zeros.
    /// </summary>    
    public NonSparseToSparse TreatMissingValuesAsZero (bool m) {
      Impl.setTreatMissingValuesAsZero(m);
      return this;
    }

    /// <summary>
    /// Insert a dummy value before the first declared value for all nominal
    /// attributes. Useful when converting market basket data that has been encoded for
    /// Apriori to sparse format. Typically used in conjuction with treat missing
    /// values as zero.
    /// </summary>    
    public NonSparseToSparse InsertDummyNominalFirstValue (bool d) {
      Impl.setInsertDummyNominalFirstValue(d);
      return this;
    }

        
        
  }
}