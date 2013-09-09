using System.Collections.Generic;
using System.Linq;

// ReSharper disable once CheckNamespace
namespace PicNetML.Fltr
{
  /// <summary>
  /// An instance filter that converts all incoming sparse instances into
  /// non-sparse format.
  /// </summary>
  public class SparseToNonSparse : BaseFilter<weka.filters.unsupervised.instance.SparseToNonSparse>
  {
    public SparseToNonSparse(Runtime rt) : base(rt, new weka.filters.unsupervised.instance.SparseToNonSparse()) {
      
    }

        
        
  }
}